using FMS.Db.Entity;

namespace FMS.Svcs.User
{
    public interface IUserSvcs
    {
        #region Stock 
        #region Crud
        Task<SvcsBase> GetStocks();
        Task<SvcsBase> CreateStock(StockModel data, AppUser user);
        Task<SvcsBase> UpdateStock(Guid Id, StockModel data, AppUser user);
        Task<SvcsBase> RemoveStock(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedStock();
        Task<SvcsBase> RecoverStock(Guid Id, AppUser user);
        Task<SvcsBase> DeleteStock(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllStock(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllStock(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region labour Details    
        #region Crud
        Task<SvcsBase> GetAllLabourTypes();
        Task<SvcsBase> GetAllLabourDetails();
        Task<SvcsBase> CreateLabourDetail(LabourModel data,AppUser user);
        Task<SvcsBase> UpdateLabourDetail(Guid Id,LabourModel data, AppUser user);
        Task<SvcsBase> RemoveLabourDetail(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedLabourDetails();
        Task<SvcsBase> RecoverLabourDetails(Guid Id, AppUser user);
        Task<SvcsBase> DeleteLabourDetails(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllLabourDetails(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllLabourDetails(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region State
        #region Crud
        Task<SvcsBase> GetStates();
        Task<SvcsBase> CreateState(StateModel data, AppUser user);
        Task<SvcsBase> UpdateState(Guid Id, StateModel data, AppUser user);
        Task<SvcsBase> RemoveState(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedStates();
        Task<SvcsBase> RecoverState(Guid Id, AppUser user);
        Task<SvcsBase> DeleteState(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllStates(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllStates(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region City
        #region Crud
        Task<SvcsBase> GetCities(Guid Id);
        Task<SvcsBase> CreateCity(CityModel data, AppUser user);
        Task<SvcsBase> UpdateCity(Guid Id, CityModel data, AppUser user);
        Task<SvcsBase> RemoveCity(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedCity();
        Task<SvcsBase> RecoverCity(Guid Id, AppUser user);
        Task<SvcsBase> DeleteCity(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllCity(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllCity(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Party Details
        #region Crud
        Task<SvcsBase> GetParties();
        Task<SvcsBase> CreateParty(PartyModel data, AppUser user);
        Task<SvcsBase> UpdateParty(Guid Id, PartyModel data, AppUser user);
        Task<SvcsBase> RemoveParty(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedParty();
        Task<SvcsBase> RecoverParty(Guid Id, AppUser user);
        Task<SvcsBase> DeleteParty(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllParty(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllParty(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region LedgerBalance
        #region Crud
        Task<SvcsBase> GetLedgerBalances();
        Task<SvcsBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user);
        Task<SvcsBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user);
        Task<SvcsBase> RemoveLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedLedgerBalance();
        Task<SvcsBase> RecoverLedgerBalance(Guid Id, AppUser user);
        Task<SvcsBase> DeleteLedgerBalance(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Subledger
        #region Crud
        Task<SvcsBase> GetSubLedgers();
        Task<SvcsBase> CreateSubLedger(SubLedgerModel Data, AppUser user);
        Task<SvcsBase> UpdateSubLedger(Guid Id, SubLedgerModel data, AppUser user);
        Task<SvcsBase> RemoveSubLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSubLedger();
        Task<SvcsBase> RecoverSubLedger(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSubLedger(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSubLedger(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSubLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region SubLedger Balance
        #region Crud
        Task<SvcsBase> GetSubLedgerBalances();
        Task<SvcsBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user);
        Task<SvcsBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user);
        Task<SvcsBase> RemoveSubLedgerBalance(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSubLedgerBalance();
        Task<SvcsBase> RecoverSubLedgerBalance(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSubLedgerBalance(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
