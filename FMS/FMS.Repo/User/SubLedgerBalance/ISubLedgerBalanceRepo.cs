using FMS.Db.Entity;

namespace FMS.Repo.User.SubLedgerBalance
{
    public interface ISubLedgerBalanceRepo
    {
        #region SubLedger Balance
        #region Crud
        //Task<Result<Db.Entity.SubLedgerBalance>> GetSubLedgerBalances();
        //Task<RepoBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user);
        //Task<RepoBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user);
        //Task<RepoBase> RemoveSubLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Db.Entity.SubLedgerBalance>> GetRemovedSubLedgerBalance();
        //Task<RepoBase> RecoverSubLedgerBalance(Guid Id, AppUser user);
        //Task<RepoBase> DeleteSubLedgerBalance(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
