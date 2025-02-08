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
                              Address = s.Address
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
                            Address = s.Address
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
                            Address = s.Address
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
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(s => s.BranchName == data.BranchName && s.IsActive == true);
                if (Query == null)
                {
                    var newBranch = _mapper.Map<Db.Entity.Branch>(data);
                    newBranch.BranchId = Guid.NewGuid();
                    newBranch.CreatedDate = DateTime.UtcNow;
                    newBranch.CreatedBy = user.Name;
                    newBranch.Address.Fk_BranchId = newBranch.BranchId;
                    newBranch.Address.Fk_UserId = null;
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
                var existingBranch = await _ctx.Branches.Where(b => b.IsActive == true && dataList.Select(br => br.BranchName).Contains(b.BranchName)).ToListAsync();
                if (existingBranch.Count == 0)
                {
                    var newBranches = _mapper.Map<List<Db.Entity.Branch>>(dataList);
                    newBranches.ForEach(branch =>
                    {
                        branch.BranchId = Guid.NewGuid();
                        branch.CreatedDate = DateTime.UtcNow;
                        branch.CreatedBy = user.Name;
                    });
                    var branchResponse = await _ctx.BulkInsert(newBranches);
                    if (branchResponse.IsSuccess)
                    {
                        var addresses = new List<Address>();
                        newBranches.ForEach(branch =>
                        {
                            var address = branch.Address;
                            address.Fk_BranchId = branch.BranchId;
                            address.Fk_UserId = null;
                            address.CreatedDate = DateTime.UtcNow;
                            address.CreatedBy = user.Name;
                            addresses.Add(address);
                        });
                        var addressResponse = await _ctx.BulkInsert(addresses);
                        if (addressResponse.IsSuccess)
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
                            _Result.Message = "Failed to create address";
                        }
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
                    var branchesToUpdate = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.Address.ModifyDate = DateTime.UtcNow;
                    Query.Address.ModifyBy = user.Name;
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
                var existingBranches = await _ctx.Branches.Where(b => b.IsActive == true && listdata.Select(br => br.BranchId).Contains(b.BranchId)).ToListAsync(); ;
                var notFoundBranches = listdata.Where(br => !existingBranches.Any(b => b.BranchId == br.BranchId)).ToList();
                if (notFoundBranches.Count == 0)
                {
                    var branchesToUpdate = _mapper.Map(listdata, existingBranches);
                    branchesToUpdate.ForEach(data =>
                    {
                        data.ModifyDate = DateTime.UtcNow;
                        data.ModifyBy = user.Name;
                    });
                    var branchResponse = await _ctx.BulkUpdate(branchesToUpdate);
                    if (branchResponse.IsSuccess)
                    {
                        var existingAddresses = await _ctx.Addresses.Where(a => existingBranches.Select(b => b.BranchId).Contains(a.Fk_BranchId.Value)) .ToListAsync();
                        var addresses = new List<Address>();
                        branchesToUpdate.ForEach(branch =>
                        {
                            var address = branch.Address;
                            address.CreatedDate = DateTime.UtcNow;
                            address.CreatedBy = user.Name;
                            addresses.Add(address);
                        });
                        var addressToUpdate = _mapper.Map(addresses, existingAddresses);
                        var addressResponse = await _ctx.BulkUpdate(branchesToUpdate);
                        if (addressResponse.IsSuccess)
                        {
                            await transaction.CommitAsync();
                            _Result.Count = branchResponse.AffectedRows;
                            _Result.Records = branchesToUpdate;
                            _Result.IsSucess = true;
                            _cache.Remove("Branches");
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            _Result.ResponseCode = 400;
                            _Result.Message = "Failed to update address";
                        }
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
                    Query.Address.ModifyDate = DateTime.UtcNow;
                    Query.Address.ModifyBy = user.Name;
                    Query.Address.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        await transaction.CommitAsync();
                        _Result.Records = Query;
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
                        var IsActiveStatus = UpdateStatus(branch, user, false);
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
                        var addresses = new List<Address>();
                        existingBranches.ForEach(branch =>
                        {
                            var address = branch.Address;
                            branch.Address.ModifyDate = DateTime.UtcNow;
                            branch.Address.ModifyBy = user.Name;
                            branch.Address.IsActive = false;
                            addresses.Add(address);
                        });
                        var addressResponse = await _ctx.BulkUpdate(addresses);
                        if (addressResponse.IsSuccess)
                        {
                            await transaction.CommitAsync();
                            _Result.Count = response.AffectedRows;
                            _Result.IsSucess = true;
                            _Result.Records = existingBranches;
                            _cache.Remove("Branches");
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                        }
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
                             Address = s.Address
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
                             Address = s.Address
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
                    if (isActiveRecordExist == null)
                    {
                        var IsActiveStatus = UpdateStatus(Query, user, true);
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        Query.Address.IsActive = true;
                        Query.Address.ModifyDate = DateTime.UtcNow;
                        Query.Address.ModifyBy = user.Name;
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
                var existingBranches = await GetBranchesWithRelatedEntity(Ids, false);
                if (existingBranches.Count != 0)
                {
                    var branchNames = listdata.Select(fy => fy.BranchName).ToList();
                    var isActiveRecordsExist = await _ctx.Branches.Where(s => s.IsActive == true && branchNames.Contains(s.BranchName)).ToListAsync();
                    var recoverBranchFinancialYear = existingBranches.Except(isActiveRecordsExist).ToList();
                    foreach (var branch in recoverBranchFinancialYear)
                    {
                        var IsActiveStatus = UpdateStatus(branch, user, true);
                        await _ctx.BulkUpdateMultiple(IsActiveStatus);
                    }
                    recoverBranchFinancialYear.ForEach(branch =>
                    {
                        branch.ModifyDate = DateTime.UtcNow;
                        branch.ModifyBy = user.Name;
                        branch.IsActive = true;
                    });
                    var branchResponse = await _ctx.BulkUpdate(existingBranches);
                    if (branchResponse.IsSuccess)
                    {
                        var addresses = new List<Address>();
                        recoverBranchFinancialYear.ForEach(branch =>
                        {
                            var address = branch.Address;
                            branch.Address.ModifyDate = DateTime.UtcNow;
                            branch.Address.ModifyBy = user.Name;
                            branch.Address.IsActive = true;
                            addresses.Add(address);
                        });
                        var addressResponse = await _ctx.BulkUpdate(addresses);
                        if (addressResponse.IsSuccess)
                        {
                            await transaction.CommitAsync();
                            _Result.Records = recoverBranchFinancialYear;
                            _Result.Count = branchResponse.AffectedRows;
                            _Result.IsSucess = true;
                            _cache.Remove("Branches");
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                        }
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
                   .Include(s=>s.Address)
                   .Include(s => s.BranchFinancialYears)
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
                .Include(s => s.BranchFinancialYears)
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
        private Dictionary<string, IList> UpdateStatus(Db.Entity.Branch branch, AppUser user, bool IsActive)
        {
            var allRelatedData = new Dictionary<string, IList>
            {
                ["BranchFinancialYears"] = branch.BranchFinancialYears?.ToList() ?? null,
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
                        var isActiveProperty = entity.GetType().GetProperty("IsActive");
                        var modifyDateProperty = entity.GetType().GetProperty("ModifyDate");
                        var modifyByProperty = entity.GetType().GetProperty("ModifyBy");
                        if (isActiveProperty.PropertyType == typeof(bool?))
                        {
                            isActiveProperty.SetValue(entity, IsActive);
                        }
                        if (modifyDateProperty.PropertyType == typeof(DateTime?))
                        {
                            modifyDateProperty.SetValue(entity, DateTime.UtcNow);
                        }
                        if (modifyByProperty.PropertyType == typeof(string))
                        {
                            modifyByProperty.SetValue(entity, user.UserName);
                        }
                    }
                }
            }
            return allRelatedData;
        }
        #endregion
    }
}
