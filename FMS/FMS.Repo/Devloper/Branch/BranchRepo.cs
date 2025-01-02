using AutoMapper;
using EFCore.BulkExtensions;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
                if (existingBranchNames.Count == 0)
                {
                    var newBranches = _mapper.Map<List<Db.Entity.Branch>>(dataList);
                    newBranches.ForEach(data => { data.CreatedDate = DateTime.UtcNow; data.CreatedBy = user.Name; });
                    var response = await _ctx.BulkInsert(newBranches);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = newBranches.Select(b => b.BranchId.ToString()).ToList();
                        _Result.Count = response.AffectedRows.ToString();
                        _Result.IsSucess = true;
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
                var branchIds = listdata.Select(s => s.BranchId).ToList();
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == true && branchIds.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = branchIds.Except(existingBranchIds).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    var branches = await _ctx.Branches.Where(b => b.IsActive == true && branchIds.Contains(b.BranchId)).ToListAsync();
                    var branchesToUpdate = _mapper.Map(listdata, branches);
                    branchesToUpdate.ForEach(data => { data.ModifyDate = DateTime.UtcNow; data.ModifyBy = user.Name; });
                    var response = await _ctx.BulkUpdate(branchesToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = branchIds.Select(id => id.ToString()).ToList();
                        _Result.Count = response.AffectedRows.ToString();
                        _Result.IsSucess = true;
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
                var Query = await GetBranchWithRelatedEntity(Id, true);
                if (Query != null)
                {
                    var response = await BulkUpdateMultiple(Query, false);
                    if (response.IsSuccess) {
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = false;
                        int Count = await _ctx.SaveChangesAsync() + response.AffectedRows;
                        if (Count > 0)
                        {
                            await transaction.CommitAsync();
                            _Result.Id = Id.ToString();
                            _Result.Count = Count.ToString();
                            _Result.IsSucess = true;
                            _cache.RemoveByPrefix("Branches");
                        }
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
            List<BulkOperationResult> bulkOperations = [];
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranches = await GetBranchesWithRelations(Ids, true);
                var notFoundBranchIds = Ids.Except(existingBranches.Select(s => s.BranchId)).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    foreach (var branch in existingBranches)
                    {
                        var response = await BulkUpdateMultiple(branch, false); 
                        bulkOperations.Add(response);
                    }
                    existingBranches.ForEach(branch => {
                        branch.ModifyDate = DateTime.UtcNow; 
                        branch.ModifyBy = user.Name; 
                        branch.IsActive = false; 
                    });
                    bulkOperations.Add(await _ctx.BulkUpdate(existingBranches));
                    int Count = bulkOperations.Select(s => s.AffectedRows).Sum();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
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
                    #region Recover Related Entity
                    var branchFinancialYears = await _ctx.BranchFinancialYears.Where(bf => bf.Fk_BranchId == Id && bf.IsActive == false).ToListAsync();
                    var companies = await _ctx.Companies.Where(c => c.Fk_BranchId == Id && c.IsActive == false).ToListAsync();
                    var userBranches = await _ctx.UserBranches.Where(c => c.Fk_BranchId == Id && c.IsActive == false).ToListAsync();
                    var labourRates = await _ctx.LabourRates.Where(c => c.Fk_BranchId == Id && c.IsActive == false).ToListAsync();
                    branchFinancialYears.ForEach(bf => bf.IsActive = true);
                    companies.ForEach(c => c.IsActive = true);
                    userBranches.ForEach(ub => ub.IsActive = true);
                    labourRates.ForEach(lr => lr.IsActive = true);
                    await Task.WhenAll(
                            _ctx.BulkUpdate(branchFinancialYears),
                            _ctx.BulkUpdate(companies),
                            _ctx.BulkUpdate(userBranches),
                            _ctx.BulkUpdate(labourRates)
                            );
                    #endregion
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
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
                var existingBranchIds = await _ctx.Branches.Where(b => b.IsActive == false && Ids.Contains(b.BranchId)).Select(b => b.BranchId).ToListAsync();
                var notFoundBranchIds = Ids.Except(existingBranchIds).ToList();
                if (notFoundBranchIds.Count == 0)
                {
                    var branchesToRecover = await _ctx.Branches.Where(x => Ids.Contains(x.BranchId) && x.IsActive == false).ToListAsync();
                    branchesToRecover.ForEach(branch => { branch.ModifyDate = DateTime.UtcNow; branch.ModifyBy = user.Name; branch.IsActive = true; });
                    await _ctx.BulkUpdate(branchesToRecover);
                    #region Update Related Entity
                    var branchFinancialYears = await _ctx.BranchFinancialYears.Where(bf => Ids.Contains(bf.Fk_BranchId) && bf.IsActive == false).ToListAsync();
                    var companies = await _ctx.Companies.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == false).ToListAsync();
                    var userBranches = await _ctx.UserBranches.Where(c => Ids.Contains(c.Fk_BranchId) && c.IsActive == false).ToListAsync();
                    var labourRates = await _ctx.LabourRates.Where(c => Ids.Contains((Guid)c.Fk_BranchId) && c.IsActive == false).ToListAsync();
                    branchFinancialYears.ForEach(bf => bf.IsActive = true);
                    companies.ForEach(c => c.IsActive = true);
                    userBranches.ForEach(ub => ub.IsActive = true);
                    labourRates.ForEach(lr => lr.IsActive = true);
                    await Task.WhenAll(
                            _ctx.BulkUpdate(branchFinancialYears),
                            _ctx.BulkUpdate(companies),
                            _ctx.BulkUpdate(userBranches),
                            _ctx.BulkUpdate(labourRates)
                            );
                    #endregion
                    await transaction.CommitAsync();
                    _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                    _Result.Count = _Result.Ids.Count.ToString();
                    _Result.IsSucess = true;
                    _cache.RemoveByPrefix("Branches");
                    _cache.RemoveByPrefix("RemovedBranches");
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
                //if DeleteBehavior.Cascade not set then first you have to include related entities then delete
                //var Query = await _ctx.Branches
                //          .Include(x => x.BranchFinancialYears)
                //          .Include(x => x.Companies)
                //          .Include(x => x.UserBranch)
                //          .Include(x => x.LabourRates)
                //          .SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == false);
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
                    #region Delete Related Entity (If DeleteBehavior.Cascade not set)
                    // var branchFinancialYears = await _ctx.BranchFinancialYears.Where(bf => Ids.Contains(bf.Fk_BranchId)).ToListAsync();
                    // var companies = await _ctx.Companies.Where(c => Ids.Contains(c.Fk_BranchId)).ToListAsync();
                    // var userBranches = await _ctx.UserBranches.Where(ub => Ids.Contains(ub.Fk_BranchId)).ToListAsync();
                    // var labourRates = await _ctx.LabourRates.Where(lr => Ids.Contains((Guid)lr.Fk_BranchId)).ToListAsync();
                    // await Task.WhenAll(
                    //    _ctx.BulkDelete(branchFinancialYears),
                    //    _ctx.BulkDelete(companies),
                    //    _ctx.BulkDelete(userBranches),
                    //    _ctx.BulkDelete(labourRates)
                    //);
                    #endregion
                    var branchesToDelete = await _ctx.Branches.Where(b => b.IsActive == false && Ids.Contains(b.BranchId)).ToListAsync();
                    await _ctx.BulkDelete(branchesToDelete);
                    await transaction.CommitAsync();
                    _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                    _Result.Count = _Result.Ids.Count.ToString();
                    _Result.IsSucess = true;
                    _cache.RemoveByPrefix("Branches");
                    _cache.RemoveByPrefix("RemovedBranches");
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
        private async Task<Db.Entity.Branch> GetBranchWithRelatedEntity(Guid id, bool IsActive)
        {
            return await _ctx.Branches
                   .Include(s => s.BranchFinancialYears)
                   .Include(s => s.Companies)
                   .Include(s => s.UserBranch)
                   .Include(s => s.LabourRates)
                   .Include(s => s.LedgerSubGroup)
                   .Include(s => s.LedgerSubGroupDev)
                   .Include(s => s.Stocks)
                   .Include(s => s.Labours)
                   .Include(s => s.LedgerBalances)
                   .Include(s => s.SubLedgers)
                   .Include(s => s.SubLedgerBalances)
                   .Include(s => s.InwardSupplyOrders)
                   .Include(s => s.InwardSupplyTransactions)
                   .Include(s => s.OutwardSupplyOrders)
                   .Include(s => s.OutwardSupplyTransactions)
                   .Include(s => s.ProductionOrders)
                   .Include(s => s.ProductionTransactions)
                   .Include(s => s.DamageOrders)
                   .Include(s => s.DamageTransactions)
                   .Include(s => s.PurchaseOrders)
                   .Include(s => s.PurchaseTransactions)
                   .Include(s => s.PurchaseReturnOrders)
                   .Include(s => s.PurchaseReturnTransactions)
                   .Include(s => s.SalesOrders)
                   .Include(s => s.SalesTransactions)
                   .Include(s => s.SalesReturnOrders)
                   .Include(s => s.SalesReturnTransactions)
                   .Include(s => s.JournalOrders)
                   .Include(s => s.JournalTransactions)
                   .Include(s => s.PaymentOrders)
                   .Include(s => s.PaymentTransactions)
                   .Include(s => s.ReceiptOrders)
                   .Include(s => s.ReceiptTransactions)
                  .SingleOrDefaultAsync(x => x.BranchId == id && x.IsActive == IsActive);
        }
        private async Task<List<Db.Entity.Branch>> GetBranchesWithRelations(List<Guid> ids, bool IsActive)
        {
            return await _ctx.Branches.
                Include(s => s.BranchFinancialYears)
                .Include(s => s.Companies)
                .Include(s => s.UserBranch)
                .Include(s => s.LabourRates)
                .Include(s => s.LedgerSubGroup)
                .Include(s => s.LedgerSubGroupDev)
                .Include(s => s.Stocks)
                .Include(s => s.Labours)
                .Include(s => s.LedgerBalances)
                .Include(s => s.SubLedgers)
                .Include(s => s.SubLedgerBalances)
                .Include(s => s.InwardSupplyOrders)
                .Include(s => s.InwardSupplyTransactions)
                .Include(s => s.OutwardSupplyOrders)
                .Include(s => s.OutwardSupplyTransactions)
                .Include(s => s.ProductionOrders)
                .Include(s => s.ProductionTransactions)
                .Include(s => s.DamageOrders)
                .Include(s => s.DamageTransactions)
                .Include(s => s.PurchaseOrders)
                .Include(s => s.PurchaseTransactions)
                .Include(s => s.PurchaseReturnOrders)
                .Include(s => s.PurchaseReturnTransactions)
                .Include(s => s.SalesOrders)
                .Include(s => s.SalesTransactions)
                .Include(s => s.SalesReturnOrders)
                .Include(s => s.SalesReturnTransactions)
                .Include(s => s.JournalOrders)
                .Include(s => s.JournalTransactions)
                .Include(s => s.PaymentOrders)
                .Include(s => s.PaymentTransactions)
                .Include(s => s.ReceiptOrders)
                .Include(s => s.ReceiptTransactions)
                .Where(b => b.IsActive == IsActive && ids.Contains(b.BranchId)).ToListAsync();
        }
        private async Task<BulkOperationResult> BulkUpdateMultiple(Db.Entity.Branch branch, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["BranchFinancialYears"] = branch.BranchFinancialYears?.ToList() ?? [],
                ["Companies"] = branch.Companies?.ToList() ?? [],
                ["UserBranch"] = branch.UserBranch?.ToList() ?? [],
                ["LabourRates"] = branch.LabourRates?.ToList() ?? [],
                ["LedgerSubGroup"] = branch.LedgerSubGroup?.ToList() ?? [],
                ["LedgerSubGroupDev"] = branch.LedgerSubGroupDev?.ToList() ?? [],
                ["Stocks"] = branch.Stocks?.ToList() ?? [],
                ["Labours"] = branch.Labours?.ToList() ?? [],
                ["LedgerBalances"] = branch.LedgerBalances?.ToList() ?? [],
                ["SubLedgers"] = branch.SubLedgers?.ToList() ?? [],
                ["SubLedgerBalances"] = branch.SubLedgerBalances?.ToList() ?? [],
                ["InwardSupplyOrders"] = branch.InwardSupplyOrders?.ToList() ?? [],
                ["InwardSupplyTransactions"] = branch.InwardSupplyTransactions?.ToList() ?? [],
                ["OutwardSupplyOrders"] = branch.OutwardSupplyOrders?.ToList() ?? [],
                ["OutwardSupplyTransactions"] = branch.OutwardSupplyTransactions?.ToList() ?? [],
                ["ProductionOrders"] = branch.ProductionOrders?.ToList() ?? [],
                ["ProductionTransactions"] = branch.ProductionTransactions?.ToList() ?? [],
                ["DamageOrders"] = branch.DamageOrders?.ToList() ?? [],
                ["DamageTransactions"] = branch.DamageTransactions?.ToList() ?? [],
                ["PurchaseOrders"] = branch.PurchaseOrders?.ToList() ?? [],
                ["PurchaseTransactions"] = branch.PurchaseTransactions?.ToList() ?? [],
                ["PurchaseReturnOrders"] = branch.PurchaseReturnOrders?.ToList() ?? [],
                ["PurchaseReturnTransactions"] = branch.PurchaseReturnTransactions?.ToList() ?? [],
                ["SalesOrders"] = branch.SalesOrders?.ToList() ?? [],
                ["SalesTransactions"] = branch.SalesTransactions?.ToList() ?? [],
                ["SalesReturnOrders"] = branch.SalesReturnOrders?.ToList() ?? [],
                ["SalesReturnTransactions"] = branch.SalesReturnTransactions?.ToList() ?? [],
                ["JournalOrders"] = branch.JournalOrders?.ToList() ?? [],
                ["JournalTransactions"] = branch.JournalTransactions?.ToList() ?? [],
                ["PaymentOrders"] = branch.PaymentOrders?.ToList() ?? [],
                ["PaymentTransactions"] = branch.PaymentTransactions?.ToList() ?? [],
                ["ReceiptOrders"] = branch.ReceiptOrders?.ToList() ?? [],
                ["ReceiptTransactions"] = branch.ReceiptTransactions?.ToList() ?? []
            };
            foreach (var group in allRelatedData) 
            {
                if (group.Value.Count != 0)
                {
                    foreach (var entity in group.Value)
                    {
                        var propertyInfo = entity.GetType().GetProperty("IsActive");
                        if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool?))
                        {
                            propertyInfo.SetValue(entity, IsActive);
                        }
                    }
                }
            }
            return await _ctx.BulkUpdateMultiple(allRelatedData);
        }
        #endregion
    }
}
