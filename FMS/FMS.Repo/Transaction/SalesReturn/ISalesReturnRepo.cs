using FMS.Db.Entity;

namespace FMS.Repo.Transaction.SalesReturn
{
    public interface ISalesReturnRepo
    {
        #region Sales Return
        //Task<RepoBase> GetLastSalesReturnTransactionNo();
        #region Crud
        //Task<Result<SalesReturnOrder>> GetSaleReturnTransactions();
        //Task<Result<SalesReturnOrder>> GetSaleReturnTransactionById(Guid Id);
        //Task<RepoBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user);
        //Task<RepoBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user);
        //Task<RepoBase> RemoveSaleReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<SalesReturnOrder>> GetRemovedSaleReturnTransactions();
        //Task<RepoBase> RecoverSaleReturnTransaction(Guid Id, AppUser user);
        //Task<RepoBase> DeleteSaleReturnTransaction(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllSaleReturnTransaction(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
