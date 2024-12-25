using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Sales
{
    public interface ISalesSvcs
    {
        #region Sales
        Task<SvcsBase> GetLastSaleTransactionNo();
        #region Crud
        Task<SvcsBase> CreateSaleTransaction(SalesOrderModel data, AppUser user);
        Task<SvcsBase> GetSaleTransactions();
        Task<SvcsBase> GetSaleTransactionById(Guid Id);
        Task<SvcsBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user);
        Task<SvcsBase> RemoveSaleTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSaleTransactions();
        Task<SvcsBase> RecoverSaleTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSaleTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }

}
