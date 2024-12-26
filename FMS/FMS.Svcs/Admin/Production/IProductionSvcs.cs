using FMS.Db.Entity;

namespace FMS.Svcs.Admin.Production
{
    public interface IProductionSvcs
    {
        #region Production 
        #region Crud
        //Task<SvcsBase> GetProduction();
        //Task<SvcsBase> CreateProduction(ProductionOrderModel requestData, AppUser user);
        //Task<SvcsBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user);
        //Task<SvcsBase> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedProduction();
        //Task<SvcsBase> RecoverProduction(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteProduction(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllProduction(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
