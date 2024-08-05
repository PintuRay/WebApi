using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Devloper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FMS.Repo.DevloperSetting
{
    public class DevloperSettingRepo(Context ctx, IMapper mapper) : IDevloperSettingRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Branch
        #region Crud
        public async Task<Result<BranchViewModel>> GetAllBranch()
        {
            Result<BranchViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Branches where s.IsActive == true select s).ToListAsync();
                if (Query.Count > 0)
                {
                    var BranchList = _mapper.Map<List<BranchViewModel>>(Query);
                    _Result.CollectionObjData = BranchList;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<BaseDb> CreateBranch(BranchModel data, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> UpdateBranch(Guid Id, BranchModel data, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RemoveBranch(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<Result<BranchViewModel>> GetRemovedBranches()
        {
            Result<BranchViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Branches where s.IsActive == false select s).ToListAsync();
                if (Query.Count > 0)
                {
                    var BranchList = _mapper.Map<List<BranchViewModel>>(Query);
                    _Result.CollectionObjData = BranchList;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<BaseDb> RecoverBranch(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> DeleteBranch(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Id && x.IsActive == false);
                if (Query != null)
                {
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
        public async Task<BaseDb> RecoverAllBranch(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Guid.Parse(item) && x.IsActive == false);
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
        public async Task<BaseDb> DeleteAllBranch(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.Branches.SingleOrDefaultAsync(x => x.BranchId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
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
        public async Task<Result<FinancialYearViewModel>> GetFinancialYears()
        {
            Result<FinancialYearViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears
                                   orderby s.StartDate descending
                                   select new
                                   {
                                       s.FinancialYearId,
                                       s.Financial_Year,
                                       s.StartDate,
                                       s.EndDate,
                                   }).ToListAsync();
                if (Query.Count > 0)
                {
                    var FinancialYears = _mapper.Map<List<FinancialYearViewModel>>(Query);
                    _Result.CollectionObjData = FinancialYears;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<BaseDb> CreateFinancialYear(FinancialYearModel data, AppUser user)
        {
            BaseDb _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears where s.Financial_Year == data.Financial_Year && s.IsActive == true select s).FirstOrDefaultAsync();
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
        public async Task<BaseDb> UpdateFinancialYear(Guid Id, FinancialYearModel data, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RemoveFinancialYear(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<Result<FinancialYearViewModel>> GetRemovedFinancialYears()
        {
            Result<FinancialYearViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.FinancialYears where s.IsActive == false select s).ToListAsync();
                if (Query.Count > 0)
                {
                    var FinancialYearList = _mapper.Map<List<FinancialYearViewModel>>(Query);
                    _Result.CollectionObjData = FinancialYearList;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<BaseDb> RecoverFinancialYear(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> DeleteFinancialYear(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RecoverAllFinancialYear(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> DeleteAllFinancialYear(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<Result<BranchFinancialYearViewModel>> GetBranchFinancialYears()
        {
            Result<BranchFinancialYearViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears
                                   where s.IsActive == true
                                   select s)
                                 .OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();
                if (Query.Count > 0)
                {
                    var BranchFinancialYearList = _mapper.Map<List<BranchFinancialYearViewModel>>(Query);
                    _Result.CollectionObjData = BranchFinancialYearList;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<Result<BranchFinancialYearViewModel>> GetBranchFinancialYears(Guid BranchId)
        {
            Result<BranchFinancialYearViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears
                                   where s.Fk_BranchId == BranchId && s.IsActive == true
                                   select s)
                                   .OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();

                if (Query.Count > 0)
                {
                    var BranchFinancialYearList = _mapper.Map<List<BranchFinancialYearViewModel>>(Query);
                    _Result.CollectionObjData = BranchFinancialYearList;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<BaseDb> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<Result<BranchFinancialYearViewModel>> GetRemovedBranchFinancialYears()
        {
            Result<BranchFinancialYearViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.BranchFinancialYears
                                   where s.IsActive == false
                                   select s)
                                 .OrderByDescending(s => s.FinancialYear.Financial_Year).ToListAsync();
                if (Query.Count > 0)
                {
                    var BranchFinancialYearList = _mapper.Map<List<BranchFinancialYearViewModel>>(Query);
                    _Result.CollectionObjData = BranchFinancialYearList;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<BaseDb> RecoverBranchFinancialYear(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> DeleteBranchFinancialYear(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.BranchFinancialYears.SingleOrDefaultAsync(x => x.BranchFinancialYearId ==Guid.Parse(item)  && x.IsActive == false);
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
        public async Task<BaseDb> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
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
