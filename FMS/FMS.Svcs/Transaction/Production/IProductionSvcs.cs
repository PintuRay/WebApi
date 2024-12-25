using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Production
{
    public interface IProductionSvcs
    {
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
    }
}
