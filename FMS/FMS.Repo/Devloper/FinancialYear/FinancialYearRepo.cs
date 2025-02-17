using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace FMS.Repo.Devloper.FinancialYear
{
    public class FinancialYearRepo(Context ctx, IMapper mapper, IRedisCache cache) : IFinancialYearRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Financial Year
        #region Crud
        public async Task<RepoBase> GetFinancialYears(Guid BranchId)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = $"FinancialYears_{BranchId}";
                var cacheData = _cache.Get<RepoBase>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.FinancialYears.Where(s => s.IsActive == true && s.Fk_BranchId == BranchId).
                                   Select(s => new FinancialYearDto()
                                   {
                                       FinancialYearId = s.FinancialYearId,
                                       Financial_Year = s.Financial_Year,
                                   }).OrderByDescending(s => s.Financial_Year)
                                         .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.IsSucess = true;
                        _Result.Count = Query.Count();
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
        public async Task<RepoBase> GetFinancialYears(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<FinancialYearDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.FinancialYears.Where(s => s.IsActive == true).
                               Select(s => new FinancialYearDto()
                               {
                                   FinancialYearId = s.FinancialYearId,
                                   Branch = s.Branch,
                                   Financial_Year = s.Financial_Year,
                                   StartDate = s.StartDate,
                                   EndDate = s.EndDate,
                               }).OrderByDescending(s => s.Financial_Year)
                                     .Skip(pagination.PageNumber * effectivePageSize)
                                     .Take(effectivePageSize)
                                     .ToListAsync();
                    Count = _ctx.FinancialYears.Where(s => s.IsActive == true).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.FinancialYears.Where(s => s.IsActive == true && s.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)).
                               Select(s => new FinancialYearDto()
                               {
                                   FinancialYearId = s.FinancialYearId,
                                   Branch = s.Branch,
                                   Financial_Year = s.Financial_Year,
                                   StartDate = s.StartDate,
                                   EndDate = s.EndDate,
                               }).OrderByDescending(s => s.Financial_Year)
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
        public async Task<RepoBase> CreateFinancialYear(FinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(s => s.Financial_Year == data.Financial_Year && s.Fk_BranchId == data.Fk_BranchId && s.IsActive == true);
                if (Query == null)
                {
                    var newFinancialYear = _mapper.Map<Db.Entity.FinancialYear>(data);
                    newFinancialYear.CreatedDate = DateTime.UtcNow;
                    newFinancialYear.CreatedBy = user.Name;
                    await _ctx.FinancialYears.AddAsync(newFinancialYear);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = newFinancialYear;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkCreateFinancialYear(List<FinancialYearModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingFinancialYears = await _ctx.FinancialYears.Where(f => f.IsActive == true && dataList.Any(b => b.Fk_BranchId == f.Fk_BranchId && b.Financial_Year == f.Financial_Year)).ToListAsync();
                if (existingFinancialYears.Count == 0)
                {
                    var newFinancialYears = dataList.Select(data =>
                    {
                        var financialYear = _mapper.Map<Db.Entity.FinancialYear>(data);
                        financialYear.CreatedDate = DateTime.UtcNow;
                        financialYear.CreatedBy = user.Name;
                        return financialYear;
                    }).ToList();
                    var response = await _ctx.BulkInsert(newFinancialYears);
                    if (response.IsSuccess)
                    {
                        _Result.Records = newFinancialYears;
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        await transaction.CommitAsync();
                        _cache.RemoveByPrefix("FinancialYears_");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to create FinancialYears";
                    }
                }
                else
                {
                    _Result.Records = existingFinancialYears;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateFinancialYear(FinancialYearUpdateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.FinancialYears.SingleOrDefaultAsync(s => s.FinancialYearId == data.FinancialYearId && s.IsActive == true);
                if (Query != null)
                {
                    var financialYearToUpdate = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Records = Query;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkUpdateFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingFinancialYears = await _ctx.FinancialYears.Where(b => b.IsActive == true && dataList.Select(f => f.FinancialYearId).Contains(b.FinancialYearId)).ToListAsync();
                var notFoundFinancialYears = dataList.Where(fy => !existingFinancialYears.Any(b => b.FinancialYearId == fy.FinancialYearId)).ToList();
                if (notFoundFinancialYears.Count == 0)
                {
                    var financialYearsToUpdate = existingFinancialYears.Select(financialYear =>
                    {
                        var updateData = dataList.First(u => u.FinancialYearId == financialYear.FinancialYearId);
                        _mapper.Map(updateData, financialYear);
                        financialYear.ModifyDate = DateTime.UtcNow; 
                        financialYear.ModifyBy = user.Name;
                        return financialYear;
                    }).ToList();
                    var response = await _ctx.BulkUpdate(financialYearsToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.Records = financialYearsToUpdate;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears_");
                    }
                }
                else
                {
                    _Result.Records = notFoundFinancialYears;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetFinancialYearWithRelatedEntity(Id, true);
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
                        _cache.RemoveByPrefix("FinancialYears_");
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
        public async Task<RepoBase> BulkRemoveFinancialYear(List<FinancialYearUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Ids = listdata.Select(s => s.FinancialYearId).ToList();
                var Query = await GetFinancialYearsWithRelatedEntity(Ids, true);
                if (Query.Count != 0)
                {
                    var IsActiveStatus = BulkUpdateStatus(Query, user, false);
                    Query.ForEach(fy =>
                    {
                        fy.ModifyDate = DateTime.UtcNow;
                        fy.ModifyBy = user.Name;
                        fy.IsActive = false;
                    });
                    var response = await _ctx.BulkUpdate(Query);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                        _cache.RemoveByPrefix("FinancialYears_");
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
        public async Task<RepoBase> GetRemovedFinancialYears(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<FinancialYearDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = await _ctx.FinancialYears.Where(s => s.IsActive == false).Select(s =>
                               new FinancialYearDto()
                               {
                                   FinancialYearId = s.FinancialYearId,
                                   Financial_Year = s.Financial_Year,
                                   StartDate = s.StartDate,
                                   EndDate = s.EndDate,
                               }).OrderByDescending(s => s.Financial_Year)
                               .Skip(pagination.PageNumber * effectivePageSize)
                               .Take(effectivePageSize)
                               .ToListAsync();
                    Count = _ctx.FinancialYears.Where(s => s.IsActive == false).Count();
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = await _ctx.FinancialYears.Where(s => s.IsActive == false && s.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)).Select(s =>
                              new FinancialYearDto()
                              {
                                  FinancialYearId = s.FinancialYearId,
                                  Financial_Year = s.Financial_Year,
                                  StartDate = s.StartDate,
                                  EndDate = s.EndDate,
                              }).ToListAsync();
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
        public async Task<RepoBase> RecoverFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetFinancialYearWithRelatedEntity(Id, false);
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.FinancialYears.SingleOrDefaultAsync(s => s.Fk_BranchId == Query.Fk_BranchId && s.Financial_Year == Query.Financial_Year && s.IsActive == true);
                    if (isActiveRecordExist == null)
                    {
                        var IsActiveStatus = UpdateStatus(Query, user, true);
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
                            _cache.RemoveByPrefix("FinancialYears_");
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
        public async Task<RepoBase> BulkRecoverFinancialYear(List<FinancialYearUpdateModel> listdata, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                var Ids = listdata.Select(s => s.FinancialYearId).ToList();
                var removedFinancialYears = await GetFinancialYearsWithRelatedEntity(Ids, false);
                if (removedFinancialYears.Count != 0)
                {
                    var isActiveRecordsExist = await _ctx.FinancialYears.Where(s => s.IsActive == true && removedFinancialYears.Any(b => b.Fk_BranchId == s.Fk_BranchId && b.Financial_Year == s.Financial_Year)).ToListAsync();
                    var recoverFinancialYears = removedFinancialYears.Except(isActiveRecordsExist).ToList();
                    var IsActiveStatus = BulkUpdateStatus(recoverFinancialYears, user, true);
                    recoverFinancialYears.ForEach(fy =>
                    {
                        fy.ModifyDate = DateTime.UtcNow;
                        fy.ModifyBy = user.Name;
                        fy.IsActive = true;
                    });
                    var response = await _ctx.BulkUpdate(recoverFinancialYears);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _Result.Records = recoverFinancialYears;
                        _cache.RemoveByPrefix("FinancialYears_");
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
        public async Task<RepoBase> DeleteFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await GetFinancialYearWithRelatedEntity(Id, false);
                if (Query != null)
                {
                    _ctx.FinancialYears.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears_");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkDeleteFinancialYear(List<Guid> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingFinancialYears = await GetFinancialYearsWithRelatedEntity(Ids, false);
                if (existingFinancialYears.Count != 0)
                {
                    var response = await _ctx.BulkDelete(existingFinancialYears);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
                        _Result.Count = response.AffectedRows;
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("FinancialYears_");
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
        private async Task<Db.Entity.FinancialYear> GetFinancialYearWithRelatedEntity(Guid id, bool IsActive)
        {
            var Query = await _ctx.FinancialYears
                   .Include(s => s.Stocks)
                   .Include(s => s.LabourRates)
                   .Include(s => s.LedgerBalances)
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
                  .SingleOrDefaultAsync(x => x.FinancialYearId == id && x.IsActive == IsActive);
            return Query;
        }
        private async Task<List<Db.Entity.FinancialYear>> GetFinancialYearsWithRelatedEntity(List<Guid> ids, bool IsActive)
        {
            var Query = await _ctx.FinancialYears
                   .Include(s => s.Stocks)
                   .Include(s => s.LabourRates)
                   .Include(s => s.LedgerBalances)
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
                .Where(b => b.IsActive == IsActive && ids.Contains(b.FinancialYearId)).ToListAsync();
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
        private async Task UpdateStatus(Db.Entity.FinancialYear financialYear, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["Stocks"] = financialYear.Stocks?.ToList() ?? null,
                ["LabourRates"] = financialYear.LabourRates?.ToList() ?? null,
                ["LedgerBalances"] = financialYear.LedgerBalances?.ToList() ?? null,
                ["SubLedgerBalances"] = financialYear.SubLedgerBalances?.ToList() ?? null,
                ["InwardSupplyOrders"] = financialYear.InwardSupplyOrders?.ToList() ?? null,
                ["InwardSupplyTransactions"] = financialYear.InwardSupplyTransactions?.ToList() ?? null,
                ["OutwardSupplyOrders"] = financialYear.OutwardSupplyOrders?.ToList() ?? null,
                ["OutwardSupplyTransactions"] = financialYear.OutwardSupplyTransactions?.ToList() ?? null,
                ["ProductionOrders"] = financialYear.ProductionOrders?.ToList() ?? null,
                ["ProductionTransactions"] = financialYear.ProductionTransactions?.ToList() ?? null,
                ["DamageOrders"] = financialYear.DamageOrders?.ToList() ?? null,
                ["DamageTransactions"] = financialYear.DamageTransactions?.ToList() ?? null,
                ["PurchaseOrders"] = financialYear.PurchaseOrders?.ToList() ?? null,
                ["PurchaseTransactions"] = financialYear.PurchaseTransactions?.ToList() ?? null,
                ["PurchaseReturnOrders"] = financialYear.PurchaseReturnOrders?.ToList() ?? null,
                ["PurchaseReturnTransactions"] = financialYear.PurchaseReturnTransactions?.ToList() ?? null,
                ["SalesOrders"] = financialYear.SalesOrders?.ToList() ?? null,
                ["SalesTransactions"] = financialYear.SalesTransactions?.ToList() ?? null,
                ["SalesReturnOrders"] = financialYear.SalesReturnOrders?.ToList() ?? null,
                ["SalesReturnTransactions"] = financialYear.SalesReturnTransactions?.ToList() ?? null,
                ["JournalOrders"] = financialYear.JournalOrders?.ToList() ?? null,
                ["JournalTransactions"] = financialYear.JournalTransactions?.ToList() ?? null,
                ["PaymentOrders"] = financialYear.PaymentOrders?.ToList() ?? null,
                ["PaymentTransactions"] = financialYear.PaymentTransactions?.ToList() ?? null,
                ["ReceiptOrders"] = financialYear.ReceiptOrders?.ToList() ?? null,
                ["ReceiptTransactions"] = financialYear.ReceiptTransactions?.ToList() ?? null,
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
        private async Task BulkUpdateStatus(List<Db.Entity.FinancialYear> financialYears, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>();

            foreach (var financialYear in financialYears)
            {
                if (financialYear.Stocks != null && financialYear.Stocks.Count > 0)
                {
                    foreach (var stock in financialYear.Stocks)
                    {
                        UpdateEntityProperties(stock, user, IsActive);
                    }
                    allRelatedData["Stocks"] = financialYear.Stocks.ToList();
                }
            }
            if (allRelatedData.Count > 0)
            {
                await _ctx.BulkUpdateMultiple(allRelatedData);
            }
        }
        #endregion
    }
}
