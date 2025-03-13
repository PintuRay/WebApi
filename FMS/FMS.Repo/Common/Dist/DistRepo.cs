using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;

namespace FMS.Repo.Common.Dist
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
                var cacheData = await _cache.GetAsync<RepoBase>(cacheKey);
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
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                      //_Result.Count= Query.Count;
                        await _cache.SetAsync(cacheKey, _Result, _cacheExpiration);
                    }
                }
                else
                {
                    _Result.Records = JsonConvert.DeserializeObject<List<DistDto>>(cacheData.Records.ToString());
                    //_Result.Count= cacheData.Count;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> GetDists(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<DistDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await (from s in _ctx.Dists
                                   where s.IsActive == true
                                   select new DistDto()
                                   {
                                       DistId = s.DistId,
                                       DistName = s.DistName
                                   }).OrderBy(s => s.DistName)
                       .Skip(skip)
                       .Take(effectivePageSize)
                       .ToListAsync();
                    Count = _ctx.Dists.Where(s => s.IsActive == true).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await (from s in _ctx.Dists
                                   where s.IsActive == true && s.DistName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                                   select new DistDto()
                                   {
                                       DistId = s.DistId,
                                       DistName = s.DistName
                                   })
                                   .OrderBy(s => s.DistName)
                                   .ToListAsync();
                }
                if (Query.Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Records = Query;
                    // _Result.Count= Count;
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
                        _Result.IsSucess = true;
                        _Result.Records = newDist;
                        // _Result.Count= Count;
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
        public async Task<RepoBase> BulkCreateDist(List<DistModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingDists = await _ctx.Dists.Where(b => b.IsActive == true && dataList.Any(br => br.Fk_StateId == b.Fk_StateId && br.DistName == b.DistName)).ToListAsync();
                if (existingDists.Count == 0)
                {
                    var newDists = dataList.Select(b =>
                    {
                        var dist = _mapper.Map<Db.Entity.Dist>(b);
                        dist.CreatedDate = DateTime.UtcNow;
                        dist.CreatedBy = user.Name;
                        return dist;
                    }).ToList();
                    var response = await _ctx.BulkInsert(newDists);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        // _Result.Count= response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = newDists;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to create Dists";
                    }
                }
                else
                {
                    _Result.Records = existingDists;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
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
                        _Result.IsSucess = true;
                        _Result.Records = updateDist;
                        // _Result.Count= Count;
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
        public async Task<RepoBase> BulkUpdateDist(List<DistUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingDists = await _ctx.Dists.Where(b => b.IsActive == true && dataList.Any(f => f.Fk_StateId == b.Fk_StateId && f.DistName == b.DistName)).ToListAsync();
                var notFoundDists = dataList.Where(fy => !existingDists.Any(b => b.DistId == fy.DistId)).ToList();
                if (notFoundDists.Count == 0)
                {
                    var distsToUpdate = existingDists.Select(s =>
                    {
                        var updateDist = dataList.First(u => u.DistId == s.DistId);
                        _mapper.Map(updateDist, s);
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        return s;
                    }).ToList();
                    var response = await _ctx.BulkUpdate(distsToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.IsSucess = true;
                        // _Result.Count= response.AffectedRows;
                        _Result.Records = distsToUpdate;
                        _cache.RemoveByPrefix($"Dist_");
                    }
                }
                else
                {
                    _Result.Records = notFoundDists;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveDist(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetDistRelatedEntity(Id, true);
                if (Query != null)
                {
                    var IsActiveStatus = UpdateStatus(Query, user, false);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                        // _Result.Count= Count;
                        _cache.RemoveByPrefix($"Dist_");
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
        public async Task<RepoBase> BulkRemoveDist(List<DistUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = dataList.Select(s => s.DistId).ToList();
                var Query = await GetDistsWithRelatedEntity(Ids, true);
                if (Query.Count != 0)
                {
                    var IsActiveStatus = BulkUpdateStatus(Query, user, false);
                    Query.ForEach(fy =>
                    {
                        fy.ModifyDate = DateTime.UtcNow;
                        fy.ModifyBy = user.Name;
                        fy.IsActive = false;
                    });
                    var response = await _ctx.BulkUpdate(Query);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        // _Result.Count= response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                        _cache.RemoveByPrefix($"State_");
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
        public async Task<RepoBase> GetRemovedDists(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<DistDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await (from s in _ctx.Dists
                                   where s.IsActive == false
                                   select new DistDto()
                                   {
                                       DistId = s.DistId,
                                       DistName = s.DistName
                                   }).OrderByDescending(s => s.DistName)
                               .Skip(pagination.PageNumber * effectivePageSize)
                               .Take(effectivePageSize)
                               .ToListAsync();
                    Count = _ctx.Dists.Where(s => s.IsActive == false).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await (from s in _ctx.Dists
                                   where s.IsActive == false && s.DistName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                                   select new DistDto()
                                   {
                                       DistId = s.DistId,
                                       DistName = s.DistName
                                   })
                            .ToListAsync();
                    Count = Query.Count();
                }
                if (Query.Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Records = Query;
                 // _Result.Count= Query.Count;
                 
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
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetDistRelatedEntity(Id, false);
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.Dists.SingleOrDefaultAsync(s => s.Fk_StateId == Query.Fk_StateId && s.DistName == Query.DistName && s.IsActive == true);
                    if (isActiveRecordExist == null)
                    {
                        var IsActiveStatus = UpdateStatus(Query, user, true);
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        int Count = await _ctx.SaveChangesAsync();
                        if (Count > 0)
                        {
                            await transaction.CommitAsync();
                            _Result.IsSucess = true;
                            _Result.Records = Query;
                            // _Result.Count= Count;
                            _cache.RemoveByPrefix($"Dist_");
                        }
                    }
                    else
                    {
                        _Result.Records = isActiveRecordExist;
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
        public async Task<RepoBase> BulkRecoverDists(List<DistUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.DistId).ToList();
                var removedDists = await GetDistsWithRelatedEntity(Ids, false);
                if (removedDists.Count != 0)
                {
                    var isActiveRecordsExist = await _ctx.Dists.Where(s => s.IsActive == true && removedDists.Any(b => b.Fk_StateId == s.Fk_StateId && b.DistName == s.DistName)).ToListAsync();
                    var recoverDists = removedDists.Except(isActiveRecordsExist).ToList();
                    var IsActiveStatus = BulkUpdateStatus(recoverDists, user, true);
                    recoverDists.ForEach(s =>
                    {
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        s.IsActive = true;
                    });
                    var response = await _ctx.BulkUpdate(recoverDists);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        // _Result.Count= response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = recoverDists;
                        _cache.RemoveByPrefix($"Dist_");
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
        public async Task<RepoBase> DeleteDist(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetDistRelatedEntity(Id, false);
                if (Query != null)
                {
                    _ctx.Dists.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Id = Id.ToString();
                        // _Result.Count= Count;
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
        public async Task<RepoBase> BulkDeleteDists(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingDists = await GetDistsWithRelatedEntity(Ids, false);
                if (existingDists.Count != 0)
                {
                    var response = await _ctx.BulkDelete(existingDists);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.IsSucess = true;
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        // _Result.Count= response.AffectedRows;
                        _cache.RemoveByPrefix($"Dist_");
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
        private async Task<Db.Entity.Dist> GetDistRelatedEntity(Guid id, bool IsActive)
        {
            var Query = await _ctx.Dists
                   .Include(s => s.Addresses)
                  .SingleOrDefaultAsync(x => x.DistId == id && x.IsActive == IsActive);
            return Query;
        }
        private async Task<List<Db.Entity.Dist>> GetDistsWithRelatedEntity(List<Guid> ids, bool IsActive)
        {
            var Query = await _ctx.Dists
                   .Include(s => s.Addresses)
                .Where(b => b.IsActive == IsActive && ids.Contains(b.DistId)).ToListAsync();
            return Query;
        }
        private void UpdateEntityProperties(object entity, AppUser user, bool IsActive)
        {
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            var modifyDateProperty = entity.GetType().GetProperty("ModifyDate");
            var modifyByProperty = entity.GetType().GetProperty("ModifyBy");

            if (isActiveProperty != null && isActiveProperty.PropertyType == typeof(bool?))
            {
                isActiveProperty.SetValue(entity, IsActive);
            }

            if (modifyDateProperty != null && modifyDateProperty.PropertyType == typeof(DateTime?))
            {
                modifyDateProperty.SetValue(entity, DateTime.UtcNow);
            }

            if (modifyByProperty != null && modifyByProperty.PropertyType == typeof(string))
            {
                modifyByProperty.SetValue(entity, user.UserName);
            }
        }
        private async Task UpdateStatus(Db.Entity.Dist dist, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["Addresses"] = dist.Addresses?.ToList() ?? null,
            };
            foreach (var group in allRelatedData)
            {
                if (group.Value.Count != 0)
                {
                    foreach (var entity in group.Value)
                    {
                        UpdateEntityProperties(entity, user, IsActive);
                    }
                }
            }
            if (allRelatedData.Count > 0)
            {
                await _ctx.BulkUpdateCollection(allRelatedData);
            }
        }
        private async Task BulkUpdateStatus(List<Db.Entity.Dist> dists, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>();
            var collections = new Dictionary<string, ICollection>
            {
                 { "Addresses", dists.SelectMany(fy => fy.Addresses).ToList() },
            };
            foreach (var collection in collections)
            {
                if (collection.Value != null && collection.Value.Count > 0)
                {
                    foreach (var entity in collection.Value)
                    {
                        UpdateEntityProperties(entity, user, IsActive);
                    }
                    allRelatedData[collection.Key] = collection.Value.Cast<object>().ToList(); // Ensure it's a List
                }
            }
            if (allRelatedData.Count > 0)
            {
                await _ctx.BulkUpdateCollection(allRelatedData);
            }
        }
    }
}
