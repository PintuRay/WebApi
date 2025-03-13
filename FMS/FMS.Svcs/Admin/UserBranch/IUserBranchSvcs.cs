using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Admin.UserBranch
{
    public interface IUserBranchSvcs
    {
        #region User Branch  
        #region Crud
        Task<SvcsBase> GetUserBranches(AppUser user);
        Task<SvcsBase> GetUserBranches(PaginationParams pagination);
        Task<SvcsBase> CreateUserBranch(UserBranchModel data, AppUser user);
        Task<SvcsBase> UpdateUserBranch(UserBranchUpdateModel data, AppUser user);
        Task<SvcsBase> RemoveUserBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedUserBranches(PaginationParams pagination);
        Task<SvcsBase> RecoverUserBranch(Guid Id, AppUser user);
        Task<SvcsBase> DeleteUserBranch(Guid Id, AppUser user);
        #endregion
        #endregion
    }
}
