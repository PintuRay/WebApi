﻿using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Damage
{
    public class DamageRepo: IDamageRepo
    {
        #region Damage
        public async Task<RepoBase> GetLastDamageEntryTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<DamageOrder>> GetDamageTransactions() { throw new NotImplementedException(); }
        public async Task<Result<DamageOrder>> GetDamageTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateDamageTransaction(DamageOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateDamageTransaction(Guid Id, DamageOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveDamageTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<DamageOrder>> GetRemovedDamageTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverDamageTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteDamageTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllDamageTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllDamageTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
