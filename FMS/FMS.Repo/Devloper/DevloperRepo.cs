using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;

namespace FMS.Repo.Devloper
{
    public class DevloperRepo(Context ctx, IMapper mapper, ICustomCache cache) : IDevloperRepo
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
                    var Query = await (from s in _ctx.Branches where s.IsActive == true select s).OrderBy(s=>s.BranchName).ToListAsync();
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
                var Query = await (from s in _ctx.Branches where s.BranchName == data.BranchName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    Branch newBranch = _mapper.Map<Branch>(data);
                    newBranch.CreatedDate = DateTime.UtcNow;
                    newBranch.CreatedBy = user.Name;
                    await _ctx.Branches.AddAsync(newBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newBranch.BranchId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
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
                    Branch updateBranch = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
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
                        _cache.Remove("Branches");
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
                var cacheKey = "RemovedBranches";
                var cacheData = _cache.Get<Result<Branch>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Branches where s.IsActive == false select s).OrderBy(s=>s.BranchName).ToListAsync();
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
                        _cache.Remove("Branches");
                        _cache.Remove("RemovedBranches");
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
                        _cache.Remove("Branches");
                        _cache.Remove("RemovedBranches");
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
                        _cache.Remove("Branches");
                        _cache.Remove("RemovedBranches");
                    }
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
                        _cache.Remove("Branches");
                        _cache.Remove("RemovedBranches");
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
        #region Financial Year
        #region Crud
        public async Task<Result<FinancialYear>> GetFinancialYears()
        {
            Result<FinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "FinancialYears";
                var cacheData = _cache.Get<Result<FinancialYear>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.FinancialYears
                                       orderby s.StartDate descending
                                       select new FinancialYear
                                       {
                                           FinancialYearId = s.FinancialYearId,
                                           Financial_Year = s.Financial_Year,
                                           StartDate = s.StartDate,
                                           EndDate = s.EndDate,
                                       }).OrderByDescending(s=>s.Financial_Year).ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.IsSucess = true;
                        _cache.Set(cacheKey, _Result, _cacheExpiration);
                    }
                    else
                    {
                        _Result = cacheData;
                    }
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
                    if (Count > 0)
                    {
                        _Result.Id = newFinancialYear.FinancialYearId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
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
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
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
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
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
                var cacheKey = "RecoverFinancialYears";
                var cacheData = _cache.Get<Result<FinancialYear>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.FinancialYears where s.IsActive == false select s).OrderByDescending(s=>s.Financial_Year).ToListAsync();
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
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
                        _cache.Remove("RecoverFinancialYears");
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
                    
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
                        _cache.Remove("RecoverFinancialYears");
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
                _Result.IsSucess = false;
                var financialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var financialYearToRecover = await _ctx.FinancialYears.Where(x => financialYearIds.Contains(x.FinancialYearId) && x.IsActive == false).ToListAsync();
                if (financialYearToRecover.Any())
                {
                    foreach (var financialyear in financialYearToRecover)
                    {
                        financialyear.ModifyDate = DateTime.UtcNow;
                        financialyear.ModifyBy = user.Name;
                        financialyear.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
                        _cache.Remove("RecoverFinancialYears");
                    }
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
                _Result.IsSucess = false;
                var financialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var financialYearToDelete = await _ctx.FinancialYears.Where(x => financialYearIds.Contains(x.FinancialYearId) && x.IsActive == false).ToListAsync();
                if (financialYearToDelete.Any())
                {
                    _ctx.FinancialYears.RemoveRange(financialYearToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("FinancialYears");
                        _cache.Remove("RecoverFinancialYears");
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
        #region Branch Financial Year
        #region Crud
        public async Task<Result<BranchFinancialYear>> GetBranchFinancialYears()
        {
            Result<BranchFinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "BranchFinancialYear";
                var cacheData = _cache.Get<Result<BranchFinancialYear>>(cacheKey);
                if (cacheData == null)
                {
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
        public async Task<Result<BranchFinancialYear>> GetBranchFinancialYears(Guid BranchId)
        {
            Result<BranchFinancialYear> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "BranchFinancialYearsByBranchId";
                var cacheData = _cache.Get<Result<BranchFinancialYear>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.BranchFinancialYears
                                       where s.Fk_BranchId == BranchId && s.IsActive == true
                                       select s)
                                   .OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();

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
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
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
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
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
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
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
                var cacheKey = "RemovedBranchFinancialYears";
                var cacheData = _cache.Get<Result<BranchFinancialYear>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.BranchFinancialYears
                                       where s.IsActive == false
                                       select s).OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();
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
                   
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
                        _cache.Remove("RemovedBranchFinancialYears");
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
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
                        _cache.Remove("RemovedBranchFinancialYears");
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
                _Result.IsSucess = false;
                var branchFinancialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var branchFinancialYearToRecover = await _ctx.BranchFinancialYears.Where(x => branchFinancialYearIds.Contains(x.BranchFinancialYearId) && x.IsActive == false).ToListAsync();
                if (branchFinancialYearToRecover.Any())
                {
                    foreach (var branchFinancialYear in branchFinancialYearToRecover)
                    {
                        branchFinancialYear.ModifyDate = DateTime.UtcNow;
                        branchFinancialYear.ModifyBy = user.Name;
                        branchFinancialYear.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
                        _cache.Remove("RemovedBranchFinancialYears");
                    }
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
                _Result.IsSucess = false;
                var branchFinancialYearIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var branchFinancialYearToDelete = await _ctx.BranchFinancialYears.Where(x => branchFinancialYearIds.Contains(x.BranchFinancialYearId) && x.IsActive == false).ToListAsync();
                if (branchFinancialYearToDelete.Any())
                {
                    _ctx.BranchFinancialYears.RemoveRange(branchFinancialYearToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("BranchFinancialYear");
                        _cache.Remove("BranchFinancialYearsByBranchId");
                        _cache.Remove("RemovedBranchFinancialYears");
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
