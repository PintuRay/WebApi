using FMS.Db.Entity;

namespace FMS.Repo.User.Labour
{
    public interface ILabourRepo
    {
        #region labour Details    
        #region Crud
        Task<RepoBase> GetAllLabourTypes();
        Task<Result<Db.Entity.Labour>> GetAllLabourDetails();
        Task<RepoBase> CreateLabourDetail(LabourModel data, AppUser user);
        Task<RepoBase> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user);
        Task<RepoBase> RemoveLabourDetail(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.Labour>> GetRemovedLabourDetails();
        Task<RepoBase> RecoverLabourDetails(Guid Id, AppUser user);
        Task<RepoBase> DeleteLabourDetails(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLabourDetails(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLabourDetails(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
