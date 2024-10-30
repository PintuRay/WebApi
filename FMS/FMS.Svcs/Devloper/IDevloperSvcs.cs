using FMS.Db.Entity;

namespace FMS.Svcs.Devloper
{
    public interface IDevloperSvcs
    {
        #region Branch
        #region Crud
        public Task<SvcsBase> GetAllBranch();
        public Task<SvcsBase> CreateBranch(BranchModel data,AppUser user);
        public Task<SvcsBase> UpdateBranch(Guid BranchId, BranchModel data, AppUser user);
        public Task<SvcsBase> RemoveBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedBranches();
        Task<SvcsBase> RecoverBranch(Guid Id, AppUser user);
        Task<SvcsBase> DeleteBranch(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllBranch(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllBranch(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Financial Year
        #region Crud
        Task<SvcsBase> GetFinancialYears();
        Task<SvcsBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<SvcsBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<SvcsBase> RemoveFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedFinancialYears();
        Task<SvcsBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllFinancialYear(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Branch Financial Year
        #region Crud
        Task<SvcsBase> GetBranchFinancialYears();
        Task<SvcsBase> GetBranchFinancialYears(Guid BranchId);
        Task<SvcsBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<SvcsBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<SvcsBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedBranchFinancialYears();
        Task<SvcsBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
