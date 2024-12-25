using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.PurchaseReturn
{
    public interface IPurchaseReturnSvcs
    {
        #region Purchase Return
        Task<SvcsBase> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<SvcsBase> GetPurchaseReturnTransactions();
        Task<SvcsBase> GetPurchaseReturnTransactionById(Guid Id);
        Task<SvcsBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user);
        Task<SvcsBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user);
        Task<SvcsBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPurchaseReturnTransactions();
        Task<SvcsBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
