using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Purchase
{
    public interface IPurchaseSvcs
    {
        #region Purchase
       // Task<SvcsBase> GetLastPurchaseTransactionNo();
        #region Crud
        //Task<SvcsBase> GetPurchaseTransactions();
        //Task<SvcsBase> GetPurchaseTransactionById(Guid Id);
        //Task<SvcsBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user);
        //Task<SvcsBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user);
        //Task<SvcsBase> RemovePurchaseTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedPurchaseTransactions();
        //Task<SvcsBase> RecoverPurchaseTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> DeletePurchaseTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
