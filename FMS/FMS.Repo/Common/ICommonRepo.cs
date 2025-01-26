using FMS.Db.Entity;

namespace FMS.Repo.Common
{
    public interface ICommonRepo
    {
        #region Country
        #region Crud
        Task<Result<CountryDto>> GetCountries();
        Task<RepoBase> CreateCountry(CountryModel data, AppUser user);
        Task<RepoBase> UpdateCountry(CountryUpdateModel data, AppUser user);
        Task<RepoBase> RemoveCountry(Guid id, AppUser user);
        #endregion
        #region Recover
        Task<Result<CountryDto>> GetRemovedCountries();
        Task<RepoBase> RecoverCountry(Guid Id, AppUser user);
        Task<RepoBase> DeleteCountry(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverCountry(List<Guid> Ids, AppUser user);
        Task<RepoBase> BulkDeleteCountry(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<Result<StateDto>> GetStates(Guid CountryId);
        Task<RepoBase> CreateState(StateModel data, AppUser user);
        Task<RepoBase> UpdateState(StateUpdateModel data, AppUser user);
        Task<RepoBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<StateDto>> GetRemovedStates();
        Task<RepoBase> RecoverState(Guid Id, AppUser user);
        Task<RepoBase> DeleteState(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverStates(List<Guid> Ids, AppUser user);
        Task<RepoBase> BulkDeleteStates(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
        #region Dist
        #region Crud
        Task<Result<DistDto>> GetDists(Guid StateId);
        Task<RepoBase> CreateDist(DistModel data, AppUser user);
        Task<RepoBase> UpdateDist(DistUpdateModel data, AppUser user);
        Task<RepoBase> RemoveDist(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<DistDto>> GetRemovedDists();
        Task<RepoBase> RecoverDist(Guid Id, AppUser user);
        Task<RepoBase> DeleteDist(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverDists(List<Guid> Ids, AppUser user);
        Task<RepoBase> BulkDeleteDists(List<Guid> Ids, AppUser user);
        #endregion
        #endregion
    }
}
