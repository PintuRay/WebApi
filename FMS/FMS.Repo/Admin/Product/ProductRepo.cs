using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Product
{
    public class ProductRepo(Context ctx, IMapper mapper, IRedisCache cache) : IProductRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion     
        #region Product Type
        //public async Task<Result<ProductType>> GetProductTypes()
        //{
        //    Result<ProductType> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "ProductTypes";
        //        var cacheData = _cache.Get<Result<ProductType>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductTypes.ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Product Group
        #region Crud
        //public async Task<Result<ProductGroup>> GetProductGroups()
        //{
        //    Result<ProductGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "ProductGroups";
        //        var cacheData = _cache.Get<Result<ProductGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductGroups.Where(s => s.IsActive == true).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<ProductGroup>> GetProductGroups(Guid ProdutTypeId)
        //{
        //    Result<ProductGroup> _Result = new();
        //    try
        //    {
        //        var cacheKey = $"ProductGroups_{ProdutTypeId}";
        //        var cacheData = _cache.Get<Result<ProductGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductGroups.Where(p => p.Fk_ProductTypeId == ProdutTypeId && p.IsActive == true).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateProductGroup(ProductGroupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupName == data.ProductGroupName).FirstOrDefaultAsync();
        //        if (Query == null)
        //        {
        //            ProductGroup newProductGroup = _mapper.Map<ProductGroup>(data);
        //            newProductGroup.CreatedDate = DateTime.UtcNow;
        //            newProductGroup.CreatedBy = user.Name;
        //            await _ctx.ProductGroups.AddAsync(newProductGroup);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newProductGroup.ProductGroupId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupId == Id).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            ProductGroup updateProductGroup = _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveProductGroup(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupId == Id && s.IsActive == true).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<ProductGroup>> GetRemovedProductGroup()
        //{
        //    Result<ProductGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedProductGroups";
        //        var cacheData = _cache.Get<Result<ProductGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductGroups.Where(s => s.IsActive == false).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverProductGroup(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupId == Id && s.IsActive == false).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductGroups");
        //                _cache.Remove("RemovedProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteProductGroup(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductGroups.FirstOrDefaultAsync(x => x.ProductGroupId == Id && x.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.ProductGroups.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductGroups");
        //                _cache.Remove("RemovedProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllProductGroup(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var productGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var productGroupToRecover = await _ctx.ProductGroups.Where(x => productGroupIds.Contains(x.ProductGroupId) && x.IsActive == false).ToListAsync();
        //        if (productGroupToRecover.Any())
        //        {
        //            foreach (var productGroup in productGroupToRecover)
        //            {
        //                productGroup.ModifyDate = DateTime.UtcNow;
        //                productGroup.ModifyBy = user.Name;
        //                productGroup.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("ProductGroups");
        //                _cache.Remove("RemovedProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAllProductGroup(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var productGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var productGroupToRecover = await _ctx.ProductGroups.Where(x => productGroupIds.Contains(x.ProductGroupId) && x.IsActive == false).ToListAsync();
        //        if (productGroupToRecover.Any())
        //        {
        //            _ctx.ProductGroups.RemoveRange(productGroupToRecover);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("ProductGroups");
        //                _cache.Remove("RemovedProductGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        //public async Task<Result<ProductSubGroup>> GetProductSubGroups(Guid GroupId)
        //{
        //    Result<ProductSubGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"ProductSubGroups_{GroupId}";
        //        var cacheData = _cache.Get<Result<ProductSubGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductSubGroups.Where(s => s.Fk_ProductGroupId == GroupId && s.IsActive == true).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.Fk_ProductGroupId == data.Fk_ProductGroupId && s.ProductSubGroupName == data.ProductSubGroupName && s.IsActive == true);
        //        if (Query == null)
        //        {
        //            ProductSubGroup newSubGroup = _mapper.Map<ProductSubGroup>(data);
        //            newSubGroup.CreatedDate = DateTime.UtcNow;
        //            newSubGroup.CreatedBy = user.Name;
        //            await _ctx.ProductSubGroups.AddAsync(newSubGroup);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newSubGroup.ProductSubGroupId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            ProductSubGroup updateProductSubGroup = _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            _Result.Count = Count.ToString();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveProductSubGroup(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<ProductSubGroup>> GetRemovedProductSubGroup()
        //{
        //    Result<ProductSubGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"RemovedProductSubGroup";
        //        var cacheData = _cache.Get<Result<ProductSubGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductSubGroups.Where(s => s.IsActive == false).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverProductSubGroup(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //                _cache.Remove("RemovedProductSubGroup");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteProductSubGroup(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.ProductSubGroups.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //                _cache.Remove("RemovedProductSubGroup");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var subGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var subGroupToRecover = await _ctx.ProductSubGroups.Where(x => subGroupIds.Contains(x.ProductSubGroupId) && x.IsActive == false).ToListAsync();
        //        if (subGroupToRecover.Any())
        //        {
        //            foreach (var subGroup in subGroupToRecover)
        //            {
        //                subGroup.ModifyDate = DateTime.UtcNow;
        //                subGroup.ModifyBy = user.Name;
        //                subGroup.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //                _cache.Remove("RemovedProductSubGroup");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;

        //}
        //public async Task<RepoBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var subGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var subGroupToDelete = await _ctx.ProductSubGroups.Where(x => subGroupIds.Contains(x.ProductSubGroupId) && x.IsActive == false).ToListAsync();
        //        if (subGroupToDelete.Any())
        //        {
        //            _ctx.ProductSubGroups.RemoveRange(subGroupToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("ProductSubGroups");
        //                _cache.Remove("RemovedProductSubGroup");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
        #region Unit
        #region Crud
        //public async Task<Result<Unit>> GetAllUnits()
        //{
        //    Result<Unit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "Units";
        //        var cacheData = _cache.Get<Result<Unit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await (from s in _ctx.Units where s.IsActive == true select s).OrderBy(s => s.UnitName).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateUnit(UnitModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = _ctx.Units.Where(s => s.UnitName == data.UnitName && s.IsActive == true).SingleOrDefaultAsync();
        //        if (Query == null)
        //        {
        //            var newUnit = _mapper.Map<Unit>(data);
        //            newUnit.CreatedDate = DateTime.UtcNow;
        //            newUnit.CreatedBy = user.Name;
        //            await _ctx.Units.AddAsync(newUnit);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newUnit.UnitId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateUnit(Guid Id, UnitModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == true).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            _Result.Count = Count.ToString();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveUnit(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == true).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<Unit>> GetRemovedUnits()
        //{
        //    Result<Unit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedUnits";
        //        var cacheData = _cache.Get<Result<Unit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await (from s in _ctx.Units where s.IsActive == true select s).OrderBy(s => s.UnitName).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverUnit(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == false).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("RemovedUnits");
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteUnit(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == false).SingleOrDefaultAsync();
        //        if (Query != null)
        //        {
        //            _ctx.Units.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("RemovedUnits");
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllUnit(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var unitIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var unitToRecover = await _ctx.Units.Where(x => unitIds.Contains(x.UnitId) && x.IsActive == false).ToListAsync();
        //        if (unitToRecover.Any())
        //        {
        //            foreach (var unit in unitToRecover)
        //            {
        //                unit.ModifyDate = DateTime.UtcNow;
        //                unit.ModifyBy = user.Name;
        //                unit.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("RemovedUnits");
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAllUnit(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var unitIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var unitToDelete = await _ctx.Units.Where(x => unitIds.Contains(x.UnitId) && x.IsActive == false).ToListAsync();
        //        if (unitToDelete.Any())
        //        {
        //            _ctx.Units.RemoveRange(unitToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("RemovedUnits");
        //                _cache.Remove("Units");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
        #region Alternate Units
        #region Crud
        //public async Task<Result<AlternateUnit>> GetAlternateUnits()
        //{
        //    Result<AlternateUnit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "AlternateUnits";
        //        var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.AlternateUnits.Where(s => s.IsActive == false).Select(s => new AlternateUnit
        //            {
        //                AlternateUnitId = s.AlternateUnitId,
        //                AlternateUnitName = s.AlternateUnitName,
        //                AlternateQuantity = s.AlternateQuantity,
        //                Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null,
        //                UnitQuantity = s.UnitQuantity,
        //                Product = s.Product != null ? new Db.Entity.Product() { ProductName = s.Product.ProductName } : null,
        //            }).ToListAsync();

        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<AlternateUnit>> GetAlternateUnitByUnitId(Guid UnitId)
        //{
        //    Result<AlternateUnit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"AlternateUnits_{UnitId}";
        //        var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.AlternateUnits.Where(s => s.Fk_UnitId == UnitId).Select(s => new AlternateUnit
        //            {
        //                AlternateUnitId = s.AlternateUnitId,
        //                AlternateUnitName = s.AlternateUnitName,
        //                AlternateQuantity = s.AlternateQuantity,
        //                Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null,
        //                UnitQuantity = s.UnitQuantity,
        //                Product = s.Product != null ? new Db.Entity.Product() { ProductName = s.Product.ProductName } : null,
        //            }).ToListAsync();

        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<AlternateUnit>> GetAlternateUnitByProductId(Guid ProductId)
        //{
        //    Result<AlternateUnit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"AlternateUnits_{ProductId}";
        //        var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.AlternateUnits.Where(s => s.FK_ProductId == ProductId).Select(s => new AlternateUnit
        //            {
        //                AlternateUnitId = s.AlternateUnitId,
        //                AlternateUnitName = s.AlternateUnitName,
        //            }).ToListAsync();

        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<AlternateUnit>> GetAlternateUnitByAlternateUnitId(Guid AlternateUnitId)
        //{
        //    Result<AlternateUnit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"AlternateUnits_{AlternateUnitId}";
        //        var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.AlternateUnits.Where(s => s.AlternateUnitId == AlternateUnitId).Select(s => new AlternateUnit
        //            {
        //                Unit = new Unit { UnitName = s.Unit.UnitName },
        //                UnitQuantity = s.UnitQuantity,
        //            }).SingleOrDefaultAsync();

        //            if (Query != null)
        //            {
        //                _Result.SingleObjData = Query;
        //                //_Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await (from s in _ctx.AlternateUnits where s.Fk_UnitId == data.Fk_UnitId && s.AlternateUnitName == data.AlternateUnitName && s.IsActive == true select s).SingleOrDefaultAsync();
        //        if (Query == null)
        //        {
        //            var newAlternateUnit = _mapper.Map<AlternateUnit>(data);
        //            newAlternateUnit.CreatedDate = DateTime.UtcNow;
        //            newAlternateUnit.CreatedBy = user.Name;
        //            await _ctx.AlternateUnits.AddAsync(newAlternateUnit);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newAlternateUnit.AlternateUnitId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("AlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("AlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveAlternateUnit(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("AlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<AlternateUnit>> GetRemovedAlternateUnits()
        //{
        //    Result<AlternateUnit> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedAlternateUnits";
        //        var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.AlternateUnits.Where(s => s.IsActive == false).Select(s => new AlternateUnit
        //            {
        //                AlternateUnitId = s.AlternateUnitId,
        //                AlternateUnitName = s.AlternateUnitName,
        //                AlternateQuantity = s.AlternateQuantity,
        //                Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null,
        //                UnitQuantity = s.UnitQuantity,
        //                Product = s.Product != null ? new Db.Entity.Product() { ProductName = s.Product.ProductName } : null,
        //            }).ToListAsync();

        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAlternateUnit(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("AlternateUnits");
        //                _cache.Remove("RemovedAlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAlternateUnit(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.AlternateUnits.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("AlternateUnits");
        //                _cache.Remove("RemovedAlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var alternateUnitIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var alternateUnitToRecover = await _ctx.AlternateUnits.Where(x => alternateUnitIds.Contains(x.AlternateUnitId) && x.IsActive == false).ToListAsync();
        //        if (alternateUnitToRecover.Any())
        //        {
        //            foreach (var alternateUnit in alternateUnitToRecover)
        //            {
        //                alternateUnit.ModifyDate = DateTime.UtcNow;
        //                alternateUnit.ModifyBy = user.Name;
        //                alternateUnit.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("AlternateUnits");
        //                _cache.Remove("RemovedAlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var alternateUnitIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var alternateUnitToDelete = await _ctx.AlternateUnits.Where(x => alternateUnitIds.Contains(x.AlternateUnitId) && x.IsActive == false).ToListAsync();
        //        if (alternateUnitToDelete.Any())
        //        {
        //            _ctx.AlternateUnits.RemoveRange(alternateUnitToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("AlternateUnits");
        //                _cache.Remove("RemovedAlternateUnits");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
        #region Product
        #region Crud
        //public async Task<Result<Db.Entity.Product>> GetAllProducts()
        //{
        //    Result<Db.Entity.Product> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "Products";
        //        var cacheData = _cache.Get<Result<Db.Entity.Product>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.Products.Select(s =>
        //                          new Db.Entity.Product()
        //                          {
        //                              ProductId = s.ProductId,
        //                              ProductName = s.ProductName,
        //                              RetailPrice = s.RetailPrice,
        //                              WholeSalePrice = s.WholeSalePrice,
        //                              GST = s.GST,
        //                              ProductGroup = s.ProductGroup != null ? new ProductGroup { ProductGroupName = s.ProductGroup.ProductGroupName } : null,
        //                              ProductSubGroup = s.ProductSubGroup != null ? new ProductSubGroup { ProductSubGroupName = s.ProductSubGroup.ProductSubGroupName } : null,
        //                              Unit = s.Unit != null ? new Unit { UnitName = s.Unit.UnitName } : null,
        //                              ProductType = s.ProductType != null ? new ProductType { Product_Type = s.ProductType.Product_Type } : null,
        //                          }).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<Db.Entity.Product>> GetProductById(Guid ProductId)
        //{
        //    Result<Db.Entity.Product> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"Products_{ProductId}";
        //        var cacheData = _cache.Get<Result<Db.Entity.Product>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.Products.Where(s => s.ProductId == ProductId).Select(s => new Db.Entity.Product
        //            {
        //                ProductId = s.ProductId,
        //                ProductName = s.ProductName,
        //                Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName, UnitId = s.Unit.UnitId } : null,
        //            }).SingleOrDefaultAsync();

        //            if (Query != null)
        //            {
        //                _Result.SingleObjData = Query;
        //                //_Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<Db.Entity.Product>> GetProductByTypeId(Guid ProductTypeId)
        //{
        //    Result<Db.Entity.Product> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"Products_{ProductTypeId}";
        //        var cacheData = _cache.Get<Result<Db.Entity.Product>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.Products.Where(s => s.Fk_ProductTypeId == ProductTypeId).Select(s => new Db.Entity.Product { ProductId = s.ProductId, ProductName = s.ProductName }).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<Db.Entity.Product>> GetProductGstWithRate(Guid id, string RateType)
        //{
        //    Result<Db.Entity.Product> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"Products_{RateType}";
        //        var cacheData = _cache.Get<Result<Db.Entity.Product>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.Products.Where(s => s.ProductId == id)
        //                   .Select(s => new Db.Entity.Product
        //                   {
        //                       Price = RateType == "wholesalerate" ? Convert.ToDecimal(s.WholeSalePrice) : s.Price,
        //                       GST = s.GST,
        //                       ProductName = s.ProductName,
        //                       Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null
        //                   }).SingleOrDefaultAsync();
        //            if (Query != null)
        //            {
        //                _Result.SingleObjData = Query;
        //                // _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateProduct(ProductModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.Fk_ProductGroupId == data.Fk_ProductGroupId && s.Fk_ProductTypeId == data.Fk_ProductTypeId && s.ProductName == data.ProductName);
        //        if (Query == null)
        //        {
        //            var newProduct = _mapper.Map<Db.Entity.Product>(data);
        //            newProduct.CreatedDate = DateTime.UtcNow;
        //            newProduct.CreatedBy = user.Name;
        //            await _ctx.Products.AddAsync(newProduct);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newProduct.ProductId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Products");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateProduct(Guid Id, ProductModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Products");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveProduct(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Products");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<Db.Entity.Product>> GetRemovedProduct()
        //{
        //    Result<Db.Entity.Product> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedProducts";
        //        var cacheData = _cache.Get<Result<Db.Entity.Product>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.Products.Select(s =>
        //                          new Db.Entity.Product()
        //                          {
        //                              ProductId = s.ProductId,
        //                              ProductName = s.ProductName,
        //                              RetailPrice = s.RetailPrice,
        //                              WholeSalePrice = s.WholeSalePrice,
        //                              GST = s.GST,
        //                              ProductGroup = s.ProductGroup != null ? new ProductGroup { ProductGroupName = s.ProductGroup.ProductGroupName } : null,
        //                              ProductSubGroup = s.ProductSubGroup != null ? new ProductSubGroup { ProductSubGroupName = s.ProductSubGroup.ProductSubGroupName } : null,
        //                              Unit = s.Unit != null ? new Unit { UnitName = s.Unit.UnitName } : null,
        //                              ProductType = s.ProductType != null ? new ProductType { Product_Type = s.ProductType.Product_Type } : null,
        //                          }).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverProduct(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Products");
        //                _cache.Remove("RemovedProducts");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteProduct(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.Products.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Products");
        //                _cache.Remove("RemovedProducts");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllProduct(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var productIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var productToRecover = await _ctx.Products.Where(x => productIds.Contains(x.ProductId) && x.IsActive == false).ToListAsync();
        //        if (productToRecover.Any())
        //        {
        //            foreach (var product in productToRecover)
        //            {
        //                product.ModifyDate = DateTime.UtcNow;
        //                product.ModifyBy = user.Name;
        //                product.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("Products");
        //                _cache.Remove("RemovedProducts");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAllProduct(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var productIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var productToDelete = await _ctx.Products.Where(x => productIds.Contains(x.ProductId) && x.IsActive == false).ToListAsync();
        //        if (productToDelete.Any())
        //        {
        //            _ctx.Products.RemoveRange(productToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("Products");
        //                _cache.Remove("RemovedProducts");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
       
    }
}
