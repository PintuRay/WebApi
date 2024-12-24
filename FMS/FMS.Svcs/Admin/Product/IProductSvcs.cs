using FMS.Db.Entity;

namespace FMS.Svcs.Admin.Product
{
    public interface IProductSvcs
    {
        #region Product 
        #region Product Type
        Task<SvcsBase> GetProductTypes();
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
        Task<SvcsBase> GetProductSubGroups(Guid GroupId);
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
        #endregion
    }
}
