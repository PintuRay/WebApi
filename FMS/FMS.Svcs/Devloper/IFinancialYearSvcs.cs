using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Devloper
{
    public interface IFinancialYearSvcs
    {
        #region Financial Year
        #region Crud
        Task<SvcsBase> GetFinancialYears(PaginationParams pagination);
        Task<SvcsBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<SvcsBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<SvcsBase> RemoveFinancialYear(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedFinancialYears(PaginationParams pagination);
        Task<SvcsBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllFinancialYear(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
