using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper
{
    public interface IBranchFinancialYearRepo
    {
        #region Branch Financial Year
        #region Crud
        Task<Result<BranchFinancialYear>> GetBranchFinancialYears(PaginationParams pagination);
        Task<Result<BranchFinancialYear>> GetBranchFinancialYears(Guid BranchId, PaginationParams pagination);
        Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<BranchFinancialYear>> GetRemovedBranchFinancialYears(PaginationParams pagination);
        Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
