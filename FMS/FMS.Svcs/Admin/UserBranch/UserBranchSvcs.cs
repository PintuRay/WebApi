using FMS.Db.Entity;
using FMS.Repo.Admin.UserBranch;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.UserBranch
{
    public class UserBranchSvcs(IUserBranchRepo userBranchRepo, IEmailSvcs emailSvc) : IUserBranchSvcs
    {
        #region Dependancy
        private readonly IUserBranchRepo _userBranchRepo = userBranchRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region User Branch  
        #region Crud
        public async Task<SvcsBase> GetUserBranches()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.GetUserBranches();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        //public async Task<SvcsBase> CreateUserBranch(UserBranchModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.CreateUserBranch(data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranch Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"UserBranch Already Exist",
        //                ResponseCode = (int)ResponseCode.Status.BadRequest,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateUserBranch", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateUserBranch(Guid Id, UserBranchModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.UpdateUserBranch(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranch Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"BranchId or UserId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateUserBranch", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveUserBranch(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.RemoveUserBranch(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranch Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"BranchId or UserId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveUserBranch", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedUserBranches()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.GetRemovedUserBranches();
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "No Record Exist",
        //                ResponseCode = (int)ResponseCode.Status.NoContent,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedUserBranches", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverUserBranch(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.RecoverUserBranch(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranch Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"UserBranchId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverUserBranch", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteUserBranch(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.DeleteUserBranch(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranch Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"UserBranchId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteUserBranch", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllUserBranches(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.RecoverAllUserBranches(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranches Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover UserBranches",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllUserBranches", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllUserBranches(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _userBranchRepo.DeleteAllUserBranches(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "UserBranches Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete UserBranches",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllUserBranches", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
    }
}
