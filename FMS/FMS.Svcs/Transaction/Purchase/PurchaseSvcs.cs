using FMS.Db.Entity;
using FMS.Repo.Transaction.Purchase;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.Purchase
{
    public class PurchaseSvcs(IPurchaseRepo purchaseRepo, IEmailSvcs emailSvc) : IPurchaseSvcs
    {
        #region Dependancy
        private readonly IPurchaseRepo _purchaseRepo = purchaseRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Purchase
        public async Task<SvcsBase> GetLastPurchaseTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetPurchaseTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetPurchaseTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemovePurchaseTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedPurchaseTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverPurchaseTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeletePurchaseTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
