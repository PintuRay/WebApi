using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Common.Country
{
    public interface ICountryRepo
    {
        #region Crud
        Task<RepoBase> GetAllCountries();
        Task<RepoBase> GetCountries(PaginationParams pagination);
        Task<RepoBase> CreateCountry(CountryModel data, AppUser user);
        Task<RepoBase> BulkCreateCountry(List<CountryModel> dataList, AppUser user);
        Task<RepoBase> UpdateCountry(CountryUpdateModel data, AppUser user);
        Task<RepoBase> BulkUpdateCountry(List<CountryUpdateModel> listdata, AppUser user);
        Task<RepoBase> RemoveCountry(Guid id, AppUser user);
        Task<RepoBase> BulkRemoveCountry(List<CountryUpdateModel> listdata, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedCountries(PaginationParams pagination);
        Task<RepoBase> RecoverCountry(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverCountry(List<CountryUpdateModel> listdata, AppUser user);
        Task<RepoBase> DeleteCountry(Guid Id, AppUser user);
        Task<RepoBase> BulkDeleteCountry(List<Guid> Ids, AppUser user);
        #endregion
    }
}
