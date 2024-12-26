using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.SalesReturn
{
    public interface ISalesReturnSvcs
    {
        #region Sales Return
       // Task<SvcsBase> GetLastSaleReturnTransactionNo();
        #region Crud
        //Task<SvcsBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user);
        //Task<SvcsBase> GetSaleReturnsTransactions();
        //Task<SvcsBase> GetSaleReturnTransactionById(Guid Id);
        //Task<SvcsBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user);
        //Task<SvcsBase> RemoveSaleReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedSaleReturnTransactions();
        //Task<SvcsBase> RecoverSaleReturnTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteSaleReturnTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllSaleReturnTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
