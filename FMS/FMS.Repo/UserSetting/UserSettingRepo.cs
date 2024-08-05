using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.User;

namespace FMS.Repo.UserSetting
{
    public  class UserSettingRepo(Context ctx, IMapper mapper) : IUserSettingRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Stock 
        #region Crud
        public async Task <Result<StockModel>> GetStocks(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateStock(StockModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateStock(Guid Id, StockModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveStock(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<StockModel>> GetRemovedStock(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverStock(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteStock(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllStock(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllStock(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region labour Details    
        #region Crud
        public async Task <BaseDb> GetAllLabourTypes(){ throw new NotImplementedException(); }
        public async Task <Result<LabourModel>> GetAllLabourDetails(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateLabourDetail(LabourModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveLabourDetail(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<LabourModel>> GetRemovedLabourDetails(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverLabourDetails(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteLabourDetails(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllLabourDetails(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllLabourDetails(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region State
        #region Crud
        public async Task <Result<StateModel>> GetStates(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateState(StateModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateState(Guid Id, StateModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveState(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<StateModel>> GetRemovedStates(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverState(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteState(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllStates(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllStates(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region City
        #region Crud
        public async Task <Result<CityModel>> GetCities(Guid Id){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateCity(CityModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateCity(Guid Id, CityModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveCity(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<CityModel>> GetRemovedCity(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverCity(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteCity(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllCity(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllCity(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Party Details
        #region Crud
        public async Task <Result<PartyModel>> GetParties(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateParty(PartyModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateParty(Guid Id, PartyModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveParty(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<PartyModel>> GetRemovedParty(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverParty(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteParty(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllParty(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllParty(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        public async Task <Result<LedgerBalanceModel>> GetLedgerBalances(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateLedgerBalance(LedgerBalanceRequest data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<LedgerBalanceModel>> GetRemovedLedgerBalance(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Subledger
        #region Crud
        public async Task <Result<SubLedgerModel>> GetSubLedgers(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateSubLedger(SubLedgerDataRequest Data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveSubLedger(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<SubLedgerModel>> GetRemovedSubLedger(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverSubLedger(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteSubLedger(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllSubLedger(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllSubLedger(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        public async Task <Result<SubLedgerBalanceModel>> GetSubLedgerBalances(){ throw new NotImplementedException(); }
        public async Task <BaseDb> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RemoveSubLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<SubLedgerBalanceModel>> GetRemovedSubLedgerBalance(){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverSubLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteSubLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <BaseDb> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
