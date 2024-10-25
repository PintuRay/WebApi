using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.Metrics;

namespace FMS.Repo.DevloperSetting
{
    public class DevloperSettingRepo(Context ctx, IMapper mapper, ICustomCache cache) : IDevloperSettingRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Branch
        #region Crud
        public async Task<Result<Branch>> GetAllBranch()
        {
            Result<Branch> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Branches";
                var cacheData = _cache.Get<Result<Branch>>(cacheKey);
                if (cacheData == null) {
                    var Query = await (from s in _ctx.Branches where s.IsActive == true select s).ToListAsync();
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
        public async Task<RepoBase> CreateBranch(BranchModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Branches where s.BranchName == data.BranchName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    _cache.Remove("Branches");
                    Branch newBranch = _mapper.Map<Branch>(data);
                    newBranch.CreatedDate = DateTime.UtcNow;
                    newBranch.CreatedBy = user.Name;
                    await _ctx.Branches.AddAsync(newBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newBranch.BranchId.ToString();
                        _Result.IsSucess = true;
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
                var Query = await (from s in _ctx.Branches where s.BranchId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    _cache.Remove("Branches");
                    Branch updateBranch = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
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
                    _cache.Remove("Branches");
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
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
        public async Task<Result<Branch>> GetRemovedBranches()
        {
            Result<Branch> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Branches where s.IsActive == false select s).ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
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
                    _cache.Remove("Branches");
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
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
                    _cache.Remove("Branches");
                    _ctx.Branches.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
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
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        _cache.Remove("Branches");
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        Count = await _ctx.SaveChangesAsync();
                    }
                    Count++;
                }
                if (Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Count = Count.ToString();
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteAllBranch(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        _cache.Remove("Branches");
                        _ctx.Branches.Remove(Query);
                        Count = await _ctx.SaveChangesAsync();
                    }
                }
                if (Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Count = Count.ToString();
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
        #region Financial Year
        #region Crud
        public async Task<Result<FinancialYear>> GetFinancialYears()
        {
            Result<FinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears
                                   orderby s.StartDate descending
                                   select new FinancialYear
                                   {
                                       FinancialYearId = s.FinancialYearId,
                                       Financial_Year = s.Financial_Year,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                   }).ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> CreateFinancialYear(FinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears where s.Financial_Year == data.Financial_Year && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    FinancialYear newFinancialYear = _mapper.Map<FinancialYear>(data);
                    newFinancialYear.CreatedDate = DateTime.UtcNow;
                    newFinancialYear.CreatedBy = user.Name;
                    await _ctx.FinancialYears.AddAsync(newFinancialYear);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.Id = newFinancialYear.FinancialYearId.ToString();
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears where s.Financial_Year == data.Financial_Year && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    FinancialYear updateFinancialYear = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int count = await _ctx.SaveChangesAsync();
                    if (count > 0)
                    {
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Id && x.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
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
        public async Task<Result<FinancialYear>> GetRemovedFinancialYears()
        {
            Result<FinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears where s.IsActive == false select s).ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.FinancialYears.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        Count = await _ctx.SaveChangesAsync();
                    }
                    Count++;
                }
                if (Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Count = Count.ToString();
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteAllFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(x => x.FinancialYearId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        _ctx.FinancialYears.Remove(Query);
                        Count = await _ctx.SaveChangesAsync();
                    }
                    Count++;
                }
                if (Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Count = Count.ToString();
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
        #region Branch Financial Year
        #region Crud
        public async Task<Result<BranchFinancialYear>> GetBranchFinancialYears()
        {
            Result<BranchFinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears
                                   where s.IsActive == true
                                   select new BranchFinancialYear
                                   {
                                       BranchFinancialYearId = s.BranchFinancialYearId,
                                       Fk_BranchId = s.Fk_BranchId,
                                       Branch = s.Branch != null ? new Branch { BranchName = s.Branch.BranchName } : null,
                                       Fk_FinancialYearId = s.Fk_FinancialYearId,
                                       FinancialYear = s.FinancialYear != null ? new FinancialYear { Financial_Year = s.FinancialYear.Financial_Year } : null,
                                   }).OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<Result<BranchFinancialYear>> GetBranchFinancialYears(Guid BranchId)
        {
            Result<BranchFinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears
                                   where s.Fk_BranchId == BranchId && s.IsActive == true
                                   select s)
                                   .OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();

                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears where s.Fk_FinancialYearId == data.Fk_FinancialYearId && s.Fk_BranchId == data.Fk_BranchId select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newYear = _mapper.Map<BranchFinancialYear>(data);
                    newYear.CreatedDate = DateTime.UtcNow;
                    newYear.CreatedBy = user.Name;
                    await _ctx.BranchFinancialYears.AddAsync(newYear);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newYear.BranchFinancialYearId.ToString();
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears where s.BranchFinancialYearId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    BranchFinancialYear updateBranchFinancialYear = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int count = await _ctx.SaveChangesAsync();
                    if (count > 0)
                    {
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Id && x.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
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
        public async Task<Result<BranchFinancialYear>> GetRemovedBranchFinancialYears()
        {
            Result<BranchFinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears
                                   where s.IsActive == false
                                   select s)
                                 .OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.BranchFinancialYears.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        Count = await _ctx.SaveChangesAsync();
                    }
                    Count++;
                }

                if (Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Count = Count.ToString();
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        _ctx.BranchFinancialYears.Remove(Query);
                        Count = await _ctx.SaveChangesAsync();
                    }
                    Count++;
                }
                if (Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Count = Count.ToString();
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
