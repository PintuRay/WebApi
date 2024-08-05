using AutoMapper;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Model.Email;
using FMS.Repo.Account.Authentication;
using FMS.Svcs.Email;
using FMS.Svcs.SMS;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twilio.Jwt.AccessToken;

namespace FMS.Svcs.Account.Authentication
{
    public class AuthenticationSvcs(
        IAuthentication authenticationRepo,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        IEmailSvcs emailSvcs,
        ISmsSvcs smsSvcs,
         IMapper mapper,
        IConfiguration configuration) : IAuthenticationSvcs
    {
        #region Dependancy
        private readonly IAuthentication _authenticationRepo = authenticationRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvcs;
        private readonly ISmsSvcs _smsSvcs = smsSvcs;
        private readonly IConfiguration _configuration = configuration;
        private readonly IMapper _mapper = mapper;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly RoleManager<AppRole> _roleManager = roleManager;
        #endregion
        #region  SignUp 
        public async Task<Base> ValidateToken(string Token)
        {
            Base Obj;
            try
            {
                var repoResult = await _authenticationRepo.ValidateToken(Token);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.SingleObjData,
                        Message = $"Token '{Token}' Found",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Token '{Token}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> IsEmailInUse(string email)
        {
            Base Obj;
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                Obj = new()
                {
                    Data = user,
                    Message = $"Mail '{email}' Already In Use",
                    ResponseCode = (int)ResponseCode.Status.Ok,
                };
            }
            else
            {
                Obj = new()
                {
                    Message = $"No Such Mail '{email}' Exist",
                    ResponseCode = (int)ResponseCode.Status.NotFound,
                };
            }
            return Obj;
        }
        public async Task<Base> SignUp(UserModel data)
        {
            bool isMailSend = false;
            Base Obj;
            try
            {
                var user = _mapper.Map<AppUser>(data);
                user.UserName = data.Email;
                user.CreatedDate = DateTime.UtcNow;
                var identity = await _userManager.CreateAsync(user, data.Password);
                if (identity.Succeeded)
                {
                    var regToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (!string.IsNullOrEmpty(regToken))
                    {
                        //string appDomin = _configuration.GetSection("Application:AppDomain").Value;
                        //string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
                        UserEmailOptions options = new()
                        {
                            ToEmail = data.Email,
                            PlaceHolders = new List<KeyValuePair<string, string>>()
                                {
                                    new KeyValuePair<string, string>("{{UserName}}", data.Name),
                                    new KeyValuePair<string, string>("{{Link}}",
                                        string.Format(/*appDomin + confirmationLink*/ data.RouteUls , user.Id, regToken))
                                }
                        };
                        isMailSend = await _emailSvcs.SendConfirmationEmail(options);
                        if (isMailSend)
                        {
                            #region Assign Default Role : Devloper to first registrar; rest is user
                            var checkDevloper = await _roleManager.FindByNameAsync("Devloper");
                            if (checkDevloper is null)
                            {
                                await _roleManager.CreateAsync(new AppRole() { Name = "Devloper" });
                                await _userManager.AddToRoleAsync(user, "Devloper");
                                await _userManager.AddClaimsAsync(user, ClaimsStoreModel.AllClaims);
                            }
                            else
                            {
                                var checkUser = await _roleManager.FindByNameAsync("User");
                                if (checkUser is null)
                                {
                                    await _roleManager.CreateAsync(new AppRole() { Name = "User" });
                                }
                                await _userManager.AddToRoleAsync(user, "User");
                                await _userManager.AddClaimsAsync(user, ClaimsStoreModel.AllClaims);
                            }
                            #endregion
                            Obj = new()
                            {
                                Data = new { Id = user.Id },
                                Message = "Registraion Successful, We Send A Comfomation Mail To Your Account",
                                ResponseCode = (int)ResponseCode.Status.Created
                            };
                        }
                        else
                        {
                            Obj = new()
                            {
                                Data = new { Id = user.Id },
                                Message = $"Failed To Send ConfirmMail To Your Provided Mail {data.Email} ",
                                ResponseCode = (int)ResponseCode.Status.Created,
                            };
                        }
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Failed To Generate Email Conformation Token",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Registration Failed",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region SignIn
        public async Task<Base> SignIn(SignInModel data)
        {
            Base Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(data.Email);
                if (user != null)
                {
                    if (user.EmailConfirmed)
                    {
                        bool checkUserPasswords = await _userManager.CheckPasswordAsync(user, data.Password);
                        if (checkUserPasswords)
                        {
                            if (await _userManager.GetTwoFactorEnabledAsync(user))
                            {
                                #region mail
                                var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
                                user.OTP = code;
                                await _userManager.UpdateAsync(user);
                                UserEmailOptions options = new()
                                {
                                    ToEmail = user.Email,
                                    PlaceHolders =
                                        [
                                            new("{{UserName}}", user.Name),
                                            new("{{OTP}}", code)
                                            ]
                                };
                                var Result = await _emailSvcs.SendTwoFactorToken(options);
                                #endregion
                                #region sms
                                //var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
                                // var Result = await _smsSvcs.SendSmsAsync(user.PhoneNumber, $"Your authentication code is: {code}");
                                #endregion
                                if (Result)
                                {
                                    //int lengthToMask = user.PhoneNumber.Length - 4;
                                    //string maskedPart = new string('*', lengthToMask);
                                    //string lastFourDigits = user.PhoneNumber.Substring(lengthToMask);
                                    Obj = new()
                                    {
                                        //Message = $"We Send An OTP To your Mobile no ends With {lastFourDigits} ",
                                        Message = $"We Send An OTP To your registered mail",
                                        ResponseCode = (int)ResponseCode.Status.Ok,
                                        Data = new { twoFactorEnable = true, userId = user.Id }
                                    };
                                }
                                else
                                {
                                    Obj = new()
                                    {
                                        Message = "Failed To Send 2FA Token",
                                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                                    };
                                }
                            }
                            else
                            {
                                var JwtToken = await GenerateJwtToken(user);
                                Obj = new()
                                {
                                    Message = "Bearer Token Created Successfully",
                                    ResponseCode = (int)ResponseCode.Status.Ok,
                                    Data = new { JwtToken = JwtToken, TwoFactorEnable = false }
                                };
                            }
                        }
                        else
                        {
                            Obj = new()
                            {
                                Message = "Invalid UserName Or Password",
                                ResponseCode = (int)ResponseCode.Status.BadRequest,
                            };
                        }
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Your Email Not Confomed Yet, We Send A link To Your Mail When You Register",
                            ResponseCode = (int)ResponseCode.Status.NotAllowed,
                        };
                    }

                }
                else
                {
                    Obj = new()
                    {
                        Message = "Invalid UserName Or Password",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        private async Task<string> GenerateJwtToken(AppUser data)
        {
            try
            {
                var getUserRole = await _userManager.GetRolesAsync(data);
                var getUserClaims = await _userManager.GetClaimsAsync(data);
                UserSession userSession = new()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Email = data.Email,
                    Role = getUserRole.Any() ? getUserRole.First() : "User",
                    Claims = (List<Claim>)getUserClaims,
                };
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var userClaims = new List<Claim>()
           {
                new(ClaimTypes.NameIdentifier, userSession.Id),
                new(ClaimTypes.Name, userSession.Name),
                new(ClaimTypes.Email, userSession.Email),
                new(ClaimTypes.Role, userSession.Role),
            };
                userClaims.AddRange(userSession.Claims);
                var token = new JwtSecurityToken(
                    issuer: _configuration.GetSection("Jwt:Issuer").Value,
                    audience: _configuration.GetSection("Jwt:Audience").Value,
                    claims: userClaims, 
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch
            {
                throw;
            }

        }
        #endregion
        #region Email
        public async Task<Base> VerifyConfirmEmail(string uid, string token)
        {
            Base Obj;
            try
            {
                var user = await _userManager.FindByIdAsync(uid);
                var orignalToken = token.Replace(' ', '+');
                var result = await _userManager.ConfirmEmailAsync(user, orignalToken);            
                if (result.Succeeded)
                {
                    Obj = new()
                    {
                        Message = "Email Verified Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Email Verifcation Failed",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> ResendConfirmEmail(string mail)
        {
            bool isEmailSend = false;
            Base Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(mail); ;
                if (user != null)
                {
                    var regToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (!string.IsNullOrEmpty(regToken))
                    {
                        string apiDomain = _configuration.GetSection("Application:ApiDomain").Value;
                        string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
                        UserEmailOptions options = new()
                        {
                            ToEmail = mail,
                            PlaceHolders =
                            [
                                    new("{{UserName}}", user.Name),
                                new("{{Link}}", string.Format(apiDomain + confirmationLink, user.Id, regToken))
                                ]
                        };
                        isEmailSend = await _emailSvcs.SendConfirmationEmail(options);
                        if (isEmailSend)
                        {
                            Obj = new()
                            {
                                Message = "We send a Confomation mail to your registed mail",
                                ResponseCode = (int)ResponseCode.Status.Ok,
                            };
                        }
                        else
                        {
                            Obj = new()
                            {
                                Message = $"Failed To Send ConfirmMail To Your Provided Mail {mail} ",
                                ResponseCode = (int)ResponseCode.Status.BadRequest,
                            };
                        }
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Failed To Generate Email Conformation Token",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = $"No User Found With Mail '{mail}'",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region SMS
        public async Task<Base> SendConformationSms(AppUser User, string PhoneNo)
        {
            Base Obj;
            try
            {
                var token = await _userManager.GenerateChangePhoneNumberTokenAsync(User, PhoneNo);
                if (token != null)
                {
                    var result = await _smsSvcs.SendSmsAsync(PhoneNo, token);
                    if (result)
                    {
                        Obj = new()
                        {
                            Data = PhoneNo,
                            Message = "We Send a OTP To Your Registered Phone No",
                            ResponseCode = (int)ResponseCode.Status.Ok,

                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Failed To Send OTP To Your Registered Phone No",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Failed To Generate Token",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> VerifyPhoneNumber(AppUser User, string Token, string PhoneNumber)
        {
            Base Obj;
            try
            {
                var result = await _userManager.VerifyChangePhoneNumberTokenAsync(User, Token, PhoneNumber);
                if (result)
                {
                    User.PhoneNumber = PhoneNumber;
                    User.PhoneNumberConfirmed = true;
                    var UpdateUser = await _userManager.UpdateAsync(User);
                    if (UpdateUser.Succeeded)
                    {
                        Obj = new()
                        {
                            Message = "Phone No Verified Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "failed to Verified Phone No",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Failed To Verify Token",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region 2FA
        public async Task<Base> SendTwoFactorToken(AppUser user)
        {
            Base Obj;
            try
            {
                #region sms
                //var TwoFactorToken = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
                // var Result = await _smsSvcs.SendSmsAsync(user.PhoneNumber, $"Your Token To {Message} Is {TwoFactorToken}");
                #endregion
                #region mail
                var TwoFactorToken = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
                user.OTP = TwoFactorToken;
                await _userManager.UpdateAsync(user);
                UserEmailOptions options = new()
                {
                    ToEmail = user.Email,
                    PlaceHolders =
                        [
                            new("{{UserName}}", user.Name),
                            new("{{OTP}}", TwoFactorToken)
                            ]
                };
                var Result = await _emailSvcs.SendTwoFactorToken(options);
                #endregion
                if (Result)
                {
                    Obj = new()
                    {
                        Message = $"We Send A Conformation Token To Your Registerd email {user.Email}",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Failed To Send Conformation Token",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> VerifyTwoFactorToken(string Token, AppUser user)
        {
            Base Obj;
            try
            {
                var result = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, Token);
                if (result)
                {
                    var Message = user.TwoFactorEnabled ? "Disable 2FA" : "Enable 2FA";
                    bool newTwoFactorEnabledState = !user.TwoFactorEnabled;
                    user.TwoFactorEnabled = newTwoFactorEnabledState;
                    var respose = await _userManager.UpdateAsync(user);
                    if (respose.Succeeded) {
                        Obj = new()
                        {
                            Message = $"You have successfully {Message}",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = $"Falied to {Message}",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }  
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Failed To Verify Token",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> SignInWithOTP(SignIn2faModel model)
        {
            Base Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (user.OTP == model.OTP)
                    {
                        var JwtToken = await GenerateJwtToken(user);
                        Obj = new()
                        {
                            Message = "Bearer Token Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                            Data = new { JwtToken = JwtToken }
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Login Failed",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = "Invalid User",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region Forgot, Reset && Change Password
        public async Task<Base> ForgotPassword(string mail)
        {
            Base Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(mail);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
                    string confirmationLink = _configuration.GetSection("Application:ResetPassword").Value;
                    UserEmailOptions options = new()
                    {
                        ToEmail = user.Email,
                        PlaceHolders = new List<KeyValuePair<string, string>>()
                                {
                                    new KeyValuePair<string, string>("{{UserName}}", user.Name),
                                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id,token))
                                }
                    };
                    var IsMailSend = await _emailSvcs.SendResetPasswordEmail(options);
                    if (IsMailSend)
                    {
                        Obj = new()
                        {
                            ResponseCode = (int)ResponseCode.Status.Ok,
                            Message = "We Send Conformation Mail To your Account Plz Conform It"
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                            Message = "Failed to Send Conformation Mail"
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                        Message = $"No User Found In Given Mail {mail}"
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                    Exception = _Exception
                };
            }
            return Obj;
        }
        public async Task<Base> ResetPassword(string uid, string token, ResetPasswordModel model)
        {
            Base Obj;
            try
            {
                var Token = token.Replace(' ', '+');
                var result = await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(uid), Token, model.NewPassword);
                if (result.Succeeded)
                {
                    Obj = new()
                    {
                        ResponseCode = (int)ResponseCode.Status.Ok,
                        Message = "Password Updated Successfully"
                    };
                }
                else
                {
                    Obj = new()
                    {
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                        Message = "Password Updated Failed"
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                    Exception = _Exception
                };
            }
            return Obj;
        }
        public async Task<Base> ChangePassword(AppUser user, ChangePasswordModel model)
        {
            Base Obj;
            try
            {
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    Obj = new()
                    {
                        ResponseCode = (int)ResponseCode.Status.Ok,
                        Message = "Password Changed Successfully"
                    };
                }
                else
                {
                    Obj = new()
                    {
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                        Message = "Password Change Failed"
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                    Exception = _Exception
                };
            }
            return Obj;
        }
        #endregion
        #region User
        public async Task<Base> GetUsers()
        {
            Base Obj;
            try
            {
                var repoResult = await _userManager.Users.ToListAsync();
                if (repoResult.Count > 0)
                {
                    var Users = _mapper.Map<List<UserDbModel>>(repoResult);
                    Obj = new()
                    {
                        Data = Users,
                        Count = Users.Count.ToString(),
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                    return Obj;
                }
                else
                {
                    Obj = new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> GetUserByMail(string email)
        {
            Base Obj;
            try
            {
                var repoResult = await _userManager.FindByEmailAsync(email);
                if (repoResult != null)
                {
                    var User = _mapper.Map<UserDbModel>(repoResult);
                    Obj = new()
                    {
                        Data = User,
                        Message = "User Found",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = "User Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> GetUserById(string Id)
        {
            Base Obj;
            try
            {
                var repoResult = await _userManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    var User = _mapper.Map<UserDbModel>(repoResult);
                    Obj = new()
                    {
                        Data = User,
                        Message = "User Found",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = "User Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> UpdateUser(string Id, UserModel User)
        {
            Base Obj;
            try
            {
                var chkUser = await _userManager.FindByIdAsync(Id);
                if (chkUser != null)
                {
                    var updateUser = _mapper.Map(User, chkUser);
                    chkUser.ModifyDate = DateTime.UtcNow;
                    chkUser.ModifyBy = "N/A";
                    var repoResult = await _userManager.UpdateAsync(updateUser);
                    if (repoResult.Succeeded)
                    {
                        Obj = new()
                        {
                            Data = new { Id = Id },
                            Message = "User Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Data = new { Id = Id },
                            Message = $"Failed To Update User",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Data = new { Id = Id },
                        Message = $"UserId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<Base> DeletUser(string Id)
        {
            Base Obj;
            try
            {
                var chkUser = await _userManager.FindByIdAsync(Id);
                if (chkUser != null)
                {
                    var repoResult = await _userManager.DeleteAsync(chkUser);
                    if (repoResult.Succeeded)
                    {
                        Obj = new()
                        {
                            Data = new { Id = Id },
                            Message = "User Deleted Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Falied To Delete User",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = $"UserId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
    }
}
