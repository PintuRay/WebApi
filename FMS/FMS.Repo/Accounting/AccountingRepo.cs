using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Accounting;

namespace FMS.Repo.Accounting
{
    public class AccountingRepo: IAccountingRepo
    {
        #region Journal
        public async Task<BaseDb> GetJournalVoucherNo(){ throw new NotImplementedException(); }
        #region Crud
        public async Task<BaseDb> CreateJournal(JournalDataRequest requestData){ throw new NotImplementedException(); }
        public async Task<Result<JournalModel>> GetJournals(){ throw new NotImplementedException(); }
        public async Task<BaseDb> GetJournalById(string Id){ throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveJournal(string Id){ throw new NotImplementedException(); }
        #endregion
        #region Recover      
        public async Task<Result<JournalModel>> GetRemovedJournal(){ throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverJournal(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteJournal(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllJournal(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllJournal(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Payment
        public async Task<BaseDb> GetPaymentVoucherNo(string CashBank){ throw new NotImplementedException(); }
        #region Crud
        public async Task<BaseDb> CreatePayment(PaymentDataRequest requestData){ throw new NotImplementedException(); }
        public async Task<Result<PaymentModel>> GetPayments(){ throw new NotImplementedException(); }
        public async Task<BaseDb> GetPaymentById(string Id){ throw new NotImplementedException(); }
        public async Task<BaseDb> RemovePayment(string Id){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PaymentModel>> GetRemovedPayment(){ throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverPayment(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> DeletePayment(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllPayment(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllPayment(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Receipt
        public async Task<BaseDb> GetReceiptVoucherNo(string CashBank){ throw new NotImplementedException(); }
        #region Crud
        public async Task<BaseDb> CreateRecipt(ReciptsDataRequest requestData){ throw new NotImplementedException(); }
        public async Task<Result<ReceptModel>> GetReceipts(){ throw new NotImplementedException(); }
        public async Task<BaseDb> GetReceiptById(string Id){ throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveReceipt(string Id){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<ReceptModel>> GetRemovedReceipt(){ throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverReceipt(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteReceipt(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllReceipt(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllReceipt(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
