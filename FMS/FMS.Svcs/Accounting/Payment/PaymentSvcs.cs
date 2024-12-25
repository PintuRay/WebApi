using FMS.Db.Entity;

namespace FMS.Svcs.Accounting.Payment
{
    public class PaymentSvcs: IPaymentSvcs
    {
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
    }
}
