using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.UserBranch
{
    public class UserBranchRepo(Context ctx, IMapper mapper, IRedisCache cache) : IUserBranchRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region User Branch 
        #region Crud
        public async Task<Result<Db.Entity.UserBranch>> GetUserBranches()
        {
            Result<Db.Entity.UserBranch> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"UserBranches";
                var cacheData = _cache.Get<Result<Db.Entity.UserBranch>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.UserBranches.Where(s => s.IsActive == true).ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.Count = Query.Count;
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
        public async Task<RepoBase> CreateUserBranch(UserBranchModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.UserBranches.Where(s => s.Fk_UserId == data.Fk_UserId && s.IsActive == true).FirstOrDefaultAsync();
                if (Query == null)
                {
                    var newUserBranch = _mapper.Map<Db.Entity.UserBranch>(data);
                    newUserBranch.CreatedDate = DateTime.UtcNow;
                    newUserBranch.CreatedBy = user.Name;
                    await _ctx.UserBranches.AddAsync(newUserBranch);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newUserBranch.Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("UserBranches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateUserBranch(Guid Id, UserBranchModel model, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.UserBranches.Where(s => s.Id == Id && s.IsActive == true).SingleOrDefaultAsync();
                if (Query != null)
                {
                    var updateUserBranch = _mapper.Map(model, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();

                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("UserBranches");
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
                var Query = await _ctx.UserBranches.Where(s => s.Id == Id && s.IsActive == true).SingleOrDefaultAsync();
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("UserBranches");
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
        public async Task<Result<Db.Entity.UserBranch>> GetRemovedUserBranches()
        {
            Result<Db.Entity.UserBranch> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedUserBranches";
                var cacheData = _cache.Get<Result<Db.Entity.UserBranch>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.UserBranches.Where(s => s.IsActive == false).ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
                        _Result.IsSucess = true;
                        _cache.Set(cacheKey, _Result, _cacheExpiration);

                    }
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
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("UserBranches");
                        _cache.Remove("RemovedUserBranches");
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
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("UserBranches");
                        _cache.Remove("RemovedUserBranches");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllUserBranches(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var userBranchIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var userBranchToRecover = await _ctx.UserBranches.Where(s => userBranchIds.Contains(s.Id) && s.IsActive == false).ToListAsync();
                if (userBranchToRecover.Any())
                {
                    foreach (var userbranch in userBranchToRecover)
                    {
                        userbranch.ModifyDate = DateTime.UtcNow;
                        userbranch.ModifyBy = user.Name;
                        userbranch.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("UserBranches");
                        _cache.Remove("RemovedUserBranches");
                    }
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteAllUserBranches(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var userBranchIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var userBranchToDelete = await _ctx.UserBranches.Where(s => userBranchIds.Contains(s.Id) && s.IsActive == false).ToListAsync();
                if (userBranchToDelete.Any())
                {
                    _ctx.UserBranches.RemoveRange(userBranchToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("UserBranches");
                        _cache.Remove("RemovedUserBranches");
                    }
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return _Result;
        }
        #endregion
        #endregion
    }
}
