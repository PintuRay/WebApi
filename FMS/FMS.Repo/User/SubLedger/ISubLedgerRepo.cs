using FMS.Db.Entity;

namespace FMS.Repo.User.SubLedger
{
    public interface ISubLedgerRepo
    {
        #region Subledger
        #region Crud
        //Task<Result<Db.Entity.SubLedger>> GetSubLedgers();
        //Task<RepoBase> CreateSubLedger(SubLedgerModel Data, AppUser user);
        //Task<RepoBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user);
        //Task<RepoBase> RemoveSubLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Db.Entity.SubLedger>> GetRemovedSubLedger();
        //Task<RepoBase> RecoverSubLedger(Guid Id, AppUser user);
        //Task<RepoBase> DeleteSubLedger(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllSubLedger(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllSubLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
