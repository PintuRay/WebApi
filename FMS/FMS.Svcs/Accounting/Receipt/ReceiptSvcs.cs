using FMS.Db.Entity;
using FMS.Repo.Accounting.Receipt;
using FMS.Repo.Devloper.Branch;
using FMS.Svcs.Email;

namespace FMS.Svcs.Accounting.Receipt
{
    public class ReceiptSvcs(IReceiptRepo receiptRepo, IEmailSvcs emailSvc) : IReceiptSvcs
    {
        #region Dependancy
        private readonly IReceiptRepo _receiptRepoo = receiptRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
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
