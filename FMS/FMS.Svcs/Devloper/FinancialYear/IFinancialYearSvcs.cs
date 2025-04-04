﻿using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo;

namespace FMS.Svcs.Devloper.FinancialYear
{
    public interface IFinancialYearSvcs
    {
        #region Crud
        Task<SvcsBase> GetFinancialYears(Guid BranchId);
        Task<SvcsBase> GetFinancialYears(PaginationParams pagination);
        Task<SvcsBase> CreateFinancialYear(FinancialYearModel data, AppUser user);
        Task<SvcsBase> BulkCreateFinancialYear(List<FinancialYearModel> dataList, AppUser user);
        Task<SvcsBase> UpdateFinancialYear(FinancialYearUpdateModel data, AppUser user);
        Task<SvcsBase> BulkUpdateFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        Task<SvcsBase> RemoveFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkRemoveFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedFinancialYears(PaginationParams pagination);
        Task<SvcsBase> RecoverFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user);
        Task<SvcsBase> DeleteFinancialYear(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteFinancialYear(List<Guid> Ids, AppUser user);
        #endregion
    }
}
