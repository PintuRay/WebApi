﻿using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper.Branch
{
    public interface IBranchRepo
    {
        #region Branch
        #region Crud
        Task<RepoBase> GetAllBranch();
        Task<RepoBase> GetAllBranch(PaginationParams pagination);
        Task<RepoBase> CreateBranch(BranchModel data, AppUser user);
        Task<RepoBase> BulkCreateBranch(List<BranchModel> dataList, AppUser user);
        Task<RepoBase> UpdateBranch(BranchUpdateModel data, AppUser user);
        Task<RepoBase> BulkUpdateBranch(List<BranchUpdateModel> dataList, AppUser user);
        Task<RepoBase> RemoveBranch(Guid Id, AppUser user);
        Task<RepoBase> BulkRemoveBranch(List<BranchUpdateModel> dataList, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedBranches(PaginationParams pagination);
        Task<RepoBase> RecoverBranch(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverBranch(List<BranchUpdateModel> dataList, AppUser user);
        Task<RepoBase> DeleteBranch(Guid Id, AppUser user);
        Task<RepoBase> BulkDeleteBranch(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
    }
}
