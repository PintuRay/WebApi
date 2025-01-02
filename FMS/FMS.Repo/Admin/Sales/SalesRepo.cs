using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Sales
{
    public class SalesRepo(Context ctx, IMapper mapper, IRedisCache cache) : ISalesRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region  Sales 
        #region Crud
        //public async Task<Result<SalesOrderSetup>> GetSales()
        //{
        //    Result<SalesOrderSetup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "Sales";
        //        var cacheData = _cache.Get<Result<SalesOrderSetup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.SalesOrderSetups.Where(s => s.IsActive == true).Select(s => new SalesOrderSetup
        //            {
        //                SalesOrderSetupId = s.SalesOrderSetupId,
        //                FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
        //                SalesTransactionSetups = s.SalesTransactionSetups.Select(st => new SalesTransactionSetup
        //                {
        //                    SubFinishedGoodName = _ctx.Products.Where(p => p.ProductId == st.Fk_SubFinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
        //                    Quantity = st.Quantity,
        //                    Unit = st.Unit,
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
        //public async Task<RepoBase> CreateSales(SalesOrderSetupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.SalesOrderSetups.SingleOrDefaultAsync(s => s.Fk_FinishedGoodId == data.Fk_FinishedGoodId && s.IsActive == true);
        //        if (Query == null)
        //        {
        //            var newSalesOrder = _mapper.Map<SalesOrderSetup>(data);
        //            newSalesOrder.CreatedDate = DateTime.UtcNow;
        //            newSalesOrder.CreatedBy = user.Name;
        //            if (data.SalesTransactionSetups.Count > 0)
        //            {
        //                newSalesOrder.SalesTransactionSetups = data.SalesTransactionSetups.Select(s =>
        //                {
        //                    var newSalesTransaction = _mapper.Map<SalesTransactionSetup>(s);
        //                    newSalesTransaction.CreatedDate = DateTime.UtcNow;
        //                    newSalesTransaction.CreatedBy = user.Name;
        //                    return newSalesTransaction;
        //                }).ToList();
        //            }
        //            await _ctx.SalesOrderSetups.AddAsync(newSalesOrder);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newSalesOrder.SalesOrderSetupId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Sales");
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
        //public async Task<RepoBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).SingleOrDefaultAsync(s => s.SalesOrderSetupId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            // Add new transactions and update existing ones
        //            var existingTransactions = Query.SalesTransactionSetups.ToList();
        //            var updatedTransactions = data.SalesTransactionSetups.ToList();
        //            foreach (var updatedTransaction in updatedTransactions)
        //            {
        //                var existingTransaction = existingTransactions.SingleOrDefault(et => et.SalesTransactionSetupId == updatedTransaction.SalesTransactionSetupId);
        //                if (existingTransaction != null)
        //                {
        //                    // Update existing transaction
        //                    _mapper.Map(updatedTransaction, existingTransaction);
        //                    existingTransaction.ModifyDate = DateTime.UtcNow;
        //                    existingTransaction.ModifyBy = user.Name;
        //                }
        //                else
        //                {
        //                    // Add new transaction
        //                    var newTransaction = _mapper.Map<SalesTransactionSetup>(updatedTransaction);
        //                    newTransaction.CreatedDate = DateTime.UtcNow;
        //                    newTransaction.CreatedBy = user.Name;
        //                    Query.SalesTransactionSetups.Add(newTransaction);
        //                }
        //            }
        //            // Remove deleted transactions
        //            foreach (var existingTransaction in existingTransactions)
        //            {
        //                if (!updatedTransactions.Any(ut => ut.SalesTransactionSetupId == existingTransaction.SalesTransactionSetupId))
        //                {
        //                    _ctx.SalesTransactionSetups.Remove(existingTransaction);
        //                }
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            _Result.Count = Count.ToString();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Sales");
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
        //public async Task<RepoBase> RemoveSales(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).SingleOrDefaultAsync(s => s.SalesOrderSetupId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            // Update related SalesTransactionSetups
        //            foreach (var existingTransaction in Query.SalesTransactionSetups)
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
        //                _cache.Remove("Sales");
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
        //public async Task<Result<SalesOrderSetup>> GetRemovedSales()
        //{
        //    Result<SalesOrderSetup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedSales";
        //        var cacheData = _cache.Get<Result<SalesOrderSetup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.SalesOrderSetups.Where(s => s.IsActive == true).Select(s => new SalesOrderSetup
        //            {
        //                SalesOrderSetupId = s.SalesOrderSetupId,
        //                FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
        //                SalesTransactionSetups = s.SalesTransactionSetups.Select(st => new SalesTransactionSetup
        //                {
        //                    SubFinishedGoodName = _ctx.Products.Where(p => p.ProductId == st.Fk_SubFinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
        //                    Quantity = st.Quantity,
        //                    Unit = st.Unit,
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
        //public async Task<RepoBase> RecoverSales(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).SingleOrDefaultAsync(s => s.SalesOrderSetupId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            // Update related SalesTransactionSetups
        //            foreach (var existingTransaction in Query.SalesTransactionSetups)
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
        //                _cache.Remove("Sales");
        //                _cache.Remove("RemovedSales");
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
        //public async Task<RepoBase> DeleteSales(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == false);
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
        //                _cache.Remove("Sales");
        //                _cache.Remove("RemovedSales");
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
        //public async Task<RepoBase> RecoverAllSales(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var SalesIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var SalesToRecover = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).Where(x => SalesIds.Contains(x.SalesOrderSetupId) && x.IsActive == false).ToListAsync();
        //        if (SalesToRecover.Any())
        //        {
        //            foreach (var Sale in SalesToRecover)
        //            {
        //                Sale.ModifyDate = DateTime.UtcNow;
        //                Sale.ModifyBy = user.Name;
        //                Sale.IsActive = true;
        //                // Update related SalesTransactionSetups
        //                foreach (var SaleTransaction in Sale.SalesTransactionSetups)
        //                {
        //                    SaleTransaction.ModifyDate = DateTime.UtcNow;
        //                    SaleTransaction.ModifyBy = user.Name;
        //                    SaleTransaction.IsActive = true;
        //                }
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Sales");
        //                _cache.Remove("RemovedSales");
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
        //public async Task<RepoBase> DeleteAllSales(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var SalesIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var SalesToDelete = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).Where(x => SalesIds.Contains(x.SalesOrderSetupId) && x.IsActive == false).ToListAsync();
        //        if (SalesToDelete.Any())
        //        {
        //            _ctx.SalesOrderSetups.RemoveRange(SalesToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("Sales");
        //                _cache.Remove("RemovedSales");
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
