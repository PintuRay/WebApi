using FMS.Db.Entity;

namespace FMS.Svcs.Accounting.Receipt
{
    public class ReceiptSvcs: IReceiptSvcs
    {
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
