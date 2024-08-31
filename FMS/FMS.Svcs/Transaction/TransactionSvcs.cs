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
        public async Task<SvcsBase> GetPurchases()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetPurchaseById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreatePurchase(PurchaseOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatePurchase(Guid Id, PurchaseOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemovePurchase(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedPurchase()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverPurchase(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeletePurchase(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllPurchase(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllPurchase(List<string> Ids, AppUser user)
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
        public async Task<SvcsBase> GetPurchaseReturns()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetPurchaseReturnById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreatetPurchaseReturn(PurchaseReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatetPurchaseReturn(Guid Id, PurchaseReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemovePurchaseReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedPurchaseReturn()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverPurchaseReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeletePurchaseReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllPurchaseReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllPurchaseReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Production
        public async Task<SvcsBase> GetLastProductionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetProduction()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateProduction(LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveProduction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProduction()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverProduction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteProduction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllProduction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllProduction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Service
        public async Task<SvcsBase> GetLastServiceNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetService()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateService(LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateService(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveService(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedService()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverService(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteService(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllService(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllService(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Sales
        public async Task<SvcsBase> GetLastSalesTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateSale(SalesOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSales()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSalesById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdatSales(Guid Id, SalesOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSales(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSale()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSale(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSale(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSale(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSale(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Sales Return
        public async Task<SvcsBase> GetLastSalesReturnTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateSalesReturn(SalesReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSalesReturns()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetSalesReturnById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateSalesReturn(Guid Id, SalesReturnOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSalesReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSalesReturn()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSalesReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSalesReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSalesReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSalesReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Inward Supply    
        public async Task<SvcsBase> GetLastInwardSupplyNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetInwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetInwardSupplyById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateInwardSupply(InwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateInwardSupply(Guid Id, InwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveInwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedInwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverInwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteInwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllInwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllInwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Outward Supply
        public async Task<SvcsBase> GetLastOutwardSupplyNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetOutwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetOutwardSupplyById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateOutwardSupply(OutwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateOutwardSupply(Guid Id, OutwardSupplyOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveOutwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedOutwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverOutwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteOutwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllOutwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllOutwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Damage
        public async Task<SvcsBase> GetLastDamageEntryNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> GetDamages()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetDamageById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateDamage(DamageOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateDamage(Guid Id, DamageOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveDamage(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedDamage()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverDamage(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteDamage(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllDamage(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllDamage(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
