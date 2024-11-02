using FMS.Db.Entity;
using FMS.Repo.Transaction;

namespace FMS.Svcs.Transaction
{
    public  class TransactionSvcs(ITransactionRepo transactionRepo) : ITransactionSvcs
    {
        #region Dependancy
        private readonly ITransactionRepo _transactionRepo = transactionRepo;
        #endregion
        #region Purchase
        public async Task<SvcsBase> GetLastPurchaseTransactionNo()
        { 
            throw new NotImplementedException(); 
        }
        #region Crud
        public async Task<SvcsBase> GetPurchaseTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetPurchaseTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemovePurchaseTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedPurchaseTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverPurchaseTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeletePurchaseTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Purchase Return
        public async Task<SvcsBase> GetLastPurchaseReturnTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetPurchaseReturnTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetPurchaseReturnTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreatetPurchaseReturnTransaction(PurchaseReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatetPurchaseReturnTransaction(Guid Id, PurchaseReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemovePurchaseReturnTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedPurchaseReturnTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverPurchaseReturnTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeletePurchaseReturnTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllPurchaseReturnTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllPurchaseReturnTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Production
        public async Task<SvcsBase> GetLastProductionTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetProductionTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateProductionTransaction(LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateProductionTransaction(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveProductionTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductionTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverProductionTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteProductionTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllProductionTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllProductionTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Service
        public async Task<SvcsBase> GetLastServiceTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetServiceTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateServiceTransaction(LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveServiceTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedServiceTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverServiceTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteServiceTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Sales
        public async Task<SvcsBase> GetLastSaleTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateSaleTransaction(SalesOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSaleTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSaleTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatSaleTransaction(Guid Id, SalesOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSaleTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSaleTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSaleTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSaleTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSaleTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSaleTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Sales Return
        public async Task<SvcsBase> GetLastSaleReturnTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSaleReturnsTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSaleReturnTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSaleReturnTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSaleReturnTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSaleReturnTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSaleReturnTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSaleReturnTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Inward Supply    
        public async Task<SvcsBase> GetLastInwardSupplyTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetInwardSupplyTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetInwardSupplyTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedInwardSupplyTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Outward Supply
        public async Task<SvcsBase> GetLastOutwardSupplyTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetOutwardSupplyTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetOutwardSupplyTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedOutwardSupplyTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Damage
        public async Task<SvcsBase> GetLastDamageEntryTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetDamagesTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetDamageTransactionById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateDamageTransaction(DamageOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveDamageTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedDamageTransactions()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverDamageTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteDamageTransaction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
