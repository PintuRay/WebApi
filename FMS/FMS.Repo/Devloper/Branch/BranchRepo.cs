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
        public async Task<RepoBase> UpdateBranch(Guid Id, BranchModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchId == Id && s.IsActive == true);
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
        public async Task<RepoBase> RecoverAllBranch(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var branchToRecover = await _ctx.Branches.Where(x => branchIds.Contains(x.BranchId) && x.IsActive == false).ToListAsync();
                if (branchToRecover.Any())
                {
                    foreach (var branch in branchToRecover)
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        branch.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
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
        public async Task<RepoBase> DeleteAllBranch(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var branchToDelete = await _ctx.Branches.Where(x => branchIds.Contains(x.BranchId) && x.IsActive == false).ToListAsync();
                if (branchToDelete.Any())
                {
                    _ctx.Branches.RemoveRange(branchToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
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
