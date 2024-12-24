using FMS.Db.Entity;

namespace FMS.Repo.Admin.Sales
{
    public interface ISalesRepo
    {
        #region  Sales 
        #region Crud
        Task<Result<SalesOrderSetup>> GetSales();
        Task<RepoBase> CreateSales(SalesOrderSetupModel data, AppUser user);
        Task<RepoBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user);
        Task<RepoBase> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesOrderSetup>> GetRemovedSales();
        Task<RepoBase> RecoverSales(Guid Id, AppUser user);
        Task<RepoBase> DeleteSales(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSales(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSales(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
