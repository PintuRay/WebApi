using FMS.Db.Entity;
using FMS.Repo.User.LedgerBalance;
using FMS.Svcs.Email;

namespace FMS.Svcs.User.LedgerBalance
{
    public class LedgerBalanceSvcs(ILedgerBalanceRepo ledgerBalanceRepo, IEmailSvcs emailSvc) : ILedgerBalanceSvcs
    {
        #region Dependancy
        private readonly ILedgerBalanceRepo _ledgerBalanceRepo = ledgerBalanceRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region LedgerBalance
        #region Crud
        //public async Task<SvcsBase> GetLedgerBalances()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemoveLedgerBalance(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedLedgerBalance()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverLedgerBalance(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteLedgerBalance(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
