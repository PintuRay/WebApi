using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Admin;
using FMS.Repo.DevloperSetting;

namespace FMS.Svcs.AdminSetting
{
    public interface IAdminSettingSvcs
    {
       
        #region Generate SignUp Token
        Task<Base> CreateToken(RegisterTokenModel Token);
        #endregion
        #region Company Details
        #region Crud
        Task<Base> GetCompany();
        Task<Base> CreateCompany(CompanyModel data, AppUser user);
        Task<Base> UpdateCompany(Guid Id, CompanyModel model, AppUser user);
        Task<Base> RemoveCompany(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedCompanies();
        Task<Base> RecoverCompany(Guid Id, AppUser user);
        Task<Base> DeleteCompany(Guid Id, AppUser user);
        Task<Base> RecoverAllCompany(List<string> Ids, AppUser user);
        Task<Base> DeleteAllCompany(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region User Branch Allocation  
        #region Crud
        Task<Base> GetAllUserAndBranch();
        Task<Base> CreateBranchAlloction(UserBranchModel data, AppUser user);
        Task<Base> UpdateBranchAlloction(Guid Id, UserBranchModel data, AppUser user);
        Task<Base> RemoveBranchAlloction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedBranchAlloction();
        Task<Base> RecoverBranchAlloction(Guid Id, AppUser user);
        Task<Base> DeleteBranchAlloction(Guid Id, AppUser user);
        Task<Base> RecoverAllBranchAlloction(List<string> Ids, AppUser user);
        Task<Base> DeleteAllBranchAlloction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Unit
        #region Crud
        Task<Base> GetAllUnits();
        Task<Base> CreateUnit(UnitModel data, AppUser user);
        Task<Base> UpdateUnit(Guid Id, UnitModel data, AppUser user);
        Task<Base> RemoveUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedUnits();
        Task<Base> RecoverUnit(Guid Id, AppUser user);
        Task<Base> DeleteUnit(Guid Id, AppUser user);
        Task<Base> RecoverAllUnit(List<string> Ids, AppUser user);
        Task<Base> DeleteAllUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Alternate Unit
        #region Crud
        Task<Base> GetAlternateUnits();
        Task<Base> CreateAlternateUnit(AlternateUnitModel data, AppUser user);
        Task<Base> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user);
        Task<Base> RemoveAlternateUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedAlternateUnits();
        Task<Base> RecoverAlternateUnit(Guid Id, AppUser user);
        Task<Base> DeleteAlternateUnit(Guid Id, AppUser user);
        Task<Base> RecoverAllAlternateUnit(List<string> Ids, AppUser user);
        Task<Base> DeleteAllAlternateUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product Group
        #region Crud
        Task<Base> GetProductGroups();
        Task<Base> CreateProductGroup(ProductGroupModel data, AppUser user);
        Task<Base> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user);
        Task<Base> RemoveProductGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedProductGroup();
        Task<Base> RecoverProductGroup(Guid Id, AppUser user);
        Task<Base> DeleteProductGroup(Guid Id, AppUser user);
        Task<Base> RecoverAllProductGroup(List<string> Ids, AppUser user);
        Task<Base> DeleteAllProductGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        Task<Base> GetProductSubGroups();
        Task<Base> CreateProductSubGroup(ProductSubGroupModel data, AppUser user);
        Task<Base> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user);
        Task<Base> RemoveProductSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedProductSubGroup();
        Task<Base> RecoverProductSubGroup(Guid Id, AppUser user);
        Task<Base> DeleteProductSubGroup(Guid Id, AppUser user);
        Task<Base> RecoverAllProductSubGroup(List<string> Ids, AppUser user);
        Task<Base> DeleteAllProductSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product
        Task<Base> GetProductTypes();
        #region Crud
        Task<Base> GetAllProducts();
        Task<Base> CreateProduct(ProductModel data, AppUser user);
        Task<Base> UpdateProduct(Guid Id, ProductModel data, AppUser user);
        Task<Base> RemoveProduct(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedProduct();
        Task<Base> RecoverProduct(Guid Id, AppUser user);
        Task<Base> DeleteProduct(Guid Id, AppUser user);
        Task<Base> RecoverAllProduct(List<string> Ids, AppUser user);
        Task<Base> DeleteAllProduct(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production Configuration
        #region Crud
        Task<Base> GetProductionConfig();
        Task<Base> CreateProductionConfig(ProductConfigDataRequest requestData, AppUser user);
        Task<Base> UpdateProductionConfig(Guid Id, ProductionModel data, AppUser user);
        Task<Base> RemoveProductionConfig(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedProductionConfig();
        Task<Base> RecoverProductionConfig(Guid Id, AppUser user);
        Task<Base> DeleteProductionConfig(Guid Id, AppUser user);
        Task<Base> RecoverAllProductionConfig(List<string> Ids, AppUser user);
        Task<Base> DeleteAllProductionConfig(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Configuration  
        #region Crud
        Task<Base> GetSalesConfig();
        Task<Base> CreateSalesConfig(ProductConfigDataRequest requestData, AppUser user);
        Task<Base> UpdateSalesConfig(Guid Id, SalesConfigModel data, AppUser user);
        Task<Base> RemoveSalesConfig(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedSalesConfig();
        Task<Base> RecoverSalesConfig(Guid Id, AppUser user);
        Task<Base> DeleteSalesConfig(Guid Id, AppUser user);
        Task<Base> RecoverAllSalesConfig(List<string> Ids, AppUser user);
        Task<Base> DeleteAllSalesConfig(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Labour Rate Configuration
        #region Crud
        Task<Base> GetAllLabourRates();
        Task<Base> CreateLabourRate(LabourRateModel data, AppUser user);
        Task<Base> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user);
        Task<Base> RemoveLabourRate(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedLabourRate();
        Task<Base> RecoverLabourRate(Guid Id, AppUser user);
        Task<Base> DeleteLabourRate(Guid Id, AppUser user);
        Task<Base> RecoverAllLabourRate(List<string> Ids, AppUser user);
        Task<Base> DeleteAllLabourRate(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Accounting Config
        #region Group
        Task<Base> GetGroups();
        #endregion
        #region SubGroup
        #region Crud
        Task<Base> GetSubGroups();
        Task<Base> CreateSubGroup(LedgerSubGroupModel data, AppUser user);
        Task<Base> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user);
        Task<Base> RemoveSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedSubGroup();
        Task<Base> RecoverSubGroup(Guid Id, AppUser user);
        Task<Base> DeleteSubGroup(Guid Id, AppUser user);
        Task<Base> RecoverAllSubGroup(List<string> Ids, AppUser user);
        Task<Base> DeleteAllSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Ledger
        #region Crud
        Task<Base> GetLedgers();
        Task<Base> CreateLedger(LedgerViewModel listData, AppUser user);
        Task<Base> UpdateLedger(Guid Id, LedgerModel data, AppUser user);
        Task<Base> RemoveLedger(Guid Id,AppUser user);
        #endregion
        #region Recover
        Task<Base> GetRemovedLedgers();
        Task<Base> RecoverLedger(Guid Id, AppUser user);
        Task<Base> DeleteLedger(Guid Id, AppUser user);
        Task<Base> RecoverAllLedger(List<string> Ids, AppUser user);
        Task<Base> DeleteAllLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
    }
}
