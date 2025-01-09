using FMS.Db.Entity;
using FMS.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Svcs.CommonSvcs
{
    public interface ICommonSvcs
    {
        #region Country
        #region Crud
        Task<SvcsBase> GetCountries();
        Task<SvcsBase> CreateCountry(CountryModel data, AppUser user);
        Task<SvcsBase> UpdateCountry(CountryUpdateModel data, AppUser user);
        Task<SvcsBase> RemoveCountry(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedCountries();
        Task<SvcsBase> RecoverCountry(Guid Id, AppUser user);
        Task<SvcsBase> DeleteCountry(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverCountry(List<Guid> Ids, AppUser user);
        Task<SvcsBase> BulkDeleteCountry(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<SvcsBase> GetStates(Guid CountryId);
        Task<SvcsBase> CreateState(StateModel data, AppUser user);
        Task<SvcsBase> UpdateState(StateUpdateModel data, AppUser user);
        Task<SvcsBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedStates();
        Task<SvcsBase> RecoverState(Guid Id, AppUser user);
        Task<SvcsBase> DeleteState(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverStates(List<Guid> Ids, AppUser user);
        Task<SvcsBase> BulkDeleteStates(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
        #region Dist
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
        #endregion
    }
}
