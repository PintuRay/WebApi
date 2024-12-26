using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Accounting
{
    public class AccountingRepo(Context ctx, IMapper mapper, IRedisCache cache): IAccountingRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Account 
        #region Group
        //public async Task<Result<LedgerGroup>> GetGroups()
        //{
        //    Result<LedgerGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "Groups";
        //        var cacheData = _cache.Get<Result<LedgerGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.LedgerGroups.
        //                         Select(s => new LedgerGroup
        //                         {
        //                             LedgerGroupId = s.LedgerGroupId,
        //                             GroupName = s.GroupName
        //                         }).ToListAsync();
        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region SubGroup
        #region Crud
        //public async Task<Result<LedgerSubGroup>> GetSubGroups(Guid GroupId, Guid BranchId)
        //{
        //    Result<LedgerSubGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"SubGroups_{BranchId}";
        //        var cacheData = _cache.Get<Result<LedgerSubGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var defaultSubGroups = await _ctx.LedgerSubGroupDevs.
        //                                     Where(s => s.Fk_BranchId == BranchId && s.Fk_LedgerGroupId == GroupId).
        //                                     Select(s => new LedgerSubGroup
        //                                     {
        //                                         LedgerSubGroupId = s.LedgerSubGroupId,
        //                                         SubGroupName = s.SubGroupName
        //                                     }).ToListAsync();
        //            var userCreatedSubGroups = await _ctx.LedgerSubGroups.
        //                                         Where(s => s.Fk_BranchId == BranchId && s.Fk_LedgerGroupId == GroupId && s.IsActive == true)
        //                                         .Select(s => new LedgerSubGroup
        //                                         {
        //                                             LedgerSubGroupId = s.LedgerSubGroupId,
        //                                             SubGroupName = s.SubGroupName
        //                                         }).ToListAsync();
        //            defaultSubGroups.AddRange(userCreatedSubGroups);
        //            if (defaultSubGroups.Any())
        //            {
        //                _Result.CollectionObjData = defaultSubGroups;
        //                _Result.Count = defaultSubGroups.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LedgerSubGroups.Where(s => s.SubGroupName == data.SubGroupName && s.Fk_LedgerGroupId == data.Fk_LedgerGroupId && s.Fk_BranchId == data.Fk_BranchId && s.IsActive == true).SingleOrDefaultAsync();
        //        if (Query == null)
        //        {
        //            var newLedgerSubGroup = _mapper.Map<LedgerSubGroup>(data);
        //            newLedgerSubGroup.CreatedDate = DateTime.UtcNow;
        //            newLedgerSubGroup.CreatedBy = user.Name;
        //            await _ctx.LedgerSubGroups.AddAsync(newLedgerSubGroup);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newLedgerSubGroup.LedgerSubGroupId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("SubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == data.Fk_BranchId && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("SubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveSubGroup(Guid Id, Guid BranchId, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == BranchId && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.Remove("Branches");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<LedgerSubGroup>> GetRemovedSubGroups(Guid BranchId)
        //{
        //    Result<LedgerSubGroup> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"RemovedSubGroups";
        //        var cacheData = _cache.Get<Result<LedgerSubGroup>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await _ctx.LedgerSubGroups.
        //                                         Where(s => s.Fk_BranchId == BranchId && s.IsActive == false)
        //                                         .Select(s => new LedgerSubGroup
        //                                         {
        //                                             LedgerSubGroupId = s.LedgerSubGroupId,
        //                                             SubGroupName = s.SubGroupName
        //                                         }).ToListAsync();
        //            if (Query.Any())
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverSubGroup(Guid Id, Guid BranchId, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == BranchId && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("SubGroups");
        //                _cache.Remove("RemovedSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteSubGroup(Guid Id, Guid BranchId, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == BranchId && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.LedgerSubGroups.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("SubGroups");
        //                _cache.Remove("RemovedSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllSubGroup(List<string> Ids, Guid BranchId, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var ledgerSubGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var ledgerSubGroupToRecover = await _ctx.LedgerSubGroups.Where(x => ledgerSubGroupIds.Contains(x.LedgerSubGroupId) && x.Fk_BranchId == BranchId && x.IsActive == false).ToListAsync();
        //        if (ledgerSubGroupToRecover.Any())
        //        {
        //            foreach (var ledgerSubGroup in ledgerSubGroupToRecover)
        //            {
        //                ledgerSubGroup.ModifyDate = DateTime.UtcNow;
        //                ledgerSubGroup.ModifyBy = user.Name;
        //                ledgerSubGroup.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("SubGroups");
        //                _cache.Remove("RemovedSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAllSubGroup(List<string> Ids, Guid BranchId, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var ledgerSubGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var ledgerSubGroupToDelete = await _ctx.LedgerSubGroups.Where(x => ledgerSubGroupIds.Contains(x.LedgerSubGroupId) && x.Fk_BranchId == BranchId && x.IsActive == false).ToListAsync();
        //        if (ledgerSubGroupToDelete.Any())
        //        {
        //            _ctx.LedgerSubGroups.RemoveRange(ledgerSubGroupToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("SubGroups");
        //                _cache.Remove("RemovedSubGroups");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
        #region Ledger
        #region Crud
        //public async Task<Result<Ledger>> GetLedgers()
        //{
        //    Result<Ledger> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "Ledgers";
        //        var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var ledgerDevs = await (from l in _ctx.LedgersDev
        //                                    select new Ledger
        //                                    {
        //                                        HasSubLedger = l.HasSubLedger,
        //                                        LedgerId = l.LedgerId,
        //                                        LedgerName = l.LedgerName,
        //                                        LedgerType = l.LedgerType,
        //                                        LedgerGroup = l.LedgerGroup != null ? new LedgerGroup { GroupName = l.LedgerGroup.GroupName } : null,
        //                                        LedgerSubGroup = l.LedgerSubGroup != null ? new LedgerSubGroup { SubGroupName = l.LedgerSubGroup.SubGroupName } : null

        //                                    }).ToListAsync();
        //            var ledgers = await (from l in _ctx.Ledgers
        //                                 select new Ledger
        //                                 {
        //                                     HasSubLedger = l.HasSubLedger,
        //                                     LedgerId = l.LedgerId,
        //                                     LedgerName = l.LedgerName,
        //                                     LedgerType = l.LedgerType,
        //                                     LedgerGroup = l.LedgerGroup != null ? new LedgerGroup { GroupName = l.LedgerGroup.GroupName } : null,
        //                                     LedgerSubGroup = l.LedgerSubGroup != null ? new LedgerSubGroup { SubGroupName = l.LedgerSubGroup.SubGroupName } : null
        //                                 }).ToListAsync();
        //            ledgers.AddRange(ledgerDevs);
        //            if (ledgers.Count > 0)
        //            {
        //                _Result.CollectionObjData = ledgers;
        //                _Result.Count = ledgers.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<Ledger>> GetLedgerById(Guid Id)
        //{
        //    Result<Ledger> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"Ledgers_{Id}";
        //        var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var ledDevs = await (from l in _ctx.LedgersDev.Where(x => x.LedgerId == Id)
        //                                 select new Ledger
        //                                 {
        //                                     HasSubLedger = l.HasSubLedger,
        //                                     LedgerId = l.LedgerId,
        //                                     LedgerType = l.LedgerType
        //                                 }).SingleOrDefaultAsync();

        //            var led = await (from l in _ctx.Ledgers.Where(x => x.LedgerId == Id)
        //                             select new Ledger
        //                             {
        //                                 HasSubLedger = l.HasSubLedger,
        //                                 LedgerId = l.LedgerId,
        //                                 LedgerType = l.LedgerType
        //                             }).SingleOrDefaultAsync();
        //            var Ledger = ledDevs ?? led;
        //            if (Ledger != null)
        //            {
        //                _Result.SingleObjData = Ledger;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<Ledger>> GetLedgersHasSubLedger(Guid BranchId)
        //{
        //    Result<Ledger> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"Ledgers_{BranchId}";
        //        var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var ledgers = await (from l in _ctx.Ledgers.Where(x => x.HasSubLedger == "Yes")
        //                                 select new Ledger
        //                                 {
        //                                     LedgerId = l.LedgerId,
        //                                     LedgerName = l.LedgerName,
        //                                 }).ToListAsync();
        //            if (ledgers.Count > 0)
        //            {
        //                _Result.CollectionObjData = ledgers;
        //                _Result.Count = ledgers.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<Result<Ledger>> GetLedgersHasNoSubLedger(Guid BranchId)
        //{
        //    Result<Ledger> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = $"Ledgers_NoSubLedger_{BranchId}";
        //        var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var ledgerDevs = await (from l in _ctx.LedgersDev.Where(x => x.HasSubLedger == "No")
        //                                    select new Ledger
        //                                    {
        //                                        LedgerId = l.LedgerId,
        //                                        LedgerName = l.LedgerName,
        //                                    }).ToListAsync();

        //            var ledgers = await (from l in _ctx.Ledgers.Where(x => x.HasSubLedger == "No")
        //                                 select new Ledger
        //                                 {
        //                                     LedgerId = l.LedgerId,
        //                                     LedgerName = l.LedgerName,
        //                                 }).ToListAsync();
        //            ledgers.AddRange(ledgerDevs);
        //            if (ledgers.Count > 0)
        //            {
        //                _Result.CollectionObjData = ledgers;
        //                _Result.Count = ledgers.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> CreateLedger(LedgerModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.Fk_LedgerGroupId == data.Fk_LedgerGroupId && s.LedgerName == data.LedgerName);
        //        if (Query == null)
        //        {
        //            var newLedger = _mapper.Map<Ledger>(data);
        //            newLedger.CreatedDate = DateTime.UtcNow;
        //            newLedger.CreatedBy = user.Name;
        //            await _ctx.Ledgers.AddAsync(newLedger);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = newLedger.LedgerId.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Ledgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            _mapper.Map(data, Query);
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Ledgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RemoveLedger(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == true);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = false;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Ledgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #region Recover
        //public async Task<Result<Ledger>> GetRemovedLedgers()
        //{
        //    Result<Ledger> _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var cacheKey = "RemovedLedgers";
        //        var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
        //        if (cacheData == null)
        //        {
        //            var Query = await (from l in _ctx.Ledgers
        //                               select new Ledger
        //                               {
        //                                   HasSubLedger = l.HasSubLedger,
        //                                   LedgerId = l.LedgerId,
        //                                   LedgerName = l.LedgerName,
        //                                   LedgerType = l.LedgerType,
        //                                   LedgerGroup = l.LedgerGroup != null ? new LedgerGroup { GroupName = l.LedgerGroup.GroupName } : null,
        //                                   LedgerSubGroup = l.LedgerSubGroup != null ? new LedgerSubGroup { SubGroupName = l.LedgerSubGroup.SubGroupName } : null
        //                               }).ToListAsync();

        //            if (Query.Count > 0)
        //            {
        //                _Result.CollectionObjData = Query;
        //                _Result.Count = Query.Count;
        //                _Result.IsSucess = true;
        //                _cache.Set(cacheKey, _Result, _cacheExpiration);
        //            }
        //        }
        //        else
        //        {
        //            _Result = cacheData;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverLedger(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            Query.ModifyDate = DateTime.UtcNow;
        //            Query.ModifyBy = user.Name;
        //            Query.IsActive = true;
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Ledgers");
        //                _cache.Remove("RemovedLedgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteLedger(Guid Id, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == false);
        //        if (Query != null)
        //        {
        //            _ctx.Ledgers.Remove(Query);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Id = Id.ToString();
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                _cache.RemoveByPrefix("Ledgers");
        //                _cache.Remove("RemovedLedgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> RecoverAllLedger(List<string> Ids, AppUser user)
        //{

        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var ledgerIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var ledgerToRecover = await _ctx.Ledgers.Where(x => ledgerIds.Contains(x.LedgerId) && x.IsActive == false).ToListAsync();
        //        if (ledgerToRecover.Any())
        //        {
        //            foreach (var ledger in ledgerToRecover)
        //            {
        //                ledger.ModifyDate = DateTime.UtcNow;
        //                ledger.ModifyBy = user.Name;
        //                ledger.IsActive = true;
        //            }
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("Ledgers");
        //                _cache.Remove("RemovedLedgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        //public async Task<RepoBase> DeleteAllLedger(List<string> Ids, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    using var transaction = await _ctx.Database.BeginTransactionAsync();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var ledgerIds = Ids.Select(id => Guid.Parse(id)).ToList();
        //        var ledgerToDelete = await _ctx.Ledgers.Where(x => ledgerIds.Contains(x.LedgerId) && x.IsActive == false).ToListAsync();
        //        if (ledgerToDelete.Any())
        //        {
        //            _ctx.Ledgers.RemoveRange(ledgerToDelete);
        //            int Count = await _ctx.SaveChangesAsync();
        //            if (Count > 0)
        //            {
        //                _Result.Ids = Ids;
        //                _Result.Count = Count.ToString();
        //                _Result.IsSucess = true;
        //                transaction.Commit();
        //                _cache.RemoveByPrefix("Ledgers");
        //                _cache.Remove("RemovedLedgers");
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
        #endregion
        #endregion
    }
}
