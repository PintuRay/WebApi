using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Production
{
    public class ProductionRepo(Context ctx, IMapper mapper, IRedisCache cache) : IProductionRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Production
        #region Crud
        //public async Task<Result<ProductionOrder>> GetProduction()
        //{
        //    Result<ProductionOrder> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "Production";
        //        var cacheData = _cache.Get<Result<ProductionOrder>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductionOrders.Where(s => s.IsActive == true).Select(s => new ProductionOrder
        //            {
        //                ProductionOrderId = s.ProductionOrderId,
        //                Fk_FinishedGoodId = s.Fk_FinishedGoodId,
        //                FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
        //                ProductionTransactions = s.ProductionTransactions.Select(pt => new ProductionTransaction
        //                {
        //                    ProductionTransactionId = pt.ProductionTransactionId,
        //                    RawMaterialName = _ctx.Products.Where(p => p.ProductId == pt.Fk_RawMaterialId).Select(s => s.ProductName).SingleOrDefault(),
        //                    Quantity = pt.Quantity,
        //                    Unit = pt.Unit,
        //                }).ToList()
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
        //public async Task<RepoBase> CreateProduction(ProductionOrderModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductionOrders.SingleOrDefaultAsync(s => s.Fk_FinishedGoodId == data.Fk_FinishedGoodId && s.IsActive == true);
        //        if (Query == null)
        //        {
        //            ProductionOrder newProduction = _mapper.Map<ProductionOrder>(data);
        //            newProduction.CreatedDate = DateTime.UtcNow;
        //            newProduction.CreatedBy = user.Name;
        //            if (data.ProductionTransactions.Count > 0)
        //            {
        //                newProduction.ProductionTransactions = data.ProductionTransactions.Select(s =>
        //                {
        //                    var newProductionTransaction = _mapper.Map<ProductionTransaction>(s);
        //                    newProductionTransaction.CreatedDate = DateTime.UtcNow;
        //                    newProductionTransaction.CreatedBy = user.Name;
        //                    return newProductionTransaction;
        //                }).ToList();
        //            }
        //            await _ctx.ProductionOrders.AddAsync(newProduction);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newProduction.ProductionOrderId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
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
        //public async Task<RepoBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            // Add new transactions and update existing ones
        //            var existingTransactions = Query.ProductionTransactions.ToList();
        //            var updatedTransactions = data.ProductionTransactions.ToList();
        //            foreach (var updatedTransaction in updatedTransactions)
        //            {
        //                var existingTransaction = existingTransactions.FirstOrDefault(et => et.ProductionTransactionId == updatedTransaction.ProductionTransactionId);
        //                if (existingTransaction != null)
        //                { // Update existing transaction
        //                    _mapper.Map(updatedTransaction, existingTransaction);
        //                    existingTransaction.ModifyDate = DateTime.UtcNow;
        //                    existingTransaction.ModifyBy = user.Name;
        //                }
        //                else
        //                {
        //                    // Add new transaction
        //                    var newTransaction = _mapper.Map<ProductionTransaction>(updatedTransaction);
        //                    newTransaction.CreatedDate = DateTime.UtcNow;
        //                    newTransaction.CreatedBy = user.Name;
        //                    Query.ProductionTransactions.Add(newTransaction);
        //                }
        //            }
        //            // Remove deleted transactions
        //            foreach (var existingTransaction in existingTransactions)
        //            {
        //                if (!updatedTransactions.Any(ut => ut.ProductionTransactionId == existingTransaction.ProductionTransactionId))
        //                {
        //                    _ctx.ProductionTransactions.Remove(existingTransaction);
        //                }
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
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
        //public async Task<RepoBase> RemoveProduction(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            // Update related ProductionTransactions
        //            foreach (var existingTransaction in Query.ProductionTransactions)
        //            {
        //                existingTransaction.ModifyDate = DateTime.UtcNow;
        //                existingTransaction.ModifyBy = user.Name;
        //                existingTransaction.IsActive = false;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
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
        #region Recover
        //public async Task<Result<ProductionOrder>> GetRemovedProduction()
        //{
        //    Result<ProductionOrder> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedProductions";
        //        var cacheData = _cache.Get<Result<ProductionOrder>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.ProductionOrders.Where(s => s.IsActive == false).Select(s => new ProductionOrder
        //            {
        //                ProductionOrderId = s.ProductionOrderId,
        //                Fk_FinishedGoodId = s.Fk_FinishedGoodId,
        //                FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
        //                ProductionTransactions = s.ProductionTransactions.Select(pt => new ProductionTransaction
        //                {
        //                    ProductionTransactionId = pt.ProductionTransactionId,
        //                    RawMaterialName = _ctx.Products.Where(p => p.ProductId == pt.Fk_RawMaterialId).Select(s => s.ProductName).SingleOrDefault(),
        //                    Quantity = pt.Quantity,
        //                    Unit = pt.Unit,
        //                }).ToList()
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
        //public async Task<RepoBase> RecoverProduction(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            // Update related ProductionTransactions
        //            foreach (var existingTransaction in Query.ProductionTransactions)
        //            {
        //                existingTransaction.ModifyDate = DateTime.UtcNow;
        //                existingTransaction.ModifyBy = user.Name;
        //                existingTransaction.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
        //                _cache.Remove("RemovedProductions");
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
        //public async Task<RepoBase> DeleteProduction(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(po => po.ProductionOrderId == Id && po.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.ProductionOrders.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
        //                _cache.Remove("RemovedProductions");
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
        //public async Task<RepoBase> RecoverAllProduction(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var ProductionIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var ProductionToRecover = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).Where(x => ProductionIds.Contains(x.ProductionOrderId) && x.IsActive == false).ToListAsync();
        //        if (ProductionToRecover.Any())
        //        {
        //            foreach (var production in ProductionToRecover)
        //            {
        //                production.ModifyDate = DateTime.UtcNow;
        //                production.ModifyBy = user.Name;
        //                production.IsActive = true;
        //                // Update related ProductionTransactions
        //                foreach (var productionTransaction in production.ProductionTransactions)
        //                {
        //                    productionTransaction.ModifyDate = DateTime.UtcNow;
        //                    productionTransaction.ModifyBy = user.Name;
        //                    productionTransaction.IsActive = true;
        //                }
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
        //                _cache.Remove("RemovedProductions");
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
        //public async Task<RepoBase> DeleteAllProduction(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var ProductionIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var ProductionToDelete = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).Where(x => ProductionIds.Contains(x.ProductionOrderId) && x.IsActive == false).ToListAsync();
        //        if (ProductionToDelete.Any())
        //        {
        //            _ctx.ProductionOrders.RemoveRange(ProductionToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Production");
        //                _cache.Remove("RemovedProductions");
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
