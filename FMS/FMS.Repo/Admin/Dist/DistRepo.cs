using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Dist
{
    public class DistRepo(Context ctx, IMapper mapper, IRedisCache cache) : IDistRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Crud
        public async Task<RepoBase> GetDists(Guid StateId)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Dist_{StateId}";
                var cacheData = _cache.Get<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Dists
                                       where s.Fk_StateId == StateId && s.IsActive == true
                                       select new DistDto()
                                       {
                                           DistId = s.DistId,
                                           DistName = s.DistName
                                       }).OrderBy(s => s.DistName).ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
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
        public async Task<RepoBase> CreateDist(DistModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Dists where s.Fk_CountryId == data.Fk_CountryId && s.Fk_StateId == data.Fk_StateId && s.DistName == data.DistName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newDist = _mapper.Map<Db.Entity.Dist>(data);
                    newDist.CreatedDate = DateTime.UtcNow;
                    newDist.CreatedBy = user.Name;
                    await _ctx.Dists.AddAsync(newDist);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newDist.DistId.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateDist(DistUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Dists where s.DistId == data.DistId && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    var updateDist = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = data.DistId.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveDist(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Dists.SingleOrDefaultAsync(x => x.DistId == Id && x.IsActive == true);
                if (Query != null)
                {
                    await UpdateDistRelatedEntity(Id, false);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
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
        public async Task<RepoBase> GetRemovedDists()
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Dists
                                   where s.IsActive == false
                                   select new DistDto()
                                   {
                                       DistId = s.DistId,
                                       Fk_StateId = s.Fk_StateId,
                                       Fk_CountryId = s.Fk_CountryId,
                                       DistName = s.DistName
                                   }).OrderBy(s => s.DistName).ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.Records = Query;
                    _Result.Count = Query.Count;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverDist(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Dists.SingleOrDefaultAsync(x => x.DistId == Id && x.IsActive == false);
                if (Query != null)
                {
                    await UpdateDistRelatedEntity(Id, true);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteDist(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Dists.SingleOrDefaultAsync(x => x.DistId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.Dists.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRecoverDists(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingDistIds = await _ctx.Dists.Where(b => b.IsActive == false && Ids.Contains(b.DistId)).Select(b => b.DistId).ToListAsync();
                var notFoundDistIds = Ids.Except(existingDistIds).ToList();
                if (notFoundDistIds.Count == 0)
                {
                    await UpdateDistsRelatedEntity(Ids, true);
                    int Count = await _ctx.Dists.Where(x => Ids.Contains(x.DistId) && x.IsActive == false)
                             .ExecuteUpdateAsync(s => s
                                 .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                                 .SetProperty(p => p.ModifyBy, user.Name)
                                 .SetProperty(p => p.IsActive, true)
                             );
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
                else
                {
                    _Result.Ids = notFoundDistIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteDists(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingDistIds = await _ctx.Dists.Where(b => b.IsActive == false && Ids.Contains(b.DistId)).Select(b => b.DistId).ToListAsync();
                var notFoundDistIds = Ids.Except(existingDistIds).ToList();
                if (notFoundDistIds.Count == 0)
                {
                    var distToDelete = await _ctx.Dists.Where(x => Ids.Contains(x.DistId) && x.IsActive == false).ToListAsync();
                    _ctx.Dists.RemoveRange(distToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
                else
                {
                    _Result.Ids = notFoundDistIds.Select(id => id.ToString()).ToList();
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
        private async Task UpdateDistRelatedEntity(Guid id, bool IsActive)
        {
            await _ctx.Addresses.Where(s => s.Fk_CountryId == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
        }
        private async Task UpdateDistsRelatedEntity(List<Guid> Ids, bool IsActive)
        {
            await _ctx.Addresses.Where(s => Ids.Contains(s.Fk_CountryId)).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
        }
    }
}
