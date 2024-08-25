using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Transaction
{
    public  class TransactionRepo(Context ctx, IMapper mapper) : ITransactionRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Purchase
        public async Task<RepoBase> GetLastPurchaseTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseOrder>> GetPurchases() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseOrder>> GetPurchaseById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreatePurchase(PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatePurchase(Guid Id, PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePurchase(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseOrder>> GetRemovedPurchase() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPurchase(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePurchase(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPurchase(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPurchase(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Purchase Return
        public async Task<RepoBase> GetLastPurchaseReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseReturnOrder>> GetPurchaseReturns() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseReturnOrder>> GetPurchaseReturnById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreatetPurchaseReturn(PurchaseReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatetPurchaseReturn(Guid Id, PurchaseReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePurchaseReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseReturnOrder>> GetRemovedPurchaseReturn() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPurchaseReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePurchaseReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPurchaseReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPurchaseReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Production
        public async Task<RepoBase> GetLastProductionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<LabourOrder>> GetProduction() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateProduction(LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveProduction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<LabourOrder>> GetRemovedProduction() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverProduction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteProduction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllProduction(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllProduction(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Service
        public async Task<RepoBase> GetLastServiceNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<LabourOrder>> GetService() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateService(LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateService(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveService(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<LabourOrder>> GetRemovedService() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverService(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteService(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllService(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllService(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Sales
        public async Task<RepoBase> GetLastSalesTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<SalesOrder>> GetSales() { throw new NotImplementedException(); }
        public async Task<Result<SalesOrder>> GetSalesById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateSale(SalesOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatSales(Guid Id, SalesOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSales(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesOrder>> GetRemovedSale() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSale(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSale(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSale(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSale(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Sales Return
        public async Task<RepoBase> GetLastSalesReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateSalesReturn(SalesReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrder>> GetSalesReturns() { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrder>> GetSalesReturnById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateSalesReturn(Guid Id, SalesReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSalesReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesReturnOrder>> GetRemovedSalesReturn() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSalesReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSalesReturn(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSalesReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSalesReturn(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Inward Supply    
        public async Task<RepoBase> GetLastInwardSupplyNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<InwardSupplyOrder>> GetInwardSupply() { throw new NotImplementedException(); }
        public async Task<Result<InwardSupplyOrder>> GetInwardSupplyById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateInwardSupply(InwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateInwardSupply(Guid Id, InwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveInwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<InwardSupplyOrder>> GetRemovedInwardSupply() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverInwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteInwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllInwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllInwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Outward Supply
        public async Task<RepoBase> GetLastOutwardSupplyNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<OutwardSupplyOrder>> GetOutwardSupply() { throw new NotImplementedException(); }
        public async Task<Result<OutwardSupplyOrder>> GetOutwardSupplyById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateOutwardSupply(OutwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateOutwardSupply(Guid Id, OutwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveOutwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<OutwardSupplyOrder>> GetRemovedOutwardSupply() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverOutwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteOutwardSupply(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllOutwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllOutwardSupply(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Damage
        public async Task<RepoBase> GetLastDamageEntryNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<DamageOrder>> GetDamages() { throw new NotImplementedException(); }
        public async Task<Result<DamageOrder>> GetDamageById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateDamage(DamageOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateDamage(Guid Id, DamageOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveDamage(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<DamageOrder>> GetRemovedDamage() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverDamage(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteDamage(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllDamage(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllDamage(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
