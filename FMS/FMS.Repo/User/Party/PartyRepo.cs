using FMS.Db.Entity;

namespace FMS.Repo.User.Party
{
    public class PartyRepo: IPartyRepo
    {
        #region Party Details
        #region Crud
        public async Task<Result<Db.Entity.Party>> GetParties() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateParty(PartyModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateParty(Guid Id, PartyModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveParty(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.Party>> GetRemovedParty() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverParty(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteParty(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllParty(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllParty(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
