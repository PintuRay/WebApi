using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper.FinancialYear
{
    public interface IFinancialYearRepo
    {
        #region Financial Year
        #region Crud
        Task<RepoBase> GetFinancialYears(Guid BranchId);
        Task<RepoBase> GetFinancialYears(PaginationParams pagination);
        Task<RepoBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<RepoBase> BulkCreateFinancialYear(List<FinancialYearModel> dataList, AppUser user);
        Task<RepoBase> UpdateFinancialYear(FinancialYearUpdateModel data, AppUser user);
        Task<RepoBase> BulkUpdateFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        Task<RepoBase> RemoveFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> BulkRemoveFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedFinancialYears(PaginationParams pagination);
        Task<RepoBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        Task<RepoBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> BulkDeleteFinancialYear(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
    }
}
