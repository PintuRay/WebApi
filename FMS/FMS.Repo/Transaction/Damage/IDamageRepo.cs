using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Damage
{
    public interface IDamageRepo
    {
        #region Damage
        //Task<RepoBase> GetLastDamageEntryTransactionNo();
        #region Crud
        //Task<Result<DamageOrder>> GetDamageTransactions();
        //Task<Result<DamageOrder>> GetDamageTransactionById(Guid Id);
        //Task<RepoBase> CreateDamageTransaction(DamageOrderModel data, AppUser user);
        //Task<RepoBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user);
        //Task<RepoBase> RemoveDamageTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<DamageOrder>> GetRemovedDamageTransactions();
        //Task<RepoBase> RecoverDamageTransaction(Guid Id, AppUser user);
        //Task<RepoBase> DeleteDamageTransaction(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
