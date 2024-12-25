using FMS.Db.Entity;

namespace FMS.Svcs.User.Party
{
    public class PartySvcs: IPartySvcs
    {
        #region Party Details
        #region Crud
        public async Task<SvcsBase> GetParties()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateParty(PartyModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateParty(Guid Id, PartyModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveParty(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedParty()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverParty(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteParty(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllParty(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllParty(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
