using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Devloper.BranchFinancialYear
{
    public interface IBranchFinancialYearSvcs
    {
        #region Branch Financial Year
        #region Crud
        Task<SvcsBase> GetBranchFinancialYears();
        Task<SvcsBase> GetBranchFinancialYears(Guid BranchId);
        Task<SvcsBase> GetBranchFinancialYears(PaginationParams pagination);
        Task<SvcsBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<SvcsBase> BulkCreateBranchFinancialYear(List<BranchFinancialYearModel> data, AppUser user);
        Task<SvcsBase> UpdateBranchFinancialYear(BranchFinancialYearUpdateModel data, AppUser user);
        Task<SvcsBase> BulkUpdateBranchFinancialYear(List<BranchFinancialYearUpdateModel> data, AppUser user);
        Task<SvcsBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkRemoveBranchFinancialYear(List<Guid> Ids, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedBranchFinancialYears(PaginationParams pagination);
        Task<SvcsBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverBranchFinancialYear(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
