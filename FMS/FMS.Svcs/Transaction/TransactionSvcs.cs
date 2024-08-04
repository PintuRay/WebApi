using FMS.Db.Entity;
using FMS.Model.Transaction;
using FMS.Model;
using FMS.Repo.User;
using FMS.Repo.Transaction;

namespace FMS.Svcs.Transaction
{
    public  class TransactionSvcs(ITransactionRepo transactionRepo) : ITransactionSvcs
    {
        #region Dependancy
        private readonly ITransactionRepo _transactionRepo = transactionRepo;
        #endregion
        #region Purchase
        public async Task<Base> GetLastPurchaseTransactionNo()
        { 
            throw new NotImplementedException(); 
        }
        #region Crud
        public async Task<Base> GetPurchases()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetPurchaseById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreatePurchase(PurchaseDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdatePurchase(Guid Id, PurchaseDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemovePurchase(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedPurchase()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverPurchase(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeletePurchase(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllPurchase(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllPurchase(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Purchase Return
        public async Task<Base> GetLastPurchaseReturnTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> GetPurchaseReturns()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetPurchaseReturnById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreatetPurchaseReturn(PurchaseDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdatetPurchaseReturn(Guid Id, PurchaseDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemovePurchaseReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedPurchaseReturn()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverPurchaseReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeletePurchaseReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllPurchaseReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllPurchaseReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Production
        public async Task<Base> GetLastProductionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> GetProduction()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateProduction(ProductionEntryRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateProduction(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveProduction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedProduction()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverProduction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteProduction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllProduction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllProduction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Service
        public async Task<Base> GetLastServiceNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> GetService()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateService(ProductionEntryRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateService(Guid Id, LabourOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveService(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedService()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverService(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteService(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllService(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllService(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Sales
        public async Task<Base> GetLastSalesTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> CreateSale(SalesDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetSales()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetSalesById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdatSales(Guid Id, SalesDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveSales(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedSale()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverSale(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteSale(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllSale(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllSale(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Sales Return
        public async Task<Base> GetLastSalesReturnTransactionNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> CreateSalesReturn(SalesReturnDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetSalesReturns()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetSalesReturnById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateSalesReturn(Guid Id, SalesReturnDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveSalesReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedSalesReturn()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverSalesReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteSalesReturn(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllSalesReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllSalesReturn(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Inward Supply    
        public async Task<Base> GetLastInwardSupplyNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> GetInwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetInwardSupplyById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateInwardSupply(SupplyDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateInwardSupply(Guid Id, SupplyDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveInwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedInwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverInwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteInwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllInwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllInwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Outward Supply
        public async Task<Base> GetLastOutwardSupplyNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> GetOutwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetOutwardSupplyById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateOutwardSupply(SupplyDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateOutwardSupply(Guid Id, SupplyDataRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveOutwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedOutwardSupply()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverOutwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteOutwardSupply(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllOutwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllOutwardSupply(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Damage
        public async Task<Base> GetLastDamageEntryNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Base> GetDamages()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetDamageById(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateDamage(DamageRequestData data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateDamage(Guid Id, DamageRequestData data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveDamage(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedDamage()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverDamage(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteDamage(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllDamage(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllDamage(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
