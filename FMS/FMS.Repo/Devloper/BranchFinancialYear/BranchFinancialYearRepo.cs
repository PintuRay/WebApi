﻿using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Devloper.BranchFinancialYear
{
    public class BranchFinancialYearRepo(Context ctx, IMapper mapper, IRedisCache cache) : IBranchFinancialYearRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Branch Financial Year
        #region Crud
        public async Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears(Guid BranchId)
        {
            Result<BranchFinancialYearDto> _Result = new();
            List<BranchFinancialYearDto> Query = [];
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"BranchFinancialYear_{BranchId}";
                var cacheData = _cache.Get<Result<BranchFinancialYearDto>>(cacheKey);
                if (cacheData == null)
                {
                    Query = await _ctx.BranchFinancialYears.
                                    Where(s => s.Fk_BranchId == BranchId && s.IsActive == true).Select(s => new BranchFinancialYearDto()
                                    {
                                        Fk_BranchId = s.Fk_BranchId,
                                        BranchName = s.Branch.BranchName,
                                        Fk_FinancialYearId = s.Fk_FinancialYearId,
                                      
                                    }).ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.IsSucess = true;
                        _cache.Set(cacheKey, _Result, _cacheExpiration);
                    }
                }
                else
                {
                    _Result = cacheData;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears(PaginationParams pagination)
        {
            Result<BranchFinancialYearDto> _Result = new();
            List<BranchFinancialYearDto> Query = [];
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                Query = await _ctx.BranchFinancialYears.
                                   Where(s => s.IsActive == true).
                                   Select(s => new BranchFinancialYearDto()
                                   {
                                       Fk_BranchId = s.Fk_BranchId,
                                       BranchName = s.Branch.BranchName,
                                       Fk_FinancialYearId = s.Fk_FinancialYearId,
                                      
                                   }).OrderByDescending(s => s.Fk_FinancialYearId)
                                   .Skip(pagination.PageNumber * effectivePageSize)
                                   .Take(effectivePageSize)
                                   .ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                    _Result.Count = Query.Count;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears where s.Fk_FinancialYearId == data.Fk_FinancialYearId && s.Fk_BranchId == data.Fk_BranchId select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newYear = _mapper.Map<Db.Entity.BranchFinancialYear>(data);
                    newYear.CreatedDate = DateTime.UtcNow;
                    newYear.CreatedBy = user.Name;
                    await _ctx.BranchFinancialYears.AddAsync(newYear);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newYear.BranchFinancialYearId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.BranchFinancialYearId == Id && s.IsActive == true);
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
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Id && x.IsActive == true);
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
                        _cache.RemoveByPrefix("BranchFinancialYear");
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
        public async Task<Result<BranchFinancialYearDto>> GetRemovedBranchFinancialYears(PaginationParams pagination)
        {
            Result<BranchFinancialYearDto> _Result = new();
            List<BranchFinancialYearDto> Query = [];
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                Query = await _ctx.BranchFinancialYears.
                                   Where(s => s.IsActive == false).
                                   Select(s => new BranchFinancialYearDto()
                                   {
                                       Fk_BranchId = s.Fk_BranchId,
                                       BranchName = s.Branch.BranchName,
                                       Fk_FinancialYearId = s.Fk_FinancialYearId,
                                      
                                   }).OrderByDescending(s => s.Fk_FinancialYearId)
                                   .Skip(pagination.PageNumber * effectivePageSize)
                                   .Take(effectivePageSize)
                                   .ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                    _Result.Count = Query.Count;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Id && x.IsActive == false);
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
                        _cache.RemoveByPrefix("BranchFinancialYear");
                        _cache.RemoveByPrefix("RemovedBranchFinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.BranchFinancialYears.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                        _cache.RemoveByPrefix("RemovedBranchFinancialYears");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchFinancialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var branchFinancialYearToRecover = await _ctx.BranchFinancialYears.Where(x => branchFinancialYearIds.Contains(x.BranchFinancialYearId) && x.IsActive == false).ToListAsync();
                if (branchFinancialYearToRecover.Any())
                {
                    foreach (var branchFinancialYear in branchFinancialYearToRecover)
                    {
                        branchFinancialYear.ModifyDate = DateTime.UtcNow;
                        branchFinancialYear.ModifyBy = user.Name;
                        branchFinancialYear.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("BranchFinancialYear");
                        _cache.RemoveByPrefix("RemovedBranchFinancialYears");
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
        public async Task<RepoBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchFinancialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var branchFinancialYearToDelete = await _ctx.BranchFinancialYears.Where(x => branchFinancialYearIds.Contains(x.BranchFinancialYearId) && x.IsActive == false).ToListAsync();
                if (branchFinancialYearToDelete.Any())
                {
                    _ctx.BranchFinancialYears.RemoveRange(branchFinancialYearToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("BranchFinancialYear");
                        _cache.RemoveByPrefix("RemovedBranchFinancialYears");
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
