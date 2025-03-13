using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.UserBranch
{
    public class UserBranchRepo(Context ctx, IMapper mapper) : IUserBranchRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region User Branch 
        #region Crud
        public async Task<RepoBase> GetUserBranches(AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.UserBranches
                            .Include(s => s.Branch)
                            .Where(s => s.IsActive == true && s.Fk_UserId == user.Id)
                            .Select(s => _mapper.Map<UserBranchDto>(s))
                            .ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.IsSucess = true;
                    _Result.Records = Query;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> GetUserBranches(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<UserBranchDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                var userBranches = await _ctx.UserBranches
                            .Include(s => s.Branch)
                            .Where(s => s.IsActive == true)
                            .OrderBy(s => s.User.Name)
                            .ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = userBranches.Select(s => _mapper.Map<UserBranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = userBranches.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = userBranches
                        .Where(s => s.User.UserName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.Branch.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<UserBranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = userBranches.Count(s => s.User.UserName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.Branch.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
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
        public async Task<RepoBase> CreateUserBranch(UserBranchModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var existingUserBranches = await _ctx.UserBranches.Where(s => (s.Fk_UserId == data.Fk_UserId && s.Fk_BranchId == data.Fk_BranchId) && s.IsActive == true).SingleOrDefaultAsync();
                if (existingUserBranches == null)
                {
                    var newUserBranch = _mapper.Map<Db.Entity.UserBranch>(data);
                    newUserBranch.CreatedDate = DateTime.UtcNow;
                    newUserBranch.CreatedBy = user.Name;
                    await _ctx.UserBranches.AddAsync(newUserBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.UserBranches
                                            .Include(s => s.Branch)
                                            .Where(s => s.Id == newUserBranch.Id)
                                            .Select(s => _mapper.Map<UserBranchDto>(s)).SingleOrDefaultAsync();
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateUserBranch(UserBranchUpdateModel model, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var existingUserBranch = await _ctx.UserBranches.SingleOrDefaultAsync(s => s.Id == model.Id && s.IsActive == true);
                if (existingUserBranch != null)
                {
                    var userBranchToUpdate = _mapper.Map(model, existingUserBranch);
                    existingUserBranch.ModifyDate = DateTime.UtcNow;
                    existingUserBranch.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.UserBranches
                                           .Include(s => s.Branch)
                                           .Select(s => _mapper.Map<UserBranchDto>(s))
                                           .SingleOrDefaultAsync(s => s.Id == existingUserBranch.Id);
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveUserBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.UserBranches.SingleOrDefaultAsync(s => s.Id == Id && s.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Records = await _ctx.UserBranches
                                             .Include(s => s.Branch)
                                             .Select(s => _mapper.Map<UserBranchDto>(s))
                                             .SingleOrDefaultAsync(s => s.Id == Query.Id);
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
        public async Task<RepoBase> GetRemovedUserBranches(PaginationParams pagination)
        {
            RepoBase _Result = new();
            List<UserBranchDto> Query = [];
            int Count = 0;
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                var userBranches = await _ctx.UserBranches
                            .Include(s => s.Branch)
                            .Where(s => s.IsActive == false)
                            .OrderBy(s => s.User.Name)
                            .ToListAsync();
                if (string.IsNullOrWhiteSpace(pagination.SearchTerm))
                {
                    Query = userBranches.Select(s => _mapper.Map<UserBranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = userBranches.Count;
                }
                else
                {
                    string searchTerm = pagination.SearchTerm.Trim().ToLower();
                    Query = userBranches
                        .Where(s => s.User.UserName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.Branch.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                        .Select(s => _mapper.Map<UserBranchDto>(s)).Skip(skip).Take(effectivePageSize).ToList();
                    Count = userBranches.Count(s => s.User.UserName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                    s.Branch.BranchName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
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
        public async Task<RepoBase> RecoverUserBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.UserBranches.Where(s => s.Id == Id && s.IsActive == false).SingleOrDefaultAsync();
                if (Query != null)
                {
                    var isActiveRecordExist = await _ctx.UserBranches.SingleOrDefaultAsync(s => (s.Fk_UserId == Query.Fk_UserId && s.Fk_BranchId == Query.Fk_BranchId)  && s.IsActive == true);
                    if (isActiveRecordExist == null)
                    {
                        Query.ModifyDate = DateTime.UtcNow;
                        Query.ModifyBy = user.Name;
                        Query.IsActive = true;
                        int Count = await _ctx.SaveChangesAsync();
                        if (Count > 0)
                        {
                            _Result.IsSucess = true;
                            _Result.Records = await _ctx.UserBranches
                                              .Include(s => s.Branch)
                                              .Select(s => _mapper.Map<UserBranchDto>(s))
                                              .SingleOrDefaultAsync(s => s.Id == Query.Id);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteUserBranch(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.UserBranches.SingleOrDefaultAsync(x => x.Id == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.UserBranches.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Id = Id.ToString();
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
