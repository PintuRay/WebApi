using FMS.Db.Entity;

namespace FMS.Svcs.Accounting.Payment
{
    public interface IPaymentSvcs
    {
        #region Payment
        Task<SvcsBase> GetPaymentVoucherNo(string CashBank);
        #region Crud
        Task<SvcsBase> CreatePayment(PaymentOrderModel data, AppUser user);
        Task<SvcsBase> GetPayments();
        Task<SvcsBase> GetPaymentById(Guid Id);
        Task<SvcsBase> RemovePayment(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPayment();
        Task<SvcsBase> RecoverPayment(Guid Id, AppUser user);
        Task<SvcsBase> DeletePayment(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllPayment(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPayment(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
