using AutoMapper;
using FMS.Db.Entity;
using FMS.Model.Account.Autherization;
using FMS.Repo.Account.AutherIzation;
using FMS.Svcs.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace FMS.Svcs.Account.Autherization
{
    public class AutherizationSvcs(
        IAutherizationRepo autherizationRepo,
        RoleManager<AppRole> roleManager,
        UserManager<AppUser> userManager,
        IEmailSvcs emailSvcs,
        IMapper mapper
        ) : IAutherizationSvcs
    {
        private readonly IAutherizationRepo _autherizationRepo = autherizationRepo;
        private readonly RoleManager<AppRole> _roleManager = roleManager;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IMapper _mapper = mapper;
        private readonly IEmailSvcs _emailSvcs = emailSvcs;
        #region User
        public async Task<SvcsBase> GetUsers()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userManager.Users.ToListAsync();
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
                        ResponseCode = (int)ResponseCode.Status.Ok,
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
        public async Task<SvcsBase> GetUserById(string Id)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _autherizationRepo.GetUserById(Id); // _userManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    Obj = new()
                    {
                        Data = repoResult,
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
                        Obj = new()
                        {
                            Data = new { Id = updateUser.Id },
                            Message = "User Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
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
        #endregion
        #region Role
        public async Task<SvcsBase> CreateRole(AppRole model)
        {
            SvcsBase Obj;
            try
            {
                bool ChkRoleExist = await _roleManager.RoleExistsAsync(model.Name);
                if (!ChkRoleExist)
                {
                    var identityRole = await _roleManager.CreateAsync(model);
                    if (identityRole.Succeeded)
                    {
                        Obj = new()
                        {
                            Data = new { Id = model.Id },
                            Message = "Role Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Faild To Create New Role",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }

                }
                else
                {
                    Obj = new()
                    {
                        Message = $"Role '{model.Name}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateRole", _Exception.ToString());
            }

            return Obj;
        }
        public async Task<SvcsBase> GetRoles()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _roleManager.Roles.ToListAsync();
                if (repoResult.Count > 0)
                {
                    Obj = new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = "No Role Exist",
                        ResponseCode = (int)ResponseCode.Status.Ok,
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRoles", _Exception.ToString());
            }

            return Obj;
        }
        public async Task<SvcsBase> GetRoleById(string Id)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _roleManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    Obj = new()
                    {
                        Data = repoResult,
                        Message = "Record Found",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {

                        Message = $"Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRoleById", _Exception.ToString());
            }


            return Obj;
        }
        public async Task<SvcsBase> UpdateRole(string Id, AppRole model)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _roleManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    var identityRole = await _roleManager.UpdateAsync(model);
                    if (identityRole.Succeeded)
                    {
                        Obj = new()
                        {
                            Data = new { Id = Id },
                            Message = "Role Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = $"Failed To Update Role",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Data = new { Id = Id },
                        Message = $"RoleId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateRole", _Exception.ToString());
            }

            return Obj;
        }
        public async Task<SvcsBase> DeleteRole(string Id)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _roleManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    var IdentityRole = await _roleManager.DeleteAsync(repoResult);
                    if (IdentityRole.Succeeded)
                    {
                        Obj = new()
                        {
                            Data = new { Id = Id },
                            Message = "Role Deleted Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Message = "Failed To Delete Role",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        };
                    }
                }
                else
                {
                    Obj = new()
                    {
                        Message = $"RoleId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteRole", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region User-Role && Claims
        public async Task<SvcsBase> GetAllUserWithRolesAndClaims()
        {
            SvcsBase Obj;
            var users = new List<UserRoleClaimModel>();
            try
            {
                foreach (var user in _userManager.Users)
                {
                    #region User Role
                    var userRoles = new List<UserRoleModel>();
                    foreach (var role in _roleManager.Roles)
                    {
                        var userRole = new UserRoleModel()
                        {
                            RoleId = role.Id,
                            RoleName = role.Name,
                            IsRoleSelected = await _userManager.IsInRoleAsync(user, role.Name),
                        };
                        userRoles.Add(userRole);
                    }
                    #endregion
                    #region User Claims
                    var userClaims = new List<UserClaimModel>();
                    var ExistingUserClaims = await _userManager.GetClaimsAsync(user);
                    foreach (Claim claim in ClaimsStoreModel.AllClaims)
                    {
                        var userClaim = new UserClaimModel()
                        {
                            ClaimValue = claim.Value,
                            ClaimType = claim.Type,
                            IsClaimSelected = ExistingUserClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value)
                        };
                        userClaims.Add(userClaim);
                    }
                    #endregion
                    var data = new UserRoleClaimModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        UserRoles = userRoles,
                        UserClaims = userClaims,
                    };
                    users.Add(data);
                }
                Obj = new()
                {
                    Data = users,
                    ResponseCode = (int)ResponseCode.Status.Ok,
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                   Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetAllUserWithRolesAndClaims", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetUserWithRolesAndClaims(string UserId)
        {
            SvcsBase Obj;
            try
            {
                var isUserExist = await _userManager.FindByIdAsync(UserId);
                if (isUserExist != null)
                {
                    #region User Claims
                    var userClaims = new List<UserClaimModel>();
                    var ExistingUserClaims = await _userManager.GetClaimsAsync(isUserExist);
                    foreach (Claim claim in ClaimsStoreModel.AllClaims)
                    {
                        var userClaim = new UserClaimModel()
                        {
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value,
                            IsClaimSelected = ExistingUserClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value)
                        };
                        userClaims.Add(userClaim);
                    }
                    #endregion
                    #region User Role
                    var userRoles = new List<UserRoleModel>();
                    foreach (var role in _roleManager.Roles)
                    {
                        var userRole = new UserRoleModel()
                        {
                            RoleId = role.Id,
                            RoleName = role.Name,
                            IsRoleSelected = await _userManager.IsInRoleAsync(isUserExist, role.Name),
                        };
                        userRoles.Add(userRole);
                    }
                    #endregion
                    var user = new UserRoleClaimModel()
                    {
                        Id = isUserExist.Id,
                        Name = isUserExist.Name,
                        UserRoles = userRoles,
                        UserClaims = userClaims,
                    };
                    Obj = new()
                    {
                        Data = user,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = "User Not Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUserWithRolesAndClaims", _Exception.ToString());
            }

            return Obj;
        }
        public async Task<SvcsBase> UpdateUserRoleAndClaims(UserRoleClaimModel model)
        {
            SvcsBase Obj;
            try
            {

                var FindUser = await _userManager.FindByIdAsync(model.Id);
                if (FindUser != null)
                {
                    #region Roles
                    foreach (var updateRole in model.UserRoles)
                    {
                        if (updateRole.IsRoleSelected)
                        {
                            await _userManager.AddToRoleAsync(FindUser, updateRole.RoleName);
                        }
                        else
                        {
                            await _userManager.RemoveFromRoleAsync(FindUser, updateRole.RoleName);
                        }
                    }
                    #endregion
                    #region claims
                    var claims = await _userManager.GetClaimsAsync(FindUser);
                    if (claims != null)
                    {
                        await _userManager.RemoveClaimsAsync(FindUser, claims);
                        await _userManager.AddClaimsAsync(FindUser, model.UserClaims.Select(c => new Claim(c.ClaimType, c.IsClaimSelected ? c.ClaimType : "")));
                    }

                    #endregion
                    Obj = new()
                    {
                        Message = "Successfully Update User Role and Claims",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Message = $"User  Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateUserRoleAndClaims", _Exception.ToString());
            }

            return Obj;
        }
        #endregion
    }
}

