using FMS.Db.Entity;

namespace FMS.Repo.Transaction.InwardSupply
{
    public interface IInwardSupplyRepo
    {
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
    }
}
