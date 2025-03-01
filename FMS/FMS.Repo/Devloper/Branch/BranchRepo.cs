using AutoMapper;
using EFCore.BulkExtensions;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Net;

namespace FMS.Repo.Devloper.Branch
{
    public class BranchRepo(Context ctx, IMapper mapper, IRedisCache cache) : IBranchRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Branch
        #region Crud
        public async Task<RepoBase> GetAllBranch()
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = $"Branches";
                var cacheData = await _cache.GetAsync<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Branches.Where(s => s.IsActive == true)
                          .Select(s => new BranchDto()
                          {
                              BranchId = s.BranchId,
                              BranchName = s.BranchName,
                          })
                          .OrderBy(s => s.BranchName)
                          .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Query.Count();
                        _Result.IsSucess = true;
                        await _cache.SetAsync(cacheKey, _Result, _cacheExpiration);
                    }
                }
                else
                {
                    _Result.Records = JsonConvert.DeserializeObject<List<BranchDto>>(cacheData.Records.ToString());
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
        public async Task<RepoBase> GetAllBranch(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<BranchDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                var branches = await _ctx.Branches
                    .Where(s => s.IsActive == true)
                    .Include(s => s.Address).ThenInclude(a => a.Country)
                    .Include(s => s.Address).ThenInclude(a => a.State)
                    .Include(s => s.Address).ThenInclude(a => a.Dist)
                    .OrderBy(s => s.BranchCode)
                    .ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = branches.Select(s => _mapper.Map<BranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = branches.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = branches
                        .Where(s => s.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<BranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = branches.Count(s => s.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
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
        public async Task<RepoBase> CreateBranch(BranchModel data, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranch = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchName == data.BranchName && s.IsActive == true);
                if (existingBranch == null)
                {
                    var newBranch = _mapper.Map<Db.Entity.Branch>(data);
                    newBranch.BranchId = Guid.NewGuid();
                    newBranch.CreatedDate = DateTime.UtcNow;
                    newBranch.CreatedBy = user.Name;
                    //newBranch.Address.Fk_BranchId = newBranch.BranchId;
                    newBranch.Address.CreatedDate = DateTime.UtcNow;
                    newBranch.Address.CreatedBy = user.Name;
                    await _ctx.Branches.AddAsync(newBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = newBranch;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
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
        public async Task<RepoBase> BulkCreateBranch(List<BranchModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranches = await _ctx.Branches.Where(b => b.IsActive == true && dataList.Select(br => br.BranchName).Contains(b.BranchName)).ToListAsync();
                if (existingBranches.Count == 0)
                {
                    var newBranches = dataList.Select(b =>
                    {
                        var branch = _mapper.Map<Db.Entity.Branch>(b);
                        branch.BranchId = Guid.NewGuid();
                        //branch.Address.Fk_BranchId = branch.BranchId;
                        branch.CreatedDate = DateTime.UtcNow;
                        branch.CreatedBy = user.Name;
                        branch.Address.CreatedDate = DateTime.UtcNow;
                        branch.Address.CreatedBy = user.Name;
                        return branch;
                    }).ToList();
                    var branchResponse = await _ctx.BulkInsert(newBranches, includeGraph: true);
                    if (branchResponse.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = branchResponse.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = newBranches;
                        _cache.Remove("Branches");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to create branches";
                    }
                }
                else
                {
                    _Result.Records = existingBranches;
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
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranch = await _ctx.Branches.Include(s => s.Address).SingleOrDefaultAsync(s => s.BranchId == data.BranchId && s.IsActive == true);
                if (existingBranch != null)
                {
                   var branchesToUpdate = _mapper.Map(data, existingBranch);
                    existingBranch.ModifyDate = DateTime.UtcNow;
                    existingBranch.ModifyBy = user.Name;
                    existingBranch.Address.ModifyDate = DateTime.UtcNow;
                    existingBranch.Address.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = existingBranch;
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkUpdateBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranches = await _ctx.Branches.Include(s => s.Address).Where(b => b.IsActive == true && listdata.Select(br => br.BranchId).Contains(b.BranchId)).ToListAsync();
                var notFoundBranches = listdata.Where(br => !existingBranches.Any(b => b.BranchId == br.BranchId)).ToList();
                if (notFoundBranches.Count == 0)
                {
                    _mapper.Map(listdata, existingBranches);
                    foreach (var branch in existingBranches)
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        if (branch.Address != null)
                        {
                            branch.Address.ModifyDate = DateTime.UtcNow;
                            branch.Address.ModifyBy = user.Name;
                        }
                    }
                    var branchResponse = await _ctx.BulkUpdate(existingBranches, true);
                    if (branchResponse.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = branchResponse.AffectedRows;
                        _Result.Records = existingBranches;
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to update branch";
                    }
                }
                else
                {
                    _Result.Records = notFoundBranches;
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
                    var IsActiveStatus = UpdateStatus(Query, user, false);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    if (Query.Address != null)
                    {
                        Query.Address.ModifyDate = DateTime.UtcNow;
                        Query.Address.ModifyBy = user.Name;
                        Query.Address.IsActive = false;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = Query;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
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
        public async Task<RepoBase> BulkRemoveBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.BranchId).ToList();
                var Query = await GetBranchesWithRelatedEntity(Ids, true);
                if (Query.Count != 0)
                {
                    var IsActiveStatus = BulkUpdateStatus(Query, user, false);
                    Query.ForEach(branch =>
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        branch.IsActive = false;
                        if (branch.Address != null)
                        {
                            branch.Address.ModifyDate = DateTime.UtcNow;
                            branch.Address.ModifyBy = user.Name;
                            branch.Address.IsActive = false;
                        }
                    });
                    var response = await _ctx.BulkUpdate(Query, true);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                        _cache.Remove("Branches");
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
        public async Task<RepoBase> GetRemovedBranches(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<BranchDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                var branches = await _ctx.Branches
                    .Where(s => s.IsActive == false)
                    .Include(s => s.Address).ThenInclude(a => a.Country)
                    .Include(s => s.Address).ThenInclude(a => a.State)
                    .Include(s => s.Address).ThenInclude(a => a.Dist)
                    .OrderBy(s => s.BranchCode)
                    .ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = branches.Select(s => _mapper.Map<BranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = branches.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = branches
                        .Where(s => s.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<BranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = branches.Count(s => s.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
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
        public async Task<RepoBase> RecoverBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetBranchWithRelatedEntity(Id, false);
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchName == Query.BranchName && s.IsActive == true);
                    if (isActiveRecordExist == null)
                    {
                        var IsActiveStatus = UpdateStatus(Query, user, true);
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        if (Query.Address != null)
                        {
                            Query.Address.IsActive = true;
                            Query.Address.ModifyDate = DateTime.UtcNow;
                            Query.Address.ModifyBy = user.Name;
                        }
                        int Count = await _ctx.SaveChangesAsync();
                        if (Count > 0)
                        {
                            await transaction.CommitAsync();
                            _Result.Records = Query;
                            _Result.Count = Count;
                            _Result.IsSucess = true;
                            _cache.Remove("Branches");
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
        public async Task<RepoBase> BulkRecoverBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.BranchId).ToList();
                var removedBranches = await GetBranchesWithRelatedEntity(Ids, false);
                if (removedBranches.Count != 0)
                {
                    var removedBranchNames = removedBranches.Select(b => b.BranchName).ToList();
                    var isActiveRecordsExist = await _ctx.Branches.Where(s => s.IsActive == true && removedBranchNames.Contains(s.BranchName)).ToListAsync();
                    var recoverBranch = removedBranches.Except(isActiveRecordsExist).ToList();
                    var IsActiveStatus = BulkUpdateStatus(recoverBranch, user, true);
                    recoverBranch.ForEach(branch =>
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        branch.IsActive = true;
                        if (branch.Address != null)
                        {
                            branch.Address.ModifyDate = DateTime.UtcNow;
                            branch.Address.ModifyBy = user.Name;
                            branch.Address.IsActive = true;
                        }
                    });
                    var branchResponse = await _ctx.BulkUpdate(recoverBranch, true);
                    if (branchResponse.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = recoverBranch;
                        _Result.Count = branchResponse.AffectedRows;
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
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
        public async Task<RepoBase> DeleteBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetBranchWithRelatedEntity(Id, false);
                if (Query != null)
                {
                    _ctx.Branches.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
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
        public async Task<RepoBase> BulkDeleteBranch(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranches = await GetBranchesWithRelatedEntity(Ids, false);
                if (existingBranches.Count != 0)
                {
                    var response = await _ctx.BulkDelete(existingBranches, true);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
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
        private async Task<Db.Entity.Branch> GetBranchWithRelatedEntity(Guid id, bool IsActive)
        {
            var Query = await _ctx.Branches
                   .Include(s => s.Address)
                   .Include(s => s.FinancialYears)
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
            return Query;
        }
        private async Task<List<Db.Entity.Branch>> GetBranchesWithRelatedEntity(List<Guid> ids, bool IsActive)
        {
            var Query = await _ctx.Branches
                .Include(s => s.Address)
                .Include(s => s.FinancialYears)
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
        private async Task UpdateStatus(Db.Entity.Branch branch, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["FinancialYears"] = branch.FinancialYears?.ToList() ?? null,
                ["UserBranch"] = branch.UserBranch?.ToList() ?? null,
                ["LabourRates"] = branch.LabourRates?.ToList() ?? null,
                ["LedgerSubGroup"] = branch.LedgerSubGroup?.ToList() ?? null,
                ["LedgerSubGroupDev"] = branch.LedgerSubGroupDev?.ToList() ?? null,
                ["Stocks"] = branch.Stocks?.ToList() ?? null,
                ["Labours"] = branch.Labours?.ToList() ?? null,
                ["LedgerBalances"] = branch.LedgerBalances?.ToList() ?? null,
                ["SubLedgers"] = branch.SubLedgers?.ToList() ?? null,
                ["SubLedgerBalances"] = branch.SubLedgerBalances?.ToList() ?? null,
                ["InwardSupplyOrders"] = branch.InwardSupplyOrders?.ToList() ?? null,
                ["InwardSupplyTransactions"] = branch.InwardSupplyTransactions?.ToList() ?? null,
                ["OutwardSupplyOrders"] = branch.OutwardSupplyOrders?.ToList() ?? null,
                ["OutwardSupplyTransactions"] = branch.OutwardSupplyTransactions?.ToList() ?? null,
                ["ProductionOrders"] = branch.ProductionOrders?.ToList() ?? null,
                ["ProductionTransactions"] = branch.ProductionTransactions?.ToList() ?? null,
                ["DamageOrders"] = branch.DamageOrders?.ToList() ?? null,
                ["DamageTransactions"] = branch.DamageTransactions?.ToList() ?? null,
                ["PurchaseOrders"] = branch.PurchaseOrders?.ToList() ?? null,
                ["PurchaseTransactions"] = branch.PurchaseTransactions?.ToList() ?? null,
                ["PurchaseReturnOrders"] = branch.PurchaseReturnOrders?.ToList() ?? null,
                ["PurchaseReturnTransactions"] = branch.PurchaseReturnTransactions?.ToList() ?? null,
                ["SalesOrders"] = branch.SalesOrders?.ToList() ?? null,
                ["SalesTransactions"] = branch.SalesTransactions?.ToList() ?? null,
                ["SalesReturnOrders"] = branch.SalesReturnOrders?.ToList() ?? null,
                ["SalesReturnTransactions"] = branch.SalesReturnTransactions?.ToList() ?? null,
                ["JournalOrders"] = branch.JournalOrders?.ToList() ?? null,
                ["JournalTransactions"] = branch.JournalTransactions?.ToList() ?? null,
                ["PaymentOrders"] = branch.PaymentOrders?.ToList() ?? null,
                ["PaymentTransactions"] = branch.PaymentTransactions?.ToList() ?? null,
                ["ReceiptOrders"] = branch.ReceiptOrders?.ToList() ?? null,
                ["ReceiptTransactions"] = branch.ReceiptTransactions?.ToList() ?? null
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
                await _ctx.BulkUpdateCollection(allRelatedData);
            }
        }
        private async Task BulkUpdateStatus(List<Db.Entity.Branch> branches, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>();
            var collections = new Dictionary<string, ICollection>
            {
                { "FinancialYears", branches.SelectMany(b => b.FinancialYears).ToList() },
                { "UserBranch", branches.SelectMany(b => b.UserBranch).ToList() },
                { "LabourRates", branches.SelectMany(b => b.LabourRates).ToList() },
                { "LedgerSubGroup", branches.SelectMany(b => b.LedgerSubGroup).ToList() },
                { "LedgerSubGroupDev", branches.SelectMany(b => b.LedgerSubGroupDev).ToList() },
                { "Stocks", branches.SelectMany(b => b.Stocks).ToList() },
                { "Labours", branches.SelectMany(b => b.Labours).ToList() },
                { "LedgerBalances", branches.SelectMany(b => b.LedgerBalances).ToList() },
                { "SubLedgers", branches.SelectMany(b => b.SubLedgers).ToList() },
                { "SubLedgerBalances", branches.SelectMany(b => b.SubLedgerBalances).ToList() },
                { "InwardSupplyOrders", branches.SelectMany(b => b.InwardSupplyOrders).ToList() },
                { "InwardSupplyTransactions", branches.SelectMany(b => b.InwardSupplyTransactions).ToList() },
                { "OutwardSupplyOrders", branches.SelectMany(b => b.OutwardSupplyOrders).ToList() },
                { "OutwardSupplyTransactions", branches.SelectMany(b => b.OutwardSupplyTransactions).ToList() },
                { "ProductionOrders", branches.SelectMany(b => b.ProductionOrders).ToList() },
                { "ProductionTransactions", branches.SelectMany(b => b.ProductionTransactions).ToList() },
                { "DamageOrders", branches.SelectMany(b => b.DamageOrders).ToList() },
                { "DamageTransactions", branches.SelectMany(b => b.DamageTransactions).ToList() },
                { "PurchaseOrders", branches.SelectMany(b => b.PurchaseOrders).ToList() },
                { "PurchaseTransactions", branches.SelectMany(b => b.PurchaseTransactions).ToList() },
                { "PurchaseReturnOrders", branches.SelectMany(b => b.PurchaseReturnOrders).ToList() },
                { "PurchaseReturnTransactions", branches.SelectMany(b => b.PurchaseReturnTransactions).ToList() },
                { "SalesOrders", branches.SelectMany(b => b.SalesOrders).ToList() },
                { "SalesTransactions", branches.SelectMany(b => b.SalesTransactions).ToList() },
                { "SalesReturnOrders", branches.SelectMany(b => b.SalesReturnOrders).ToList() },
                { "SalesReturnTransactions", branches.SelectMany(b => b.SalesReturnTransactions).ToList() },
                { "JournalOrders", branches.SelectMany(b => b.JournalOrders).ToList() },
                { "JournalTransactions", branches.SelectMany(b => b.JournalTransactions).ToList() },
                { "PaymentOrders", branches.SelectMany(b => b.PaymentOrders).ToList() },
                { "PaymentTransactions", branches.SelectMany(b => b.PaymentTransactions).ToList() },
                { "ReceiptOrders", branches.SelectMany(b => b.ReceiptOrders).ToList() },
                { "ReceiptTransactions", branches.SelectMany(b => b.ReceiptTransactions).ToList() },
            };
            foreach (var collection in collections)
            {
                if (collection.Value != null && collection.Value.Count > 0)
                {
                    foreach (var entity in collection.Value)
                    {
                        UpdateEntityProperties(entity, user, IsActive);
                    }
                    allRelatedData[collection.Key] = collection.Value.Cast<object>().ToList();
                }
            }
            if (allRelatedData.Count > 0)
            {
                await _ctx.BulkUpdateCollection(allRelatedData);
            }
        }
    }
    #endregion
}

