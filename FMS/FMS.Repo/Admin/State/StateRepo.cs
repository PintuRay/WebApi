using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

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
                var cacheData = _cache.Get<RepoBase>(cacheKey);
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
        public async Task<RepoBase> CreateState(StateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.States where s.Fk_CountryId == data.Fk_CountryId && s.StateName == data.StateName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newState = _mapper.Map<Db.Entity.State>(data);
                    newState.CreatedDate = DateTime.UtcNow;
                    newState.CreatedBy = user.Name;
                    await _ctx.States.AddAsync(newState);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newState.StateId.ToString();
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
        public async Task<RepoBase> UpdateState(StateUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.States where s.StateId == data.StateId && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    var updateState = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
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
        public async Task<RepoBase> RemoveState(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.States.SingleOrDefaultAsync(x => x.StateId == Id && x.IsActive == true);
                if (Query != null)
                {
                    await UpdateStateRelatedEntity(Id, false);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
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
        #endregion
        #region Recover
        public async Task<RepoBase> GetRemovedStates()
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.States
                                   where s.IsActive == false
                                   select new StateDto()
                                   {
                                       StateId = s.StateId,
                                       Fk_CountryId = s.Fk_CountryId,
                                       StateName = s.StateName
                                   }).OrderBy(s => s.StateName).ToListAsync();
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
        public async Task<RepoBase> RecoverState(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.States.SingleOrDefaultAsync(x => x.StateId == Id && x.IsActive == false);
                if (Query != null)
                {
                    await UpdateStateRelatedEntity(Id, true);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
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
        public async Task<RepoBase> DeleteState(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.States.SingleOrDefaultAsync(x => x.StateId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.States.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
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
        public async Task<RepoBase> BulkRecoverStates(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingStateIds = await _ctx.States.Where(b => b.IsActive == false && Ids.Contains(b.StateId)).Select(b => b.StateId).ToListAsync();
                var notFoundStateIds = Ids.Except(existingStateIds).ToList();
                if (notFoundStateIds.Count == 0)
                {
                    await UpdateStatesRelatedEntity(Ids, true);
                    int Count = await _ctx.States.Where(x => Ids.Contains(x.StateId) && x.IsActive == false)
                                .ExecuteUpdateAsync(s => s
                                    .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                                    .SetProperty(p => p.ModifyBy, user.Name)
                                    .SetProperty(p => p.IsActive, true)
                                );
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.IsSucess = true;
                        _Result.Count = Count;
                        _cache.RemoveByPrefix($"State_");
                    }
                }
                else
                {
                    _Result.Ids = notFoundStateIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
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
                var existingStateIds = await _ctx.States.Where(b => b.IsActive == false && Ids.Contains(b.StateId)).Select(b => b.StateId).ToListAsync();
                var notFoundStateIds = Ids.Except(existingStateIds).ToList();
                if (notFoundStateIds.Count == 0)
                {
                    var stateToDelete = await _ctx.States.Where(x => Ids.Contains(x.StateId) && x.IsActive == false).ToListAsync();
                    _ctx.States.RemoveRange(stateToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.IsSucess = true;
                        _Result.Count = Count;
                        _cache.RemoveByPrefix($"State_");
                    }
                }
                else
                {
                    _Result.Ids = notFoundStateIds.Select(id => id.ToString()).ToList();
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
        private async Task UpdateStateRelatedEntity(Guid id, bool IsActive)
        {
            await _ctx.Dists.Where(s => s.Fk_CountryId == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
            await _ctx.Addresses.Where(s => s.Fk_CountryId == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
        }
        private async Task UpdateStatesRelatedEntity(List<Guid> Ids, bool IsActive)
        {
            await _ctx.Dists.Where(s => Ids.Contains(s.Fk_CountryId)).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
            await _ctx.Addresses.Where(s => Ids.Contains(s.Fk_CountryId)).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
        }
    }
}
