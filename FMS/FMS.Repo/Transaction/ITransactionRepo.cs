using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Admin;
using FMS.Model.Transaction;

namespace FMS.Repo.Transaction
{
    public interface ITransactionRepo
    {
        #region Purchase
        Task<BaseDb> GetLastPurchaseTransactionNo();
        #region Crud
        Task<Result<PurchaseOrderModel>> GetPurchases();
        Task<Result<PurchaseOrderModel>> GetPurchaseById(Guid Id);
        Task<BaseDb> CreatePurchase(PurchaseDataRequest data, AppUser user);
        Task<BaseDb> UpdatePurchase(Guid Id, PurchaseDataRequest data, AppUser user);
        Task<BaseDb> RemovePurchase(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseOrderModel>> GetRemovedPurchase();
        Task<BaseDb> RecoverPurchase(Guid Id, AppUser user);
        Task<BaseDb> DeletePurchase(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllPurchase(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllPurchase(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Purchase Return
        Task<BaseDb> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<Result<PurchaseReturnOrderModel>> GetPurchaseReturns();
        Task<Result<PurchaseReturnOrderModel>> GetPurchaseReturnById(Guid Id);
        Task<BaseDb> CreatetPurchaseReturn(PurchaseDataRequest data, AppUser user);
        Task<BaseDb> UpdatetPurchaseReturn(Guid Id, PurchaseDataRequest data, AppUser user);
        Task<BaseDb> RemovePurchaseReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseReturnOrderModel>> GetRemovedPurchaseReturn();
        Task<BaseDb> RecoverPurchaseReturn(Guid Id, AppUser user);
        Task<BaseDb> DeletePurchaseReturn(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllPurchaseReturn(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllPurchaseReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production
        Task<BaseDb> GetLastProductionNo();
        #region Crud
        Task<Result<ProductionModel>> GetProduction();
        Task<BaseDb> CreateProduction(ProductionEntryRequest data, AppUser user);
        Task<BaseDb> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user);
        Task<BaseDb> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductionModel>> GetRemovedProduction();
        Task<BaseDb> RecoverProduction(Guid Id, AppUser user);
        Task<BaseDb> DeleteProduction(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllProduction(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Service
        Task<BaseDb> GetLastServiceNo();
        #region Crud
        Task<Result<LabourOrderModel>> GetService();
        Task<BaseDb> CreateService(ProductionEntryRequest data, AppUser user);
        Task<BaseDb> UpdateService(Guid Id, LabourOrderModel data, AppUser user);
        Task<BaseDb> RemoveService(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrderModel>> GetRemovedService();
        Task<BaseDb> RecoverService(Guid Id, AppUser user);
        Task<BaseDb> DeleteService(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllService(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllService(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales
        Task<BaseDb> GetLastSalesTransactionNo();
        #region Crud
        Task<BaseDb> CreateSale(SalesDataRequest data, AppUser user);
        Task<Result<SalesOrderModel>> GetSales();
        Task<Result<SalesOrderModel>> GetSalesById(Guid Id);
        Task<BaseDb> UpdatSales(Guid Id, SalesDataRequest data, AppUser user);
        Task<BaseDb> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesOrderModel>> GetRemovedSale();
        Task<BaseDb> RecoverSale(Guid Id, AppUser user);
        Task<BaseDb> DeleteSale(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllSale(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllSale(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Return
        Task<BaseDb> GetLastSalesReturnTransactionNo();
        #region Crud
        Task<BaseDb> CreateSalesReturn(SalesReturnDataRequest data, AppUser user);
        Task<Result<SalesReturnOrderModel>> GetSalesReturns();
        Task<Result<SalesReturnOrderModel>> GetSalesReturnById(Guid Id);
        Task<BaseDb> UpdateSalesReturn(Guid Id, SalesReturnDataRequest data, AppUser user);
        Task<BaseDb> RemoveSalesReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesReturnOrderModel>> GetRemovedSalesReturn();
        Task<BaseDb> RecoverSalesReturn(Guid Id, AppUser user);
        Task<BaseDb> DeleteSalesReturn(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllSalesReturn(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllSalesReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Inward Supply    
        Task<BaseDb> GetLastInwardSupplyNo();
        #region Crud
        Task<Result<InwardSupplyOrderModel>> GetInwardSupply();
        Task<Result<InwardSupplyOrderModel>> GetInwardSupplyById(Guid Id);
        Task<BaseDb> CreateInwardSupply(SupplyDataRequest data, AppUser user);
        Task<BaseDb> UpdateInwardSupply(Guid Id, SupplyDataRequest data, AppUser user);
        Task<BaseDb> RemoveInwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<InwardSupplyOrderModel>> GetRemovedInwardSupply();
        Task<BaseDb> RecoverInwardSupply(Guid Id, AppUser user);
        Task<BaseDb> DeleteInwardSupply(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllInwardSupply(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllInwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Outward Supply
        Task<BaseDb> GetLastOutwardSupplyNo();
        #region Crud
        Task<Result<OutwardSupplyOrderModel>> GetOutwardSupply();
        Task<Result<OutwardSupplyOrderModel>> GetOutwardSupplyById(Guid Id);
        Task<BaseDb> CreateOutwardSupply(SupplyDataRequest data, AppUser user);
        Task<BaseDb> UpdateOutwardSupply(Guid Id, SupplyDataRequest data, AppUser user);
        Task<BaseDb> RemoveOutwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<OutwardSupplyOrderModel>> GetRemovedOutwardSupply();
        Task<BaseDb> RecoverOutwardSupply(Guid Id, AppUser user);
        Task<BaseDb> DeleteOutwardSupply(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllOutwardSupply(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllOutwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Damage
        Task<BaseDb> GetLastDamageEntryNo();
        #region Crud
        Task<Result<DamageOrderModel>> GetDamages();
        Task<Result<DamageOrderModel>> GetDamageById(Guid Id);
        Task<BaseDb> CreateDamage(DamageRequestData data, AppUser user);
        Task<BaseDb> UpdateDamage(Guid Id, DamageRequestData data, AppUser user);
        Task<BaseDb> RemoveDamage(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<DamageOrderModel>> GetRemovedDamage();
        Task<BaseDb> RecoverDamage(Guid Id, AppUser user);
        Task<BaseDb> DeleteDamage(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllDamage(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllDamage(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}