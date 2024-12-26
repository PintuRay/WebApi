using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Devloper.Branch
{
    public interface IBranchRepo
    {
        #region Branch
        #region Crud
        //Task<Result<Db.Entity.Branch>> GetAllBranch(PaginationParams pagination);
        //Task<RepoBase> CreateBranch(BranchModel data, AppUser user);
        //Task<RepoBase> UpdateBranch(Guid Id, BranchModel data, AppUser user);
        //Task<RepoBase> RemoveBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Db.Entity.Branch>> GetRemovedBranches(PaginationParams pagination);
        //Task<RepoBase> RecoverBranch(Guid Id, AppUser user);
        //Task<RepoBase> DeleteBranch(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllBranch(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllBranch(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
