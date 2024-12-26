using FMS.Db.Entity;

namespace FMS.Svcs.Admin.Sales
{
    public interface ISalesSvcs
    {
        #region Sales   
        #region Crud
        //Task<SvcsBase> GetSales();
        //Task<SvcsBase> CreateSales(SalesOrderSetupModel data, AppUser user);
        //Task<SvcsBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user);
        //Task<SvcsBase> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedSales();
        //Task<SvcsBase> RecoverSales(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteSales(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllSales(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllSales(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
