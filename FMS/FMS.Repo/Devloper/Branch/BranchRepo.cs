using AutoMapper;
using EFCore.BulkExtensions;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<RepoBase> GetAllBranch()
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = $"Branches";
                var cacheData = _cache.Get<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Branches.Where(s => s.IsActive == true)
                          .Select(s => new BranchDto()
                          {
                              BranchId = s.BranchId,
                              BranchName = s.BranchName,
                              BranchCode = s.BranchCode,
                              ContactNumber = s.ContactNumber,
                              BranchAddress = s.BranchAddress
                          })
                          .OrderBy(s => s.BranchCode)
                          .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Query.Count();
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
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.Branches.Where(s => s.IsActive == true)
                        .Select(s => new BranchDto()
                        {
                            BranchId = s.BranchId,
                            BranchName = s.BranchName,
                            BranchCode = s.BranchCode,
                            ContactNumber = s.ContactNumber,
                            BranchAddress = s.BranchAddress
                        })
                        .OrderBy(s => s.BranchCode)
                        .Skip(skip)
                        .Take(effectivePageSize)
                        .ToListAsync();
                    Count = _ctx.Branches.Where(s => s.IsActive == true).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.Branches.Where(s => s.IsActive == true && s.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || s.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => new BranchDto()
                        {
                            BranchId = s.BranchId,
                            BranchName = s.BranchName,
                            BranchCode = s.BranchCode,
                            ContactNumber = s.ContactNumber,
                            BranchAddress = s.BranchAddress
                        }).OrderBy(s => s.BranchCode)
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
                        _Result.Records = newBranch;
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
        public async Task<RepoBase> BulkCreateBranch(List<BranchModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingBranch = await _ctx.Branches.Where(b => b.IsActive == true && dataList.Any(br => br.BranchName == b.BranchName))
                    .Select(b => new BranchDto()
                    {
                        BranchId = b.BranchId,
                        BranchName = b.BranchName,
                        BranchCode = b.BranchCode,
                        ContactNumber = b.ContactNumber,
                        BranchAddress = b.BranchAddress
                    }).ToListAsync();
                if (existingBranch.Count == 0)
                {
                    var newBranches = _mapper.Map<List<Db.Entity.Branch>>(dataList);
                    newBranches.ForEach(data => { data.CreatedDate = DateTime.UtcNow; data.CreatedBy = user.Name; });
                    var response = await _ctx.BulkInsert(newBranches);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = newBranches;
                        _cache.Remove("Branches");
                    }
                }
                else
                {
                    _Result.Records = existingBranch;
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
                var existingBranches = await _ctx.Branches.Where(b => b.IsActive == true && listdata.Any(br => br.BranchId == b.BranchId)).ToListAsync();
                var notFoundBranches = listdata.Except(existingBranches).ToList();
                if (notFoundBranches.Count == 0)
                {
                    var branchesToUpdate = _mapper.Map(listdata, existingBranches);
                    branchesToUpdate.ForEach(data => { data.ModifyDate = DateTime.UtcNow; data.ModifyBy = user.Name; });
                    var response = await _ctx.BulkUpdate(branchesToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.Records = branchesToUpdate;
                        _Result.IsSucess = true;
                        _cache.Remove("Branches");
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
                    var IsActiveStatus = UpdateStatus(Query, false);
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
                var existingBranches = await GetBranchesWithRelatedEntity(Ids, true);
                if (existingBranches.Count != 0)
                {
                    foreach (var branch in existingBranches)
                    {
                        var IsActiveStatus = UpdateStatus(branch, false);
                        await _ctx.BulkUpdateMultiple(IsActiveStatus);
                    }
                    existingBranches.ForEach(branch =>
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        branch.IsActive = false;
                    });
                    var response = await _ctx.BulkUpdate(existingBranches);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = existingBranches;
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
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.Branches.Where(s => s.IsActive == false)
                         .Select(s => new BranchDto()
                         {
                             BranchId = s.BranchId,
                             BranchName = s.BranchName,
                             BranchCode = s.BranchCode,
                             ContactNumber = s.ContactNumber,
                             BranchAddress = s.BranchAddress
                         })
                         .OrderBy(s => s.BranchCode)
                         .Skip(skip)
                         .Take(effectivePageSize)
                         .ToListAsync();
                    Count = _ctx.Branches.Where(s => s.IsActive == false).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.Branches.Where(s => s.IsActive == false && (s.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) || s.BranchCode.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)))
                         .Select(s => new BranchDto()
                         {
                             BranchId = s.BranchId,
                             BranchName = s.BranchName,
                             BranchCode = s.BranchCode,
                             ContactNumber = s.ContactNumber,
                             BranchAddress = s.BranchAddress
                         }).OrderBy(s => s.BranchCode)
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
                    if(isActiveRecordExist == null)
                    {
                        var IsActiveStatus = UpdateStatus(Query, true);
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
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
                var existingBranches = await GetBranchesWithRelatedEntity(Ids, false);
                if (existingBranches.Count != 0)
                {
                    var isActiveRecordsExist = await _ctx.Branches.Where(s => s.IsActive == true && listdata.Any(fy => fy.BranchName == s.BranchName)).ToListAsync();
                    var recoverBranchFinancialYear = existingBranches.Except(isActiveRecordsExist).ToList();
                    foreach (var branch in recoverBranchFinancialYear)
                    {
                        var IsActiveStatus = UpdateStatus(branch, true);
                        await _ctx.BulkUpdateMultiple(IsActiveStatus);
                    }
                    recoverBranchFinancialYear.ForEach(branch =>
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        branch.IsActive = true;
                    });
                    var response = await _ctx.BulkUpdate(existingBranches);
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
                    var response = await _ctx.BulkDelete(existingBranches);
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
            return Query;
        }
        private async Task<List<Db.Entity.Branch>> GetBranchesWithRelatedEntity(List<Guid> ids, bool IsActive)
        {
            var Query = await _ctx.Branches.
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
            return Query;
        }
        private Dictionary<string, IList> UpdateStatus(Db.Entity.Branch branch, bool IsActive)
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
            return allRelatedData;
        }
        #endregion
    }
}
