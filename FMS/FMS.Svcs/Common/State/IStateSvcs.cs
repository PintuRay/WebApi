using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Common.State
{
    public interface IStateSvcs
    {
        #region Crud
        Task<SvcsBase> GetStates(Guid CountryId);
        Task<SvcsBase> GetStates(PaginationParams pagination);
        Task<SvcsBase> CreateState(StateModel data, AppUser user);
        Task<SvcsBase> BulkCreateState(List<StateModel> datalist, AppUser user);
        Task<SvcsBase> UpdateState(StateUpdateModel data, AppUser user);
        Task<SvcsBase> BulkUpdateState(List<StateUpdateModel> datalist, AppUser user);
        Task<SvcsBase> RemoveState(Guid Id, AppUser user);
        Task<SvcsBase> BulkRemoveState(List<StateUpdateModel> datalist, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedStates(PaginationParams pagination);
        Task<SvcsBase> RecoverState(Guid Id, AppUser user);
        Task<SvcsBase> BulkRecoverStates(List<StateUpdateModel> datalist, AppUser user);
        Task<SvcsBase> DeleteState(Guid Id, AppUser user);
        Task<SvcsBase> BulkDeleteStates(List<Guid> Ids, AppUser user);
        #endregion
    }
}
