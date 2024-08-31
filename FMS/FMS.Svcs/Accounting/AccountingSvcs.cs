using FMS.Db.Entity;

namespace FMS.Svcs.Accounting
{
    public class AccountingSvcs : IAccountingSvcs
    {
        #region Journal
        public async Task<SvcsBase> GetJournalVoucherNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateJournal(JournalOrderModel requestData, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetJournals() { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetJournalById(Guid Id) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RemoveJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover      
        public async Task<SvcsBase> GetRemovedJournal() { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Payment
        public async Task<SvcsBase> GetPaymentVoucherNo(string CashBank) { throw new NotImplementedException(); }
        #region Crud
        public async Task<SvcsBase> CreatePayment(PaymentOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetPayments() { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetPaymentById(Guid Id) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RemovePayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedPayment() { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverPayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeletePayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverAllPayment(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteAllPayment(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Receipt
        public async Task<SvcsBase> GetReceiptVoucherNo(string CashBank) { throw new NotImplementedException(); }
        #region Crud
        public async Task<SvcsBase> CreateRecipt(ReceiptOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetReceipts() { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetReceiptById(Guid Id) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RemoveReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedReceipt() { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverAllReceipt(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteAllReceipt(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
