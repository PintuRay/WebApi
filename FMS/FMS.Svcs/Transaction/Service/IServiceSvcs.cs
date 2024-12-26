using FMS.Db.Entity;

namespace FMS.Svcs.Transaction.Service
{
    public interface IServiceSvcs
    {
        #region Service
       // Task<SvcsBase> GetLastServiceTransactionNo();
        #region Crud
        //Task<SvcsBase> GetServiceTransactions();
        //Task<SvcsBase> CreateServiceTransaction(LabourOrderModel data, AppUser user);
        //Task<SvcsBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user);
        //Task<SvcsBase> RemoveServiceTransaction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedServiceTransactions();
        //Task<SvcsBase> RecoverServiceTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteServiceTransaction(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
