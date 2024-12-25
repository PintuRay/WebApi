using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Purchase
{
    public interface IPurchaseRepo
    {
        #region Purchase
        Task<RepoBase> GetLastPurchaseTransactionNo();
        #region Crud
        Task<Result<PurchaseOrder>> GetPurchaseTransactions();
        Task<Result<PurchaseOrder>> GetPurchaseTransactionById(Guid Id);
        Task<RepoBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user);
        Task<RepoBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user);
        Task<RepoBase> RemovePurchaseTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseOrder>> GetRemovedPurchaseTransactions();
        Task<RepoBase> RecoverPurchaseTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeletePurchaseTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
