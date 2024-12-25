using FMS.Db.Entity;

namespace FMS.Svcs.User.Subledger
{
    public interface ISubledgerSvcs
    {
        #region Subledger
        #region Crud
        Task<SvcsBase> GetSubLedgers();
        Task<SvcsBase> CreateSubLedger(SubLedgerModel Data, AppUser user);
        Task<SvcsBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user);
        Task<SvcsBase> RemoveSubLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSubLedger();
        Task<SvcsBase> RecoverSubLedger(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSubLedger(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSubLedger(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSubLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
