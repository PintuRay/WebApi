using FMS.Db.Entity;
using FMS.Repo.User.SubLedger;
using FMS.Svcs.Email;

namespace FMS.Svcs.User.Subledger
{
    public class SubledgerSvcs(ISubLedgerRepo subLedgerRepo, IEmailSvcs emailSvc) : ISubledgerSvcs
    {
        #region Dependancy
        private readonly ISubLedgerRepo _subLedgerRepo = subLedgerRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Subledger
        #region Crud
        //public async Task<SvcsBase> GetSubLedgers()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> CreateSubLedger(SubLedgerModel Data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemoveSubLedger(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedSubLedger()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverSubLedger(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteSubLedger(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllSubLedger(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllSubLedger(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
