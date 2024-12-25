using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Production
{
    public interface IProductionRepo
    {
        #region Production
        Task<RepoBase> GetLastProductionTransactionNo();
        #region Crud
        Task<Result<LabourOrder>> GetProductionTransactions();
        Task<RepoBase> CreateProductionTransaction(LabourOrderModel data, AppUser user);
        Task<RepoBase> UpdateProductionTransaction(Guid Id, LabourOrderModel data, AppUser user);
        Task<RepoBase> RemoveProductionTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrder>> GetRemovedProductionTransactions();
        Task<RepoBase> RecoverProductionTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteProductionTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProductionTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProductionTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
