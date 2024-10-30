using FMS.Db.Entity;
using FMS.Repo.Devloper;
using FMS.Svcs.Email;
namespace FMS.Svcs.Devloper
{
    public class DevloperSvcs(IDevloperRepo devloperRepo, IEmailSvcs emailSvc)  : IDevloperSvcs
    {
        #region Dependancy
        private readonly IDevloperRepo _devloperRepo = devloperRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Branch
        #region Crud
        public async Task<SvcsBase> GetAllBranch()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetAllBranch();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateBranch(BranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.CreateBranch(data, user);
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
                        Message = $"Branch '{data.BranchName}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateBranch(Guid Id, BranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.UpdateBranch(Id, data, user);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RemoveBranch(Id, user);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedBranches()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetRemovedBranches();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RecoverBranch(Id, user);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.DeleteBranch(Id, user);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllBranch(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RecoverAllBranch(Ids, user);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllBranch(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.DeleteAllBranch(Ids, user);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Financial Year
        #region Crud
        public async Task<SvcsBase> GetFinancialYears()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetFinancialYears();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateFinancialYear(FinancialYearModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.CreateFinancialYear(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Financial Year Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Financial Year {data.Financial_Year} Already Exist",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.UpdateFinancialYear(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Financial Year Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Financial Year '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RemoveFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Financial Year Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"FinancialYear Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedFinancialYears()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetRemovedFinancialYears();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RecoverFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Financial Year Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"FinancialYear Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.DeleteFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Financial Year Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Financial Year",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllFinancialYear(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RecoverAllFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Financial Years Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Financial Years",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllFinancialYear(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.DeleteAllFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Financial Years Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Financial Years",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Branch Financial Year
        #region Crud
        public async Task<SvcsBase> GetBranchFinancialYears()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetBranchFinancialYears();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetBranchFinancialYears(Guid BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetBranchFinancialYears(BranchId);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.CreateBranchFinancialYear(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = repoResult.Id },
                        Count = repoResult.Count,
                        Message = "Branch FinancialYear Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Branch FinancialYear Already Exist",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.UpdateBranchFinancialYear(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id = Id },
                        Count = repoResult.Count,
                        Message = "Branch FinancialYear Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RemoveBranchFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch FinancialYear Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedBranchFinancialYears()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.GetRemovedBranchFinancialYears();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverBranchFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RecoverBranchFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch FinancialYear Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteBranchFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.DeleteBranchFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Count = repoResult.Count,
                        Message = "Branch Financial Year Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.RecoverAllBranchFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branch FinancialYears Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch FinancialYears",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _devloperRepo.DeleteAllBranchFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Count = repoResult.Count,
                        Message = "Branch FinancialYears Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch Financial Years",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
    }
}
