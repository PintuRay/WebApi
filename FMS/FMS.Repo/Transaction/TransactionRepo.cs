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
        public async Task<Result<PurchaseOrder>> GetPurchaseTransactions() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseOrder>> GetPurchaseTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseOrder>> GetRemovedPurchaseTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Purchase Return
        public async Task<RepoBase> GetLastPurchaseReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactions() { throw new NotImplementedException(); }
        public async Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<PurchaseReturnOrder>> GetRemovedPurchaseReturnTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
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
        #region Service
        public async Task<RepoBase> GetLastServiceTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<LabourOrder>> GetServiceTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateServiceTransaction(LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveServiceTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<LabourOrder>> GetRemovedServiceTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverServiceTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteServiceTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Sales
        public async Task<RepoBase> GetLastSalesTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<SalesOrder>> GetSaleTransactions() { throw new NotImplementedException(); }
        public async Task<Result<SalesOrder>> GetSaleTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateSaleTransaction(SalesOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSaleTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesOrder>> GetRemovedSaleTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSaleTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSaleTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Sales Return
        public async Task<RepoBase> GetLastSalesReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrder>> GetSaleReturnTransactions() { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrder>> GetSaleReturnTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSaleReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesReturnOrder>> GetRemovedSaleReturnTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSaleReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSaleReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSaleReturnTransaction(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Inward Supply    
        public async Task<RepoBase> GetLastInwardSupplyTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<InwardSupplyOrder>> GetInwardSupplyTransactions() { throw new NotImplementedException(); }
        public async Task<Result<InwardSupplyOrder>> GetInwardSupplyTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<InwardSupplyOrder>> GetRemovedInwardSupplyTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Outward Supply
        public async Task<RepoBase> GetLastOutwardSupplyTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactions() { throw new NotImplementedException(); }
        public async Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<OutwardSupplyOrder>> GetRemovedOutwardSupplyTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Damage
        public async Task<RepoBase> GetLastDamageEntryTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<DamageOrder>> GetDamageTransactions() { throw new NotImplementedException(); }
        public async Task<Result<DamageOrder>> GetDamageTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateDamageTransaction(DamageOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveDamageTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<DamageOrder>> GetRemovedDamageTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverDamageTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteDamageTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
