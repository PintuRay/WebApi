using FMS.Db.Entity;

namespace FMS.Repo.Admin.UserBranch
{
    public interface IUserBranchRepo
    {
        #region User Branch 
        #region Crud
        Task<Result<Db.Entity.UserBranch>> GetUserBranches();
        Task<RepoBase> CreateUserBranch(UserBranchModel data, AppUser user);
        Task<RepoBase> UpdateUserBranch(Guid Id, UserBranchModel model, AppUser user);
        Task<RepoBase> RemoveUserBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.UserBranch>> GetRemovedUserBranches();
        Task<RepoBase> RecoverUserBranch(Guid Id, AppUser user);
        Task<RepoBase> DeleteUserBranch(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllUserBranches(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllUserBranches(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
