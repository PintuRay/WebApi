using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.InwardSupply
{
    public interface IInwardSupplySvcs
    {
        #region Inward Supply    
       // Task<SvcsBase> GetLastInwardSupplyTransactionNo();
        #region Crud
        //Task<SvcsBase> GetInwardSupplyTransactions();
        //Task<SvcsBase> GetInwardSupplyTransactionById(Guid Id);
        //Task<SvcsBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user);
        //Task<SvcsBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user);
        //Task<SvcsBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedInwardSupplyTransactions();
        //Task<SvcsBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
