using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Sales
{
    public class SalesRepo: ISalesRepo
    {
        #region Sales
        public async Task<RepoBase> GetLastSalesTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<SalesOrder>> GetSaleTransactions() { throw new NotImplementedException(); }
        public async Task<Result<SalesOrder>> GetSaleTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateSaleTransaction(SalesOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSaleTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesOrder>> GetRemovedSaleTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSaleTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSaleTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
