using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;

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
            List<Db.Entity.FinancialYear> Query = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = pagination.PageNumber > 0 && pagination.PageSize > 0 ? $"FinancialYears_{pagination.PageNumber}_{pagination.PageSize}" : "FinancialYears";
                var cacheData = _cache.Get<Result<Db.Entity.FinancialYear>>(cacheKey);
                if (cacheData == null)
                {

                    int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                    Query = await _ctx.FinancialYears.Where(s => s.IsActive == true).
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
        public async Task<RepoBase> RecoverAllFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var financialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var financialYearToRecover = await _ctx.FinancialYears.Where(x => financialYearIds.Contains(x.FinancialYearId) && x.IsActive == false).ToListAsync();
                if (financialYearToRecover.Any())
                {
                    foreach (var financialyear in financialYearToRecover)
                    {
                        financialyear.ModifyDate = DateTime.UtcNow;
                        financialyear.ModifyBy = user.Name;
                        financialyear.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
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
        public async Task<RepoBase> DeleteAllFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var financialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var financialYearToDelete = await _ctx.FinancialYears.Where(x => financialYearIds.Contains(x.FinancialYearId) && x.IsActive == false).ToListAsync();
                if (financialYearToDelete.Any())
                {
                    _ctx.FinancialYears.RemoveRange(financialYearToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
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
        #endregion
        #endregion
    }
}
