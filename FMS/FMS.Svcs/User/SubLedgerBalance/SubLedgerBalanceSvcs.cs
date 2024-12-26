using FMS.Db.Entity;
using FMS.Repo.User.SubLedgerBalance;
using FMS.Svcs.Email;

namespace FMS.Svcs.User.SubLedgerBalance
{
    public class SubLedgerBalanceSvcs(ISubLedgerBalanceRepo subLedgerBalanceRepo, IEmailSvcs emailSvc) : ISubLedgerBalanceSvcs
    {
        #region Dependancy
        private readonly ISubLedgerBalanceRepo _subLedgerBalanceRepo = subLedgerBalanceRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region SubLedger Balance
        #region Crud
        //public async Task<SvcsBase> GetSubLedgerBalances()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemoveSubLedgerBalance(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedSubLedgerBalance()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverSubLedgerBalance(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteSubLedgerBalance(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
