using FMS.Db.Entity;

namespace FMS.Svcs.Transaction
{
    public interface ITransactionSvcs
    {
        #region Purchase
        Task<SvcsBase> GetLastPurchaseTransactionNo();
        #region Crud
        Task<SvcsBase> GetPurchaseTransactions();
        Task<SvcsBase> GetPurchaseTransactionById(Guid Id);
        Task<SvcsBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user);
        Task<SvcsBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user);
        Task<SvcsBase> RemovePurchaseTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPurchaseTransactions();
        Task<SvcsBase> RecoverPurchaseTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeletePurchaseTransaction(Guid Id, AppUser user);
       Task<SvcsBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Purchase Return
        Task<SvcsBase> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<SvcsBase> GetPurchaseReturnTransactions();
        Task<SvcsBase> GetPurchaseReturnTransactionById(Guid Id);
        Task<SvcsBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user);
        Task<SvcsBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user);
        Task<SvcsBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedPurchaseReturnTransactions();
        Task<SvcsBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production
        Task<SvcsBase> GetLastProductionTransactionNo();
        #region Crud
        Task<SvcsBase> GetProductionTransactions();
        Task<SvcsBase> CreateProductionTransaction(LabourOrderModel data, AppUser user);
        Task<SvcsBase> UpdateProductionTransaction(Guid Id, LabourOrderModel data, AppUser user);
        Task<SvcsBase> RemoveProductionTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedProductionTransactions();
        Task<SvcsBase> RecoverProductionTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteProductionTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllProductionTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllProductionTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Service
        Task<SvcsBase> GetLastServiceTransactionNo();
        #region Crud
        Task<SvcsBase> GetServiceTransactions();
        Task<SvcsBase> CreateServiceTransaction(LabourOrderModel data, AppUser user);
        Task<SvcsBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user);
        Task<SvcsBase> RemoveServiceTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedServiceTransactions();
        Task<SvcsBase> RecoverServiceTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteServiceTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales
        Task<SvcsBase> GetLastSaleTransactionNo();
        #region Crud
        Task<SvcsBase> CreateSaleTransaction(SalesOrderModel data, AppUser user);
        Task<SvcsBase> GetSaleTransactions();
        Task<SvcsBase> GetSaleTransactionById(Guid Id);
        Task<SvcsBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user);
        Task<SvcsBase> RemoveSaleTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSaleTransactions();
        Task<SvcsBase> RecoverSaleTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSaleTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Return
        Task<SvcsBase> GetLastSaleReturnTransactionNo();
        #region Crud
        Task<SvcsBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user);
        Task<SvcsBase> GetSaleReturnsTransactions();
        Task<SvcsBase> GetSaleReturnTransactionById(Guid Id);
        Task<SvcsBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user);
        Task<SvcsBase> RemoveSaleReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSaleReturnTransactions();
        Task<SvcsBase> RecoverSaleReturnTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSaleReturnTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSaleReturnTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Inward Supply    
        Task<SvcsBase> GetLastInwardSupplyTransactionNo();
        #region Crud
        Task<SvcsBase> GetInwardSupplyTransactions();
        Task<SvcsBase> GetInwardSupplyTransactionById(Guid Id);
        Task<SvcsBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user);
        Task<SvcsBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user);
        Task<SvcsBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedInwardSupplyTransactions();
        Task<SvcsBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Outward Supply
        Task<SvcsBase> GetLastOutwardSupplyTransactionNo();
        #region Crud
        Task<SvcsBase> GetOutwardSupplyTransactions();
        Task<SvcsBase> GetOutwardSupplyTransactionById(Guid Id);
        Task<SvcsBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user);
        Task<SvcsBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user);
        Task<SvcsBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedOutwardSupplyTransactions();
        Task<SvcsBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Damage
        Task<SvcsBase> GetLastDamageEntryTransactionNo();
        #region Crud
        Task<SvcsBase> GetDamagesTransactions();
        Task<SvcsBase> GetDamageTransactionById(Guid Id);
        Task<SvcsBase> CreateDamageTransaction(DamageOrderModel data, AppUser user);
        Task<SvcsBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user);
        Task<SvcsBase> RemoveDamageTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedDamageTransactions();
        Task<SvcsBase> RecoverDamageTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteDamageTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
