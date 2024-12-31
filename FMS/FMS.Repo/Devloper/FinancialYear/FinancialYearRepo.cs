using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.Repo.Devloper.FinancialYear
{
    public class FinancialYearRepo(Context ctx, IMapper mapper, IRedisCache cache) : IFinancialYearRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Financial Year
        #region Crud
        public async Task<Result<Db.Entity.FinancialYear>> GetFinancialYears(PaginationParams pagination)
        {
            Result<Db.Entity.FinancialYear> _Result = new();

            try
            {
                _Result.IsSucess = false;
                string cacheKey = pagination.PageNumber > 0 && pagination.PageSize > 0 ? $"FinancialYears_{pagination.PageNumber}_{pagination.PageSize}" : "FinancialYears";
                var cacheData = _cache.Get<Result<Db.Entity.FinancialYear>>(cacheKey);
                if (cacheData == null)
                {
                    int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                    var Query = await _ctx.FinancialYears.Where(s => s.IsActive == true).
                                   Select(s => new Db.Entity.FinancialYear
                                   {
                                       FinancialYearId = s.FinancialYearId,
                                       Financial_Year = s.Financial_Year,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                   }).OrderByDescending(s => s.Financial_Year)
                                         .Skip(pagination.PageNumber * effectivePageSize)
                                         .Take(effectivePageSize)
                                         .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.IsSucess = true;
                        _cache.Set(cacheKey, _Result, _cacheExpiration);
                    }
                    else
                    {
                        _Result = cacheData;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> CreateFinancialYear(FinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(s => s.Financial_Year == data.Financial_Year && s.IsActive == true);
                if (Query == null)
                {
                    var newFinancialYear = _mapper.Map<Db.Entity.FinancialYear>(data);
                    newFinancialYear.CreatedDate = DateTime.UtcNow;
                    newFinancialYear.CreatedBy = user.Name;
                    await _ctx.FinancialYears.AddAsync(newFinancialYear);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newFinancialYear.FinancialYearId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkCreateFinancialYear(List<FinancialYearModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var financialYearNames = dataList.Select(b => b.Financial_Year).ToList();
                var existingfinancialYearNames = await _ctx.FinancialYears.Where(f => f.IsActive == true && financialYearNames.Contains(f.Financial_Year)).Select(b => b.Financial_Year).ToListAsync();
                if (existingfinancialYearNames.Count == 0)
                {
                    var newFinancialYears = dataList.Select(data =>
                    {
                        var financialYear = _mapper.Map<Db.Entity.FinancialYear>(data);
                        financialYear.CreatedDate = DateTime.UtcNow;
                        financialYear.CreatedBy = user.Name;
                        return financialYear;
                    }).ToList();
                    await _ctx.FinancialYears.AddRangeAsync(newFinancialYears);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = newFinancialYears.Select(b => b.FinancialYearId.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("FinancialYears");
                    }
                }
                else
                {
                    _Result.Data = existingfinancialYearNames;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(s => s.Financial_Year == data.Financial_Year && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkUpdateFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var financialYearIds = dataList.Select(s => s.FinancialYearId).ToList();
                var financialYearDict = await _ctx.FinancialYears.Where(b => b.IsActive == true && financialYearIds.Contains(b.FinancialYearId)).ToDictionaryAsync(b => b.FinancialYearId, b => b.Financial_Year);
                var notFoundfinancialYearIds = financialYearIds.Except(financialYearDict.Keys).ToList();
                if (notFoundfinancialYearIds.Count == 0)
                {
                    var financialYearToUpdate = await _ctx.FinancialYears.Where(b => b.IsActive == true && financialYearIds.Contains(b.FinancialYearId)).ToListAsync();
                    foreach (var financialYear in financialYearToUpdate)
                    {
                        var updateData = dataList.First(u => u.FinancialYearId == financialYear.FinancialYearId);
                        _mapper.Map(updateData, financialYear);
                        financialYear.ModifyDate = DateTime.UtcNow;
                        financialYear.ModifyBy = user.Name;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = financialYearIds.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("FinancialYears");
                    }
                }
                else
                {
                    _Result.Data = financialYearDict.Where(kvp => notFoundfinancialYearIds.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Id && x.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRemoveFinancialYear(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingFinancialYearIds = await _ctx.FinancialYears.Where(b => b.IsActive == true && Ids.Contains(b.FinancialYearId)).Select(b => b.FinancialYearId).ToListAsync();
                var notFoundFinancialYearIds = Ids.Except(existingFinancialYearIds).ToList();
                if (notFoundFinancialYearIds.Count == 0)
                {
                    #region Update Related Entity
                    await _ctx.BranchFinancialYears.Where(bf => Ids.Contains(bf.Fk_BranchId) && bf.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.Companies.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.UserBranches.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.LabourRates.Where(c => Ids.Contains((Guid)c.Fk_BranchId) && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    #endregion
                    int Count = await _ctx.FinancialYears.Where(x => Ids.Contains(x.FinancialYearId) && x.IsActive == true)
                             .ExecuteUpdateAsync(s => s
                                 .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                                 .SetProperty(p => p.ModifyBy, user.Name)
                                 .SetProperty(p => p.IsActive, false)
                             );
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("FinancialYears");
                    }
                }
                else
                {
                    _Result.Ids = notFoundFinancialYearIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.FinancialYear>> GetRemovedFinancialYears(PaginationParams pagination)
        {
            Result<Db.Entity.FinancialYear> _Result = new();
            List<Db.Entity.FinancialYear> Query = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = pagination.PageNumber > 0 && pagination.PageSize > 0 ? $"RecoverFinancialYears_{pagination.PageNumber}_{pagination.PageSize}" : "RecoverFinancialYears";
                var cacheData = _cache.Get<Result<Db.Entity.FinancialYear>>(cacheKey);
                if (cacheData == null)
                {
                    int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                    Query = await _ctx.FinancialYears.Where(s => s.IsActive == false).
                                   Select(s => new Db.Entity.FinancialYear
                                   {
                                       FinancialYearId = s.FinancialYearId,
                                       Financial_Year = s.Financial_Year,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                   })
                                         .OrderByDescending(s => s.Financial_Year)
                                         .Skip(pagination.PageNumber * effectivePageSize)
                                         .Take(effectivePageSize)
                                         .ToListAsync();


                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.IsSucess = true;
                        _cache.Set(cacheKey, _Result, _cacheExpiration);
                    }
                    else
                    {
                        _Result = cacheData;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears");
                        _cache.RemoveByPrefix("RecoverFinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.FinancialYears.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears");
                        _cache.RemoveByPrefix("RecoverFinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRecoverFinancialYear(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingFinancialYearIds = await _ctx.FinancialYears.Where(b => b.IsActive == false && Ids.Contains(b.FinancialYearId)).Select(b => b.FinancialYearId).ToListAsync();
                var notFoundFinancialYearIds = Ids.Except(existingFinancialYearIds).ToList();
                if (notFoundFinancialYearIds.Count == 0)
                {
                    #region Update Related Entity
                    var branchFinancialYears = await _ctx.BranchFinancialYears.Where(bf => Ids.Contains(bf.Fk_BranchId) && bf.IsActive == true).ToListAsync();
                    var companies = await _ctx.Companies.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == true).ToListAsync();
                    var userBranches = await _ctx.UserBranches.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == true).ToListAsync();
                    var labourRates = await _ctx.LabourRates.Where(c => Ids.Contains((Guid)c.Fk_BranchId) && c.IsActive == true).ToListAsync();
                    branchFinancialYears.ForEach(bf => bf.IsActive = false);
                    companies.ForEach(c => c.IsActive = false);
                    userBranches.ForEach(ub => ub.IsActive = false);
                    labourRates.ForEach(lr => lr.IsActive = false);
                    #endregion
                    var financialYearToRecover = await _ctx.FinancialYears.Where(x => Ids.Contains(x.FinancialYearId) && x.IsActive == false).ToListAsync();
                    financialYearToRecover.ForEach(financialyear => { 
                        financialyear.ModifyDate = DateTime.UtcNow; 
                        financialyear.ModifyBy = user.Name; 
                        financialyear.IsActive = false; 
                    });
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("FinancialYears");
                        _cache.RemoveByPrefix("RecoverFinancialYears");
                    }
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteFinancialYear(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingFinancialYearIds = await _ctx.FinancialYears.Where(b => b.IsActive == false && Ids.Contains(b.FinancialYearId)).Select(b => b.FinancialYearId).ToListAsync();
                var notFoundFinancialYearIds = Ids.Except(existingFinancialYearIds).ToList();
                if (notFoundFinancialYearIds.Count == 0)
                {
                    var financialYearToDelete = await _ctx.FinancialYears.Where(x => Ids.Contains(x.FinancialYearId) && x.IsActive == false).ToListAsync();
                    _ctx.FinancialYears.RemoveRange(financialYearToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("FinancialYears");
                        _cache.RemoveByPrefix("RecoverFinancialYears");
                    }
                }
                else
                {
                    _Result.Ids = notFoundFinancialYearIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return _Result;
        }
        #endregion
        #endregion
    }
}
