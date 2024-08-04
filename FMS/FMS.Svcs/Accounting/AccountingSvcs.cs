using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Accounting;

namespace FMS.Svcs.Accounting
{
    public class AccountingSvcs : IAccountingSvcs
    {
        #region Journal
        public async Task<Base> GetJournalVoucherNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> CreateJournal(JournalDataRequest requestData, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> GetJournals() { throw new NotImplementedException(); }
        public async Task<Base> GetJournalById(Guid Id) { throw new NotImplementedException(); }
        public async Task<Base> RemoveJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover      
        public async Task<Base> GetRemovedJournal() { throw new NotImplementedException(); }
        public async Task<Base> RecoverJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> DeleteJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> RecoverAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> DeleteAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Payment
        public async Task<Base> GetPaymentVoucherNo(string CashBank) { throw new NotImplementedException(); }
        #region Crud
        public async Task<Base> CreatePayment(PaymentDataRequest requestData, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> GetPayments() { throw new NotImplementedException(); }
        public async Task<Base> GetPaymentById(Guid Id) { throw new NotImplementedException(); }
        public async Task<Base> RemovePayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedPayment() { throw new NotImplementedException(); }
        public async Task<Base> RecoverPayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> DeletePayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> RecoverAllPayment(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> DeleteAllPayment(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Receipt
        public async Task<Base> GetReceiptVoucherNo(string CashBank) { throw new NotImplementedException(); }
        #region Crud
        public async Task<Base> CreateRecipt(ReciptsDataRequest requestData, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> GetReceipts() { throw new NotImplementedException(); }
        public async Task<Base> GetReceiptById(Guid Id) { throw new NotImplementedException(); }
        public async Task<Base> RemoveReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedReceipt() { throw new NotImplementedException(); }
        public async Task<Base> RecoverReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> DeleteReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> RecoverAllReceipt(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<Base> DeleteAllReceipt(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
