using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Admin.UserBranch
{
    public interface IUserBranchRepo
    {
        #region User Branch 
        #region Crud
        Task<RepoBase> GetUserBranches(AppUser user);
        Task<RepoBase> GetUserBranches(PaginationParams pagination);
        Task<RepoBase> CreateUserBranch(UserBranchModel data, AppUser user);
        Task<RepoBase> UpdateUserBranch(UserBranchUpdateModel model, AppUser user);
        Task<RepoBase> RemoveUserBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedUserBranches(PaginationParams pagination);
        Task<RepoBase> RecoverUserBranch(Guid Id, AppUser user);
        Task<RepoBase> DeleteUserBranch(Guid Id, AppUser user);
        #endregion
        #endregion
    }
}
