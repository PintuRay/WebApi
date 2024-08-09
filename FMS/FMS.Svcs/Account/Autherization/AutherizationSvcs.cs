using AutoMapper;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Repo;
using FMS.Repo.Account.AutherIzation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FMS.Svcs.Account.Autherization
{
    public class AutherizationSvcs(
        IAutherizationRepo autherizationRepo,
        RoleManager<AppRole> roleManager,
        UserManager<AppUser> userManager,
        IMapper mapper
        ) : IAutherizationSvcs
    {
        private readonly IAutherizationRepo _autherizationRepo = autherizationRepo;
        private readonly RoleManager<AppRole> _roleManager = roleManager;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IMapper _mapper = mapper;
        #region Role
        public async Task<Base> CreateRole(RoleModel model)
        {
            Base Obj;
            try
            {
                bool ChkRoleExist = await _roleManager.RoleExistsAsync(model.Name);
                if (!ChkRoleExist)
                {
                    var Role = _mapper.Map<AppRole>(model);
                    Role.CreatedDate = DateTime.UtcNow;
                    Role.CreatedBy = "N/A";
                    var identityRole = await _roleManager.CreateAsync(Role);
                    if (identityRole.Succeeded)
                    {
                        Obj = new()
                        {
                            Data = new { Id = Role.Id },
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }

            return Obj;
        }
        public async Task<Base> GetRoles()
        {
            Base Obj;
            try
            {
                var repoResult = await _roleManager.Roles.ToListAsync();
                if (repoResult.Count > 0)
                {
                    var roles = _mapper.Map<List<RoleDbModel>>(repoResult);
                    Obj = new()
                    {
                        Data = roles,
                        Count = roles.Count.ToString(),
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }

            return Obj;
        }
        public async Task<Base> GetRoleById(string Id)
        {
            Base Obj;
            try
            {
                var repoResult = await _roleManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    var role = _mapper.Map<RoleDbModel>(repoResult);
                    Obj = new()
                    {
                        Data = role,
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }


            return Obj;
        }
        public async Task<Base> UpdateRole(string Id, RoleModel model)
        {
            Base Obj;
            try
            {
                var repoResult = await _roleManager.FindByIdAsync(Id);
                if (repoResult != null)
                {
                    var updateRole = _mapper.Map(model, repoResult);
                    repoResult.ModifyDate = DateTime.UtcNow;
                    repoResult.ModifyBy = "N/A";
                    var identityRole = await _roleManager.UpdateAsync(updateRole);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }

            return Obj;
        }
        public async Task<Base> DeleteRole(string Id)
        {
            Base Obj;
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region User-Role && Claims
        public async Task<Base> GetAllUserWithRolesAndClaims()
        {
            Base Obj;
            var users = new List<UserRoleClaimViewModel>();
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
                            ClaimType = claim.Type,
                            IsClaimSelected = ExistingUserClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value)
                        };
                        userClaims.Add(userClaim);
                    }
                    #endregion
                    var data = new UserRoleClaimViewModel()
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
                    Count = users.Count.ToString(),
                    ResponseCode = (int)ResponseCode.Status.Ok,
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
        public async Task<Base> GetUserWithRolesAndClaims(string UserId)
        {
            Base Obj;
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
                            UserId = isUserExist.Id,
                            ClaimType = claim.Type,
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
                    var user = new UserRoleClaimViewModel()
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }

            return Obj;
        }
        public async Task<Base> UpdateUserRoleAndClaims(UserRoleClaimModel model)
        {
            Base Obj;
            try
            {
                var FindUser = await _userManager.FindByIdAsync(model.Id);
                if (FindUser != null)
                {
                    var OldRole = _userManager.GetRolesAsync(FindUser).Result.First();
                    var NewRole = _roleManager.FindByIdAsync(model.UserRole.RoleId).Result.Name;
                    if (!await _userManager.IsInRoleAsync(FindUser, NewRole))
                    {
                        await _userManager.RemoveFromRoleAsync(FindUser, OldRole);
                        await _userManager.AddToRoleAsync(FindUser, NewRole);
                    }
                    //claims
                    var claims = await _userManager.GetClaimsAsync(FindUser);
                    if (claims != null)
                    {
                        await _userManager.RemoveClaimsAsync(FindUser, claims);
                    }

                    await _userManager.AddClaimsAsync(FindUser, model.UserClaims.Select(c => new Claim(c.ClaimType, c.IsClaimSelected ? c.ClaimType : "")));
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }

            return Obj;
        }
        #endregion
    }
}
