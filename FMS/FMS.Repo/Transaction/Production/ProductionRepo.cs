using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Production
{
    public class ProductionRepo: IProductionRepo
    {
        #region Production
        public async Task<RepoBase> GetLastProductionTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<LabourOrder>> GetProductionTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateProductionTransaction(LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateProductionTransaction(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveProductionTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<LabourOrder>> GetRemovedProductionTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverProductionTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteProductionTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllProductionTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllProductionTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
