using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Purchase
{
    public class PurchaseRepo: IPurchaseRepo
    {
        #region Purchase
        public async Task<RepoBase> GetLastPurchaseTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseOrder>> GetPurchaseTransactions() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseOrder>> GetPurchaseTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseOrder>> GetRemovedPurchaseTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
