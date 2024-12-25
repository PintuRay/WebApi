using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.InwardSupply
{
    public class InwardSupplySvcs: IInwardSupplySvcs
    {
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
