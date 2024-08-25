using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Admin;
using FMS.Repo.AdminSetting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FMS.Svcs.AdminSetting
{
    public class AdminSettingSvcs(IAdminSettingRepo adminRepo) : IAdminSettingSvcs
    {
        #region Dependancy
        private readonly IAdminSettingRepo _adminRepo = adminRepo;
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region Company Details
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #region User Branch Allocation  
        #region Crud
        public async Task<SvcsBase> GetAllUserAndBranch()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetBranchAlloctions();
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateBranchAlloction(UserBranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateBranchAlloction(data, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateBranchAlloction(Guid Id, UserBranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateBranchAlloction(Id, data, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveBranchAlloction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveBranchAlloction(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedBranchAlloction()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedBranchAlloction();
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverBranchAlloction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverBranchAlloction(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteBranchAlloction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteBranchAlloction(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllBranchAlloction(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllBranchAlloction(Ids, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllBranchAlloction(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllBranchAlloction(Ids, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Production Configuration
        #region Crud
        public async Task<SvcsBase> GetProductionConfig()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetProductionConfig();
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProductionConfig(ProductConfigDataRequest requestData, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateProductionConfig(requestData, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProductionConfig(Guid Id, ProductionOrderModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateProductionConfig(Id, data, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProductionConfig(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveProductionConfig(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductionConfig()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedProductionConfig();
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProductionConfig(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverProductionConfig(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProductionConfig(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteProductionConfig(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProductionConfig(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllProductionConfig(Ids, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProductionConfig(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllProductionConfig(Ids, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Sales Config  
        #region Crud
        public async Task<SvcsBase> GetSalesConfig()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetSalesConfig();
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateSalesConfig(ProductConfigDataRequest requestData, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateSalesConfig(requestData, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateSalesConfig(Guid Id, SalesConfigModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.UpdateSalesConfig(Id, data, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveSalesConfig(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RemoveSalesConfig(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSalesConfig()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.GetRemovedSalesConfig();
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverSalesConfig(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverSalesConfig(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteSalesConfig(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteSalesConfig(Id, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllSalesConfig(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.RecoverAllSalesConfig(Ids, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllSalesConfig(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.DeleteAllSalesConfig(Ids, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Labour Rate Configuration
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Accounting Config
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateLedger(LedgerViewModel listData, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _adminRepo.CreateLedger(listData, user);
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
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
                    Exception = _Exception,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
            }
            return Obj;
        }
        #endregion
        #endregion
        #endregion
    }
}
