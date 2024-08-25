using FMS.Db.Entity;
using FMS.Model;


namespace FMS.Repo.Accounting
{
    public class AccountingRepo: IAccountingRepo
    {
        #region Journal
        public async Task<RepoBase> GetJournalVoucherNo(){ throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateJournal(JournalOrderModel requestData){ throw new NotImplementedException(); }
        public async Task<Result<JournalOrder>> GetJournals(){ throw new NotImplementedException(); }
        public async Task<RepoBase> GetJournalById(string Id){ throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveJournal(string Id){ throw new NotImplementedException(); }
        #endregion
        #region Recover      
        public async Task<Result<JournalOrder>> GetRemovedJournal(){ throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverJournal(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteJournal(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllJournal(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllJournal(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Payment
        public async Task<RepoBase> GetPaymentVoucherNo(string CashBank){ throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreatePayment(PaymentOrderModel data){ throw new NotImplementedException(); }
        public async Task<Result<PaymentOrder>> GetPayments(){ throw new NotImplementedException(); }
        public async Task<RepoBase> GetPaymentById(string Id){ throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePayment(string Id){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PaymentOrder>> GetRemovedPayment(){ throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPayment(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePayment(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPayment(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPayment(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Receipt
        public async Task<RepoBase> GetReceiptVoucherNo(string CashBank){ throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateRecipt(ReceiptOrderModel data){ throw new NotImplementedException(); }
        public async Task<Result<ReceiptOrder>> GetReceipts(){ throw new NotImplementedException(); }
        public async Task<RepoBase> GetReceiptById(string Id){ throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveReceipt(string Id){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<ReceiptOrder>> GetRemovedReceipt(){ throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverReceipt(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteReceipt(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllReceipt(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllReceipt(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
