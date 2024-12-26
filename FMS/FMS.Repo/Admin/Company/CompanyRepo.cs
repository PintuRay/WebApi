using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Company
{
    public class CompanyRepo(Context ctx, IMapper mapper, IRedisCache cache) : ICompanyRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Company
        #region Crud
        public async Task<Result<Db.Entity.Company>> GetCompany(string BranchId)
        {
            Result<Db.Entity.Company> _Result = new();
            List<Db.Entity.Company> Query = null;
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Company_{BranchId}";
                var cacheData = _cache.Get<Result<Db.Entity.Company>>(cacheKey);
                if (cacheData == null)
                {
                    if (BranchId != "All")
                    {
                        Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == true).ToListAsync();
                    }
                    else
                    {
                        Query = await _ctx.Companies.Where(s => s.IsActive == true).ToListAsync();
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
        public async Task<RepoBase> CreateCompany(CompanyModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Companies where s.CompanyName == data.CompanyName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newCompany = _mapper.Map<Db.Entity.Company>(data);
                    newCompany.CreatedDate = DateTime.UtcNow;
                    newCompany.CreatedBy = user.Name;
                    await _ctx.Companies.AddAsync(newCompany);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newCompany.CompanyId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove($"Company_{data.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Companies where s.CompanyId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    var updateCompany = _mapper.Map(model, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove($"Company_{model.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveCompany(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Id && x.IsActive == true);
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
                        _cache.Remove($"Company_{Query.Fk_BranchId}");
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
        public async Task<Result<Db.Entity.Company>> GetRemovedCompanies(string BranchId)
        {
            Result<Db.Entity.Company> _Result = new();
            List<Db.Entity.Company> Query = null;
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"RemovedCompanies_{BranchId}";
                var cacheData = _cache.Get<Result<Db.Entity.Company>>(cacheKey);
                if (cacheData == null)
                {
                    if (BranchId != "All")
                    {
                        Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == false).ToListAsync();
                    }
                    else
                    {
                        Query = await _ctx.Companies.Where(s => s.IsActive == false).ToListAsync();
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
        public async Task<RepoBase> RecoverCompany(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Id && x.IsActive == false);
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
                        _cache.Remove($"Company_{Query.Fk_BranchId}");
                        _cache.Remove($"RemovedCompanies_{Query.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteCompany(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.Companies.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove($"Company_{Query.Fk_BranchId}");
                        _cache.Remove($"RemovedCompanies_{Query.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllCompany(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var companyIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var companiesToRecover = await _ctx.Companies.Where(x => companyIds.Contains(x.CompanyId) && x.IsActive == false).ToListAsync();
                if (companiesToRecover.Any())
                {
                    foreach (var company in companiesToRecover)
                    {
                        company.ModifyDate = DateTime.UtcNow;
                        company.ModifyBy = user.Name;
                        company.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Company_");
                        _cache.RemoveByPrefix($"RemovedCompanies_");
                        transaction.Commit();
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
        public async Task<RepoBase> DeleteAllCompany(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var companyIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var companiesToDelete = await _ctx.Companies.Where(x => companyIds.Contains(x.CompanyId) && x.IsActive == false).ToListAsync();
                if (companiesToDelete.Any())
                {
                    _ctx.Companies.RemoveRange(companiesToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Company_");
                        _cache.RemoveByPrefix($"RemovedCompanies_");
                        transaction.Commit();
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
