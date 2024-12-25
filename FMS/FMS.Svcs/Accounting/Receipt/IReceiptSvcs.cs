using FMS.Db.Entity;

namespace FMS.Svcs.Accounting.Receipt
{
    public interface IReceiptSvcs
    {
        #region Receipt
        Task<SvcsBase> GetReceiptVoucherNo(string CashBank);
        #region Crud
        Task<SvcsBase> CreateRecipt(ReceiptOrderModel data, AppUser user);
        Task<SvcsBase> GetReceipts();
        Task<SvcsBase> GetReceiptById(Guid Id);
        Task<SvcsBase> RemoveReceipt(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedReceipt();
        Task<SvcsBase> RecoverReceipt(Guid Id, AppUser user);
        Task<SvcsBase> DeleteReceipt(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllReceipt(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllReceipt(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
