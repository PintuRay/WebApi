using FMS.Db.Entity;

namespace FMS.Repo.User.SubLedger
{
    public class SubLedgerRepo: ISubLedgerRepo
    {
        #region Subledger
        #region Crud
        public async Task<Result<Db.Entity.SubLedger>> GetSubLedgers() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateSubLedger(SubLedgerModel Data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSubLedger(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.SubLedger>> GetRemovedSubLedger() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSubLedger(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSubLedger(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSubLedger(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSubLedger(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
