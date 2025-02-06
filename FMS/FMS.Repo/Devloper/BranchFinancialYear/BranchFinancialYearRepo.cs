using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<RepoBase> GetAllBranchFinancialYears()
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = $"BranchFinancialYear";
                var cacheData = _cache.Get<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.BranchFinancialYears.Where(s => s.IsActive == true)
                          .Select(s => new BranchFinancialYearDto()
                          {
                              BranchFinancialYearId = s.BranchFinancialYearId,
                              Fk_BranchId = s.Fk_BranchId,
                              Fk_FinancialYearId = s.Fk_FinancialYearId,
                              Branch = s.Branch,
                              FinancialYear = s.FinancialYear
                          })
                          .OrderByDescending(s => s.Branch.BranchName)
                          .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Query.Count();
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
        public async Task<RepoBase> GetBranchFinancialYears(Guid BranchId)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = $"BranchFinancialYear_{BranchId}";
                var cacheData = _cache.Get<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.BranchFinancialYears.Where(s => s.IsActive == true && s.Fk_BranchId == BranchId)
                         .Select(s => new BranchFinancialYearDto()
                         {
                             BranchFinancialYearId = s.BranchFinancialYearId,
                             Fk_BranchId = s.Fk_BranchId,
                             Fk_FinancialYearId = s.Fk_FinancialYearId,
                             Branch = s.Branch,
                             FinancialYear = s.FinancialYear
                         })
                         .OrderByDescending(s => s.Branch.BranchName)
                         .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Query.Count();
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
        public async Task<RepoBase> GetBranchFinancialYears(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<BranchFinancialYearDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.BranchFinancialYears.Where(s => s.IsActive == true)
                          .Select(s => new BranchFinancialYearDto()
                          {
                              BranchFinancialYearId = s.BranchFinancialYearId,
                              Fk_BranchId = s.Fk_BranchId,
                              Fk_FinancialYearId = s.Fk_FinancialYearId,
                              Branch = s.Branch,
                              FinancialYear = s.FinancialYear
                          })
                        .OrderByDescending(s => s.Branch.BranchName)
                        .Skip(skip)
                        .Take(effectivePageSize)
                        .ToListAsync();
                    Count = _ctx.BranchFinancialYears.Where(s => s.IsActive == true).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.BranchFinancialYears.Where(s => s.IsActive == true && (s.Branch.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || s.FinancialYear.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)))
                          .Select(s => new BranchFinancialYearDto()
                          {
                              BranchFinancialYearId = s.BranchFinancialYearId,
                              Fk_BranchId = s.Fk_BranchId,
                              Fk_FinancialYearId = s.Fk_FinancialYearId,
                              Branch = s.Branch,
                              FinancialYear = s.FinancialYear
                          }).OrderByDescending(s => s.Branch.BranchName)
                        .ToListAsync();
                    Count = Query.Count;
                }
                if (Query.Count > 0)
                {
                    _Result.Records = Query;
                    _Result.Count = Count;
                    _Result.IsSucess = true;
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
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.Fk_FinancialYearId == data.Fk_FinancialYearId && s.Fk_BranchId == data.Fk_BranchId && s.IsActive == true);
                if (Query == null)
                {
                    var newBranchFinancialYear = _mapper.Map<Db.Entity.BranchFinancialYear>(data);
                    newBranchFinancialYear.CreatedDate = DateTime.UtcNow;
                    newBranchFinancialYear.CreatedBy = user.Name;
                    await _ctx.BranchFinancialYears.AddAsync(newBranchFinancialYear);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = newBranchFinancialYear;
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkCreateBranchFinancialYear(List<BranchFinancialYearModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchFinancialYears = await _ctx.BranchFinancialYears
                    .Where(b => b.IsActive == true && dataList.Any(bf => bf.Fk_FinancialYearId == b.Fk_FinancialYearId && bf.Fk_BranchId == b.Fk_BranchId))
                    .Select(b => new BranchFinancialYearDto()
                    {
                        BranchFinancialYearId = b.BranchFinancialYearId,
                        Branch = b.Branch,
                        FinancialYear = b.FinancialYear
                    }).ToListAsync();

                if (existingBranchFinancialYears.Count == 0)
                {
                    var newBranchFinancialYear = _mapper.Map<List<Db.Entity.BranchFinancialYear>>(dataList);
                    newBranchFinancialYear.ForEach(data => { data.CreatedDate = DateTime.UtcNow; data.CreatedBy = user.Name; });
                    var response = await _ctx.BulkInsert(newBranchFinancialYear);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = newBranchFinancialYear;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
                else
                {
                    _Result.Records = existingBranchFinancialYears;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateBranchFinancialYear(BranchFinancialYearUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.BranchFinancialYearId == data.BranchFinancialYearId && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = data.BranchFinancialYearId.ToString();
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkUpdateBranchFinancialYear(List<BranchFinancialYearUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchFinancialYears = await _ctx.BranchFinancialYears.Where(b => b.IsActive == true && dataList.Any(fy => fy.BranchFinancialYearId == b.BranchFinancialYearId)).ToListAsync();
                var notFoundBranchFinancialYear = dataList.Except(existingBranchFinancialYears).ToList();
                if (notFoundBranchFinancialYear.Count == 0)
                {
                    var branchFinancialYearToUpdate = _mapper.Map(dataList, existingBranchFinancialYears);
                    branchFinancialYearToUpdate.ForEach(data => { data.ModifyDate = DateTime.UtcNow; data.ModifyBy = user.Name; });
                    var response = await _ctx.BulkUpdate(branchFinancialYearToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.Records = branchFinancialYearToUpdate;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
                else
                {
                    _Result.Records = notFoundBranchFinancialYear;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.BranchFinancialYearId == Id && s.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = Query;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRemoveBranchFinancialYear(List<BranchFinancialYearUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchFinancialYears = await _ctx.BranchFinancialYears.Where(b => b.IsActive == true && dataList.Any(fy => fy.BranchFinancialYearId == b.BranchFinancialYearId)).ToListAsync();
                if (existingBranchFinancialYears.Count != 0)
                {
                    existingBranchFinancialYears.ForEach(bf =>
                    {
                        bf.ModifyDate = DateTime.UtcNow;
                        bf.ModifyBy = user.Name;
                        bf.IsActive = false;
                    });
                    var response = await _ctx.BulkUpdate(existingBranchFinancialYears);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = existingBranchFinancialYears;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
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
        public async Task<RepoBase> GetRemovedBranchFinancialYears(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<BranchFinancialYearDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.BranchFinancialYears.Where(s => s.IsActive == false)
                          .Select(s => new BranchFinancialYearDto()
                          {
                              BranchFinancialYearId = s.BranchFinancialYearId,
                              Fk_BranchId = s.Fk_BranchId,
                              Fk_FinancialYearId = s.Fk_FinancialYearId,
                              Branch = s.Branch,
                              FinancialYear = s.FinancialYear
                          })
                        .OrderByDescending(s => s.Branch.BranchName)
                        .Skip(skip)
                        .Take(effectivePageSize)
                        .ToListAsync();
                    Count = _ctx.BranchFinancialYears.Where(s => s.IsActive == false).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.BranchFinancialYears.Where(s => s.IsActive == false && (s.Branch.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || s.FinancialYear.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)))
                          .Select(s => new BranchFinancialYearDto()
                          {
                              BranchFinancialYearId = s.BranchFinancialYearId,
                              Fk_BranchId = s.Fk_BranchId,
                              Fk_FinancialYearId = s.Fk_FinancialYearId,
                              Branch = s.Branch,
                              FinancialYear = s.FinancialYear
                          }).OrderByDescending(s => s.Branch.BranchName)
                        .ToListAsync();
                    Count = Query.Count;
                }
                if (Query.Count > 0)
                {
                    _Result.Records = Query;
                    _Result.Count = Count;
                    _Result.IsSucess = true;
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
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.BranchFinancialYearId == Id && s.IsActive == false);
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.Fk_BranchId == Query.Fk_BranchId && s.Fk_FinancialYearId == Query.Fk_FinancialYearId && s.IsActive == true);
                    if (isActiveRecordExist == null)
                    {
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        int Count = await _ctx.SaveChangesAsync();
                        if (Count > 0)
                        {
                            await transaction.CommitAsync();
                            _Result.Records = Query;
                            _Result.Count = Count;
                            _Result.IsSucess = true;
                            _cache.RemoveByPrefix("BranchFinancialYear");
                        }
                    }
                    else
                    {
                        _Result.ResponseCode = 302;
                    }
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRecoverBranchFinancialYear(List<BranchFinancialYearUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchFinancialYears = await _ctx.BranchFinancialYears.Where(b => b.IsActive == false && dataList.Any(fy => fy.BranchFinancialYearId == b.BranchFinancialYearId)).ToListAsync();
                if (existingBranchFinancialYears.Count != 0)
                {
                    var isActiveRecordsExist = await _ctx.BranchFinancialYears.Where(s => s.IsActive == true && dataList.Any(fy => fy.Fk_BranchId == s.Fk_BranchId && fy.Fk_FinancialYearId == s.Fk_FinancialYearId)).ToListAsync();
                    var recoverBranchFinancialYear = existingBranchFinancialYears.Except(isActiveRecordsExist).ToList();
                    recoverBranchFinancialYear.ForEach(bf =>
                    {
                        bf.ModifyDate = DateTime.UtcNow;
                        bf.ModifyBy = user.Name;
                        bf.IsActive = true;
                    });
                    var response = await _ctx.BulkUpdate(recoverBranchFinancialYear);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = recoverBranchFinancialYear;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
            }
            catch
            {
                await transaction.RollbackAsync();
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
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(s => s.BranchFinancialYearId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.BranchFinancialYears.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkDeleteBranchFinancialYear(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchFinancialYears = await _ctx.BranchFinancialYears.Where(b => b.IsActive == false && Ids.Contains(b.BranchFinancialYearId)).ToListAsync();
                if (existingBranchFinancialYears.Count != 0)
                {
                    var response = await _ctx.BulkDelete(existingBranchFinancialYears);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = existingBranchFinancialYears.Select(s => s.BranchFinancialYearId.ToString()).ToList();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
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
        #endregion
    }
}
