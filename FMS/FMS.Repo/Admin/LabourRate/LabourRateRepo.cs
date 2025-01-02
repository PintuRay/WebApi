using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.LabourRate
{
    public class LabourRateRepo(Context ctx, IMapper mapper, IRedisCache cache) : ILabourRateRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Labour Rate
        #region Crud
        //public async Task<Result<Db.Entity.LabourRate>> GetAllLabourRates(Guid FinancialYearId, Guid BranchId)
        //{
        //    Result<Db.Entity.LabourRate> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "LabourRates";
        //        var cacheData = _cache.Get<Result<Db.Entity.LabourRate>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.LabourRates.Where(s => s.Fk_FinancialYearId == FinancialYearId && s.Fk_BranchId == BranchId && s.IsActive == true)
        //                       .Select(lr => new Db.Entity.LabourRate
        //                       {
        //                           LabourRateId = lr.LabourRateId,
        //                           Date = lr.Date,
        //                           ProductType = lr.ProductType ?? new ProductType { Product_Type = lr.ProductType.Product_Type },
        //                           Product = lr.Product ?? new Db.Entity.Product { ProductName = lr.Product.ProductName },
        //                           Rate = lr.Rate
        //                       }).ToListAsync();
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
        //public async Task<RepoBase> CreateLabourRate(LabourRateModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var newLabourRate = _mapper.Map<Db.Entity.LabourRate>(data);
        //        newLabourRate.CreatedDate = DateTime.UtcNow;
        //        newLabourRate.CreatedBy = user.Name;
        //        await _ctx.LabourRates.AddAsync(newLabourRate);
        //        int Count = await _ctx.SaveChangesAsync();
        //        if (Count > 0)
        //        {
        //            _Result.Id = newLabourRate.LabourRateId.ToString();
        //            _Result.Count = Count.ToString();
        //            _Result.IsSucess = true;
        //            _cache.Remove("LabourRates");
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == true);
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
        //                _cache.Remove("LabourRates");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveLabourRate(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == true);
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
        //                _cache.Remove("LabourRates");
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
        //public async Task<Result<Db.Entity.LabourRate>> GetRemovedLabourRate(Guid FinancialYearId, Guid BranchId)
        //{
        //    Result<Db.Entity.LabourRate> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemoveLabourRates";
        //        var cacheData = _cache.Get<Result<Db.Entity.LabourRate>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.LabourRates.Where(s => s.Fk_FinancialYearId == FinancialYearId && s.Fk_BranchId == BranchId && s.IsActive == true)
        //                       .Select(lr => new Db.Entity.LabourRate
        //                       {
        //                           LabourRateId = lr.LabourRateId,
        //                           Date = lr.Date,
        //                           ProductType = lr.ProductType ?? new ProductType { Product_Type = lr.ProductType.Product_Type },
        //                           Product = lr.Product ?? new Db.Entity.Product { ProductName = lr.Product.ProductName },
        //                           Rate = lr.Rate
        //                       }).ToListAsync();
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
        //public async Task<RepoBase> RecoverLabourRate(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == false);
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
        //                _cache.Remove("LabourRates");
        //                _cache.Remove("RemoveLabourRates");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteLabourRate(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.LabourRates.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("LabourRates");
        //                _cache.Remove("RemoveLabourRates");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllLabourRate(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var labourRateIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var labourRateToRecover = await _ctx.LabourRates.Where(x => labourRateIds.Contains(x.LabourRateId) && x.IsActive == false).ToListAsync();
        //        if (labourRateToRecover.Any())
        //        {
        //            foreach (var labourRate in labourRateToRecover)
        //            {
        //                labourRate.ModifyDate = DateTime.UtcNow;
        //                labourRate.ModifyBy = user.Name;
        //                labourRate.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("LabourRates");
        //                _cache.Remove("RemoveLabourRates");
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
        //public async Task<RepoBase> DeleteAllLabourRate(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var labourRateIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var labourRateToDelete = await _ctx.LabourRates.Where(x => labourRateIds.Contains(x.LabourRateId) && x.IsActive == false).ToListAsync();
        //        if (labourRateToDelete.Any())
        //        {
        //            _ctx.LabourRates.RemoveRange(labourRateToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.Remove("LabourRates");
        //                _cache.Remove("RemoveLabourRates");
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
