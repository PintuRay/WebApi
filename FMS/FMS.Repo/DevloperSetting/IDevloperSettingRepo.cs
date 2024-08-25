using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.DevloperSetting
{
    public interface IDevloperSettingRepo
    {
        #region Branch
        #region Crud
        Task<Result<Branch>> GetAllBranch();
        Task<RepoBase> CreateBranch(BranchModel data, AppUser user);
        Task<RepoBase> UpdateBranch(Guid Id, BranchModel data, AppUser user);
        Task<RepoBase> RemoveBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Branch>> GetRemovedBranches();
        Task<RepoBase> RecoverBranch(Guid Id, AppUser user);
        Task<RepoBase> DeleteBranch(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllBranch(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllBranch(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Financial Year
        #region Crud
        Task<Result<FinancialYear>> GetFinancialYears();
        Task<RepoBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<RepoBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<RepoBase> RemoveFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<FinancialYear>> GetRemovedFinancialYears();
        Task<RepoBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllFinancialYear(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Branch Financial Year
        #region Crud
        Task<Result<BranchFinancialYear>> GetBranchFinancialYears();
        Task<Result<BranchFinancialYear>> GetBranchFinancialYears(Guid BranchId);
        Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<BranchFinancialYear>> GetRemovedBranchFinancialYears();
        Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}

