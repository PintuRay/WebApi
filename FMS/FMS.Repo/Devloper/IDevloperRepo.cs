using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Devloper;

namespace FMS.Repo.Devloper
{
    public interface IDevloperRepo
    {
        #region Branch
        #region Crud
        Task<Result<BranchViewModel>> GetAllBranch();
        Task<BaseDb> CreateBranch(BranchModel data, AppUser user);
        Task<BaseDb> UpdateBranch(Guid Id, BranchModel data, AppUser user);
        Task<BaseDb> RemoveBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<BranchViewModel>> GetRemovedBranches();
        Task<BaseDb> RecoverBranch(Guid Id, AppUser user);
        Task<BaseDb> DeleteBranch(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllBranch(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllBranch(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Financial Year
        #region Crud
        Task<Result<FinancialYearViewModel>> GetFinancialYears();
        Task<BaseDb> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<BaseDb> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<BaseDb> RemoveFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<FinancialYearViewModel>> GetRemovedFinancialYears();
        Task<BaseDb> RecoverFinancialYear(Guid Id, AppUser user);
        Task<BaseDb> DeleteFinancialYear(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllFinancialYear(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Branch Financial Year
        #region Crud
        Task<Result<BranchFinancialYearViewModel>> GetBranchFinancialYears();
        Task<Result<BranchFinancialYearViewModel>> GetBranchFinancialYears(Guid BranchId);
        Task<BaseDb> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<BaseDb> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<BaseDb> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<BranchFinancialYearViewModel>> GetRemovedBranchFinancialYears();
        Task<BaseDb> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<BaseDb> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}

