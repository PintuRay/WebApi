using FMS.Db.Entity;

namespace FMS.Repo.User.Party
{
    public interface IPartyRepo
    {
        #region Party Details
        #region Crud
        Task<Result<Db.Entity.Party>> GetParties();
        Task<RepoBase> CreateParty(PartyModel data, AppUser user);
        Task<RepoBase> UpdateParty(Guid Id, PartyModel data, AppUser user);
        Task<RepoBase> RemoveParty(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.Party>> GetRemovedParty();
        Task<RepoBase> RecoverParty(Guid Id, AppUser user);
        Task<RepoBase> DeleteParty(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllParty(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllParty(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
