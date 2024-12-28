using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper.FinancialYear
{
    public interface IFinancialYearRepo
    {
        #region Financial Year
        #region Crud
        Task<Result<Db.Entity.FinancialYear>> GetFinancialYears(PaginationParams pagination);
        Task<RepoBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<RepoBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<RepoBase> RemoveFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.FinancialYear>> GetRemovedFinancialYears(PaginationParams pagination);
        Task<RepoBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllFinancialYear(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
