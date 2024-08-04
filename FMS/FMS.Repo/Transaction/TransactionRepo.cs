using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Admin;
using FMS.Model.Transaction;

namespace FMS.Repo.Transaction
{
    public  class TransactionRepo(Context ctx, IMapper mapper) : ITransactionRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Purchase
        public async Task<BaseDb> GetLastPurchaseTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseOrderModel>> GetPurchases() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseOrderModel>> GetPurchaseById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> CreatePurchase(PurchaseDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdatePurchase(Guid Id, PurchaseDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemovePurchase(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseOrderModel>> GetRemovedPurchase() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverPurchase(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeletePurchase(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllPurchase(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllPurchase(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Purchase Return
        public async Task<BaseDb> GetLastPurchaseReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseReturnOrderModel>> GetPurchaseReturns() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseReturnOrderModel>> GetPurchaseReturnById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> CreatetPurchaseReturn(PurchaseDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdatetPurchaseReturn(Guid Id, PurchaseDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemovePurchaseReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseReturnOrderModel>> GetRemovedPurchaseReturn() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverPurchaseReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeletePurchaseReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllPurchaseReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllPurchaseReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Production
        public async Task<BaseDb> GetLastProductionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<ProductionModel>> GetProduction() { throw new NotImplementedException(); }
        public async Task<BaseDb> CreateProduction(ProductionEntryRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveProduction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<ProductionModel>> GetRemovedProduction() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverProduction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteProduction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllProduction(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllProduction(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Service
        public async Task<BaseDb> GetLastServiceNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<LabourOrderModel>> GetService() { throw new NotImplementedException(); }
        public async Task<BaseDb> CreateService(ProductionEntryRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdateService(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveService(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<LabourOrderModel>> GetRemovedService() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverService(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteService(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllService(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllService(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Sales
        public async Task<BaseDb> GetLastSalesTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<BaseDb> CreateSale(SalesDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<Result<SalesOrderModel>> GetSales() { throw new NotImplementedException(); }
        public async Task<Result<SalesOrderModel>> GetSalesById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdatSales(Guid Id, SalesDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveSales(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesOrderModel>> GetRemovedSale() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverSale(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteSale(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllSale(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllSale(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Sales Return
        public async Task<BaseDb> GetLastSalesReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<BaseDb> CreateSalesReturn(SalesReturnDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrderModel>> GetSalesReturns() { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrderModel>> GetSalesReturnById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdateSalesReturn(Guid Id, SalesReturnDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveSalesReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesReturnOrderModel>> GetRemovedSalesReturn() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverSalesReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteSalesReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllSalesReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllSalesReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Inward Supply    
        public async Task<BaseDb> GetLastInwardSupplyNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<InwardSupplyOrderModel>> GetInwardSupply() { throw new NotImplementedException(); }
        public async Task<Result<InwardSupplyOrderModel>> GetInwardSupplyById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> CreateInwardSupply(SupplyDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdateInwardSupply(Guid Id, SupplyDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveInwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<InwardSupplyOrderModel>> GetRemovedInwardSupply() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverInwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteInwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllInwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllInwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Outward Supply
        public async Task<BaseDb> GetLastOutwardSupplyNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<OutwardSupplyOrderModel>> GetOutwardSupply() { throw new NotImplementedException(); }
        public async Task<Result<OutwardSupplyOrderModel>> GetOutwardSupplyById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> CreateOutwardSupply(SupplyDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdateOutwardSupply(Guid Id, SupplyDataRequest data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveOutwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<OutwardSupplyOrderModel>> GetRemovedOutwardSupply() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverOutwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteOutwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllOutwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllOutwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Damage
        public async Task<BaseDb> GetLastDamageEntryNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<DamageOrderModel>> GetDamages() { throw new NotImplementedException(); }
        public async Task<Result<DamageOrderModel>> GetDamageById(Guid Id) { throw new NotImplementedException(); }
        public async Task<BaseDb> CreateDamage(DamageRequestData data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> UpdateDamage(Guid Id, DamageRequestData data, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RemoveDamage(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<DamageOrderModel>> GetRemovedDamage() { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverDamage(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteDamage(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> RecoverAllDamage(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<BaseDb> DeleteAllDamage(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
