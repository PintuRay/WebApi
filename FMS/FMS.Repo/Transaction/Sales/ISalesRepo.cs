using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Sales
{
    public interface ISalesRepo
    {
        #region Sales
        //Task<RepoBase> GetLastSalesTransactionNo();
        #region Crud
        //Task<RepoBase> CreateSaleTransaction(SalesOrderModel data, AppUser user);
        //Task<Result<SalesOrder>> GetSaleTransactions();
        //Task<Result<SalesOrder>> GetSaleTransactionById(Guid Id);
        //Task<RepoBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user);
        //Task<RepoBase> RemoveSaleTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<SalesOrder>> GetRemovedSaleTransactions();
        //Task<RepoBase> RecoverSaleTransaction(Guid Id, AppUser user);
        //Task<RepoBase> DeleteSaleTransaction(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
