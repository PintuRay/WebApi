using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
namespace FMS.Repo.User
{
    public  class UserRepo(Context ctx, IMapper mapper) : IUserRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Stock 
        #region Crud
        public async Task <Result<Stock>> GetStocks(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateStock(StockModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateStock(Guid Id, StockModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveStock(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<Stock>> GetRemovedStock(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverStock(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteStock(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllStock(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllStock(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region labour Details    
        #region Crud
        public async Task <RepoBase> GetAllLabourTypes(){ throw new NotImplementedException(); }
        public async Task <Result<Labour>> GetAllLabourDetails(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateLabourDetail(LabourModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveLabourDetail(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<Labour>> GetRemovedLabourDetails(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverLabourDetails(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteLabourDetails(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllLabourDetails(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllLabourDetails(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region State
        #region Crud
        public async Task <Result<State>> GetStates(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateState(StateModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateState(Guid Id, StateModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveState(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<State>> GetRemovedStates(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverState(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteState(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllStates(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllStates(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region City
        #region Crud
        public async Task <Result<City>> GetCities(Guid Id){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateCity(CityModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateCity(Guid Id, CityModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveCity(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<City>> GetRemovedCity(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverCity(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteCity(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllCity(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllCity(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Party Details
        #region Crud
        public async Task <Result<Party>> GetParties(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateParty(PartyModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateParty(Guid Id, PartyModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveParty(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<Party>> GetRemovedParty(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverParty(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteParty(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllParty(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllParty(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        public async Task <Result<LedgerBalance>> GetLedgerBalances(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<LedgerBalance>> GetRemovedLedgerBalance(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region Subledger
        #region Crud
        public async Task <Result<SubLedger>> GetSubLedgers(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateSubLedger(SubLedgerModel Data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveSubLedger(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<SubLedger>> GetRemovedSubLedger(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverSubLedger(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteSubLedger(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllSubLedger(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllSubLedger(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        public async Task <Result<SubLedgerBalance>> GetSubLedgerBalances(){ throw new NotImplementedException(); }
        public async Task <RepoBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RemoveSubLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task <Result<SubLedgerBalance>> GetRemovedSubLedgerBalance(){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverSubLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteSubLedgerBalance(Guid Id, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        public async Task <RepoBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user){ throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
