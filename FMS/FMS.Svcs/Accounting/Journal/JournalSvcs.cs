using FMS.Db.Entity;
using FMS.Repo.Accounting.Journal;
using FMS.Svcs.Email;

namespace FMS.Svcs.Accounting.Journal
{
    public class JournalSvcs(IJournalRepo journalRepo, IEmailSvcs emailSvc) : IJournalSvcs
    {
        #region Dependancy
        private readonly IJournalRepo _journalRepo = journalRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Journal
        //public async Task<SvcsBase> GetJournalVoucherNo(){ throw new NotImplementedException(); }
        #region Crud
        //public async Task<SvcsBase> CreateJournal(JournalOrderModel requestData, AppUser user) { throw new NotImplementedException(); }
        //public async Task<SvcsBase> GetJournals() { throw new NotImplementedException(); }
        //public async Task<SvcsBase> GetJournalById(Guid Id) { throw new NotImplementedException(); }
        //public async Task<SvcsBase> RemoveJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover      
        //public async Task<SvcsBase> GetRemovedJournal() { throw new NotImplementedException(); }
        //public async Task<SvcsBase> RecoverJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<SvcsBase> DeleteJournal(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<SvcsBase> RecoverAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        //public async Task<SvcsBase> DeleteAllJournal(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
