using FMS.Db.Entity;

namespace FMS.Svcs.User.Subledger
{
    public class SubledgerSvcs: ISubledgerSvcs
    {
        #region Subledger
        #region Crud
        public async Task<SvcsBase> GetSubLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateSubLedger(SubLedgerModel Data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSubLedger()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSubLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSubLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
