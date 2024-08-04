using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.User;

namespace FMS.Repo.User
{
    public interface IUserRepo
    {
        #region Stock 
        #region Crud
        Task<Result<StockModel>> GetStocks();
        Task<BaseDb> CreateStock(StockModel data, AppUser user);
        Task<BaseDb> UpdateStock(Guid Id, StockModel data, AppUser user);
        Task<BaseDb> RemoveStock(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<StockModel>> GetRemovedStock();
        Task<BaseDb> RecoverStock(Guid Id, AppUser user);
        Task<BaseDb> DeleteStock(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllStock(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllStock(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region labour Details    
        #region Crud
        Task<BaseDb> GetAllLabourTypes();
        Task<Result<LabourModel>> GetAllLabourDetails();
        Task<BaseDb> CreateLabourDetail(LabourModel data, AppUser user);
        Task<BaseDb> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user);
        Task<BaseDb> RemoveLabourDetail(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourModel>> GetRemovedLabourDetails();
        Task<BaseDb> RecoverLabourDetails(Guid Id, AppUser user);
        Task<BaseDb> DeleteLabourDetails(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllLabourDetails(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllLabourDetails(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<Result<StateModel>> GetStates();
        Task<BaseDb> CreateState(StateModel data, AppUser user);
        Task<BaseDb> UpdateState(Guid Id, StateModel data, AppUser user);
        Task<BaseDb> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<StateModel>> GetRemovedStates();
        Task<BaseDb> RecoverState(Guid Id, AppUser user);
        Task<BaseDb> DeleteState(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllStates(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllStates(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region City
        #region Crud
        Task<Result<CityModel>> GetCities(Guid Id);
        Task<BaseDb> CreateCity(CityModel data, AppUser user);
        Task<BaseDb> UpdateCity(Guid Id, CityModel data, AppUser user);
        Task<BaseDb> RemoveCity(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<CityModel>> GetRemovedCity();
        Task<BaseDb> RecoverCity(Guid Id, AppUser user);
        Task<BaseDb> DeleteCity(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllCity(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllCity(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Party Details
        #region Crud
        Task<Result<PartyModel>> GetParties();
        Task<BaseDb> CreateParty(PartyModel data, AppUser user);
        Task<BaseDb> UpdateParty(Guid Id, PartyModel data, AppUser user);
        Task<BaseDb> RemoveParty(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<PartyModel>> GetRemovedParty();
        Task<BaseDb> RecoverParty(Guid Id, AppUser user);
        Task<BaseDb> DeleteParty(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllParty(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllParty(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        Task<Result<LedgerBalanceModel>> GetLedgerBalances();
        Task<BaseDb> CreateLedgerBalance(LedgerBalanceRequest data, AppUser user);
        Task<BaseDb> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user);
        Task<BaseDb> RemoveLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LedgerBalanceModel>> GetRemovedLedgerBalance();
        Task<BaseDb> RecoverLedgerBalance(Guid Id, AppUser user);
        Task<BaseDb> DeleteLedgerBalance(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllLedgerBalance(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Subledger
        #region Crud
        Task<Result<SubLedgerModel>> GetSubLedgers();
        Task<BaseDb> CreateSubLedger(SubLedgerDataRequest Data, AppUser user);
        Task<BaseDb> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user);
        Task<BaseDb> RemoveSubLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SubLedgerModel>> GetRemovedSubLedger();
        Task<BaseDb> RecoverSubLedger(Guid Id, AppUser user);
        Task<BaseDb> DeleteSubLedger(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllSubLedger(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllSubLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        Task<Result<SubLedgerBalanceModel>> GetSubLedgerBalances();
        Task<BaseDb> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user);
        Task<BaseDb> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user);
        Task<BaseDb> RemoveSubLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SubLedgerBalanceModel>> GetRemovedSubLedgerBalance();
        Task<BaseDb> RecoverSubLedgerBalance(Guid Id, AppUser user);
        Task<BaseDb> DeleteSubLedgerBalance(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
