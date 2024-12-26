using FMS.Db.Entity;

namespace FMS.Repo.Accounting.Payment
{
    public interface IPaymentRepo
    {
        #region Payment
       // Task<RepoBase> GetPaymentVoucherNo(string CashBank);
        #region Crud
        //Task<RepoBase> CreatePayment(PaymentOrderModel data);
        //Task<Result<PaymentOrder>> GetPayments();
        //Task<RepoBase> GetPaymentById(string Id);
        //Task<RepoBase> RemovePayment(string Id);
        #endregion
        #region Recover
        //Task<Result<PaymentOrder>> GetRemovedPayment();
        //Task<RepoBase> RecoverPayment(Guid Id, AppUser user);
        //Task<RepoBase> DeletePayment(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllPayment(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllPayment(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
