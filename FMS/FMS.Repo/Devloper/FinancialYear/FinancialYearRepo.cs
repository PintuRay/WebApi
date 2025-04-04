﻿using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        #region Crud
        public async Task<RepoBase> GetFinancialYears(Guid BranchId)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string cacheKey = $"FinancialYears_{BranchId}";
                var cacheData = await _cache.GetAsync<RepoBase>(cacheKey);
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
                        _Result.IsSucess = true;
                        _Result.Records = Query;
                        await _cache.SetAsync(cacheKey, _Result, _cacheExpiration);
                    }
                }
                else
                {
                    _Result.IsSucess = true;
                    _Result.Records = JsonConvert.DeserializeObject<List<FinancialYearDto>>(cacheData.Records.ToString());  
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
                int skip = pagination.PageNumber * effectivePageSize;
                var financialyears = await _ctx.FinancialYears.Include(s => s.Branch).Where(s => s.IsActive == true).OrderByDescending(s => s.Financial_Year).ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = financialyears.Select(s => _mapper.Map<FinancialYearDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = Query.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = financialyears.Where(s => s.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<FinancialYearDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = financialyears.Count(s => s.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
                }
                if (Query.Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Records = Query;
                    _Result.Count = Count;
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
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                            .Include(s => s.Branch)
                                            .Where(s => s.FinancialYearId == newFinancialYear.FinancialYearId)
                                            .Select(s => _mapper.Map<FinancialYearDto>(s))
                                            .SingleOrDefaultAsync();
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
                var branchIds = dataList.Select(d => d.Fk_BranchId).ToList();
                var existingFinancialYears = await _ctx.FinancialYears.Where(f => f.IsActive == true && branchIds.Contains(f.Fk_BranchId)).ToListAsync();
                var duplicates = existingFinancialYears.Where(f => dataList.Any(d => d.Fk_BranchId == f.Fk_BranchId && d.Financial_Year == f.Financial_Year)).ToList();
                if (duplicates.Count == 0)
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
                        await transaction.CommitAsync();
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                        .Include(s => s.Branch)
                                        .Where(s => newFinancialYears.Select(nf => nf.FinancialYearId).Contains(s.FinancialYearId))
                                        .Select(s => _mapper.Map<FinancialYearDto>(s))
                                        .ToListAsync();
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
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                            .Include(s => s.Branch)
                                            .Where(s => s.FinancialYearId == financialYearToUpdate.FinancialYearId)
                                            .Select(s => _mapper.Map<FinancialYearDto>(s))
                                            .SingleOrDefaultAsync();
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
                    var financialYearsToUpdate = existingFinancialYears.Select(s =>
                    {
                        var updateData = dataList.First(u => u.FinancialYearId == s.FinancialYearId);
                        _mapper.Map(updateData, s);
                        s.ModifyDate = DateTime.UtcNow;
                        s.ModifyBy = user.Name;
                        return s;
                    }).ToList();
                    var response = await _ctx.BulkUpdate(financialYearsToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                            .Include(s => s.Branch)
                                            .Where(s => financialYearsToUpdate.Select(nf => nf.FinancialYearId).Contains(s.FinancialYearId))
                                            .Select(s => _mapper.Map<FinancialYearDto>(s))
                                            .ToListAsync();
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
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                        .Include(s => s.Branch)
                                        .Where(s => s.FinancialYearId == Query.FinancialYearId)
                                        .Select(s => _mapper.Map<FinancialYearDto>(s))
                                        .SingleOrDefaultAsync();
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
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                            .Include(s => s.Branch)
                                            .Where(s => Query.Select(nf => nf.FinancialYearId).Contains(s.FinancialYearId))
                                            .Select(s => _mapper.Map<FinancialYearDto>(s))
                                            .ToListAsync();
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
                int skip = pagination.PageNumber * effectivePageSize;
                var financialyears = await _ctx.FinancialYears.Include(s => s.Branch).Where(s => s.IsActive == false).OrderByDescending(s => s.Financial_Year).ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = financialyears.Select(s => _mapper.Map<FinancialYearDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = Query.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = financialyears.Where(s => s.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<FinancialYearDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = financialyears.Count(s => s.Financial_Year.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
                }
                if (Query.Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Records = Query;
                    _Result.Count = Count;
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
                    var isActiveRecordExist = await _ctx.FinancialYears.Include(s=>s.Branch).SingleOrDefaultAsync(s => s.Fk_BranchId == Query.Fk_BranchId && s.Financial_Year == Query.Financial_Year && s.IsActive == true);
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
                            _Result.IsSucess = true;
                            _Result.Records = await _ctx.FinancialYears
                                .Include(s => s.Branch).Where(s => s.FinancialYearId == Query.FinancialYearId)
                                .Select(s => _mapper.Map<FinancialYearDto>(s))
                                .SingleOrDefaultAsync();
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
                _Result.IsSucess = false;
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
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.FinancialYears
                                            .Include(s => s.Branch)
                                            .Where(s => recoverFinancialYears.Select(nf => nf.FinancialYearId).Contains(s.FinancialYearId))
                                            .Select(s => _mapper.Map<FinancialYearDto>(s))
                                            .ToListAsync();
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
                        _Result.IsSucess = true;
                        _Result.Id = Id.ToString();
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
                        _Result.IsSucess = true;
                        _Result.Ids = Ids.Select(id => id.ToString()).ToList();
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
                await _ctx.BulkUpdateCollection(allRelatedData);
            }
        }
        private async Task BulkUpdateStatus(List<Db.Entity.FinancialYear> financialYears, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>();
            var collections = new Dictionary<string, ICollection>
                {
                    { "Stocks", financialYears.SelectMany(fy => fy.Stocks).ToList() },
                    { "LabourRates", financialYears.SelectMany(fy => fy.LabourRates).ToList() },
                    { "LedgerBalances", financialYears.SelectMany(fy => fy.LedgerBalances).ToList() },
                    { "SubLedgerBalances", financialYears.SelectMany(fy => fy.SubLedgerBalances).ToList() },
                    { "InwardSupplyOrders", financialYears.SelectMany(fy => fy.InwardSupplyOrders).ToList() },
                    { "InwardSupplyTransactions", financialYears.SelectMany(fy => fy.InwardSupplyTransactions).ToList() },
                    { "OutwardSupplyOrders", financialYears.SelectMany(fy => fy.OutwardSupplyOrders).ToList() },
                    { "OutwardSupplyTransactions", financialYears.SelectMany(fy => fy.OutwardSupplyTransactions).ToList() },
                    { "ProductionOrders", financialYears.SelectMany(fy => fy.ProductionOrders).ToList() },
                    { "ProductionTransactions", financialYears.SelectMany(fy => fy.ProductionTransactions).ToList() },
                    { "DamageOrders", financialYears.SelectMany(fy => fy.DamageOrders).ToList() },
                    { "DamageTransactions", financialYears.SelectMany(fy => fy.DamageTransactions).ToList() },
                    { "PurchaseOrders", financialYears.SelectMany(fy => fy.PurchaseOrders).ToList() },
                    { "PurchaseTransactions", financialYears.SelectMany(fy => fy.PurchaseTransactions).ToList() },
                    { "PurchaseReturnOrders", financialYears.SelectMany(fy => fy.PurchaseReturnOrders).ToList() },
                    { "PurchaseReturnTransactions", financialYears.SelectMany(fy => fy.PurchaseReturnTransactions).ToList() },
                    { "SalesOrders", financialYears.SelectMany(fy => fy.SalesOrders).ToList() },
                    { "SalesTransactions", financialYears.SelectMany(fy => fy.SalesTransactions).ToList() },
                    { "SalesReturnOrders", financialYears.SelectMany(fy => fy.SalesReturnOrders).ToList() },
                    { "SalesReturnTransactions", financialYears.SelectMany(fy => fy.SalesReturnTransactions).ToList() },
                    { "JournalOrders", financialYears.SelectMany(fy => fy.JournalOrders).ToList() },
                    { "JournalTransactions", financialYears.SelectMany(fy => fy.JournalTransactions).ToList() },
                    { "PaymentOrders", financialYears.SelectMany(fy => fy.PaymentOrders).ToList() },
                    { "PaymentTransactions", financialYears.SelectMany(fy => fy.PaymentTransactions).ToList() },
                    { "ReceiptOrders", financialYears.SelectMany(fy => fy.ReceiptOrders).ToList() },
                    { "ReceiptTransactions", financialYears.SelectMany(fy => fy.ReceiptTransactions).ToList() },
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
                await _ctx.BulkUpdateCollection(allRelatedData);
            }
        }
    }
}
