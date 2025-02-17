using FMS.Db.Entity;

namespace FMS.Svcs.Admin.Dist
{
    public interface IDistSvcs
    {
        #region Crud
        Task<SvcsBase> GetDists(Guid Id);
        Task<SvcsBase> CreateDist(DistModel data, AppUser user);
        Task<SvcsBase> UpdateDist(DistUpdateModel data, AppUser user);
        Task<SvcsBase> RemoveDist(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedDists();
        Task<SvcsBase> RecoverDist(Guid Id, AppUser user);
        Task<SvcsBase> DeleteDist(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverDists(List<Guid> Ids, AppUser user);
        Task<SvcsBase> BulkDeleteDists(List<Guid> Ids, AppUser user);
        #endregion
    }
}
