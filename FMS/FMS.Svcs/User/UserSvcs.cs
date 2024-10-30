using FMS.Db.Entity;
using FMS.Repo.User;

namespace FMS.Svcs.User
{
    public  class UserSvcs(IUserRepo userRepo) : IUserSvcs
    {
        #region Dependancy
        private readonly IUserRepo _userRepo = userRepo;
        #endregion
        #region Stock 
        #region Crud
        public async Task<SvcsBase> GetStocks()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateStock(StockModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateStock(Guid Id, StockModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedStock()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllStock(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllStock(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Labour Details
        #region Crud
        public async Task<SvcsBase> GetAllLabourTypes()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetAllLabourDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateLabourDetail(LabourModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveLabourDetail(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedLabourDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverLabourDetails(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteLabourDetails(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllLabourDetails(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllLabourDetails(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region State
        #region Crud
        public async Task<SvcsBase> GetStates()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateState(StateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateState(Guid Id, StateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveState(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedStates()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverState(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteState(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllStates(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllStates(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region City
        #region Crud
        public async Task<SvcsBase> GetCities(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateCity(CityModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateCity(Guid Id, CityModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveCity(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedCity()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverCity(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteCity(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllCity(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllCity(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
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
        #region LedgerBalance
        #region Crud
        public async Task<SvcsBase> GetLedgerBalances()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedLedgerBalance()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Subledger
        #region Crud
        public async Task<SvcsBase> GetSubLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateSubLedger(SubLedgerModel Data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSubLedger(Guid Id,AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSubLedger()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSubLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSubLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        public async Task<SvcsBase> GetSubLedgerBalances()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveSubLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedSubLedgerBalance()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverSubLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteSubLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
