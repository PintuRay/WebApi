using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Accounting
{
    public interface IAccountingRepo
    {
        #region Journal
        Task<RepoBase> GetJournalVoucherNo();
        #region Crud
        Task<Result<JournalOrder>> GetJournals();
        Task<RepoBase> CreateJournal(JournalOrderModel data);
        Task<RepoBase> GetJournalById(string Id);
        Task<RepoBase> RemoveJournal(string Id);
        #endregion
        #region Recover      
        Task<Result<JournalOrder>> GetRemovedJournal();
        Task<RepoBase> RecoverJournal(Guid Id, AppUser user);
        Task<RepoBase> DeleteJournal(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllJournal(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllJournal(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Payment
        Task<RepoBase> GetPaymentVoucherNo(string CashBank);
        #region Crud
        Task<RepoBase> CreatePayment(PaymentOrderModel data);
        Task<Result<PaymentOrder>> GetPayments();
        Task<RepoBase> GetPaymentById(string Id);
        Task<RepoBase> RemovePayment(string Id);
        #endregion
        #region Recover
        Task<Result<PaymentOrder>> GetRemovedPayment();
        Task<RepoBase> RecoverPayment(Guid Id, AppUser user);
        Task<RepoBase> DeletePayment(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllPayment(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllPayment(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Receipt
        Task<RepoBase> GetReceiptVoucherNo(string CashBank);
        #region Crud
        Task<RepoBase> CreateRecipt(ReceiptOrderModel data);
        Task<Result<ReceiptOrder>> GetReceipts();
        Task<RepoBase> GetReceiptById(string Id);
        Task<RepoBase> RemoveReceipt(string Id);
        #endregion
        #region Recover
        Task<Result<ReceiptOrder>> GetRemovedReceipt();
        Task<RepoBase> RecoverReceipt(Guid Id, AppUser user);
        Task<RepoBase> DeleteReceipt(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllReceipt(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllReceipt(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
