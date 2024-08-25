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
        Task<SvcsBase> GetLastPurchaseTransactionNo();
        #region Crud
        Task<SvcsBase> GetPurchases();
        Task<SvcsBase> GetPurchaseById(Guid Id);
        Task<SvcsBase> CreatePurchase(PurchaseDataRequest data, AppUser user);
        Task<SvcsBase> UpdatePurchase(Guid Id, PurchaseDataRequest data, AppUser user);
        Task<SvcsBase> RemovePurchase(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPurchase();
        Task<SvcsBase> RecoverPurchase(Guid Id, AppUser user);
        Task<SvcsBase> DeletePurchase(Guid Id, AppUser user);
       Task<SvcsBase> RecoverAllPurchase(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPurchase(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Purchase Return
        Task<SvcsBase> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<SvcsBase> GetPurchaseReturns();
        Task<SvcsBase> GetPurchaseReturnById(Guid Id);
        Task<SvcsBase> CreatetPurchaseReturn(PurchaseDataRequest data, AppUser user);
        Task<SvcsBase> UpdatetPurchaseReturn(Guid Id, PurchaseDataRequest data, AppUser user);
        Task<SvcsBase> RemovePurchaseReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPurchaseReturn();
        Task<SvcsBase> RecoverPurchaseReturn(Guid Id, AppUser user);
        Task<SvcsBase> DeletePurchaseReturn(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllPurchaseReturn(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPurchaseReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production
        Task<SvcsBase> GetLastProductionNo();
        #region Crud
        Task<SvcsBase> GetProduction();
        Task<SvcsBase> CreateProduction(ProductionEntryRequest data, AppUser user);
        Task<SvcsBase> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user);
        Task<SvcsBase> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedProduction();
        Task<SvcsBase> RecoverProduction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteProduction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllProduction(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Service
        Task<SvcsBase> GetLastServiceNo();
        #region Crud
        Task<SvcsBase> GetService();
        Task<SvcsBase> CreateService(ProductionEntryRequest data, AppUser user);
        Task<SvcsBase> UpdateService(Guid Id, LabourOrderModel data, AppUser user);
        Task<SvcsBase> RemoveService(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedService();
        Task<SvcsBase> RecoverService(Guid Id, AppUser user);
        Task<SvcsBase> DeleteService(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllService(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllService(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales
        Task<SvcsBase> GetLastSalesTransactionNo();
        #region Crud
        Task<SvcsBase> CreateSale(SalesDataRequest data, AppUser user);
        Task<SvcsBase> GetSales();
        Task<SvcsBase> GetSalesById(Guid Id);
        Task<SvcsBase> UpdatSales(Guid Id, SalesDataRequest data, AppUser user);
        Task<SvcsBase> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSale();
        Task<SvcsBase> RecoverSale(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSale(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSale(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSale(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Return
        Task<SvcsBase> GetLastSalesReturnTransactionNo();
        #region Crud
        Task<SvcsBase> CreateSalesReturn(SalesReturnDataRequest data, AppUser user);
        Task<SvcsBase> GetSalesReturns();
        Task<SvcsBase> GetSalesReturnById(Guid Id);
        Task<SvcsBase> UpdateSalesReturn(Guid Id, SalesReturnDataRequest data, AppUser user);
        Task<SvcsBase> RemoveSalesReturn(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSalesReturn();
        Task<SvcsBase> RecoverSalesReturn(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSalesReturn(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSalesReturn(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSalesReturn(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Inward Supply    
        Task<SvcsBase> GetLastInwardSupplyNo();
        #region Crud
        Task<SvcsBase> GetInwardSupply();
        Task<SvcsBase> GetInwardSupplyById(Guid Id);
        Task<SvcsBase> CreateInwardSupply(SupplyDataRequest data, AppUser user);
        Task<SvcsBase> UpdateInwardSupply(Guid Id, SupplyDataRequest data, AppUser user);
        Task<SvcsBase> RemoveInwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedInwardSupply();
        Task<SvcsBase> RecoverInwardSupply(Guid Id, AppUser user);
        Task<SvcsBase> DeleteInwardSupply(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllInwardSupply(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllInwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Outward Supply
        Task<SvcsBase> GetLastOutwardSupplyNo();
        #region Crud
        Task<SvcsBase> GetOutwardSupply();
        Task<SvcsBase> GetOutwardSupplyById(Guid Id);
        Task<SvcsBase> CreateOutwardSupply(SupplyDataRequest data, AppUser user);
        Task<SvcsBase> UpdateOutwardSupply(Guid Id, SupplyDataRequest data, AppUser user);
        Task<SvcsBase> RemoveOutwardSupply(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedOutwardSupply();
        Task<SvcsBase> RecoverOutwardSupply(Guid Id, AppUser user);
        Task<SvcsBase> DeleteOutwardSupply(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllOutwardSupply(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllOutwardSupply(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Damage
        Task<SvcsBase> GetLastDamageEntryNo();
        #region Crud
        Task<SvcsBase> GetDamages();
        Task<SvcsBase> GetDamageById(Guid Id);
        Task<SvcsBase> CreateDamage(DamageRequestData data, AppUser user);
        Task<SvcsBase> UpdateDamage(Guid Id, DamageRequestData data, AppUser user);
        Task<SvcsBase> RemoveDamage(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedDamage();
        Task<SvcsBase> RecoverDamage(Guid Id, AppUser user);
        Task<SvcsBase> DeleteDamage(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllDamage(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllDamage(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
