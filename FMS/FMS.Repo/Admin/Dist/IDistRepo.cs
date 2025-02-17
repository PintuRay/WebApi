using FMS.Db.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repo.Admin.Dist
{
    public interface IDistRepo
    {
        #region Crud
        Task<RepoBase> GetDists(Guid StateId);
        Task<RepoBase> CreateDist(DistModel data, AppUser user);
        Task<RepoBase> UpdateDist(DistUpdateModel data, AppUser user);
        Task<RepoBase> RemoveDist(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedDists();
        Task<RepoBase> RecoverDist(Guid Id, AppUser user);
        Task<RepoBase> DeleteDist(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverDists(List<Guid> Ids, AppUser user);
        Task<RepoBase> BulkDeleteDists(List<Guid> Ids, AppUser user);
        #endregion
    }
}
