using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Transaction
{
    public interface ITransactionRepo
    {
        #region Purchase
        Task<RepoBase> GetLastPurchaseTransactionNo();
        #region Crud
        Task<Result<PurchaseOrder>> GetPurchaseTransactions();
        Task<Result<PurchaseOrder>> GetPurchaseTransactionById(Guid Id);
        Task<RepoBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user);
        Task<RepoBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user);
        Task<RepoBase> RemovePurchaseTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseOrder>> GetRemovedPurchaseTransactions();
        Task<RepoBase> RecoverPurchaseTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeletePurchaseTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Purchase Return
        Task<RepoBase> GetLastPurchaseReturnTransactionNo();
        #region Crud
        Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactions();
        Task<Result<PurchaseReturnOrder>> GetPurchaseReturnTransactionById(Guid Id);
        Task<RepoBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user);
        Task<RepoBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user);
        Task<RepoBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PurchaseReturnOrder>> GetRemovedPurchaseReturnTransactions();
        Task<RepoBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production
        Task<RepoBase> GetLastProductionTransactionNo();
        #region Crud
        Task<Result<LabourOrder>> GetProductionTransactions();
        Task<RepoBase> CreateProductionTransaction(LabourOrderModel data, AppUser user);
        Task<RepoBase> UpdateProductionTransaction(Guid Id, LabourOrderModel data, AppUser user);
        Task<RepoBase> RemoveProductionTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrder>> GetRemovedProductionTransactions();
        Task<RepoBase> RecoverProductionTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteProductionTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProductionTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProductionTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Service
        Task<RepoBase> GetLastServiceTransactionNo();
        #region Crud
        Task<Result<LabourOrder>> GetServiceTransactions();
        Task<RepoBase> CreateServiceTransaction(LabourOrderModel data, AppUser user);
        Task<RepoBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user);
        Task<RepoBase> RemoveServiceTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourOrder>> GetRemovedServiceTransactions();
        Task<RepoBase> RecoverServiceTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteServiceTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales
        Task<RepoBase> GetLastSalesTransactionNo();
        #region Crud
        Task<RepoBase> CreateSaleTransaction(SalesOrderModel data, AppUser user);
        Task<Result<SalesOrder>> GetSaleTransactions();
        Task<Result<SalesOrder>> GetSaleTransactionById(Guid Id);
        Task<RepoBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user);
        Task<RepoBase> RemoveSaleTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesOrder>> GetRemovedSaleTransactions();
        Task<RepoBase> RecoverSaleTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteSaleTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Return
        Task<RepoBase> GetLastSalesReturnTransactionNo();
        #region Crud
        Task<Result<SalesReturnOrder>> GetSaleReturnTransactions();
        Task<Result<SalesReturnOrder>> GetSaleReturnTransactionById(Guid Id);
        Task<RepoBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user);
        Task<RepoBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user);
        Task<RepoBase> RemoveSaleReturnTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesReturnOrder>> GetRemovedSaleReturnTransactions();
        Task<RepoBase> RecoverSaleReturnTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteSaleReturnTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSaleReturnTransaction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Inward Supply    
        Task<RepoBase> GetLastInwardSupplyTransactionNo();
        #region Crud
        Task<Result<InwardSupplyOrder>> GetInwardSupplyTransactions();
        Task<Result<InwardSupplyOrder>> GetInwardSupplyTransactionById(Guid Id);
        Task<RepoBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<InwardSupplyOrder>> GetRemovedInwardSupplyTransactions();
        Task<RepoBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Outward Supply
        Task<RepoBase> GetLastOutwardSupplyTransactionNo();
        #region Crud
        Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactions();
        Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactionById(Guid Id);
        Task<RepoBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user);
        Task<RepoBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<OutwardSupplyOrder>> GetRemovedOutwardSupplyTransactions();
        Task<RepoBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Damage
        Task<RepoBase> GetLastDamageEntryTransactionNo();
        #region Crud
        Task<Result<DamageOrder>> GetDamageTransactions();
        Task<Result<DamageOrder>> GetDamageTransactionById(Guid Id);
        Task<RepoBase> CreateDamageTransaction(DamageOrderModel data, AppUser user);
        Task<RepoBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user);
        Task<RepoBase> RemoveDamageTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<DamageOrder>> GetRemovedDamageTransactions();
        Task<RepoBase> RecoverDamageTransaction(Guid Id, AppUser user);
        Task<RepoBase> DeleteDamageTransaction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
