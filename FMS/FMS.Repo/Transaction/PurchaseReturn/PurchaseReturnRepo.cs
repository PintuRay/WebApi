﻿using FMS.Db.Entity;

namespace FMS.Repo.Transaction.PurchaseReturn
{
    public class PurchaseReturnRepo: IPurchaseReturnRepo
    {
        #region Purchase Return
        public async Task<RepoBase> GetLastPurchaseReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactions() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseReturnOrder>> GetRemovedPurchaseReturnTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
