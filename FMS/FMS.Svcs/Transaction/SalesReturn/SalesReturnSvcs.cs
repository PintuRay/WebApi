using FMS.Db.Entity;
using FMS.Repo.Transaction.SalesReturn;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.SalesReturn
{
    public class SalesReturnSvcs(ISalesReturnRepo salesReturnRepo, IEmailSvcs emailSvc) : ISalesReturnSvcs
    {
        #region Dependancy
        private readonly ISalesReturnRepo _salesReturnRepo = salesReturnRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Sales Return
        //public async Task<SvcsBase> GetLastSaleReturnTransactionNo()
        //{
        //    throw new NotImplementedException();
        //}
        #region Crud
        //public async Task<SvcsBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> GetSaleReturnsTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> GetSaleReturnTransactionById(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemoveSaleReturnTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedSaleReturnTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverSaleReturnTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteSaleReturnTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllSaleReturnTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
