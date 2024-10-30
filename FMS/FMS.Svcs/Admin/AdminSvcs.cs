using FMS.Db.Entity;
using FMS.Repo.Admin;
using FMS.Svcs.Admin;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin
{
    public class AdminSvcs(IAdminRepo adminRepo, IEmailSvcs emailSvc) : IAdminSvcs
    {
        #region Dependancy
        private readonly IAdminRepo _adminRepo = adminRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;

        #endregion
        #region Generate SignUp Token
        public async Task<SvcsBase> CreateToken(RegisterTokenModel Token)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateToken(Token);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Token Created",
                        ResponseCode = (int)ResponseCode.Status.Created,

                    },
                    false => new()
                    {
                        Message = "Token Already Used",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateToken", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Company
        #region Crud
        public async Task<SvcsBase> GetCompany(string BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetCompany(BranchId);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateCompany(CompanyModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateCompany(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateCompany(Id, model, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveCompany(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveCompany(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveCompany", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedCompanies(string BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedCompanies(BranchId);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedCompanies", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverCompany(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverCompany(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteCompany(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteCompany(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllCompany(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllCompany(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllCompany(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllCompany(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllCompany", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region User Branch  
        #region Crud
        public async Task<SvcsBase> GetUserBranches()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetUserBranches();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateUserBranch(UserBranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateUserBranch(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateUserBranch(Guid Id, UserBranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateUserBranch(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveUserBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveUserBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedUserBranches()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedUserBranches();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverUserBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverUserBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteUserBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteUserBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteUserBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllUserBranches(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllUserBranches(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllUserBranches(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllUserBranches(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllUserBranches", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product 
        #region Product Type
        public async Task<SvcsBase> GetProductTypes()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetProductTypes();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProductTypes", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Unit
        #region Crud
        public async Task<SvcsBase> GetAllUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetAllUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAllUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateUnit(UnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateUnit(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Unit Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Unit '{data.UnitName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateUnit(Guid Id, UnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateUnit(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Alternate Unit
        #region Crud
        public async Task<SvcsBase> GetAlternateUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetAlternateUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAlternateUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateAlternateUnit(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateAlternateUnit(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveAlternateUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveAlternateUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedAlternateUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedAlternateUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedAlternateUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAlternateUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAlternateUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAlternateUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAlternateUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllAlternateUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllCompany(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product Group
        #region Crud
        public async Task<SvcsBase> GetProductGroups()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetProductGroups();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProductGroups", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProductGroup(ProductGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateProductGroup(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateProductGroup(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProductGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveProductGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductGroup()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedProductGroup();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProductGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverProductGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProductGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteProductGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProductGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllProductGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProductGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllProductGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        public async Task<SvcsBase> GetProductSubGroups()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetProductSubGroups();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProductSubGroups", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateProductSubGroup(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateProductSubGroup(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProductSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveProductSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductSubGroup()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedProductSubGroup();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProductSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverProductSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProductSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteProductSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllProductSubGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllProductSubGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product
        #region Crud
        public async Task<SvcsBase> GetAllProducts()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetAllProducts();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAllProducts", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProduct(ProductModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateProduct(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProduct(Guid Id, ProductModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateProduct(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProduct(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveProduct(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProduct", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProduct()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedProduct();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProduct(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverProduct(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProduct(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteProduct(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProduct(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllProduct(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProduct(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllProduct(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProduct", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #endregion
        #region Production 
        #region Crud
        public async Task<SvcsBase> GetProduction()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetProduction();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProduction(ProductionOrderModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateProduction(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateProduction(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProduction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveProduction(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProduction", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProduction()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedProduction();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProduction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverProduction(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProduction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteProduction(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProduction(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllProduction(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProduction(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllProduction(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProduction", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Sales   
        #region Crud
        public async Task<SvcsBase> GetSales()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetSales();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", " GetSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateSales(SalesOrderSetupModel requestData, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateSales(requestData, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateSales(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveSales(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveSales(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveSales", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSales()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedSales();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverSales(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverSales(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteSales(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteSales(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllSales(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllSales(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllSales", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllSales(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllSales(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllSales", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Labour Rate 
        #region Crud
        public async Task<SvcsBase> GetAllLabourRates()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetAllLabourRates();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAllLabourRates", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateLabourRate(LabourRateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateLabourRate(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateLabourRate(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveLabourRate(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveLabourRate(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedLabourRate()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedLabourRate();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverLabourRate(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverLabourRate(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteLabourRate(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteLabourRate(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllLabourRate(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllLabourRate(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllLabourRate(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllCompany(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllLabourRate", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Accounting 
        #region Group
        public async Task<SvcsBase> GetGroups()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetGroups();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetGroups", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region SubGroup
        #region Crud
        public async Task<SvcsBase> GetSubGroups()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetSubGroups();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetSubGroups", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateSubGroup(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateSubGroup(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSubGroup()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedSubGroup();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllSubGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllSubGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllSubGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllSubGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Ledger
        #region Crud
        public async Task<SvcsBase> GetLedgers()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetLedgers();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetLedgers", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateLedger(LedgerModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateLedger(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        //Message = $"Branch '{data.BranchName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateLedger", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateLedger(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateLedger", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveLedger(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveLedger(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveLedger", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedLedgers()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedLedgers();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.CollectionObjData,
                        Count = repoResult.CollectionObjData.Count.ToString(),
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedLedgers", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverLedger(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverLedger(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverLedger", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteLedger(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteLedger(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteLedger", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllLedger(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllLedger(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllLedger", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllLedger(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllLedger(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllLedger", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #endregion
    }
}
