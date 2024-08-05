using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Devloper;
using FMS.Repo;

namespace FMS.Svcs.DevloperSetting
{
    public interface IDevloperSettingSvcs
    {
        #region Branch
        #region Crud
        public Task<Base> GetAllBranch();
        public Task<Base> CreateBranch(BranchModel data,AppUser user);
        public Task<Base> UpdateBranch(Guid BranchId, BranchModel data, AppUser user);
        public Task<Base> RemoveBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedBranches();
        Task<Base> RecoverBranch(Guid Id, AppUser user);
        Task<Base> DeleteBranch(Guid Id, AppUser user);
        Task<Base> RecoverAllBranch(List<string> Ids, AppUser user);
        Task<Base> DeleteAllBranch(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Financial Year
        #region Crud
        Task<Base> GetFinancialYears();
        Task<Base> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<Base> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<Base> RemoveFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedFinancialYears();
        Task<Base> RecoverFinancialYear(Guid Id, AppUser user);
        Task<Base> DeleteFinancialYear(Guid Id, AppUser user);
        Task<Base> RecoverAllFinancialYear(List<string> Ids, AppUser user);
        Task<Base> DeleteAllFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Branch Financial Year
        #region Crud
        Task<Base> GetBranchFinancialYears();
        Task<Base> GetBranchFinancialYears(Guid BranchId);
        Task<Base> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<Base> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<Base> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedBranchFinancialYears();
        Task<Base> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<Base> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<Base> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<Base> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
