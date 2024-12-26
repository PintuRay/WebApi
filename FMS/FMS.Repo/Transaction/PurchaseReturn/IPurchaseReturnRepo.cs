using FMS.Db.Entity;

namespace FMS.Repo.Transaction.PurchaseReturn
{
    public interface IPurchaseReturnRepo
    {
        #region Purchase Return
        //Task<RepoBase> GetLastPurchaseReturnTransactionNo();
        #region Crud
        //Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactions();
        //Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactionById(Guid Id);
        //Task<RepoBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user);
        //Task<RepoBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user);
        //Task<RepoBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<PurchaseReturnOrder>> GetRemovedPurchaseReturnTransactions();
        //Task<RepoBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user);
        //Task<RepoBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
