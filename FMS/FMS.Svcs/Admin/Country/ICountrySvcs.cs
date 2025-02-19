using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Admin.Country
{
    public interface ICountrySvcs
    {
        #region Crud
        Task<SvcsBase> GetCountries();
        Task<SvcsBase> GetCountries(PaginationParams pagination);
        Task<SvcsBase> CreateCountry(CountryModel data, AppUser user);
        Task<SvcsBase> BulkCreateCountry(List<CountryModel> listdata, AppUser user);
        Task<SvcsBase> UpdateCountry(CountryUpdateModel data, AppUser user);
        Task<SvcsBase> BulkUpdateCountry(List<CountryUpdateModel> listdata, AppUser user);
        Task<SvcsBase> RemoveCountry(Guid Id, AppUser user);
        Task<SvcsBase> BulkRemoveCountry(List<CountryUpdateModel> listdata, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedCountries(PaginationParams pagination);
        Task<SvcsBase> RecoverCountry(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverCountry(List<CountryUpdateModel> listdata, AppUser user);
        Task<SvcsBase> DeleteCountry(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteCountry(List<Guid> Ids, AppUser user);
        #endregion
    }
}
