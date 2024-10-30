using FMS.Db.Entity;
namespace FMS.Repo.User
{
    public interface IUserRepo
    {
        #region Stock 
        #region Crud
        Task<Result<Stock>> GetStocks();
        Task<RepoBase> CreateStock(StockModel data, AppUser user);
        Task<RepoBase> UpdateStock(Guid Id, StockModel data, AppUser user);
        Task<RepoBase> RemoveStock(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Stock>> GetRemovedStock();
        Task<RepoBase> RecoverStock(Guid Id, AppUser user);
        Task<RepoBase> DeleteStock(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllStock(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllStock(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region labour Details    
        #region Crud
        Task<RepoBase> GetAllLabourTypes();
        Task<Result<Labour>> GetAllLabourDetails();
        Task<RepoBase> CreateLabourDetail(LabourModel data, AppUser user);
        Task<RepoBase> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user);
        Task<RepoBase> RemoveLabourDetail(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Labour>> GetRemovedLabourDetails();
        Task<RepoBase> RecoverLabourDetails(Guid Id, AppUser user);
        Task<RepoBase> DeleteLabourDetails(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLabourDetails(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLabourDetails(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<Result<State>> GetStates();
        Task<RepoBase> CreateState(StateModel data, AppUser user);
        Task<RepoBase> UpdateState(Guid Id, StateModel data, AppUser user);
        Task<RepoBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<State>> GetRemovedStates();
        Task<RepoBase> RecoverState(Guid Id, AppUser user);
        Task<RepoBase> DeleteState(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllStates(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllStates(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region City
        #region Crud
        Task<Result<City>> GetCities(Guid Id);
        Task<RepoBase> CreateCity(CityModel data, AppUser user);
        Task<RepoBase> UpdateCity(Guid Id, CityModel data, AppUser user);
        Task<RepoBase> RemoveCity(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<City>> GetRemovedCity();
        Task<RepoBase> RecoverCity(Guid Id, AppUser user);
        Task<RepoBase> DeleteCity(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllCity(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllCity(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Party Details
        #region Crud
        Task<Result<Party>> GetParties();
        Task<RepoBase> CreateParty(PartyModel data, AppUser user);
        Task<RepoBase> UpdateParty(Guid Id, PartyModel data, AppUser user);
        Task<RepoBase> RemoveParty(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Party>> GetRemovedParty();
        Task<RepoBase> RecoverParty(Guid Id, AppUser user);
        Task<RepoBase> DeleteParty(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllParty(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllParty(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        Task<Result<LedgerBalance>> GetLedgerBalances();
        Task<RepoBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user);
        Task<RepoBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user);
        Task<RepoBase> RemoveLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LedgerBalance>> GetRemovedLedgerBalance();
        Task<RepoBase> RecoverLedgerBalance(Guid Id, AppUser user);
        Task<RepoBase> DeleteLedgerBalance(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Subledger
        #region Crud
        Task<Result<SubLedger>> GetSubLedgers();
        Task<RepoBase> CreateSubLedger(SubLedgerModel Data, AppUser user);
        Task<RepoBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user);
        Task<RepoBase> RemoveSubLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SubLedger>> GetRemovedSubLedger();
        Task<RepoBase> RecoverSubLedger(Guid Id, AppUser user);
        Task<RepoBase> DeleteSubLedger(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSubLedger(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSubLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        Task<Result<SubLedgerBalance>> GetSubLedgerBalances();
        Task<RepoBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user);
        Task<RepoBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user);
        Task<RepoBase> RemoveSubLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SubLedgerBalance>> GetRemovedSubLedgerBalance();
        Task<RepoBase> RecoverSubLedgerBalance(Guid Id, AppUser user);
        Task<RepoBase> DeleteSubLedgerBalance(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
