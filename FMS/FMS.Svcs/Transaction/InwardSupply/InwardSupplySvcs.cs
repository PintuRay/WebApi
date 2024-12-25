using FMS.Db.Entity;
using FMS.Repo.Transaction.InwardSupply;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.InwardSupply
{
    public class InwardSupplySvcs(IInwardSupplyRepo inwardSupplyRepo, IEmailSvcs emailSvc) : IInwardSupplySvcs
    {
        #region Dependancy
        private readonly IInwardSupplyRepo _inwardSupplyRepo = inwardSupplyRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Inward Supply    
        public async Task<SvcsBase> GetLastInwardSupplyTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetInwardSupplyTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetInwardSupplyTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedInwardSupplyTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
