using FMS.Db.Entity;

namespace FMS.Svcs.Accounting.Journal
{
    public class JournalSvcs: IJournalSvcs
    {
        #region Journal
        public async Task<SvcsBase> GetJournalVoucherNo()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<SvcsBase> CreateJournal(JournalOrderModel requestData, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetJournals() { throw new NotImplementedException(); }
        public async Task<SvcsBase> GetJournalById(Guid Id) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RemoveJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover      
        public async Task<SvcsBase> GetRemovedJournal() { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> RecoverAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<SvcsBase> DeleteAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
