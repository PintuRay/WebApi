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
        Task<SvcsBase> UpdateCountry(Guid Id, CountryModel data, AppUser user);
        Task<SvcsBase> RemoveCountry(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedCountries();
        Task<SvcsBase> RecoverCountry(Guid Id, AppUser user);
        Task<SvcsBase> DeleteCountry(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllCountry(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllCountry(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<SvcsBase> GetStates(Guid CountryId);
        Task<SvcsBase> CreateState(StateModel data, AppUser user);
        Task<SvcsBase> UpdateState(Guid Id, StateModel data, AppUser user);
        Task<SvcsBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedStates();
        Task<SvcsBase> RecoverState(Guid Id, AppUser user);
        Task<SvcsBase> DeleteState(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllStates(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllStates(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Dist
        #region Crud
        Task<SvcsBase> GetDists(Guid Id);
        Task<SvcsBase> CreateDist(DistModel data, AppUser user);
        Task<SvcsBase> UpdateDist(Guid Id, DistModel data, AppUser user);
        Task<SvcsBase> RemoveDist(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedDists();
        Task<SvcsBase> RecoverDist(Guid Id, AppUser user);
        Task<SvcsBase> DeleteDist(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllDists(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllDists(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
