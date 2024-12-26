using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Admin.Accounting
{
    public interface IAccountingRepo
    {
        #region Account 
        #region Group
        //Task<Result<LedgerGroup>> GetGroups();
        #endregion
        #region SubGroup  
        #region Crud
        //Task<Result<LedgerSubGroup>> GetSubGroups(Guid GroupId, Guid BranchId);
        //Task<RepoBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user);
        //Task<RepoBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user);
        //Task<RepoBase> RemoveSubGroup(Guid Id, Guid BranchId, AppUser user);
        #endregion
        #region Recover
        //Task<Result<LedgerSubGroup>> GetRemovedSubGroups(Guid BranchId);
        //Task<RepoBase> RecoverSubGroup(Guid Id, Guid BranchId, AppUser user);
        //Task<RepoBase> DeleteSubGroup(Guid Id, Guid BranchId, AppUser user);
        //Task<RepoBase> RecoverAllSubGroup(List<string> Ids, Guid BranchId, AppUser user);
        //Task<RepoBase> DeleteAllSubGroup(List<string> Ids, Guid BranchId, AppUser user);
        #endregion
        #endregion
        #region Ledger
        #region Crud
        //Task<Result<Ledger>> GetLedgers();
        //Task<Result<Ledger>> GetLedgerById(Guid Id);
        //Task<Result<Ledger>> GetLedgersHasSubLedger(Guid BranchId);
        //Task<Result<Ledger>> GetLedgersHasNoSubLedger(Guid BranchId);
        //Task<RepoBase> CreateLedger(LedgerModel data, AppUser user);
        //Task<RepoBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user);
        //Task<RepoBase> RemoveLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Ledger>> GetRemovedLedgers();
        //Task<RepoBase> RecoverLedger(Guid Id, AppUser user);
        //Task<RepoBase> DeleteLedger(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllLedger(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
    }
}
