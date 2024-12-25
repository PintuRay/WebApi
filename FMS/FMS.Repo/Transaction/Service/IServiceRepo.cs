using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Service
{
    public interface IServiceRepo
    {
        #region Service
        Task<RepoBase> GetLastServiceTransactionNo();
        #region Crud
        Task<Result<LabourOrder>> GetServiceTransactions();
        Task<RepoBase> CreateServiceTransaction(LabourOrderModel data, AppUser user);
        Task<RepoBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user);
        Task<RepoBase> RemoveServiceTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrder>> GetRemovedServiceTransactions();
        Task<RepoBase> RecoverServiceTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteServiceTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
