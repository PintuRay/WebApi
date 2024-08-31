using FMS.Db.Entity;

namespace FMS.Svcs.AdminSetting
{
    public interface IAdminSettingSvcs
    {
       
        #region Generate SignUp Token
        Task<SvcsBase> CreateToken(RegisterTokenModel Token);
        #endregion
        #region Company Details
        #region Crud
        Task<SvcsBase> GetCompany(string BranchId);
        Task<SvcsBase> CreateCompany(CompanyModel data, AppUser user);
        Task<SvcsBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user);
        Task<SvcsBase> RemoveCompany(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedCompanies(string BranchId);
        Task<SvcsBase> RecoverCompany(Guid Id, AppUser user);
        Task<SvcsBase> DeleteCompany(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllCompany(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllCompany(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region User Branch Allocation  
        #region Crud
        Task<SvcsBase> GetAllUserAndBranch();
        Task<SvcsBase> CreateBranchAlloction(UserBranchModel data, AppUser user);
        Task<SvcsBase> UpdateBranchAlloction(Guid Id, UserBranchModel data, AppUser user);
        Task<SvcsBase> RemoveBranchAlloction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedBranchAlloction();
        Task<SvcsBase> RecoverBranchAlloction(Guid Id, AppUser user);
        Task<SvcsBase> DeleteBranchAlloction(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllBranchAlloction(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllBranchAlloction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Unit
        #region Crud
        Task<SvcsBase> GetAllUnits();
        Task<SvcsBase> CreateUnit(UnitModel data, AppUser user);
        Task<SvcsBase> UpdateUnit(Guid Id, UnitModel data, AppUser user);
        Task<SvcsBase> RemoveUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedUnits();
        Task<SvcsBase> RecoverUnit(Guid Id, AppUser user);
        Task<SvcsBase> DeleteUnit(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllUnit(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Alternate Unit
        #region Crud
        Task<SvcsBase> GetAlternateUnits();
        Task<SvcsBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user);
        Task<SvcsBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user);
        Task<SvcsBase> RemoveAlternateUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedAlternateUnits();
        Task<SvcsBase> RecoverAlternateUnit(Guid Id, AppUser user);
        Task<SvcsBase> DeleteAlternateUnit(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product Group
        #region Crud
        Task<SvcsBase> GetProductGroups();
        Task<SvcsBase> CreateProductGroup(ProductGroupModel data, AppUser user);
        Task<SvcsBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user);
        Task<SvcsBase> RemoveProductGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedProductGroup();
        Task<SvcsBase> RecoverProductGroup(Guid Id, AppUser user);
        Task<SvcsBase> DeleteProductGroup(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllProductGroup(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllProductGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        Task<SvcsBase> GetProductSubGroups();
        Task<SvcsBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user);
        Task<SvcsBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user);
        Task<SvcsBase> RemoveProductSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedProductSubGroup();
        Task<SvcsBase> RecoverProductSubGroup(Guid Id, AppUser user);
        Task<SvcsBase> DeleteProductSubGroup(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product
        Task<SvcsBase> GetProductTypes();
        #region Crud
        Task<SvcsBase> GetAllProducts();
        Task<SvcsBase> CreateProduct(ProductModel data, AppUser user);
        Task<SvcsBase> UpdateProduct(Guid Id, ProductModel data, AppUser user);
        Task<SvcsBase> RemoveProduct(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedProduct();
        Task<SvcsBase> RecoverProduct(Guid Id, AppUser user);
        Task<SvcsBase> DeleteProduct(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllProduct(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllProduct(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production Configuration
        #region Crud
        Task<SvcsBase> GetProductionConfig();
        Task<SvcsBase> CreateProductionConfig(ProductionOrderModel requestData, AppUser user);
        Task<SvcsBase> UpdateProductionConfig(Guid Id, ProductionOrderModel data, AppUser user);
        Task<SvcsBase> RemoveProductionConfig(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedProductionConfig();
        Task<SvcsBase> RecoverProductionConfig(Guid Id, AppUser user);
        Task<SvcsBase> DeleteProductionConfig(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllProductionConfig(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllProductionConfig(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Sales Configuration  
        #region Crud
        Task<SvcsBase> GetSalesConfig();
        Task<SvcsBase> CreateSalesConfig(SalesOrderSetupModel data, AppUser user);
        Task<SvcsBase> UpdateSalesConfig(Guid Id, SalesOrderSetupModel data, AppUser user);
        Task<SvcsBase> RemoveSalesConfig(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSalesConfig();
        Task<SvcsBase> RecoverSalesConfig(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSalesConfig(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSalesConfig(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSalesConfig(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Labour Rate Configuration
        #region Crud
        Task<SvcsBase> GetAllLabourRates();
        Task<SvcsBase> CreateLabourRate(LabourRateModel data, AppUser user);
        Task<SvcsBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user);
        Task<SvcsBase> RemoveLabourRate(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedLabourRate();
        Task<SvcsBase> RecoverLabourRate(Guid Id, AppUser user);
        Task<SvcsBase> DeleteLabourRate(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllLabourRate(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllLabourRate(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Accounting Config
        #region Group
        Task<SvcsBase> GetGroups();
        #endregion
        #region SubGroup
        #region Crud
        Task<SvcsBase> GetSubGroups();
        Task<SvcsBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user);
        Task<SvcsBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user);
        Task<SvcsBase> RemoveSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedSubGroup();
        Task<SvcsBase> RecoverSubGroup(Guid Id, AppUser user);
        Task<SvcsBase> DeleteSubGroup(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllSubGroup(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Ledger
        #region Crud
        Task<SvcsBase> GetLedgers();
        Task<SvcsBase> CreateLedger(LedgerModel data, AppUser user);
        Task<SvcsBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user);
        Task<SvcsBase> RemoveLedger(Guid Id,AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedLedgers();
        Task<SvcsBase> RecoverLedger(Guid Id, AppUser user);
        Task<SvcsBase> DeleteLedger(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllLedger(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
    }
}
