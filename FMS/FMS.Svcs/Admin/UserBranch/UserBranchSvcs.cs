using FMS.Db.Entity;
using FMS.Model;
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
        #region Crud
        public async Task<SvcsBase> GetUserBranches(AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.GetUserBranches(user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetUserBranches(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.GetUserBranches(pagination);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Count = repoResult.Count,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateUserBranch(UserBranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                    var repoResult = await _userBranchRepo.CreateUserBranch(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult.Records,
                            Message = "User Branch Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"User Branch Already Exist",
                            ResponseCode = (int)ResponseCode.Status.Found,
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateUserBranch(UserBranchUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                    var repoResult = await _userBranchRepo.UpdateUserBranch(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult.Records,
                            Message = "User Branch Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"Id '{data.Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveUserBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.RemoveUserBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = "User Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedUserBranches(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.GetRemovedUserBranches(pagination);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Count = repoResult.Count,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverUserBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.RecoverUserBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = "User Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Data = repoResult.Records,
                        Message = repoResult.ResponseCode == 302 ? $"Unable to recover due to an  active record found" : $"Id '{Id}' not found",
                        ResponseCode = repoResult.ResponseCode == 302 ? (int)ResponseCode.Status.Found : (int)ResponseCode.Status.NotFound,
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteUserBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _userBranchRepo.DeleteUserBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Id,
                        Message = "User Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
    }
}
