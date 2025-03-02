using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Common.State
{
    public interface IStateRepo
    {
        #region Crud
        Task<RepoBase> GetStates(Guid CountryId);
        Task<RepoBase> GetStates(PaginationParams pagination);
        Task<RepoBase> CreateState(StateModel data, AppUser user);
        Task<RepoBase> BulkCreateState(List<StateModel> dataList, AppUser user);
        Task<RepoBase> UpdateState(StateUpdateModel data, AppUser user);
        Task<RepoBase> BulkUpdateState(List<StateUpdateModel> dataList, AppUser user);
        Task<RepoBase> RemoveState(Guid Id, AppUser user);
        Task<RepoBase> BulkRemoveState(List<StateUpdateModel> dataList, AppUser user);
        #endregion
        #region Recover
        Task<RepoBase> GetRemovedStates(PaginationParams pagination);
        Task<RepoBase> RecoverState(Guid Id, AppUser user);
        Task<RepoBase> BulkRecoverStates(List<StateUpdateModel> Ids, AppUser user);
        Task<RepoBase> DeleteState(Guid Id, AppUser user);
        Task<RepoBase> BulkDeleteStates(List<Guid> Ids, AppUser user);
        #endregion
    }
}
