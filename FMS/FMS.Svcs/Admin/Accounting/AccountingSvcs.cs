using FMS.Db.Entity;
using FMS.Repo.Admin.Accounting;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Accounting
{
    public class AccountingSvcs(IAccountingRepo accountingRepo, IEmailSvcs emailSvc) : IAccountingSvcs
    {
        #region Dependancy
        private readonly IAccountingRepo _accountingRepo = accountingRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Accounting 
        #region Group
        public async Task<SvcsBase> GetGroups()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.GetGroups();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetGroups", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region SubGroup
        #region Crud
        public async Task<SvcsBase> GetSubGroups(Guid GroupId, Guid BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.GetSubGroups(GroupId, BranchId);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetSubGroups", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.CreateSubGroup(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroup Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"SubGroup '{data.SubGroupName}' Already Exist",
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
                var repoResult = await _accountingRepo.UpdateSubGroup(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroup Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"SubGroupId '{Id}' Not Found",
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
        public async Task<SvcsBase> RemoveSubGroup(Guid Id, Guid BranchId, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.RemoveSubGroup(Id, BranchId, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroup Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"SubGroupId '{Id}' Not Found",
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
        public async Task<SvcsBase> GetRemovedSubGroups(Guid BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.GetRemovedSubGroups(BranchId);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverSubGroup(Guid Id, Guid BranchId, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.RecoverSubGroup(Id, BranchId, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroup Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"SubGroupId '{Id}' Not Found",
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
        public async Task<SvcsBase> DeleteSubGroup(Guid Id, Guid BranchId, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.DeleteSubGroup(Id, BranchId, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroup Deleted Successfully",
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
        public async Task<SvcsBase> RecoverAllSubGroup(List<string> Ids, Guid BranchId, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.RecoverAllSubGroup(Ids, BranchId, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroups Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover SubGroups",
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
        public async Task<SvcsBase> DeleteAllSubGroup(List<string> Ids, Guid BranchId, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.DeleteAllSubGroup(Ids, BranchId, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "SubGroups Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete SubGroups",
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
                var repoResult = await _accountingRepo.GetLedgers();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetLedgers", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateLedger(LedgerModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.CreateLedger(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Ledger Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Ledger '{data.LedgerName}' Already Exist",
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
                var repoResult = await _accountingRepo.UpdateLedger(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Ledger Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"LedgerId '{Id}' Not Found",
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
                var repoResult = await _accountingRepo.RemoveLedger(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Ledger Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"LedgerId '{Id}' Not Found",
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
                var repoResult = await _accountingRepo.GetRemovedLedgers();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedLedgers", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverLedger(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _accountingRepo.RecoverLedger(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = new { Id },
                        Message = "Ledger Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"LedgerId '{Id}' Not Found",
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
                var repoResult = await _accountingRepo.DeleteLedger(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Ledger Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"LedgerId '{Id}' Not Found",
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
                var repoResult = await _accountingRepo.RecoverAllLedger(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Ledgers Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Ledgers",
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
                var repoResult = await _accountingRepo.DeleteAllLedger(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Ledgers Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Ledgers",
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
