using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper.BranchFinancialYear
{
    public interface IBranchFinancialYearRepo
    {
        #region Branch Financial Year
        #region Crud
        Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears();
        Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears(Guid BranchId);
        Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears(PaginationParams pagination);
        Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> BulkCreateBranchFinancialYear(List<BranchFinancialYearModel> data, AppUser user);
        Task<RepoBase> UpdateBranchFinancialYear(BranchFinancialYearUpdateModel data, AppUser user);
        Task<RepoBase> BulkUpdateBranchFinancialYear(List<BranchFinancialYearUpdateModel> data, AppUser user);
        Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> BulkRemoveBranchFinancialYear(List<Guid> Ids, AppUser user);
        #endregion
        #region Recover
        Task<Result<BranchFinancialYearDto>> GetRemovedBranchFinancialYears(PaginationParams pagination);
        Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverBranchFinancialYear(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> BulkDeleteBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
