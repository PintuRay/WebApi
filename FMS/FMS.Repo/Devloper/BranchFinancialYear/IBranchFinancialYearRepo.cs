using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper.BranchFinancialYear
{
    public interface IBranchFinancialYearRepo
    {
        #region Branch Financial Year
        #region Crud
        Task<Result<Db.Entity.BranchFinancialYear>> GetBranchFinancialYears(PaginationParams pagination);
        Task<Result<Db.Entity.BranchFinancialYear>> GetBranchFinancialYears(Guid BranchId, PaginationParams pagination);
        Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.BranchFinancialYear>> GetRemovedBranchFinancialYears(PaginationParams pagination);
        Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
