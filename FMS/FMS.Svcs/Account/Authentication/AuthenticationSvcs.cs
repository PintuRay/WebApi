using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Model.Email;
using FMS.Repo;
using FMS.Repo.Account.Authentication;
using FMS.Svcs.Email;
using FMS.Svcs.SMS;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FMS.Svcs.Account.Authentication
{
    public class AuthenticationSvcs(
      
        IAuthenticationRepo authenticationRepo,
        UserManager<AppUser> userManager,
        IEmailSvcs emailSvcs,
        ISmsSvcs smsSvcs,
         IRedisCache cache,
        IConfiguration configuration) : IAuthenticationSvcs
    {
        #region Dependancy
        private readonly IAuthenticationRepo _authenticationRepo = authenticationRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvcs;
        private readonly ISmsSvcs _smsSvcs = smsSvcs;
        private readonly IConfiguration _configuration = configuration;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IRedisCache _cache = cache;
        #endregion
        #region SignIn
        public async Task<SvcsBase> SignIn(SignInModel data)
        {
            SvcsBase Obj;
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
                                #region sms
                                //var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
                                // var Result = await _smsSvcs.SendSmsAsync(user.PhoneNumber, $"Your authentication code is: {code}");
                                #endregion
                                #region mail
                                var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
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
                                if (Result)
                                {
                                    #region Caching
                                    var tokenGenerationTime = DateTime.UtcNow;
                                    var tokenCacheKey = $"TwoFactorToken_{code}";
                                    var tokenTimeCacheKey = $"TokenGenerationTime_{code}";
                                    _cache.Remove(tokenCacheKey);
                                    _cache.Remove(tokenTimeCacheKey);
                                    await _cache.SetAsync(tokenCacheKey, code);
                                    await _cache.SetAsync(tokenTimeCacheKey, tokenGenerationTime);
                                    #endregion
                                    Obj = new()
                                    {
                                        Message = $"We Send An OTP To your registered mail",
                                        ResponseCode = (int)ResponseCode.Status.Ok,
                                        Data = new { twoFactorEnable = true, userId = user.Id, OtpExpiredIn = tokenGenerationTime.AddMinutes(3) }
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "SignIn", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> SignInWithOTP(SignIn2faModel model)
        {
            SvcsBase Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var tokenCacheKey = $"TwoFactorToken_{model.OTP}";
                    var tokenTimeCacheKey = $"TokenGenerationTime_{model.OTP}";
                    var tokenGenerationTime = await _cache.GetAsync<DateTime>(tokenTimeCacheKey);
                    var tokenValue = await _cache.GetAsync<string>(tokenCacheKey);
                    if (tokenGenerationTime.AddMinutes(3) > DateTime.UtcNow && tokenValue == model.OTP)
                    {
                        _cache.Remove(tokenCacheKey);
                        _cache.Remove(tokenTimeCacheKey);
                        var result = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider, model.OTP) ||
                            await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, model.OTP);
                        if (result)
                        {
                            var JwtToken = await GenerateJwtToken(user);
                            Obj = new()
                            {
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
                            Message = "Token Expired or Invalid Token",
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "SignInWithOTP", _Exception.ToString());
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
        public async Task<SvcsBase> ReSendTwoFactorToken(string mail)
        {
            SvcsBase Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(mail);
                if (await _userManager.GetTwoFactorEnabledAsync(user))
                {
                    #region mail
                    var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
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
                    if (Result)
                    {
                        #region Caching
                        var tokenGenerationTime = DateTime.UtcNow;
                        var tokenCacheKey = $"TwoFactorToken_{code}";
                        var tokenTimeCacheKey = $"TokenGenerationTime_{code}";
                        _cache.Remove(tokenCacheKey);
                        _cache.Remove(tokenTimeCacheKey);
                        await _cache.SetAsync(tokenCacheKey, code);
                        await _cache.SetAsync(tokenTimeCacheKey, tokenGenerationTime);
                        #endregion
                        Obj = new()
                        {
                            Message = $"We Send An OTP To your registered mail",
                            ResponseCode = (int)ResponseCode.Status.Ok,
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
                    Obj = new()
                    {
                        Message = "Failed To Send 2FA Token",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "ReSendTwoFactorToken", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Email
        public async Task<SvcsBase> VerifyConfirmEmail(string uid, string token)
        {
            SvcsBase Obj;
            try
            {
                var user = await _userManager.FindByIdAsync(uid);
                var result = await _userManager.ConfirmEmailAsync(user, Uri.UnescapeDataString(token));
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "VerifyConfirmEmail", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> ResendConfirmEmail(string mail, string RouteUrl)
        {
            bool isEmailSend = false;
            SvcsBase Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(mail); ;
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        var regToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        if (!string.IsNullOrEmpty(regToken))
                        {
                            UserEmailOptions options = new()
                            {
                                ToEmail = mail,
                                PlaceHolders =
                                [
                                        new("{{UserName}}", user.Name),
                                    new("{{Link}}", string.Format(RouteUrl.Replace("{uid}", user.Id.ToString()).Replace("{token}", Uri.EscapeDataString(regToken))))
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
                            Message = $"Your Email '{mail}' Already Confirmed",
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "ResendConfirmEmail", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region SMS
        public async Task<SvcsBase> SendConformationSms(AppUser User, string PhoneNo)
        {
            SvcsBase Obj;
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "SendConformationSms", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> VerifyPhoneNumber(AppUser User, string Token, string PhoneNumber)
        {
            SvcsBase Obj;
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "VerifyPhoneNumber", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region 2FA
        public async Task<SvcsBase> SendTwoFactorToken(string uid)
        {
            SvcsBase Obj;
            bool Result = false;
            try
            {
                var user = await _userManager.FindByIdAsync(uid);
                string Message = user.TwoFactorEnabled ? "Disable 2FA" : "Enable 2FA";
                if (user.PhoneNumberConfirmed)
                {
                    #region sms
                    var TwoFactorToken = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
                    Result = await _smsSvcs.SendSmsAsync(user.PhoneNumber, $"Your Token To {Message} Is {TwoFactorToken}");
                    Obj = new()
                    {
                        Message = $"We Send A Conformation Token To Your Registerd Phone Number for {Message}",
                        Data = new { email = user.Email },
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                    #endregion
                }
                else if (user.EmailConfirmed)
                {
                    #region mail
                    var TwoFactorToken = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
                    UserEmailOptions options = new()
                    {
                        ToEmail = user.Email,
                        PlaceHolders =
                            [
                            new("{{UserName}}", user.Name),
                            new("{{OTP}}", TwoFactorToken)
                            ]
                    };
                    Result = await _emailSvcs.SendTwoFactorToken(options);
                    if (Result)
                    {
                        Obj = new()
                        {
                            Message = $"We Send A Conformation Token To Your Registerd Mail To {Message} ",
                            Data = new { email = user.Email },
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
                    #endregion
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "SendTwoFactorToken", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> VerifyTwoFactorToken(SignIn2faModel model)
        {
            SvcsBase Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider, model.OTP) ||
                             await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, model.OTP);
                if (result)
                {
                    var Message = user.TwoFactorEnabled ? "Disable 2FA" : "Enable 2FA";
                    bool newTwoFactorEnabledState = !user.TwoFactorEnabled;
                    user.TwoFactorEnabled = newTwoFactorEnabledState;
                    var respose = await _userManager.UpdateAsync(user);
                    if (respose.Succeeded)
                    {
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "VerifyTwoFactorToken", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Forgot, Reset && Change Password
        public async Task<SvcsBase> ForgotPassword(string mail, string routeUrl)
        {
            SvcsBase Obj;
            try
            {
                var user = await _userManager.FindByEmailAsync(mail);
                if (user != null)
                {
                    var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    UserEmailOptions options = new()
                    {
                        ToEmail = mail,
                        PlaceHolders = new List<KeyValuePair<string, string>>()
                        {
                                    new KeyValuePair<string, string>("{{UserName}}", user.Name),
                                    new KeyValuePair<string, string>("{{Link}}", routeUrl.Replace("{uid}", user.Id.ToString()).Replace("{token}", Uri.EscapeDataString(resetPasswordToken)))
                                }
                    };
                    var IsMailSend = await _emailSvcs.SendResetPasswordEmail(options);
                    if (IsMailSend)
                    {
                        Obj = new()
                        {
                            ResponseCode = (int)ResponseCode.Status.Ok,
                            Message = "We send a conformation link  To your Mail Plese Click that link to Reset Your Password"
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                            Message = $"Failed to Send Conformation link to mail {mail}"
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "ForgotPassword", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> ResetPassword(ResetPasswordModel model)
        {
            SvcsBase Obj;
            try
            {
                var result = await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), Uri.UnescapeDataString(model.Token), model.NewPassword);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "ResetPassword", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> ChangePassword(AppUser user, ChangePasswordModel model)
        {
            SvcsBase Obj;
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "ChangePassword", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region LogOut
        public SvcsBase LogOut()
        {
            _cache.Clear();
            SvcsBase Obj = new()
            {
                ResponseCode = (int)ResponseCode.Status.Ok,
                Message = "Cache cleared"
            };
            return Obj;
        }
        #endregion
    }
}
