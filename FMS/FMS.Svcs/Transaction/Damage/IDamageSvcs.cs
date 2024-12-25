using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Damage
{
    public interface IDamageSvcs
    {
        #region Damage
        Task<SvcsBase> GetLastDamageEntryTransactionNo();
        #region Crud
        Task<SvcsBase> GetDamagesTransactions();
        Task<SvcsBase> GetDamageTransactionById(Guid Id);
        Task<SvcsBase> CreateDamageTransaction(DamageOrderModel data, AppUser user);
        Task<SvcsBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user);
        Task<SvcsBase> RemoveDamageTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedDamageTransactions();
        Task<SvcsBase> RecoverDamageTransaction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteDamageTransaction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
