using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Production
{
    public class ProductionSvcs: IProductionSvcs
    {
        #region Production
        public async Task<SvcsBase> GetLastProductionTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetProductionTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateProductionTransaction(LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateProductionTransaction(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveProductionTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductionTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverProductionTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteProductionTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllProductionTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllProductionTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
