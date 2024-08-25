using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Accounting;

namespace FMS.Svcs.Accounting
{
    public interface IAccountingSvcs
    {
        #region Journal
        Task<SvcsBase> GetJournalVoucherNo();
        #region Crud
        Task<SvcsBase> CreateJournal(JournalDataRequest requestData,AppUser user);
        Task<SvcsBase> GetJournals();
        Task<SvcsBase> GetJournalById(Guid Id);
        Task<SvcsBase> RemoveJournal(Guid Id, AppUser user);
        #endregion
        #region Recover      
        Task<SvcsBase> GetRemovedJournal();
        Task<SvcsBase> RecoverJournal(Guid Id, AppUser user);
        Task<SvcsBase> DeleteJournal(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllJournal(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllJournal(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Payment
        Task<SvcsBase> GetPaymentVoucherNo(string CashBank);
        #region Crud
        Task<SvcsBase> CreatePayment(PaymentDataRequest requestData, AppUser user);
        Task<SvcsBase> GetPayments();
        Task<SvcsBase> GetPaymentById(Guid Id);
        Task<SvcsBase> RemovePayment(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPayment();
        Task<SvcsBase> RecoverPayment(Guid Id, AppUser user);
        Task<SvcsBase> DeletePayment(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllPayment(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPayment(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Receipt
        Task<SvcsBase> GetReceiptVoucherNo(string CashBank);
        #region Crud
        Task<SvcsBase> CreateRecipt(ReciptsDataRequest requestData, AppUser user);
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
