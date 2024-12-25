using FMS.Db.Entity;

namespace FMS.Svcs.Accounting.Journal
{
    public interface IJournalSvcs
    {
        #region Journal
        Task<SvcsBase> GetJournalVoucherNo();
        #region Crud
        Task<SvcsBase> CreateJournal(JournalOrderModel data, AppUser user);
        Task<SvcsBase> GetJournals();
        Task<SvcsBase> GetJournalById(Guid Id);
        Task<SvcsBase> RemoveJournal(Guid Id, AppUser user);
        #endregion
        #region Recover      
        Task<SvcsBase> GetRemovedJournal();
        Task<SvcsBase> RecoverJournal(Guid Id, AppUser user);
        Task<SvcsBase> DeleteJournal(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllJournal(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllJournal(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
