using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.User;

namespace FMS.Svcs.UserSetting
{
    public interface IUserSettingSvcs
    {
        #region Stock 
        #region Crud
        Task<Base> GetStocks();
        Task<Base> CreateStock(StockModel data, AppUser user);
        Task<Base> UpdateStock(Guid Id, StockModel data, AppUser user);
        Task<Base> RemoveStock(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedStock();
        Task<Base> RecoverStock(Guid Id, AppUser user);
        Task<Base> DeleteStock(Guid Id, AppUser user);
        Task<Base> RecoverAllStock(List<string> Ids, AppUser user);
        Task<Base> DeleteAllStock(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region labour Details    
        #region Crud
        Task<Base> GetAllLabourTypes();
        Task<Base> GetAllLabourDetails();
        Task<Base> CreateLabourDetail(LabourModel data,AppUser user);
        Task<Base> UpdateLabourDetail(Guid Id,LabourModel data, AppUser user);
        Task<Base> RemoveLabourDetail(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedLabourDetails();
        Task<Base> RecoverLabourDetails(Guid Id, AppUser user);
        Task<Base> DeleteLabourDetails(Guid Id, AppUser user);
        Task<Base> RecoverAllLabourDetails(List<string> Ids, AppUser user);
        Task<Base> DeleteAllLabourDetails(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<Base> GetStates();
        Task<Base> CreateState(StateModel data, AppUser user);
        Task<Base> UpdateState(Guid Id, StateModel data, AppUser user);
        Task<Base> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedStates();
        Task<Base> RecoverState(Guid Id, AppUser user);
        Task<Base> DeleteState(Guid Id, AppUser user);
        Task<Base> RecoverAllStates(List<string> Ids, AppUser user);
        Task<Base> DeleteAllStates(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region City
        #region Crud
        Task<Base> GetCities(Guid Id);
        Task<Base> CreateCity(CityModel data, AppUser user);
        Task<Base> UpdateCity(Guid Id, CityModel data, AppUser user);
        Task<Base> RemoveCity(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedCity();
        Task<Base> RecoverCity(Guid Id, AppUser user);
        Task<Base> DeleteCity(Guid Id, AppUser user);
        Task<Base> RecoverAllCity(List<string> Ids, AppUser user);
        Task<Base> DeleteAllCity(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Party Details
        #region Crud
        Task<Base> GetParties();
        Task<Base> CreateParty(PartyModel data, AppUser user);
        Task<Base> UpdateParty(Guid Id, PartyModel data, AppUser user);
        Task<Base> RemoveParty(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedParty();
        Task<Base> RecoverParty(Guid Id, AppUser user);
        Task<Base> DeleteParty(Guid Id, AppUser user);
        Task<Base> RecoverAllParty(List<string> Ids, AppUser user);
        Task<Base> DeleteAllParty(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        Task<Base> GetLedgerBalances();
        Task<Base> CreateLedgerBalance(LedgerBalanceRequest data, AppUser user);
        Task<Base> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user);
        Task<Base> RemoveLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedLedgerBalance();
        Task<Base> RecoverLedgerBalance(Guid Id, AppUser user);
        Task<Base> DeleteLedgerBalance(Guid Id, AppUser user);
        Task<Base> RecoverAllLedgerBalance(List<string> Ids, AppUser user);
        Task<Base> DeleteAllLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Subledger
        #region Crud
        Task<Base> GetSubLedgers();
        Task<Base> CreateSubLedger(SubLedgerDataRequest Data, AppUser user);
        Task<Base> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user);
        Task<Base> RemoveSubLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedSubLedger();
        Task<Base> RecoverSubLedger(Guid Id, AppUser user);
        Task<Base> DeleteSubLedger(Guid Id, AppUser user);
        Task<Base> RecoverAllSubLedger(List<string> Ids, AppUser user);
        Task<Base> DeleteAllSubLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        Task<Base> GetSubLedgerBalances();
        Task<Base> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user);
        Task<Base> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user);
        Task<Base> RemoveSubLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedSubLedgerBalance();
        Task<Base> RecoverSubLedgerBalance(Guid Id, AppUser user);
        Task<Base> DeleteSubLedgerBalance(Guid Id, AppUser user);
        Task<Base> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user);
        Task<Base> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
