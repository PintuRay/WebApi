using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Admin.Dist
{
    public interface IDistSvcs
    {
        #region Crud
        Task<SvcsBase> GetDists(Guid StateId);
        Task<SvcsBase> GetDists(PaginationParams pagination);
        Task<SvcsBase> CreateDist(DistModel data, AppUser user);
        Task<SvcsBase> BulkCreateDist(List<DistModel> datalist, AppUser user);
        Task<SvcsBase> UpdateDist(DistUpdateModel data, AppUser user);
        Task<SvcsBase> BulkUpdateDist(List<DistUpdateModel> datalist, AppUser user);
        Task<SvcsBase> RemoveDist(Guid Id, AppUser user);
        Task<SvcsBase> BulkRemoveDist(List<DistUpdateModel> datalist, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedDists(PaginationParams pagination);
        Task<SvcsBase> RecoverDist(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverDists(List<DistUpdateModel> datalist, AppUser user);
        Task<SvcsBase> DeleteDist(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteDists(List<Guid> Ids, AppUser user);
        #endregion
    }
}
