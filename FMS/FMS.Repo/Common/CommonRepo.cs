using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Common
{
    public class CommonRepo(Context ctx, IMapper mapper, ICustomCache cache) : ICommonRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
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
        public async Task<RepoBase> UpdateCountry(Guid Id, CountryModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Countries where s.CountryId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    Country updateCountry = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
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
        public async Task<RepoBase> RemoveCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Countries.SingleOrDefaultAsync(x => x.CountryId == Id && x.IsActive == true);
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
                    var Query = await (from s in _ctx.Countries where s.IsActive == false select s).OrderBy(s=>s.CountryName).ToListAsync();
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
        public async Task<RepoBase> RecoverCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Countries.SingleOrDefaultAsync(x => x.CountryId == Id && x.IsActive == false);
                if (Query != null)
                {
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
        public async Task<RepoBase> RecoverAllCountry(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var countryIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var countriesToRecover = await _ctx.Countries.Where(x => countryIds.Contains(x.CountryId) && x.IsActive == false).ToListAsync();
                if (countriesToRecover.Any())
                {
                    foreach (var country in countriesToRecover)
                    {
                        country.ModifyDate = DateTime.UtcNow;
                        country.ModifyBy = user.Name;
                        country.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Count = Count.ToString();
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
        public async Task<RepoBase> DeleteAllCountry(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var countryIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var countriesToDelete = await _ctx.Countries.Where(x => countryIds.Contains(x.CountryId) && x.IsActive == false).ToListAsync();
                if (countriesToDelete.Any())
                {
                    _ctx.Countries.RemoveRange(countriesToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Count = Count.ToString();
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
        #endregion
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
                    var Query = await (from s in _ctx.States where s.Fk_CounryId == CountryId && s.IsActive == true select s).OrderBy(s=>s.StateName).ToListAsync();
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
        public async Task<RepoBase> CreateState(StateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.States where s.Fk_CounryId == data.Fk_CounryId && s.StateName == data.StateName && s.IsActive == true select s).SingleOrDefaultAsync();
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
        public async Task<RepoBase> UpdateState(Guid Id, StateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.States where s.StateId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
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
        public async Task<RepoBase> RecoverAllStates(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var stateIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var statesToRecover = await _ctx.States.Where(x => stateIds.Contains(x.StateId) && x.IsActive == false).ToListAsync();
                if (statesToRecover.Any())
                {
                    foreach (var state in statesToRecover)
                    {
                        state.ModifyDate = DateTime.UtcNow;
                        state.ModifyBy = user.Name;
                        state.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Count = Count.ToString();
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
        public async Task<RepoBase> DeleteAllStates(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var stateIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var stateToDelete = await _ctx.States.Where(x => stateIds.Contains(x.StateId) && x.IsActive == false).ToListAsync();
                if (stateToDelete.Any())
                {
                    _ctx.States.RemoveRange(stateToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Count = Count.ToString();
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
        #endregion
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
        public async Task<RepoBase> UpdateDist(Guid Id, DistModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Dists where s.DistId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    Dist updateDist = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
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
        public async Task<RepoBase> RemoveDist(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Dists.SingleOrDefaultAsync(x => x.DistId == Id && x.IsActive == true);
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
        public async Task<RepoBase> RecoverAllDist(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var distIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var distToRecover = await _ctx.Dists.Where(x => distIds.Contains(x.DistId) && x.IsActive == false).ToListAsync();
                if (distToRecover.Any())
                {
                    foreach (var country in distToRecover)
                    {
                        country.ModifyDate = DateTime.UtcNow;
                        country.ModifyBy = user.Name;
                        country.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
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
        public async Task<RepoBase> DeleteAllDist(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var distIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var distToDelete = await _ctx.Dists.Where(x => distIds.Contains(x.DistId) && x.IsActive == false).ToListAsync();
                if (distToDelete.Any())
                {
                    _ctx.Dists.RemoveRange(distToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
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
        #endregion
        #endregion
    }
}
