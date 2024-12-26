using FMS.Db.Entity;
using FMS.Repo.Transaction.OutwardSupply;
using FMS.Svcs.Email;

namespace FMS.Svcs.Transaction.OutwardSupply
{
    public class OutwardSupplySvcs(IOutwardSupplyRepo outwardSupplyRepo, IEmailSvcs emailSvc) : IOutwardSupplySvcs
    {
        #region Dependancy
        private readonly IOutwardSupplyRepo _outwardSupplyRepo = outwardSupplyRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Outward Supply
        //public async Task<SvcsBase> GetLastOutwardSupplyTransactionNo()
        //{
        //    throw new NotImplementedException();
        //}
        #region Crud
        //public async Task<SvcsBase> GetOutwardSupplyTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> GetOutwardSupplyTransactionById(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedOutwardSupplyTransactions()
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<SvcsBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
