using FMS.Db.Entity;

namespace FMS.Svcs.Admin.Accounting
{
    public interface IAccountingSvcs
    {
        #region Accounting 
        #region Group
        //Task<SvcsBase> GetGroups();
        #endregion
        #region SubGroup
        #region Crud
        //Task<SvcsBase> GetSubGroups(Guid GroupId, Guid BranchId);
        //Task<SvcsBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user);
        //Task<SvcsBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user);
        //Task<SvcsBase> RemoveSubGroup(Guid Id, Guid BranchId, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedSubGroups(Guid BranchId);
        //Task<SvcsBase> RecoverSubGroup(Guid Id, Guid BranchId, AppUser user);
        //Task<SvcsBase> DeleteSubGroup(Guid Id, Guid BranchId, AppUser user);
        //Task<SvcsBase> RecoverAllSubGroup(List<string> Ids, Guid BranchId, AppUser user);
        //Task<SvcsBase> DeleteAllSubGroup(List<string> Ids, Guid BranchId, AppUser user);
        #endregion
        #endregion
        #region Ledger
        #region Crud
        //Task<SvcsBase> GetLedgers();
        //Task<SvcsBase> CreateLedger(LedgerModel data, AppUser user);
        //Task<SvcsBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user);
        //Task<SvcsBase> RemoveLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedLedgers();
        //Task<SvcsBase> RecoverLedger(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteLedger(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllLedger(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
    }
}
