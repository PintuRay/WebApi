using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.AdminSetting
{
    public interface IAdminSettingRepo
    {
        #region Generate SignUp Token
        Task<BaseDb> CreateToken(RegisterTokenModel model);
        #endregion
        #region Company Details
        #region Crud
        Task<BaseDb> CreateCompany(CompanyModel data, AppUser user);
        Task<Result<Company>> GetCompany(string BranchId);
        Task<BaseDb> UpdateCompany(Guid Id, CompanyModel model, AppUser user);
        Task<BaseDb> RemoveCompany(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Company>> GetRemovedCompanies(string BranchId);
        Task<BaseDb> RecoverCompany(Guid Id, AppUser user);
        Task<BaseDb> DeleteCompany(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllCompany(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllCompany(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Branch Allocation
        #region Crud
        Task<Result<UserBranch>> GetBranchAlloctions();
        Task<BaseDb> CreateBranchAlloction(UserBranchModel data, AppUser user);
        Task<BaseDb> UpdateBranchAlloction(Guid Id, UserBranchModel model, AppUser user);
        Task<BaseDb> RemoveBranchAlloction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<UserBranch>> GetRemovedBranchAlloction();
        Task<BaseDb> RecoverBranchAlloction(Guid Id, AppUser user);
        Task<BaseDb> DeleteBranchAlloction(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllBranchAlloction(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllBranchAlloction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Unit
        #region Crud
        Task<Result<UnitModel>> GetAllUnits();
        Task<BaseDb> CreateUnit(UnitModel data, AppUser user);
        Task<BaseDb> UpdateUnit(Guid Id, UnitModel data, AppUser user);
        Task<BaseDb> RemoveUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<UnitModel>> GetRemovedUnits();
        Task<BaseDb> RecoverUnit(Guid Id, AppUser user);
        Task<BaseDb> DeleteUnit(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllUnit(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Alternate Units
        #region Crud
        Task<Result<AlternateUnitModel>> GetAlternateUnits();
        Task<BaseDb> CreateAlternateUnit(AlternateUnitModel data, AppUser user);
        Task<BaseDb> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user);
        Task<BaseDb> RemoveAlternateUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<AlternateUnitModel>> GetRemovedAlternateUnits();
        Task<BaseDb> RecoverAlternateUnit(Guid Id, AppUser user);
        Task<BaseDb> DeleteAlternateUnit(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllAlternateUnit(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllAlternateUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product Group
        #region Crud
        Task<Result<ProductGroupModel>> GetProductGroups();
        Task<BaseDb> CreateProductGroup(ProductGroupModel data, AppUser user);
        Task<BaseDb> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user);
        Task<BaseDb> RemoveProductGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductGroupModel>> GetRemovedProductGroup();
        Task<BaseDb> RecoverProductGroup(Guid Id, AppUser user);
        Task<BaseDb> DeleteProductGroup(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllProductGroup(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllProductGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        Task<Result<ProductSubGroupModel>> GetProductSubGroups();
        Task<BaseDb> CreateProductSubGroup(ProductSubGroupModel data, AppUser user);
        Task<BaseDb> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user);
        Task<BaseDb> RemoveProductSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductSubGroupModel>> GetRemovedProductSubGroup();
        Task<BaseDb> RecoverProductSubGroup(Guid Id, AppUser user);
        Task<BaseDb> DeleteProductSubGroup(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllProductSubGroup(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllProductSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product
        Task<Result<ProductTypeModel>> GetProductTypes();
        #region Crud
        Task<Result<ProductModel>> GetAllProducts();
        Task<BaseDb> CreateProduct(ProductModel data, AppUser user);
        Task<BaseDb> UpdateProduct(Guid Id, ProductModel data, AppUser user);
        Task<BaseDb> RemoveProduct(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductModel>> GetRemovedProduct();
        Task<BaseDb> RecoverProduct(Guid Id, AppUser user);
        Task<BaseDb> DeleteProduct(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllProduct(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllProduct(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Production Configuration
        #region Crud
        Task<Result<ProductionModel>> GetProductionConfig();
        Task<BaseDb> CreateProductionConfig(ProductConfigDataRequest requestData, AppUser user);
        Task<BaseDb> UpdateProductionConfig(Guid Id, ProductionModel data, AppUser user);
        Task<BaseDb> RemoveProductionConfig(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductionModel>> GetRemovedProductionConfig();
        Task<BaseDb> RecoverProductionConfig(Guid Id, AppUser user);
        Task<BaseDb> DeleteProductionConfig(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllProductionConfig(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllProductionConfig(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region  Sales Config
        #region Crud
        Task<Result<SalesConfigModel>> GetSalesConfig();
        Task<BaseDb> CreateSalesConfig(ProductConfigDataRequest requestData, AppUser user);
        Task<BaseDb> UpdateSalesConfig(Guid Id, SalesConfigModel data, AppUser user);
        Task<BaseDb> RemoveSalesConfig(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesConfigModel>> GetRemovedSalesConfig();
        Task<BaseDb> RecoverSalesConfig(Guid Id, AppUser user);
        Task<BaseDb> DeleteSalesConfig(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllSalesConfig(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllSalesConfig(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Labour Rate Configration
        #region Crud
        Task<Result<LabourRateModel>> GetAllLabourRates();
        Task<BaseDb> CreateLabourRate(LabourRateModel data, AppUser user);
        Task<BaseDb> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user);
        Task<BaseDb> RemoveLabourRate(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourRateModel>> GetRemovedLabourRate();
        Task<BaseDb> RecoverLabourRate(Guid Id, AppUser user);
        Task<BaseDb> DeleteLabourRate(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllLabourRate(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllLabourRate(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Account Configuration
        #region Group
        Task<Result<LedgerGroupModel>> GetGroups();
        #endregion
        #region SubGroup  
        #region Crud
        Task<Result<LedgerSubGroupModel>> GetSubGroups();
        Task<BaseDb> CreateSubGroup(LedgerSubGroupModel data,AppUser user);
        Task<BaseDb> UpdateSubGroup(Guid Id,LedgerSubGroupModel data, AppUser user);
        Task<BaseDb> RemoveSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LedgerSubGroupModel>> GetRemovedSubGroup();
        Task<BaseDb> RecoverSubGroup(Guid Id, AppUser user);
        Task<BaseDb> DeleteSubGroup(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllSubGroup(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Ledger
        #region Crud
        Task<Result<LedgerModel>> GetLedgers();
        Task<BaseDb> CreateLedger(LedgerViewModel listData, AppUser user);
        Task<BaseDb> UpdateLedger(Guid Id, LedgerModel data, AppUser user);
        Task<BaseDb> RemoveLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LedgerModel>> GetRemovedLedgers();
        Task<BaseDb> RecoverLedger(Guid Id, AppUser user);
        Task<BaseDb> DeleteLedger(Guid Id, AppUser user);
        Task<BaseDb> RecoverAllLedger(List<string> Ids, AppUser user);
        Task<BaseDb> DeleteAllLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
    }
}
