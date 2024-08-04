using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Accounting;

namespace FMS.Svcs.Accounting
{
    public interface IAccountingSvcs
    {
        #region Journal
        Task<Base> GetJournalVoucherNo();
        #region Crud
        Task<Base> CreateJournal(JournalDataRequest requestData,AppUser user);
        Task<Base> GetJournals();
        Task<Base> GetJournalById(Guid Id);
        Task<Base> RemoveJournal(Guid Id, AppUser user);
        #endregion
        #region Recover      
        Task<Base> GetRemovedJournal();
        Task<Base> RecoverJournal(Guid Id, AppUser user);
        Task<Base> DeleteJournal(Guid Id, AppUser user);
        Task<Base> RecoverAllJournal(List<string> Ids, AppUser user);
        Task<Base> DeleteAllJournal(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Payment
        Task<Base> GetPaymentVoucherNo(string CashBank);
        #region Crud
        Task<Base> CreatePayment(PaymentDataRequest requestData, AppUser user);
        Task<Base> GetPayments();
        Task<Base> GetPaymentById(Guid Id);
        Task<Base> RemovePayment(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedPayment();
        Task<Base> RecoverPayment(Guid Id, AppUser user);
        Task<Base> DeletePayment(Guid Id, AppUser user);
        Task<Base> RecoverAllPayment(List<string> Ids, AppUser user);
        Task<Base> DeleteAllPayment(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Receipt
        Task<Base> GetReceiptVoucherNo(string CashBank);
        #region Crud
        Task<Base> CreateRecipt(ReciptsDataRequest requestData, AppUser user);
        Task<Base> GetReceipts();
        Task<Base> GetReceiptById(Guid Id);
        Task<Base> RemoveReceipt(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedReceipt();
        Task<Base> RecoverReceipt(Guid Id, AppUser user);
        Task<Base> DeleteReceipt(Guid Id, AppUser user);
        Task<Base> RecoverAllReceipt(List<string> Ids, AppUser user);
        Task<Base> DeleteAllReceipt(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
