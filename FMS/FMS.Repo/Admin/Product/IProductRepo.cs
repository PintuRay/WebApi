using FMS.Db.Entity;

namespace FMS.Repo.Admin.Product
{
    public interface IProductRepo
    {
      
        #region Product Type
        //Task<Result<ProductType>> GetProductTypes();
        #endregion
        #region Product Group
        #region Crud
        //Task<Result<ProductGroup>> GetProductGroups();
        //Task<Result<ProductGroup>> GetProductGroups(Guid ProdutTypeId);
        //Task<RepoBase> CreateProductGroup(ProductGroupModel data, AppUser user);
        //Task<RepoBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user);
        //Task<RepoBase> RemoveProductGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<ProductGroup>> GetRemovedProductGroup();
        //Task<RepoBase> RecoverProductGroup(Guid Id, AppUser user);
        //Task<RepoBase> DeleteProductGroup(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllProductGroup(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllProductGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        //Task<Result<ProductSubGroup>> GetProductSubGroups(Guid GroupId);
        //Task<RepoBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user);
        //Task<RepoBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user);
        //Task<RepoBase> RemoveProductSubGroup(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<ProductSubGroup>> GetRemovedProductSubGroup();
        //Task<RepoBase> RecoverProductSubGroup(Guid Id, AppUser user);
        //Task<RepoBase> DeleteProductSubGroup(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Unit
        #region Crud
        //Task<Result<Unit>> GetAllUnits();
        //Task<RepoBase> CreateUnit(UnitModel data, AppUser user);
        //Task<RepoBase> UpdateUnit(Guid Id, UnitModel data, AppUser user);
        //Task<RepoBase> RemoveUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Unit>> GetRemovedUnits();
        //Task<RepoBase> RecoverUnit(Guid Id, AppUser user);
        //Task<RepoBase> DeleteUnit(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllUnit(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion
        #region Alternate Units
        #region Crud
        //Task<Result<AlternateUnit>> GetAlternateUnits();
        //Task<Result<AlternateUnit>> GetAlternateUnitByUnitId(Guid UnitId);
        //Task<Result<AlternateUnit>> GetAlternateUnitByProductId(Guid ProductId);
        //Task<Result<AlternateUnit>> GetAlternateUnitByAlternateUnitId(Guid AlternateUnitId);
        //Task<RepoBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user);
        //Task<RepoBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user);
        //Task<RepoBase> RemoveAlternateUnit(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<AlternateUnit>> GetRemovedAlternateUnits();
        //Task<RepoBase> RecoverAlternateUnit(Guid Id, AppUser user);
        //Task<RepoBase> DeleteAlternateUnit(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user);
        #endregion
        #endregion    
        #region Product
        #region Crud
        //Task<Result<Db.Entity.Product>> GetAllProducts();
        //Task<Result<Db.Entity.Product>> GetProductById(Guid ProductId);
        //Task<Result<Db.Entity.Product>> GetProductByTypeId(Guid ProductTypeId);
        //Task<Result<Db.Entity.Product>> GetProductGstWithRate(Guid id, string RateType);
        //Task<RepoBase> CreateProduct(ProductModel data, AppUser user);
        //Task<RepoBase> UpdateProduct(Guid Id, ProductModel data, AppUser user);
        //Task<RepoBase> RemoveProduct(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Db.Entity.Product>> GetRemovedProduct();
        //Task<RepoBase> RecoverProduct(Guid Id, AppUser user);
        //Task<RepoBase> DeleteProduct(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllProduct(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllProduct(List<string> Ids, AppUser user);
        #endregion
        #endregion
       
    }
}
