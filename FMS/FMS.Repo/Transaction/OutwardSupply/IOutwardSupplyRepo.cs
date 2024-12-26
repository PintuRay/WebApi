using FMS.Db.Entity;

namespace FMS.Repo.Transaction.OutwardSupply
{
    public interface IOutwardSupplyRepo
    {
        #region Outward Supply
        //Task<RepoBase> GetLastOutwardSupplyTransactionNo();
        #region Crud
        //Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactions();
        //Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactionById(Guid Id);
        //Task<RepoBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user);
        //Task<RepoBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user);
        //Task<RepoBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<OutwardSupplyOrder>> GetRemovedOutwardSupplyTransactions();
        //Task<RepoBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user);
        //Task<RepoBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
