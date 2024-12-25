using FMS.Db.Entity;

namespace FMS.Repo.User.LedgerBalance
{
    public interface ILedgerBalanceRepo
    {
        #region LedgerBalance
        #region Crud
        Task<Result<Db.Entity.LedgerBalance>> GetLedgerBalances();
        Task<RepoBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user);
        Task<RepoBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user);
        Task<RepoBase> RemoveLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.LedgerBalance>> GetRemovedLedgerBalance();
        Task<RepoBase> RecoverLedgerBalance(Guid Id, AppUser user);
        Task<RepoBase> DeleteLedgerBalance(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
