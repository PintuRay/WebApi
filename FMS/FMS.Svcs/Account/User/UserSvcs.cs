using AutoMapper;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Account.Autherization;
using FMS.Model.Email;
using FMS.Repo;
using FMS.Repo.Account.User;
using FMS.Svcs.Common.Address;
using FMS.Svcs.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Svcs.Account.User
{
    public class UserSvcs(
        IUserRepo userRepo,
        UserValidator userValidator,
        IAddressSvcs addressSvcs,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        IEmailSvcs emailSvcs,
        IMapper mapper) : IUserSvcs
    {
        private readonly IUserRepo _userRepo = userRepo;
        private readonly UserValidator _userValidator = userValidator;
        private readonly IAddressSvcs _addressSvcs = addressSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly RoleManager<AppRole> _roleManager = roleManager;
        private readonly IMapper _mapper = mapper;
        private readonly IEmailSvcs _emailSvcs = emailSvcs;
        #region  SignUp 
        public async Task<SvcsBase> ValidateToken(string Token)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userRepo.ValidateToken(Token);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "ValidateToken", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> IsEmailInUse(string email)
        {
            SvcsBase Obj;
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                Obj = new()
                {
                    Message = $"Mail '{email}' Already In Use",
                    ResponseCode = (int)ResponseCode.Status.Found,
                };
            }
            else
            {
                Obj = new()
                {
                    Message = $"No Such Mail '{email}' Exist",
                    ResponseCode = (int)ResponseCode.Status.Ok,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> IsPhoneNumberInUse(string phoneNumber)
        {
            SvcsBase Obj;
            var isPhoneNuberInUse = await _userRepo.IsPhoneNumberInUse(phoneNumber);
            if (isPhoneNuberInUse)
            {
                Obj = new()
                {
                    Message = $"Phone Number '{phoneNumber}' Already In Use",
                    ResponseCode = (int)ResponseCode.Status.Found,
                };
            }
            else
            {
                Obj = new()
                {
                    Message = $"No Such Phone Number '{phoneNumber}' Exist",
                    ResponseCode = (int)ResponseCode.Status.Ok,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> IsUserNameExist(string userName)
        {
            SvcsBase Obj;
            var isPhoneNuberInUse = await _userRepo.IsUserNameExist(userName);
            if (isPhoneNuberInUse)
            {
                Obj = new()
                {
                    Message = $"user  '{userName}' Already Exist",
                    ResponseCode = (int)ResponseCode.Status.Found,
                };
            }
            else
            {
                Obj = new()
                {
                    Message = $"No Such User '{userName}' Exist",
                    ResponseCode = (int)ResponseCode.Status.Ok,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> SignUp(UserModel data)
        {
            bool isMailSend = false;
            SvcsBase Obj;
            try
            {
                var validationResult = await _userValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var svcsResult = await _addressSvcs.CreateAdress(data.Address);
                    if (svcsResult.ResponseCode == 201)
                    {
                        var user = _mapper.Map<AppUser>(data);
                        user.UserName = data.Email;
                        user.Fk_AdressId = Guid.Parse(((RepoBase)svcsResult.Data).Id);
                        var identity = await _userManager.CreateAsync(user, data.Password);
                        if (identity.Succeeded)
                        {
                            var regToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            if (!string.IsNullOrEmpty(regToken))
                            {
                                UserEmailOptions options = new()
                                {
                                    ToEmail = data.Email,
                                    PlaceHolders = new List<KeyValuePair<string, string>>()
                                {
                                    new KeyValuePair<string, string>("{{UserName}}", data.Name),
                                    new KeyValuePair<string, string>("{{Link}}", data.RouteUls.Replace("{uid}", user.Id.ToString()).Replace("{token}", Uri.EscapeDataString(regToken)))
                                }
                                };
                                isMailSend = await _emailSvcs.SendConfirmationEmail(options);
                                if (isMailSend)
                                {
                                    #region Assign Default Role : Devloper to first registrar; rest is user
                                    if (_userManager.Users.Count() == 1)
                                    {
                                        var checkDevloper = await _roleManager.FindByNameAsync("Devloper");
                                        if (checkDevloper is null)
                                        {
                                            await _roleManager.CreateAsync(new AppRole() { Name = "Devloper" });
                                        }
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
                                        Message = $"Account Created But Failed To Send ConfirmMail To Your Provided Mail {data.Email} ",
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
                    else
                    {
                        Obj = new()
                        {
                            Message = "registration failed",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Data = validationResult.Errors.ToArray(),
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "SignUp", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        public async Task<SvcsBase> GetUsers()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userManager.Users.Select(s=> new UserDto
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToListAsync();

                if (repoResult.Count > 0)
                {
                    Obj = new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                    return Obj;
                }
                else
                {
                    Obj = new()
                    {
                        Message = "No Record Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetUsers(PaginationParams pagination)
        {
            SvcsBase Obj;
            List<UserDto> Query = [];
            int Count = 0;
            try
            {
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                var repoResult = await _userManager.Users.Include(s => s.Address).ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = repoResult.Select(s => _mapper.Map<UserDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = repoResult.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = repoResult
                        .Where(s => s.Name.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.Email.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<UserDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = repoResult.Count(s => s.Name.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.Email.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
                }
                if (Query.Count > 0)
                {
                    Obj = new()
                    {
                        Data = Query,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                    return Obj;
                }
                else
                {
                    Obj = new()
                    {
                        Message = "No Record Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUsers", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetUserById(string Id)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userRepo.GetUserById(Id);
                if (repoResult != null)
                {
                    Obj = new()
                    {
                        Data = repoResult.Records,
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUserById", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetUserByMail(string email)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userManager.FindByEmailAsync(email);
                if (repoResult != null)
                {

                    Obj = new()
                    {
                        Data = repoResult,
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUserByMail", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateUser(UserUpdateModel User)
        {
            SvcsBase Obj;
            try
            {
                var chkUser = await _userManager.FindByIdAsync(User.Id);
                if (chkUser != null)
                {
                    var updateUser = _mapper.Map(User, chkUser);
                    var repoResult = await _userManager.UpdateAsync(updateUser);
                    if (repoResult.Succeeded)
                    {
                        var svcsResult = await _addressSvcs.UpdateAdress(User.Address);
                        if (svcsResult.ResponseCode == 200)
                        {
                            Obj = new()
                            {
                                Data = updateUser,
                                Message = "User Updated Successfully",
                                ResponseCode = (int)ResponseCode.Status.Ok,
                            };
                        }
                        else
                        {
                            Obj = new()
                            {
                                Message = svcsResult.Message,
                                ResponseCode = svcsResult.ResponseCode,
                            };
                        }
                    }
                    else
                    {
                        Obj = new()
                        {
                            Data = new { Id = User.Id },
                            Message = $"Failed To Update User",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = $"UserId '{User.Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateUser", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeletUser(string Id)
        {
            SvcsBase Obj;
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
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeletUser", _Exception.ToString());
            }
            return Obj;
        }
    }
}
