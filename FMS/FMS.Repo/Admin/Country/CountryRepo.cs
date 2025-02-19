using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FMS.Repo.Admin.Country
{
    public class CountryRepo(Context ctx, IMapper mapper, IRedisCache cache) : ICountryRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Crud
        public async Task<RepoBase> GetAllCountries()
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Country";
                var cacheData = _cache.Get<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Countries
                                       where s.IsActive == true
                                       select new CountryDto()
                                       {
                                           CountryId = s.CountryId,
                                           CountryCode = s.CountryCode,
                                           CountryName = s.CountryName
                                       }).OrderBy(s => s.CountryName).ToListAsync();
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
        public async Task<RepoBase> GetCountries(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<CountryDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.Countries.Where(s => s.IsActive == true)
                        .Select(s => new CountryDto()
                        {
                            CountryId = s.CountryId,
                            CountryName = s.CountryName,
                            CountryCode = s.CountryCode
                        })
                        .OrderBy(s => s.CountryName)
                        .Skip(skip)
                        .Take(effectivePageSize)
                        .ToListAsync();
                    Count = _ctx.Countries.Where(s => s.IsActive == true).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.Countries.Where(s => s.IsActive == true && s.CountryName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || s.CountryCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => new CountryDto()
                        {
                            CountryId = s.CountryId,
                            CountryName = s.CountryName,
                            CountryCode = s.CountryCode
                        }).OrderBy(s => s.CountryName)
                        .ToListAsync();
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
        public async Task<RepoBase> CreateCountry(CountryModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Countries where s.CountryName == data.CountryName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newCountry = _mapper.Map<Db.Entity.Country>(data);
                    newCountry.CreatedDate = DateTime.UtcNow;
                    newCountry.CreatedBy = user.Name;
                    await _ctx.Countries.AddAsync(newCountry);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = newCountry;
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkCreateCountry(List<CountryModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingCountries = await _ctx.Countries.Where(b => b.IsActive == true && dataList.Select(br => br.CountryName).Contains(b.CountryName)).ToListAsync();
                if (existingCountries.Count == 0)
                {
                    var newCountries = dataList.Select(s =>
                    {
                        var country = _mapper.Map<Db.Entity.Country>(s);
                        country.CreatedDate = DateTime.UtcNow;
                        country.CreatedBy = user.Name;
                        return country;
                    }).ToList();
                    var response = await _ctx.BulkInsert(newCountries);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = newCountries;
                        _cache.Remove("Country");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to create  countries";
                    }
                }
                else
                {
                    _Result.Records = existingCountries;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
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
                    var updateCountry = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkUpdateCountry(List<CountryUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingCountries = await _ctx.Countries.Where(b => b.IsActive == true && listdata.Select(br => br.CountryId).Contains(b.CountryId)).ToListAsync(); ;
                var notFoundCountries = listdata.Where(br => !existingCountries.Any(b => b.CountryId == br.CountryId)).ToList();
                if (notFoundCountries.Count == 0)
                {
                    var countriesToUpdate = existingCountries.Select(s =>
                    {
                        var updateData = listdata.First(u => u.CountryId == s.CountryId);
                        _mapper.Map(updateData, s);
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        return s;
                    }).ToList();
                    var response = await _ctx.BulkUpdate(countriesToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.Records = countriesToUpdate;
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to update countries";
                    }
                }
                else
                {
                    _Result.Records = notFoundCountries;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetCountryWithRelatedEntity(Id, true);
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
                        _cache.Remove("Country");
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
        public async Task<RepoBase> BulkRemoveCountry(List<CountryUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.CountryId).ToList();
                var Query = await GetCountriesWithRelatedEntity(Ids, true);
                if (Query.Count != 0)
                {
                    await BulkUpdateStatus(Query, user, false);
                    Query.ForEach(s =>
                    {
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        s.IsActive = false;
                    });
                    var response = await _ctx.BulkUpdate(Query);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                        _cache.Remove("Country");
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
        public async Task<RepoBase> GetRemovedCountries(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<CountryDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await (from s in _ctx.Countries
                                   where s.IsActive == false
                                   select new CountryDto()
                                   {
                                       CountryId = s.CountryId,
                                       CountryCode = s.CountryCode,
                                       CountryName = s.CountryName
                                   }).OrderBy(s => s.CountryName)
                        .Skip(skip)
                        .Take(effectivePageSize)
                        .ToListAsync();
                    Count = _ctx.Countries.Where(s => s.IsActive == false).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.Countries.Where(s => s.IsActive == false && (s.CountryName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || s.CountryCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)))
                       .Select(s => new CountryDto()
                       {
                           CountryId = s.CountryId,
                           CountryCode = s.CountryCode,
                           CountryName = s.CountryName
                       }).OrderBy(s => s.CountryName)
                       .ToListAsync();
                    Count = Query.Count();
                }

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
        public async Task<RepoBase> RecoverCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetCountryWithRelatedEntity(Id, false);
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.Countries.SingleOrDefaultAsync(s => s.CountryName == Query.CountryName && s.IsActive == true);
                    if (isActiveRecordExist == null)
                    {
                        var IsActiveStatus = UpdateStatus(Query, user, true);
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        int Count = await _ctx.SaveChangesAsync();
                        if (Count > 0)
                        {
                            _Result.Records = Query;
                            _Result.Count = Count;
                            _Result.IsSucess = true;
                            _cache.Remove("Country");
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
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkRecoverCountry(List<CountryUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.CountryId).ToList();
                var removedCountries = await GetCountriesWithRelatedEntity(Ids, false);
                if (removedCountries.Count != 0)
                {
                    var isActiveRecordsExist = await _ctx.Countries.Where(s => s.IsActive == true && removedCountries.Any(c => c.CountryName == s.CountryName)).ToListAsync();
                    var recoverCountries = removedCountries.Except(isActiveRecordsExist).ToList();
                    var IsActiveStatus = BulkUpdateStatus(recoverCountries, user, true);
                    recoverCountries.ForEach(country =>
                    {
                        country.ModifyDate = DateTime.UtcNow;
                        country.ModifyBy = user.Name;
                        country.IsActive = true;
                    });
                    var response = await _ctx.BulkUpdate(recoverCountries);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = recoverCountries;
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
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
        public async Task<RepoBase> DeleteCountry(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetCountryWithRelatedEntity(Id, false);
                if (Query != null)
                {
                    _ctx.Countries.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count;
                    if (Count > 0)
                    {
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
        public async Task<RepoBase> BulkDeleteCountry(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingCountries = await GetCountriesWithRelatedEntity(Ids, false);
                if (existingCountries.Count != 0)
                {
                    var response = await _ctx.BulkDelete(existingCountries);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _cache.Remove("Country");
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
        private async Task<Db.Entity.Country> GetCountryWithRelatedEntity(Guid id, bool IsActive)
        {
            var Query = await _ctx.Countries
                   .Include(s => s.Addresses)
                   .Include(s => s.States)
                   .Include(s => s.Dists)
                  .SingleOrDefaultAsync(x => x.CountryId == id && x.IsActive == IsActive);
            return Query;
        }
        private async Task<List<Db.Entity.Country>> GetCountriesWithRelatedEntity(List<Guid> ids, bool IsActive)
        {
            var Query = await _ctx.Countries
                .Include(s => s.Dists)
                .Include(s => s.States)
                .Include(s => s.Addresses)
                .Where(b => b.IsActive == IsActive && ids.Contains(b.CountryId)).ToListAsync();
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
        private async Task UpdateStatus(Db.Entity.Country country, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["Addresses"] = country.Addresses?.ToList() ?? null,
                ["States"] = country.States?.ToList() ?? null,
                ["Dists"] = country.Dists?.ToList() ?? null,
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
        private async Task BulkUpdateStatus(List<Db.Entity.Country> countries, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>();
            var collections = new Dictionary<string, ICollection>
            {
                 { "Addresses", countries.SelectMany(fy => fy.Addresses).ToList() },
                 { "States", countries.SelectMany(fy => fy.States).ToList() },
                 { "Dists", countries.SelectMany(fy => fy.Dists).ToList() },
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
