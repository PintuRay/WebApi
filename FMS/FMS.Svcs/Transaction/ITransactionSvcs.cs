using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Admin;
using FMS.Model.Transaction;
using FMS.Model.User;

namespace FMS.Svcs.Transaction
{
    public interface ITransactionSvcs
    {
        #region Purchase
        Task<Base> GetLastPurchaseTransactionNo();
        #region Crud
        Task<Base> GetPurchases();
        Task<Base> GetPurchaseById(Guid Id);
        Task<Base> CreatePurchase(PurchaseDataRequest data, AppUser user);
        Task<Base> UpdatePurchase(Guid Id, PurchaseDataRequest data, AppUser user);
        Task<Base> RemovePurchase(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedPurchase();
        Task<Base> RecoverPurchase(Guid Id, AppUser user);
        Task<Base> DeletePurchase(Guid Id, AppUser user);
       Task<Base> RecoverAllPurchase(List<string> Ids, AppUser user);
        Task<Base> DeleteAllPurchase(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Purchase Return
        Task<Base> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<Base> GetPurchaseReturns();
        Task<Base> GetPurchaseReturnById(Guid Id);
        Task<Base> CreatetPurchaseReturn(PurchaseDataRequest data, AppUser user);
        Task<Base> UpdatetPurchaseReturn(Guid Id, PurchaseDataRequest data, AppUser user);
        Task<Base> RemovePurchaseReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedPurchaseReturn();
        Task<Base> RecoverPurchaseReturn(Guid Id, AppUser user);
        Task<Base> DeletePurchaseReturn(Guid Id, AppUser user);
        Task<Base> RecoverAllPurchaseReturn(List<string> Ids, AppUser user);
        Task<Base> DeleteAllPurchaseReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production
        Task<Base> GetLastProductionNo();
        #region Crud
        Task<Base> GetProduction();
        Task<Base> CreateProduction(ProductionEntryRequest data, AppUser user);
        Task<Base> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user);
        Task<Base> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedProduction();
        Task<Base> RecoverProduction(Guid Id, AppUser user);
        Task<Base> DeleteProduction(Guid Id, AppUser user);
        Task<Base> RecoverAllProduction(List<string> Ids, AppUser user);
        Task<Base> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Service
        Task<Base> GetLastServiceNo();
        #region Crud
        Task<Base> GetService();
        Task<Base> CreateService(ProductionEntryRequest data, AppUser user);
        Task<Base> UpdateService(Guid Id, LabourOrderModel data, AppUser user);
        Task<Base> RemoveService(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedService();
        Task<Base> RecoverService(Guid Id, AppUser user);
        Task<Base> DeleteService(Guid Id, AppUser user);
        Task<Base> RecoverAllService(List<string> Ids, AppUser user);
        Task<Base> DeleteAllService(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales
        Task<Base> GetLastSalesTransactionNo();
        #region Crud
        Task<Base> CreateSale(SalesDataRequest data, AppUser user);
        Task<Base> GetSales();
        Task<Base> GetSalesById(Guid Id);
        Task<Base> UpdatSales(Guid Id, SalesDataRequest data, AppUser user);
        Task<Base> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedSale();
        Task<Base> RecoverSale(Guid Id, AppUser user);
        Task<Base> DeleteSale(Guid Id, AppUser user);
        Task<Base> RecoverAllSale(List<string> Ids, AppUser user);
        Task<Base> DeleteAllSale(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Return
        Task<Base> GetLastSalesReturnTransactionNo();
        #region Crud
        Task<Base> CreateSalesReturn(SalesReturnDataRequest data, AppUser user);
        Task<Base> GetSalesReturns();
        Task<Base> GetSalesReturnById(Guid Id);
        Task<Base> UpdateSalesReturn(Guid Id, SalesReturnDataRequest data, AppUser user);
        Task<Base> RemoveSalesReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedSalesReturn();
        Task<Base> RecoverSalesReturn(Guid Id, AppUser user);
        Task<Base> DeleteSalesReturn(Guid Id, AppUser user);
        Task<Base> RecoverAllSalesReturn(List<string> Ids, AppUser user);
        Task<Base> DeleteAllSalesReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Inward Supply    
        Task<Base> GetLastInwardSupplyNo();
        #region Crud
        Task<Base> GetInwardSupply();
        Task<Base> GetInwardSupplyById(Guid Id);
        Task<Base> CreateInwardSupply(SupplyDataRequest data, AppUser user);
        Task<Base> UpdateInwardSupply(Guid Id, SupplyDataRequest data, AppUser user);
        Task<Base> RemoveInwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedInwardSupply();
        Task<Base> RecoverInwardSupply(Guid Id, AppUser user);
        Task<Base> DeleteInwardSupply(Guid Id, AppUser user);
        Task<Base> RecoverAllInwardSupply(List<string> Ids, AppUser user);
        Task<Base> DeleteAllInwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Outward Supply
        Task<Base> GetLastOutwardSupplyNo();
        #region Crud
        Task<Base> GetOutwardSupply();
        Task<Base> GetOutwardSupplyById(Guid Id);
        Task<Base> CreateOutwardSupply(SupplyDataRequest data, AppUser user);
        Task<Base> UpdateOutwardSupply(Guid Id, SupplyDataRequest data, AppUser user);
        Task<Base> RemoveOutwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedOutwardSupply();
        Task<Base> RecoverOutwardSupply(Guid Id, AppUser user);
        Task<Base> DeleteOutwardSupply(Guid Id, AppUser user);
        Task<Base> RecoverAllOutwardSupply(List<string> Ids, AppUser user);
        Task<Base> DeleteAllOutwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Damage
        Task<Base> GetLastDamageEntryNo();
        #region Crud
        Task<Base> GetDamages();
        Task<Base> GetDamageById(Guid Id);
        Task<Base> CreateDamage(DamageRequestData data, AppUser user);
        Task<Base> UpdateDamage(Guid Id, DamageRequestData data, AppUser user);
        Task<Base> RemoveDamage(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedDamage();
        Task<Base> RecoverDamage(Guid Id, AppUser user);
        Task<Base> DeleteDamage(Guid Id, AppUser user);
        Task<Base> RecoverAllDamage(List<string> Ids, AppUser user);
        Task<Base> DeleteAllDamage(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
