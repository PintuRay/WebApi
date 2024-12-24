using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Devloper
{
    public interface IBranchFinancialYearSvcs
    {
        #region Branch Financial Year
        #region Crud
        Task<SvcsBase> GetBranchFinancialYears(PaginationParams pagination);
        Task<SvcsBase> GetBranchFinancialYears(Guid BranchId, PaginationParams pagination);
        Task<SvcsBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user);
        Task<SvcsBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user);
        Task<SvcsBase> RemoveBranchFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedBranchFinancialYears(PaginationParams pagination);
        Task<SvcsBase> RecoverBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> DeleteBranchFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
