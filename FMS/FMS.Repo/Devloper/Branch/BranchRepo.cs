using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Devloper.Branch
{
    public class BranchRepo(Context ctx, IMapper mapper, IRedisCache cache) : IBranchRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Branch
        #region Crud
        public async Task<Result<Db.Entity.Branch>> GetAllBranch(PaginationParams pagination)
        {
            Result<Db.Entity.Branch> _Result = new();
            List<Db.Entity.Branch> Query = [];
            try
            {
                _Result.IsSucess = false;
                string cacheKey = (pagination.PageNumber > 0 && pagination.PageSize > 0) ? $"Branches_{pagination.PageNumber}_{pagination.PageSize}_{pagination.SearchTerm}" : "Branches";
                var cacheData = _cache.Get<Result<Db.Entity.Branch>>(cacheKey);
                if (cacheData == null)
                {
                    int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                    if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                    {
                        Query = await _ctx.Branches.Where(s => s.IsActive == true)
                            .Select(s => new Db.Entity.Branch()
                            {
                                BranchId = s.BranchId,
                                BranchName = s.BranchName,
                                BranchCode = s.BranchCode,
                                ContactNumber = s.ContactNumber,
                                BranchAddress = s.BranchAddress
                            })
                            .OrderBy(s => s.BranchName)
                            .Skip(pagination.PageNumber * effectivePageSize)
                            .Take(effectivePageSize)
                            .ToListAsync();
                    }
                    else
                    {
                        string searchTerm = pagination.SearchTerm.Trim().ToLower();
                        var branches = await _ctx.Branches.Where(s => s.IsActive == true)
                            .Select(s => new Db.Entity.Branch()
                            {
                                BranchId = s.BranchId,
                                BranchName = s.BranchName,
                                BranchCode = s.BranchCode,
                                ContactNumber = s.ContactNumber,
                                BranchAddress = s.BranchAddress
                            }).ToListAsync();
                        Query = branches.Where(b => b.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || b.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)).ToList();
                    }
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.Count = _Result.CollectionObjData.Count;
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
                var Query = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchName == data.BranchName && s.IsActive == true);
                if (Query == null)
                {
                    var newBranch = _mapper.Map<Db.Entity.Branch>(data);
                    newBranch.CreatedDate = DateTime.UtcNow;
                    newBranch.CreatedBy = user.Name;
                    await _ctx.Branches.AddAsync(newBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newBranch.BranchId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                       _cache.RemoveByPrefix("Branches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkCreateBranch(List<BranchModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchNames = dataList.Select(b => b.BranchName).ToList();
                var existingBranchNames = await _ctx.Branches.Where(b => b.IsActive == true && branchNames.Contains(b.BranchName)).Select(b => b.BranchName).ToListAsync();
                if (!existingBranchNames.Any())
                {
                    var newBranches = dataList.Select(data =>
                    {
                        var branch = _mapper.Map<Db.Entity.Branch>(data);
                        branch.CreatedDate = DateTime.UtcNow;
                        branch.CreatedBy = user.Name;
                        return branch;
                    }).ToList();
                    await _ctx.Branches.AddRangeAsync(newBranches);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = newBranches.Select(b => b.BranchId.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                       _cache.RemoveByPrefix("Branches");
                    }
                }
                else
                {
                    _Result.Data = existingBranchNames;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateBranch(BranchUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchId == data.BranchId && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = data.BranchId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                       _cache.RemoveByPrefix("Branches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkUpdateBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var branchIds = listdata.Select(s=> s.BranchId).ToList();
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && branchIds.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = branchIds.Except(existingBranchIds).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    var branchesToUpdate = await _ctx.Branches.Where(b => b.IsActive == true && branchIds.Contains(b.BranchId)).ToListAsync();
                    foreach (var branch in branchesToUpdate)
                    {
                        var updateData = listdata.First(u => u.BranchId == branch.BranchId);
                       _mapper.Map(updateData, branch);
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = branchIds.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                       _cache.RemoveByPrefix("Branches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    #region Update Related Entity
                    await _ctx.BranchFinancialYears.Where(bf => bf.Fk_BranchId == Id && bf.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.Companies.Where(c => c.Fk_BranchId == Id && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.UserBranches.Where(c => c.Fk_BranchId == Id && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.LabourRates.Where(c => c.Fk_BranchId == Id && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    #endregion
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
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
        public async Task<RepoBase> BulkRemoveBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    int Count = await _ctx.Branches.Where(x => Ids.Contains(x.BranchId) && x.IsActive == true)
                             .ExecuteUpdateAsync(s => s
                                 .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                                 .SetProperty(p => p.ModifyBy, user.Name)
                                 .SetProperty(p => p.IsActive, false)
                             );
                    #region Update Related Entity
                    await _ctx.BranchFinancialYears.Where(bf => Ids.Contains(bf.Fk_BranchId) && bf.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.Companies.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.UserBranches.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    await _ctx.LabourRates.Where(c => Ids.Contains((Guid)c.Fk_BranchId) && c.IsActive == true).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));
                    #endregion
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
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
        public async Task<Result<Db.Entity.Branch>> GetRemovedBranches(PaginationParams pagination)
        {
            Result<Db.Entity.Branch> _Result = new();
            List<Db.Entity.Branch> Query = [];
            try
            {
                _Result.IsSucess = false;
                string cacheKey = pagination.PageNumber > 0 && pagination.PageSize > 0 ? $"RemovedBranches_{pagination.PageNumber}_{pagination.PageSize}_{pagination.SearchTerm}" : "RemovedBranches";
                var cacheData = _cache.Get<Result<Db.Entity.Branch>>(cacheKey);
                if (cacheData == null)
                {
                    int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                    if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                    {
                        Query = await _ctx.Branches.Where(s => s.IsActive == false)
                             .Select(s => new Db.Entity.Branch()
                             {
                                 BranchId = s.BranchId,
                                 BranchName = s.BranchName,
                                 BranchCode = s.BranchCode,
                                 ContactNumber = s.ContactNumber,
                                 BranchAddress = s.BranchAddress
                             })
                             .OrderBy(s => s.BranchName)
                             .Skip(pagination.PageNumber * effectivePageSize)
                             .Take(effectivePageSize)
                             .ToListAsync();
                    }
                    else
                    {
                        string searchTerm = pagination.SearchTerm.Trim().ToLower();
                        var branches = await _ctx.Branches.Where(s => s.IsActive == false)
                             .Select(s => new Db.Entity.Branch()
                             {
                                 BranchId = s.BranchId,
                                 BranchName = s.BranchName,
                                 BranchCode = s.BranchCode,
                                 ContactNumber = s.ContactNumber,
                                 BranchAddress = s.BranchAddress
                             }).ToListAsync();
                        Query = branches.Where(b => b.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || b.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)).ToList();
                    }
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.Count = _Result.CollectionObjData.Count;
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
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == false);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    #region Update Related Entity
                    await _ctx.BranchFinancialYears.Where(bf => bf.Fk_BranchId == Id && bf.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    await _ctx.Companies.Where(c => c.Fk_BranchId == Id && c.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    await _ctx.UserBranches.Where(c => c.Fk_BranchId == Id && c.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    await _ctx.LabourRates.Where(c => c.Fk_BranchId == Id && c.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    #endregion
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
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
        public async Task<RepoBase> BulkRecoverBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    int Count = await _ctx.Branches.Where(x => Ids.Contains(x.BranchId) && x.IsActive == false).
                       ExecuteUpdateAsync(s => s
                       .SetProperty(p => p.ModifyDate, DateTime.UtcNow)
                       .SetProperty(p => p.ModifyBy, user.Name)
                       .SetProperty(p => p.IsActive, true)
                       );
                    #region Update Related Entity
                    await _ctx.BranchFinancialYears.Where(bf => Ids.Contains(bf.Fk_BranchId) && bf.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    await _ctx.Companies.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    await _ctx.UserBranches.Where(bf => Ids.Contains(bf.Fk_BranchId) && bf.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    await _ctx.LabourRates.Where(c => Ids.Contains((Guid)c.Fk_BranchId) && c.IsActive == false).ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));
                    #endregion
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
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
                var Query = await _ctx.Branches
                          .Include(x => x.BranchFinancialYears)
                          .Include(x => x.Companies)
                          .Include(x => x.UserBranch)
                          .Include(x => x.LabourRates)
                          .SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.Branches.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == false && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    int Count = await _ctx.Branches.Include(x => x.BranchFinancialYears)
                                    .Include(x => x.Companies)
                                    .Include(x => x.UserBranch)
                                    .Include(x => x.LabourRates)
                                    .Where(b => b.IsActive == false && Ids.Contains(b.BranchId))
                                    .ExecuteDeleteAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("Branches");
                        _cache.RemoveByPrefix("RemovedBranches");
                    }
                }
                else
                {
                    _Result.Ids = notFoundBranchIds.Select(id => id.ToString()).ToList();
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
        #endregion
    }
}
