using FMS.Db.Entity;

namespace FMS.Repo.Admin.State
{
    public interface IStateRepo
    {
        #region Crud
        Task<RepoBase> GetStates(Guid CountryId);
        Task<RepoBase> CreateState(StateModel data, AppUser user);
        Task<RepoBase> UpdateState(StateUpdateModel data, AppUser user);
        Task<RepoBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedStates();
        Task<RepoBase> RecoverState(Guid Id, AppUser user);
        Task<RepoBase> DeleteState(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverStates(List<Guid> Ids, AppUser user);
        Task<RepoBase> BulkDeleteStates(List<Guid> Ids, AppUser user);
        #endregion
    }
}
