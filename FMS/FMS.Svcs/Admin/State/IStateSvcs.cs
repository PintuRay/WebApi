using FMS.Db.Entity;

namespace FMS.Svcs.Admin.State
{
    public interface IStateSvcs
    {
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
    }
}
