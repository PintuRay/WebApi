using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Devloper.Branch
{
    public class BranchRepo(Context ctx, IMapper mapper, IRedisCache cache) : IBranchRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Branch
        #region Crud
        public async Task<Result<Db.Entity.Branch>> GetAllBranch(PaginationParams pagination)
        {
            Result<Db.Entity.Branch> _Result = new();
            List<Db.Entity.Branch> Query = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = pagination.PageNumber.HasValue && pagination.PageSize.HasValue ? $"Branches_{pagination.PageNumber}_{pagination.PageSize}" : "Branches";
                var cacheData = _cache.Get<Result<Db.Entity.Branch>>(cacheKey);
                if (cacheData == null)
                {
                    if (pagination.PageNumber.HasValue && pagination.PageSize.HasValue)
                    {
                        Query = await _ctx.Branches.Where(s => s.IsActive == true)
                                 .OrderBy(s => s.BranchName)
                                 .Skip((pagination.PageNumber.Value - 1) * pagination.PageSize.Value)
                                 .Take(pagination.PageSize.Value)
                                 .ToListAsync();
                    }
                    else
                    {
                        Query = await _ctx.Branches.Where(s => s.IsActive == true)
                             .OrderBy(s => s.BranchName)
                             .ToListAsync();
                    }
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.Count = Query.Count;
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
        public async Task<RepoBase> CreateBranch(BranchModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchName == data.BranchName && s.IsActive == true);
                if (Query == null)
                {
                    var newBranch = _mapper.Map<Db.Entity.Branch>(data);
                    newBranch.CreatedDate = DateTime.UtcNow;
                    newBranch.CreatedBy = user.Name;
                    await _ctx.Branches.AddAsync(newBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newBranch.BranchId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Branches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkCreateBranch(List<BranchModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchNames = dataList.Select(b => b.BranchName).ToList();
                var existingBranchNames = await _ctx.Branches.Where(b => b.IsActive == true && branchNames.Contains(b.BranchName)).Select(b => b.BranchName).ToListAsync();
                if (!existingBranchNames.Any())
                {
                    var newBranches = dataList.Select(data =>
                    {
                        var branch = _mapper.Map<Db.Entity.Branch>(data);
                        branch.CreatedDate = DateTime.UtcNow;
                        branch.CreatedBy = user.Name;
                        return branch;
                    }).ToList();
                    await _ctx.Branches.AddRangeAsync(newBranches);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = newBranches.Select(b => b.BranchId.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
                    }
                }
                else
                {
                    _Result.Data = existingBranchNames;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateBranch(BranchUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchId == data.BranchId && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = data.BranchId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Branches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkUpdateBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchUpdates = listdata.ToDictionary(b => b.BranchId, b => b);
                var branchIds = branchUpdates.Keys.ToList();
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && branchIds.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = branchIds.Except(existingBranchIds).ToList();
                if (!notFoundBranchIds.Any()) {
                    int Count = await _ctx.Branches
                                 .Where(x => branchIds.Contains(x.BranchId) && x.IsActive == true)
                                 .ExecuteUpdateAsync(s => s
                                     .SetProperty(p => p.BranchName, p => branchUpdates[p.BranchId].BranchName)
                                     .SetProperty(p => p.BranchAddress, p => branchUpdates[p.BranchId].BranchAddress)
                                     .SetProperty(p => p.ContactNumber, p => branchUpdates[p.BranchId].ContactNumber)
                                     .SetProperty(p => p.BranchCode, p => branchUpdates[p.BranchId].BranchCode)
                                     .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                                     .SetProperty(p => p.ModifyBy, user.Name)
                                 );
                    if (Count > 0)
                    {
                        _Result.Ids = branchIds.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
                } 
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == true);
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
                        _cache.RemoveByPrefix("Branches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRemoveBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (!notFoundBranchIds.Any())
                {
                    int Count = await _ctx.Branches.Where(x => Ids.Contains(x.BranchId) && x.IsActive == true)
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
                        transaction.Commit();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
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
        public async Task<Result<Db.Entity.Branch>> GetRemovedBranches(PaginationParams pagination)
        {
            Result<Db.Entity.Branch> _Result = new();
            List<Db.Entity.Branch> Query = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = pagination.PageNumber.HasValue && pagination.PageSize.HasValue ? $"RemovedBranches_{pagination.PageNumber}_{pagination.PageSize}" : "RemovedBranches";
                var cacheData = _cache.Get<Result<Db.Entity.Branch>>(cacheKey);
                if (cacheData == null)
                {
                    if (pagination.PageNumber.HasValue && pagination.PageSize.HasValue)
                    {
                        Query = await _ctx.Branches.Where(s => s.IsActive == false)
                                 .OrderBy(s => s.BranchName)
                                 .Skip((pagination.PageNumber.Value - 1) * pagination.PageSize.Value)
                                 .Take(pagination.PageSize.Value)
                                 .ToListAsync();
                    }
                    else
                    {
                        Query = await _ctx.Branches.Where(s => s.IsActive == false)
                             .OrderBy(s => s.BranchName)
                             .ToListAsync();
                    }
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.Count = Query.Count;
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
        public async Task<RepoBase> RecoverBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == false);
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
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRecoverBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (!notFoundBranchIds.Any())
                {
                    int Count = await _ctx.Branches.Where(x => Ids.Contains(x.BranchId) && x.IsActive == false).
                       ExecuteUpdateAsync(s => s
                       .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                       .SetProperty(p => p.ModifyBy, user.Name)
                       .SetProperty(p => p.IsActive, true)
                       );
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.Branches.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (!notFoundBranchIds.Any())
                {
                    int Count = await _ctx.Branches.Where(x => Ids.Contains(x.BranchId) && x.IsActive == false).ExecuteDeleteAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
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
