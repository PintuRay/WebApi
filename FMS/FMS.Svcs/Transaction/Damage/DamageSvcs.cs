using FMS.Db.Entity;
using FMS.Repo.Transaction.Damage;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.Damage
{
    public class DamageSvcs(IDamageRepo damageRepo, IEmailSvcs emailSvc) : IDamageSvcs
    {
        #region Dependancy
        private readonly IDamageRepo _damageRepo = damageRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Damage
        //public async Task<SvcsBase> GetLastDamageEntryTransactionNo()
        //{
        //    throw new NotImplementedException();
        //}
        #region Crud
        //public async Task<SvcsBase> GetDamagesTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> GetDamageTransactionById(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> CreateDamageTransaction(DamageOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemoveDamageTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedDamageTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverDamageTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteDamageTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
