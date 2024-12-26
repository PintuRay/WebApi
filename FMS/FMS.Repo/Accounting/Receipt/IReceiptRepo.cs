using FMS.Db.Entity;

namespace FMS.Repo.Accounting.Receipt
{
    public interface IReceiptRepo
    {
        #region Receipt
        //Task<RepoBase> GetReceiptVoucherNo(string CashBank);
        #region Crud
        //Task<RepoBase> CreateRecipt(ReceiptOrderModel data);
        //Task<Result<ReceiptOrder>> GetReceipts();
        //Task<RepoBase> GetReceiptById(string Id);
        //Task<RepoBase> RemoveReceipt(string Id);
        #endregion
        #region Recover
        //Task<Result<ReceiptOrder>> GetRemovedReceipt();
        //Task<RepoBase> RecoverReceipt(Guid Id, AppUser user);
        //Task<RepoBase> DeleteReceipt(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllReceipt(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllReceipt(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
