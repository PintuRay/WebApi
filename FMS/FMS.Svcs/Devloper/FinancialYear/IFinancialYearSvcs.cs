using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo;

namespace FMS.Svcs.Devloper.FinancialYear
{
    public interface IFinancialYearSvcs
    {
        #region Financial Year
        #region Crud
        Task<SvcsBase> GetFinancialYears(PaginationParams pagination);
        Task<SvcsBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<SvcsBase> BulkCreateFinancialYear(List<FinancialYearModel> dataList, AppUser user);
        Task<SvcsBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user);
        Task<SvcsBase> BulkUpdateFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        Task<SvcsBase> RemoveFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkRemoveFinancialYear(List<Guid> Ids, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedFinancialYears(PaginationParams pagination);
        Task<SvcsBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverFinancialYear(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteFinancialYear(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
