using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Common
{
    public class CommonRepo(Context ctx, IMapper mapper, IRedisCache cache) : ICommonRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Country
        #region Crud
        public async Task<Result<Country>> GetCountries()
        {
            Result<Country> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Country";
                var cacheData = _cache.Get<Result<Country>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Countries where s.IsActive == true select s).OrderBy(s => s.CountryName).ToListAsync();
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
        public async Task<RepoBase> CreateCountry(CountryModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Countries where s.CountryName == data.CountryName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    Country newCountry = _mapper.Map<Country>(data);
                    newCountry.CreatedDate = DateTime.UtcNow;
                    newCountry.CreatedBy = user.Name;
                    await _ctx.Countries.AddAsync(newCountry);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newCountry.CountryId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateCountry(CountryUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Countries where s.CountryId == data.CountryId && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    Country updateCountry = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = data.CountryId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Countries.SingleOrDefaultAsync(x => x.CountryId == Id && x.IsActive == true);
                if (Query != null)
                {
                    await UpdateCountryRelatedEntity(Id, false);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
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
        public async Task<Result<Country>> GetRemovedCountries()
        {
            Result<Country> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedCountries";
                var cacheData = _cache.Get<Result<Country>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Countries where s.IsActive == false select s).OrderBy(s => s.CountryName).ToListAsync();
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
        public async Task<RepoBase> RecoverCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Countries.SingleOrDefaultAsync(x => x.CountryId == Id && x.IsActive == false);
                if (Query != null)
                {
                    await UpdateCountryRelatedEntity(Id, true);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                        _cache.Remove("RemovedCountries");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRecoverCountry(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingCountryIds = await _ctx.Countries.Where(b => b.IsActive == false && Ids.Contains(b.CountryId)).Select(b => b.CountryId).ToListAsync();
                var notFoundCountryIds = Ids.Except(existingCountryIds).ToList();
                var countriesToRecover = await _ctx.Countries.Where(x => Ids.Contains(x.CountryId) && x.IsActive == false).ToListAsync();
                if (notFoundCountryIds.Count == 0)
                {
                    await UpdateCountriesRelatedEntity(Ids, true);
                    int Count = await _ctx.Countries.Where(x => Ids.Contains(x.CountryId) && x.IsActive == false)
                                 .ExecuteUpdateAsync(s => s
                                     .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                                     .SetProperty(p => p.ModifyBy, user.Name)
                                     .SetProperty(p => p.IsActive, true)
                                 );
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                        _cache.Remove("RemovedCountries");
                    }
                }
                else
                {
                    _Result.Ids = notFoundCountryIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Countries.SingleOrDefaultAsync(x => x.CountryId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.Countries.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                        _cache.Remove("RemovedCountries");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteCountry(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingCountryIds = await _ctx.Countries.Where(b => b.IsActive == false && Ids.Contains(b.CountryId)).Select(b => b.CountryId).ToListAsync();
                var notFoundCountryIds = Ids.Except(existingCountryIds).ToList();
                if (notFoundCountryIds.Count == 0)
                {
                    var countriesToDelete = await _ctx.Countries.Where(x => Ids.Contains(x.CountryId) && x.IsActive == false).ToListAsync();
                    _ctx.Countries.RemoveRange(countriesToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                        _cache.Remove("RemovedCountries");
                    }
                }
                else
                {
                    _Result.Ids = notFoundCountryIds.Select(id => id.ToString()).ToList();
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
        private async Task UpdateCountryRelatedEntity(Guid id, bool IsActive)
        {
            await _ctx.States.Where(s => s.Fk_CountryId == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
            await _ctx.Dists.Where(s => s.Fk_CountryId == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
            await _ctx.Addresses.Where(s => s.Fk_CountryId == id).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
        }
        private async Task UpdateCountriesRelatedEntity(List<Guid> Ids, bool IsActive)
        {
            await _ctx.States.Where(s => Ids.Contains(s.Fk_CountryId)).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
            await _ctx.Dists.Where(s => Ids.Contains(s.Fk_CountryId)).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
            await _ctx.Addresses.Where(s => Ids.Contains(s.Fk_CountryId)).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, IsActive));
        }
        #endregion
        #region State
        #region Crud
        public async Task<Result<State>> GetStates(Guid CountryId)
        {
            Result<State> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"State_{CountryId}";
                var cacheData = _cache.Get<Result<State>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.States where s.Fk_CountryId == CountryId && s.IsActive == true select s).OrderBy(s => s.StateName).ToListAsync();
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
        public async Task<RepoBase> CreateState(StateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.States where s.Fk_CountryId == data.Fk_CountryId && s.StateName == data.StateName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    State newState = _mapper.Map<State>(data);
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
                    State updateState = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Count = Count.ToString();
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
                        _Result.Count = Count.ToString();
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
        public async Task<Result<State>> GetRemovedStates()
        {
            Result<State> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedState";
                var cacheData = _cache.Get<Result<State>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.States where s.IsActive == false select s).OrderBy(s => s.StateName).ToListAsync();
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
                        _cache.Remove("RemovedState");
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
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"State_");
                        _cache.Remove("RemovedState");
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
                        _Result.Count = Count.ToString();
                        _cache.RemoveByPrefix($"State_");
                        _cache.Remove("RemovedState");
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
                        _Result.Count = Count.ToString();
                        _cache.RemoveByPrefix($"State_");
                        _cache.Remove("RemovedState");
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
        #endregion  
        #region Dist
        #region Crud
        public async Task<Result<Dist>> GetDists(Guid StateId)
        {
            Result<Dist> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Dist_{StateId}";
                var cacheData = _cache.Get<Result<Dist>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Dists where s.Fk_StateId == StateId && s.IsActive == true select s).OrderBy(s => s.DistName).ToListAsync();
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
        public async Task<RepoBase> CreateDist(DistModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Dists where s.Fk_CountryId == data.Fk_CountryId && s.Fk_StateId == data.Fk_StateId && s.DistName == data.DistName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    Dist newDist = _mapper.Map<Dist>(data);
                    newDist.CreatedDate = DateTime.UtcNow;
                    newDist.CreatedBy = user.Name;
                    await _ctx.Dists.AddAsync(newDist);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newDist.DistId.ToString();
                        _Result.Count = Count.ToString();
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
                    Dist updateDist = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = data.DistId.ToString();
                        _Result.Count = Count.ToString();
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
                        _Result.Count = Count.ToString();
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
        public async Task<Result<Dist>> GetRemovedDists()
        {
            Result<Dist> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedDists";
                var cacheData = _cache.Get<Result<Dist>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Dists where s.IsActive == false select s).OrderBy(s => s.DistName).ToListAsync();
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
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                        _cache.Remove("RemovedDists");
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
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                        _cache.Remove("RemovedDists");
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
                        _Result.Ids = Ids.Select(id=> id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                        _cache.Remove("RemovedDists");
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
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Dist_");
                        _cache.Remove("RemovedDists");
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
        #endregion
    }
}
