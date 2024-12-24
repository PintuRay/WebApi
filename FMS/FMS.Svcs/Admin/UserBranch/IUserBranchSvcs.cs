using FMS.Db.Entity;

namespace FMS.Svcs.Admin.UserBranch
{
    public interface IUserBranchSvcs
    {
        #region User Branch  
        #region Crud
        Task<SvcsBase> GetUserBranches();
        Task<SvcsBase> CreateUserBranch(UserBranchModel data, AppUser user);
        Task<SvcsBase> UpdateUserBranch(Guid Id, UserBranchModel data, AppUser user);
        Task<SvcsBase> RemoveUserBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedUserBranches();
        Task<SvcsBase> RecoverUserBranch(Guid Id, AppUser user);
        Task<SvcsBase> DeleteUserBranch(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllUserBranches(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllUserBranches(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
