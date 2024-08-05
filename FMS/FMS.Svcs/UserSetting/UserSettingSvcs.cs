using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.User;
using FMS.Repo.UserSetting;

namespace FMS.Svcs.UserSetting
{
    public  class UserSettingSvcs(IUserSettingRepo userRepo) : IUserSettingSvcs
    {
        #region Dependancy
        private readonly IUserSettingRepo _userRepo = userRepo;
        #endregion
        #region Stock 
        #region Crud
        public async Task<Base> GetStocks()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateStock(StockModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateStock(Guid Id, StockModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedStock()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllStock(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllStock(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Labour Details
        #region Crud
        public async Task<Base> GetAllLabourTypes()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> GetAllLabourDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateLabourDetail(LabourModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveLabourDetail(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedLabourDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverLabourDetails(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteLabourDetails(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllLabourDetails(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllLabourDetails(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region State
        #region Crud
        public async Task<Base> GetStates()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateState(StateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateState(Guid Id, StateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveState(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedStates()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverState(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteState(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllStates(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllStates(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region City
        #region Crud
        public async Task<Base> GetCities(Guid Id)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateCity(CityModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateCity(Guid Id, CityModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveCity(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedCity()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverCity(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteCity(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllCity(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllCity(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Party Details
        #region Crud
        public async Task<Base> GetParties()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateParty(PartyModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateParty(Guid Id, PartyModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveParty(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedParty()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverParty(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteParty(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllParty(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllParty(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        public async Task<Base> GetLedgerBalances()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateLedgerBalance(LedgerBalanceRequest data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedLedgerBalance()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Subledger
        #region Crud
        public async Task<Base> GetSubLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateSubLedger(SubLedgerDataRequest Data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveSubLedger(Guid Id,AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedSubLedger()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteSubLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllSubLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllSubLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        public async Task<Base> GetSubLedgerBalances()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RemoveSubLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Base> GetRemovedSubLedgerBalance()
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverSubLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteSubLedgerBalance(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Base> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
