using FMS.Db.Entity;

namespace FMS.Repo.Accounting.Journal
{
    public interface IJournalRepo
    {
        #region Journal
       // Task<RepoBase> GetJournalVoucherNo();
        #region Crud
        //Task<Result<JournalOrder>> GetJournals();
        //Task<RepoBase> CreateJournal(JournalOrderModel data);
        //Task<RepoBase> GetJournalById(string Id);
        //Task<RepoBase> RemoveJournal(string Id);
        #endregion
        #region Recover      
        //Task<Result<JournalOrder>> GetRemovedJournal();
        //Task<RepoBase> RecoverJournal(Guid Id, AppUser user);
        //Task<RepoBase> DeleteJournal(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllJournal(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllJournal(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
