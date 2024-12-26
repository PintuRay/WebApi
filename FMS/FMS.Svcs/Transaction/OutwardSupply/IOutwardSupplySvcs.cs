using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.OutwardSupply
{
    public interface IOutwardSupplySvcs
    {
        #region Outward Supply
       // Task<SvcsBase> GetLastOutwardSupplyTransactionNo();
        #region Crud
        //Task<SvcsBase> GetOutwardSupplyTransactions();
        //Task<SvcsBase> GetOutwardSupplyTransactionById(Guid Id);
        //Task<SvcsBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user);
        //Task<SvcsBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user);
        //Task<SvcsBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedOutwardSupplyTransactions();
        //Task<SvcsBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
