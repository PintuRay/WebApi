using FMS.Db.Entity;
using FMS.Repo.Accounting.Payment;
using FMS.Svcs.Email;

namespace FMS.Svcs.Accounting.Payment
{
    public class PaymentSvcs(IPaymentRepo paymentRepo, IEmailSvcs emailSvc) : IPaymentSvcs
    {
        #region Dependancy
        private readonly IPaymentRepo _paymentRepo = paymentRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
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
    }
}
