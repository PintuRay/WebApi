using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Transaction
{
    public interface ITransactionRepo
    {
        #region Purchase
        Task<RepoBase> GetLastPurchaseTransactionNo();
        #region Crud
        Task<Result<PurchaseOrder>> GetPurchases();
        Task<Result<PurchaseOrder>> GetPurchaseById(Guid Id);
        Task<RepoBase> CreatePurchase(PurchaseOrderModel data, AppUser user);
        Task<RepoBase> UpdatePurchase(Guid Id, PurchaseOrderModel data, AppUser user);
        Task<RepoBase> RemovePurchase(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseOrder>> GetRemovedPurchase();
        Task<RepoBase> RecoverPurchase(Guid Id, AppUser user);
        Task<RepoBase> DeletePurchase(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllPurchase(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllPurchase(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Purchase Return
        Task<RepoBase> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<Result<PurchaseReturnOrder>> GetPurchaseReturns();
        Task<Result<PurchaseReturnOrder>> GetPurchaseReturnById(Guid Id);
        Task<RepoBase> CreatetPurchaseReturn(PurchaseReturnOrderModel data, AppUser user);
        Task<RepoBase> UpdatetPurchaseReturn(Guid Id, PurchaseReturnOrderModel data, AppUser user);
        Task<RepoBase> RemovePurchaseReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseReturnOrder>> GetRemovedPurchaseReturn();
        Task<RepoBase> RecoverPurchaseReturn(Guid Id, AppUser user);
        Task<RepoBase> DeletePurchaseReturn(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllPurchaseReturn(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllPurchaseReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production
        Task<RepoBase> GetLastProductionNo();
        #region Crud
        Task<Result<LabourOrder>> GetProduction();
        Task<RepoBase> CreateProduction(LabourOrderModel data, AppUser user);
        Task<RepoBase> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user);
        Task<RepoBase> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrder>> GetRemovedProduction();
        Task<RepoBase> RecoverProduction(Guid Id, AppUser user);
        Task<RepoBase> DeleteProduction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProduction(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Service
        Task<RepoBase> GetLastServiceNo();
        #region Crud
        Task<Result<LabourOrder>> GetService();
        Task<RepoBase> CreateService(LabourOrderModel data, AppUser user);
        Task<RepoBase> UpdateService(Guid Id, LabourOrderModel data, AppUser user);
        Task<RepoBase> RemoveService(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrder>> GetRemovedService();
        Task<RepoBase> RecoverService(Guid Id, AppUser user);
        Task<RepoBase> DeleteService(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllService(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllService(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales
        Task<RepoBase> GetLastSalesTransactionNo();
        #region Crud
        Task<RepoBase> CreateSale(SalesOrderModel data, AppUser user);
        Task<Result<SalesOrder>> GetSales();
        Task<Result<SalesOrder>> GetSalesById(Guid Id);
        Task<RepoBase> UpdatSales(Guid Id, SalesOrderModel data, AppUser user);
        Task<RepoBase> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesOrder>> GetRemovedSale();
        Task<RepoBase> RecoverSale(Guid Id, AppUser user);
        Task<RepoBase> DeleteSale(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSale(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSale(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Return
        Task<RepoBase> GetLastSalesReturnTransactionNo();
        #region Crud
        Task<Result<SalesReturnOrder>> GetSalesReturns();
        Task<Result<SalesReturnOrder>> GetSalesReturnById(Guid Id);
        Task<RepoBase> CreateSalesReturn(SalesReturnOrderModel data, AppUser user);
        Task<RepoBase> UpdateSalesReturn(Guid Id, SalesReturnOrderModel data, AppUser user);
        Task<RepoBase> RemoveSalesReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesReturnOrder>> GetRemovedSalesReturn();
        Task<RepoBase> RecoverSalesReturn(Guid Id, AppUser user);
        Task<RepoBase> DeleteSalesReturn(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSalesReturn(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSalesReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Inward Supply    
        Task<RepoBase> GetLastInwardSupplyNo();
        #region Crud
        Task<Result<InwardSupplyOrder>> GetInwardSupply();
        Task<Result<InwardSupplyOrder>> GetInwardSupplyById(Guid Id);
        Task<RepoBase> CreateInwardSupply(InwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> UpdateInwardSupply(Guid Id, InwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> RemoveInwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<InwardSupplyOrder>> GetRemovedInwardSupply();
        Task<RepoBase> RecoverInwardSupply(Guid Id, AppUser user);
        Task<RepoBase> DeleteInwardSupply(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllInwardSupply(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllInwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Outward Supply
        Task<RepoBase> GetLastOutwardSupplyNo();
        #region Crud
        Task<Result<OutwardSupplyOrder>> GetOutwardSupply();
        Task<Result<OutwardSupplyOrder>> GetOutwardSupplyById(Guid Id);
        Task<RepoBase> CreateOutwardSupply(OutwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> UpdateOutwardSupply(Guid Id, OutwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> RemoveOutwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<OutwardSupplyOrder>> GetRemovedOutwardSupply();
        Task<RepoBase> RecoverOutwardSupply(Guid Id, AppUser user);
        Task<RepoBase> DeleteOutwardSupply(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllOutwardSupply(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllOutwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Damage
        Task<RepoBase> GetLastDamageEntryNo();
        #region Crud
        Task<Result<DamageOrder>> GetDamages();
        Task<Result<DamageOrder>> GetDamageById(Guid Id);
        Task<RepoBase> CreateDamage(DamageOrderModel data, AppUser user);
        Task<RepoBase> UpdateDamage(Guid Id, DamageOrderModel data, AppUser user);
        Task<RepoBase> RemoveDamage(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<DamageOrder>> GetRemovedDamage();
        Task<RepoBase> RecoverDamage(Guid Id, AppUser user);
        Task<RepoBase> DeleteDamage(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllDamage(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllDamage(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
