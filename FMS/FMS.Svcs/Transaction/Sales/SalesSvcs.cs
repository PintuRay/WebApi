using FMS.Db.Entity;
using FMS.Repo.Transaction.Sales;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.Sales
{
    public class SalesSvcs(ISalesRepo salesRepo, IEmailSvcs emailSvc) : ISalesSvcs
    {
        #region Dependancy
        private readonly ISalesRepo _salesRepo = salesRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Sales
        public async Task<SvcsBase> GetLastSaleTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateSaleTransaction(SalesOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSaleTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSaleTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSaleTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSaleTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSaleTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSaleTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
