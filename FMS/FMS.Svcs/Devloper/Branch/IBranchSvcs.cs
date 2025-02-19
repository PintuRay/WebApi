using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Devloper.Branch
{
    public interface IBranchSvcs
    {
        #region Crud
        public Task<SvcsBase> GetAllBranch();
        public Task<SvcsBase> GetAllBranch(PaginationParams pagination);
        public Task<SvcsBase> CreateBranch(BranchModel data, AppUser user);
        public Task<SvcsBase> BulkCreateBranch(List<BranchModel> listdata, AppUser user);
        public Task<SvcsBase> UpdateBranch(BranchUpdateModel data, AppUser user);
        public Task<SvcsBase> BulkUpdateBranch(List<BranchUpdateModel> listdata, AppUser user);
        public Task<SvcsBase> RemoveBranch(Guid Id, AppUser user);
        public Task<SvcsBase> BulkRemoveBranch(List<BranchUpdateModel> listdata, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedBranches(PaginationParams pagination);
        Task<SvcsBase> RecoverBranch(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverBranch(List<BranchUpdateModel> listdata, AppUser user);
        Task<SvcsBase> DeleteBranch(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteBranch(List<Guid> Ids, AppUser user);
        #endregion
    }
}
