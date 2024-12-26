using FMS.Db.Entity;

namespace FMS.Repo.Admin.Production
{
    public interface IProductionRepo
    {
        #region Production 
        #region Crud
        //Task<Result<ProductionOrder>> GetProduction();
        //Task<RepoBase> CreateProduction(ProductionOrderModel data, AppUser user);
        //Task<RepoBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user);
        //Task<RepoBase> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<ProductionOrder>> GetRemovedProduction();
        //Task<RepoBase> RecoverProduction(Guid Id, AppUser user);
        //Task<RepoBase> DeleteProduction(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllProduction(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
