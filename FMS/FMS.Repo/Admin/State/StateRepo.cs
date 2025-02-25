using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using static Pipelines.Sockets.Unofficial.SocketConnection;

namespace FMS.Repo.Admin.State
{
    public class StateRepo(Context ctx, IMapper mapper, IRedisCache cache) : IStateRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Crud
        public async Task<RepoBase> GetStates(Guid CountryId)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"State_{CountryId}";
                var cacheData = await _cache.GetAsync<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.States
                                       where s.Fk_CountryId == CountryId && s.IsActive == true
                                       select new StateDto()
                                       {
                                           StateId = s.StateId,
                                           StateName = s.StateName
                                       }).OrderBy(s => s.StateName).ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Query.Count;
                        _Result.IsSucess = true;
                        await _cache.SetAsync(cacheKey, _Result, _cacheExpiration);
                    }
                }
                else
                {
                    _Result.Records = JsonConvert.DeserializeObject<List<StateDto>>(cacheData.Records.ToString());
                    _Result.Count = cacheData.Count;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> GetStates(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<StateDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await (from s in _ctx.States
                                   where s.IsActive == true
                                   select new StateDto()
                                   {
                                       StateId = s.StateId,
                                       StateName = s.StateName
                                   }).OrderBy(s => s.StateName)
                        .Skip(skip)
                        .Take(effectivePageSize)
                        .ToListAsync();
                    Count = _ctx.States.Where(s => s.IsActive == true).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await (from s in _ctx.States
                                   where s.IsActive == true && s.StateName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                                   select new StateDto()
                                   {
                                       StateId = s.StateId,
                                       StateName = s.StateName
                                   })
                                   .OrderBy(s => s.StateName)
                                   .ToListAsync();
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
        public async Task<RepoBase> CreateState(StateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var existingState = await (from s in _ctx.States where s.Fk_CountryId == data.Fk_CountryId && s.StateName == data.StateName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (existingState == null)
                {
                    var newState = _mapper.Map<Db.Entity.State>(data);
                    newState.CreatedDate = DateTime.UtcNow;
                    newState.CreatedBy = user.Name;
                    await _ctx.States.AddAsync(newState);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = newState;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"State_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkCreateState(List<StateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingStates = await _ctx.States.Where(b => b.IsActive == true && dataList.Any(br => br.Fk_CountryId == b.Fk_CountryId && br.StateName == b.StateName)).ToListAsync();
                if (existingStates.Count == 0)
                {
                    var newStates = dataList.Select(b =>
                    {
                        var state = _mapper.Map<Db.Entity.State>(b);
                        state.CreatedDate = DateTime.UtcNow;
                        state.CreatedBy = user.Name;
                        return state;
                    }).ToList();
                    var response = await _ctx.BulkInsert(newStates);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = newStates;
                        _cache.RemoveByPrefix($"State_");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to create Staes";
                    }
                }
                else
                {
                    _Result.Records = existingStates;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateState(StateUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var existingState = await (from s in _ctx.States where s.StateId == data.StateId && s.IsActive == true select s).SingleOrDefaultAsync();
                if (existingState != null)
                {
                    var updateState = _mapper.Map(data, existingState);
                    existingState.ModifyDate = DateTime.UtcNow;
                    existingState.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = existingState;
                        _Result.IsSucess = true;
                        _Result.Count = Count;
                        _cache.RemoveByPrefix($"State_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkUpdateState(List<StateUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingStates = await _ctx.States.Where(b => b.IsActive == true && dataList.Any(f => f.Fk_CountryId == b.Fk_CountryId && f.StateName == b.StateName)).ToListAsync();
                var notFoundStates = dataList.Where(fy => !existingStates.Any(b => b.StateId == fy.StateId)).ToList();
                if (notFoundStates.Count == 0)
                {
                    var StatesToUpdate = existingStates.Select(s =>
                    {
                        var updateState = dataList.First(u => u.StateId == s.StateId);
                        _mapper.Map(updateState, s);
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        return s;
                    }).ToList();
                    var response = await _ctx.BulkUpdate(StatesToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.Records = StatesToUpdate;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"State_");
                    }
                }
                else
                {
                    _Result.Records = notFoundStates;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveState(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetStateRelatedEntity(Id, true);
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
                        _Result.Records = Query;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
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
        public async Task<RepoBase> BulkRemoveState(List<StateUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = dataList.Select(s => s.StateId).ToList();
                var Query = await GetStatesWithRelatedEntity(Ids, true);
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
                        _Result.Count = response.AffectedRows;
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
        public async Task<RepoBase> GetRemovedStates(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<StateDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await (from s in _ctx.States
                                   where s.IsActive == false
                                   select new StateDto()
                                   {
                                       StateId = s.StateId,
                                       Fk_CountryId = s.Fk_CountryId,
                                       StateName = s.StateName
                                   }).OrderByDescending(s => s.StateName)
                               .Skip(pagination.PageNumber * effectivePageSize)
                               .Take(effectivePageSize)
                               .ToListAsync();
                    Count = _ctx.States.Where(s => s.IsActive == false).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await (from s in _ctx.States
                                   where s.IsActive == false && s.StateName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                                   select new StateDto()
                                   {
                                       StateId = s.StateId,
                                       Fk_CountryId = s.Fk_CountryId,
                                       StateName = s.StateName
                                   }).ToListAsync();
                    Count = Query.Count();
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
        public async Task<RepoBase> RecoverState(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetStateRelatedEntity(Id, false);
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.States.SingleOrDefaultAsync(s => s.Fk_CountryId == Query.Fk_CountryId && s.StateName == Query.StateName && s.IsActive == true);
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
                            _Result.Records = Query;
                            _Result.Count = Count;
                            _Result.IsSucess = true;
                            _cache.RemoveByPrefix($"State_");
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
        public async Task<RepoBase> BulkRecoverStates(List<StateUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.StateId).ToList();
                var removedStates = await GetStatesWithRelatedEntity(Ids, false);
                if (removedStates.Count != 0)
                {
                    var isActiveRecordsExist = await _ctx.States.Where(s => s.IsActive == true && removedStates.Any(b => b.Fk_CountryId == s.Fk_CountryId && b.StateName == s.StateName)).ToListAsync();
                    var recoverStates = removedStates.Except(isActiveRecordsExist).ToList();
                    var IsActiveStatus = BulkUpdateStatus(recoverStates, user, true);
                    recoverStates.ForEach(s =>
                    {
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        s.IsActive = true;
                    });
                    var response = await _ctx.BulkUpdate(recoverStates);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = recoverStates;
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
        public async Task<RepoBase> DeleteState(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetStateRelatedEntity(Id, false);
                if (Query != null)
                {
                    _ctx.States.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"State_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteStates(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingStates = await GetStatesWithRelatedEntity(Ids, false);
                if (existingStates.Count != 0)
                {
                    var response = await _ctx.BulkDelete(existingStates);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
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
        private async Task<Db.Entity.State> GetStateRelatedEntity(Guid id, bool IsActive)
        {
            var Query = await _ctx.States
                   .Include(s => s.Dists)
                   .Include(s => s.Addresses)
                  .SingleOrDefaultAsync(x => x.StateId == id && x.IsActive == IsActive);
            return Query;
        }
        private async Task<List<Db.Entity.State>> GetStatesWithRelatedEntity(List<Guid> ids, bool IsActive)
        {
            var Query = await _ctx.States
                   .Include(s => s.Dists)
                   .Include(s => s.Addresses)
                .Where(b => b.IsActive == IsActive && ids.Contains(b.StateId)).ToListAsync();
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
        private async Task UpdateStatus(Db.Entity.State state, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["Dists"] = state.Dists?.ToList() ?? null,
                ["Addresses"] = state.Addresses?.ToList() ?? null,
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
                await _ctx.BulkUpdateMultiple(allRelatedData);
            }
        }
        private async Task BulkUpdateStatus(List<Db.Entity.State> states, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>();
            var collections = new Dictionary<string, ICollection>
            {
                 { "Addresses", states.SelectMany(fy => fy.Addresses).ToList() },
                 { "Dists", states.SelectMany(fy => fy.Dists).ToList() },
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
                await _ctx.BulkUpdateMultiple(allRelatedData);
            }
        }
    }
}
