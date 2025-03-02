using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Common.Dist
{
    public interface IDistRepo
    {
        #region Crud
        Task<RepoBase> GetDists(Guid StateId);
        Task<RepoBase> GetDists(PaginationParams pagination);
        Task<RepoBase> CreateDist(DistModel data, AppUser user);
        Task<RepoBase> BulkCreateDist(List<DistModel> datalist, AppUser user);
        Task<RepoBase> UpdateDist(DistUpdateModel data, AppUser user);
        Task<RepoBase> BulkUpdateDist(List<DistUpdateModel> datalist, AppUser user);
        Task<RepoBase> RemoveDist(Guid Id, AppUser user);
        Task<RepoBase> BulkRemoveDist(List<DistUpdateModel> datalist, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedDists(PaginationParams pagination);
        Task<RepoBase> RecoverDist(Guid Id, AppUser user);
        Task<RepoBase> DeleteDist(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverDists(List<DistUpdateModel> Ids, AppUser user);
        Task<RepoBase> BulkDeleteDists(List<Guid> Ids, AppUser user);
        #endregion
    }
}
