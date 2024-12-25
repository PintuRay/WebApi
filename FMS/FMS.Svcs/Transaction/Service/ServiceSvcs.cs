using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Service
{
    public class ServiceSvcs: IServiceSvcs
    {
        #region Service
        public async Task<SvcsBase> GetLastServiceTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetServiceTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateServiceTransaction(LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveServiceTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedServiceTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverServiceTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteServiceTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
