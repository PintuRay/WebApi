using FMS.Db.Entity;
using FMS.Repo.Transaction.PurchaseReturn;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.PurchaseReturn
{
    public class PurchaseReturnSvcs(IPurchaseReturnRepo purchaseReturnRepo, IEmailSvcs emailSvc) : IPurchaseReturnSvcs
    {
        #region Dependancy
        private readonly IPurchaseReturnRepo _purchaseReturnRepo = purchaseReturnRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Purchase Return
        //public async Task<SvcsBase> GetLastPurchaseReturnTransactionNo()
        //{
        //    throw new NotImplementedException();
        //}
        #region Crud
        //public async Task<SvcsBase> GetPurchaseReturnTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> GetPurchaseReturnTransactionById(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedPurchaseReturnTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
