using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Repo.Admin
{
    public interface IAdminRepo
    {
        #region Generate SignUp Token
        Task<RepoBase> CreateToken(RegisterTokenModel model, AppUser user);
        #endregion
        #region Company
        #region Crud
        Task<RepoBase> CreateCompany(CompanyModel data, AppUser user);
        Task<Result<Company>> GetCompany(string BranchId);
        Task<RepoBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user);
        Task<RepoBase> RemoveCompany(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Company>> GetRemovedCompanies(string BranchId);
        Task<RepoBase> RecoverCompany(Guid Id, AppUser user);
        Task<RepoBase> DeleteCompany(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllCompany(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllCompany(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region User Branch 
        #region Crud
        Task<Result<UserBranch>> GetUserBranches();
        Task<RepoBase> CreateUserBranch(UserBranchModel data, AppUser user);
        Task<RepoBase> UpdateUserBranch(Guid Id, UserBranchModel model, AppUser user);
        Task<RepoBase> RemoveUserBranch(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<UserBranch>> GetRemovedUserBranches();
        Task<RepoBase> RecoverUserBranch(Guid Id, AppUser user);
        Task<RepoBase> DeleteUserBranch(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllUserBranches(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllUserBranches(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product 
        #region Product Type
        Task<Result<ProductType>> GetProductTypes();
        #endregion
        #region Unit
        #region Crud
        Task<Result<Unit>> GetAllUnits();
        Task<RepoBase> CreateUnit(UnitModel data, AppUser user);
        Task<RepoBase> UpdateUnit(Guid Id, UnitModel data, AppUser user);
        Task<RepoBase> RemoveUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Unit>> GetRemovedUnits();
        Task<RepoBase> RecoverUnit(Guid Id, AppUser user);
        Task<RepoBase> DeleteUnit(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllUnit(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Alternate Units
        #region Crud
        Task<Result<AlternateUnit>> GetAlternateUnits();
        Task<RepoBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user);
        Task<RepoBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user);
        Task<RepoBase> RemoveAlternateUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<AlternateUnit>> GetRemovedAlternateUnits();
        Task<RepoBase> RecoverAlternateUnit(Guid Id, AppUser user);
        Task<RepoBase> DeleteAlternateUnit(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product Group
        #region Crud
        Task<Result<ProductGroup>> GetProductGroups();
        Task<RepoBase> CreateProductGroup(ProductGroupModel data, AppUser user);
        Task<RepoBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user);
        Task<RepoBase> RemoveProductGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductGroup>> GetRemovedProductGroup();
        Task<RepoBase> RecoverProductGroup(Guid Id, AppUser user);
        Task<RepoBase> DeleteProductGroup(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProductGroup(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProductGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        Task<Result<ProductSubGroup>> GetProductSubGroups();
        Task<RepoBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user);
        Task<RepoBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user);
        Task<RepoBase> RemoveProductSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductSubGroup>> GetRemovedProductSubGroup();
        Task<RepoBase> RecoverProductSubGroup(Guid Id, AppUser user);
        Task<RepoBase> DeleteProductSubGroup(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product
        #region Crud
        Task<Result<Product>> GetAllProducts();
        Task<RepoBase> CreateProduct(ProductModel data, AppUser user);
        Task<RepoBase> UpdateProduct(Guid Id, ProductModel data, AppUser user);
        Task<RepoBase> RemoveProduct(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Product>> GetRemovedProduct();
        Task<RepoBase> RecoverProduct(Guid Id, AppUser user);
        Task<RepoBase> DeleteProduct(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProduct(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProduct(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
        #region Production 
        #region Crud
        Task<Result<ProductionOrder>> GetProduction();
        Task<RepoBase> CreateProduction(ProductionOrderModel data, AppUser user);
        Task<RepoBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user);
        Task<RepoBase> RemoveProduction(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<ProductionOrder>> GetRemovedProduction();
        Task<RepoBase> RecoverProduction(Guid Id, AppUser user);
        Task<RepoBase> DeleteProduction(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllProduction(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllProduction(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region  Sales 
        #region Crud
        Task<Result<SalesOrderSetup>> GetSales();
        Task<RepoBase> CreateSales(SalesOrderSetupModel data, AppUser user);
        Task<RepoBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user);
        Task<RepoBase> RemoveSales(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<SalesOrderSetup>> GetRemovedSales();
        Task<RepoBase> RecoverSales(Guid Id, AppUser user);
        Task<RepoBase> DeleteSales(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSales(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSales(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Labour Rate
        #region Crud
        Task<Result<LabourRate>> GetAllLabourRates();
        Task<RepoBase> CreateLabourRate(LabourRateModel data, AppUser user);
        Task<RepoBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user);
        Task<RepoBase> RemoveLabourRate(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LabourRate>> GetRemovedLabourRate();
        Task<RepoBase> RecoverLabourRate(Guid Id, AppUser user);
        Task<RepoBase> DeleteLabourRate(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLabourRate(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLabourRate(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Account 
        #region Group
        Task<Result<LedgerGroup>> GetGroups();
        #endregion
        #region SubGroup  
        #region Crud
        Task<Result<LedgerSubGroup>> GetSubGroups();
        Task<RepoBase> CreateSubGroup(LedgerSubGroupModel data,AppUser user);
        Task<RepoBase> UpdateSubGroup(Guid Id,LedgerSubGroupModel data, AppUser user);
        Task<RepoBase> RemoveSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<LedgerSubGroup>> GetRemovedSubGroup();
        Task<RepoBase> RecoverSubGroup(Guid Id, AppUser user);
        Task<RepoBase> DeleteSubGroup(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllSubGroup(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Ledger
        #region Crud
        Task<Result<Ledger>> GetLedgers();
        Task<RepoBase> CreateLedger(LedgerModel data, AppUser user);
        Task<RepoBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user);
        Task<RepoBase> RemoveLedger(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Ledger>> GetRemovedLedgers();
        Task<RepoBase> RecoverLedger(Guid Id, AppUser user);
        Task<RepoBase> DeleteLedger(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLedger(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLedger(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #endregion
    }
}
