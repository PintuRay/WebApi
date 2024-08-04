using FMS.Db.Entity;
using FMS.Model.Accounting;
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repo.Accounting
{
    public interface IAccountingRepo
    {
        #region Journal
        Task<BaseDb> GetJournalVoucherNo();
        #region Crud
        Task<BaseDb> CreateJournal(JournalDataRequest requestData);
        Task<Result<JournalModel>> GetJournals();
        Task<BaseDb> GetJournalById(string Id);
        Task<BaseDb> RemoveJournal(string Id);
        #endregion
        #region Recover      
        Task<Result<JournalModel>> GetRemovedJournal();
        Task<BaseDb> RecoverJournal(Guid Id, AppUser user);
        Task<BaseDb> DeleteJournal(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllJournal(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllJournal(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Payment
        Task<BaseDb> GetPaymentVoucherNo(string CashBank);
        #region Crud
        Task<BaseDb> CreatePayment(PaymentDataRequest requestData);
        Task<Result<PaymentModel>> GetPayments();
        Task<BaseDb> GetPaymentById(string Id);
        Task<BaseDb> RemovePayment(string Id);
        #endregion
        #region Recover
        Task<Result<PaymentModel>> GetRemovedPayment();
        Task<BaseDb> RecoverPayment(Guid Id, AppUser user);
        Task<BaseDb> DeletePayment(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllPayment(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllPayment(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Receipt
        Task<BaseDb> GetReceiptVoucherNo(string CashBank);
        #region Crud
        Task<BaseDb> CreateRecipt(ReciptsDataRequest requestData);
        Task<Result<ReceptModel>> GetReceipts();
        Task<BaseDb> GetReceiptById(string Id);
        Task<BaseDb> RemoveReceipt(string Id);
        #endregion
        #region Recover
        Task<Result<ReceptModel>> GetRemovedReceipt();
        Task<BaseDb> RecoverReceipt(Guid Id, AppUser user);
        Task<BaseDb> DeleteReceipt(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllReceipt(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllReceipt(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
