using FMS.Db.Entity;

namespace FMS.Repo.Common
{
    public interface ICommonRepo
    {
        #region Country
        #region Crud
        //Task<Result<Country>> GetCountries();
        //Task<RepoBase> CreateCountry(CountryModel data, AppUser user);
        //Task<RepoBase> UpdateCountry(Guid Id, CountryModel data, AppUser user);
        //Task<RepoBase> RemoveCountry(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Country>> GetRemovedCountries();
        //Task<RepoBase> RecoverCountry(Guid Id, AppUser user);
        //Task<RepoBase> DeleteCountry(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllCountry(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllCountry(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        //Task<Result<State>> GetStates(Guid CountryId);
        //Task<RepoBase> CreateState(StateModel data, AppUser user);
        //Task<RepoBase> UpdateState(Guid Id, StateModel data, AppUser user);
        //Task<RepoBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<State>> GetRemovedStates();
        //Task<RepoBase> RecoverState(Guid Id, AppUser user);
        //Task<RepoBase> DeleteState(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllStates(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllStates(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Dist
        #region Crud
        //Task<Result<Dist>> GetDists(Guid StateId);
        //Task<RepoBase> CreateDist(DistModel data, AppUser user);
        //Task<RepoBase> UpdateDist(Guid Id, DistModel data, AppUser user);
        //Task<RepoBase> RemoveDist(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Dist>> GetRemovedDists();
        //Task<RepoBase> RecoverDist(Guid Id, AppUser user);
        //Task<RepoBase> DeleteDist(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllDist(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllDist(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
