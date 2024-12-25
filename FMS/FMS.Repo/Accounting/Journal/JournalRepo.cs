using FMS.Db.Entity;

namespace FMS.Repo.Accounting.Journal
{
    public class JournalRepo: IJournalRepo
    {
        #region Journal
        public async Task<RepoBase> GetJournalVoucherNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateJournal(JournalOrderModel requestData) { throw new NotImplementedException(); }
        public async Task<Result<JournalOrder>> GetJournals() { throw new NotImplementedException(); }
        public async Task<RepoBase> GetJournalById(string Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveJournal(string Id) { throw new NotImplementedException(); }
        #endregion
        #region Recover      
        public async Task<Result<JournalOrder>> GetRemovedJournal() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
