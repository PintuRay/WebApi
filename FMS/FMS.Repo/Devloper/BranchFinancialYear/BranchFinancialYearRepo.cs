using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FMS.Repo.Devloper.BranchFinancialYear
{
    public class BranchFinancialYearRepo(Context ctx, IMapper mapper, IRedisCache cache) : IBranchFinancialYearRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Branch Financial Year
        #region Crud
        public async Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears(Guid BranchId)
        {
            Result<BranchFinancialYearDto> _Result = new();
            List<BranchFinancialYearDto> Query = [];
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"BranchFinancialYear_{BranchId}";
                var cacheData = _cache.Get<Result<BranchFinancialYearDto>>(cacheKey);
                if (cacheData == null)
                {
                    string sql = @" SELECT b.Fk_BranchId, br.BranchName, b.Fk_FinancialYearId, f.Financial_Year
                                        FROM BranchFinancialYears b
                                        INNER JOIN Branches br ON b.Fk_BranchId = br.BranchId
                                        INNER JOIN FinancialYears f ON b.Fk_FinancialYearId = f.FinancialYearId
                                    WHERE b.Fk_BranchId = @BranchId AND b.IsActive = true";
                    Query = await _ctx.Set<BranchFinancialYearDto>()
                        .FromSqlRaw(sql, new NpgsqlParameter("@BranchId", BranchId))
                        .ToListAsync();
                    if (Query.Count > 0)
                    {
                        _Result.CollectionObjData = Query;
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
        public async Task<Result<BranchFinancialYearDto>> GetBranchFinancialYears(PaginationParams pagination)
        {
            Result<BranchFinancialYearDto> _Result = new();
            List<BranchFinancialYearDto> Query = [];
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;
                string sql = @" SELECT b.Fk_BranchId, br.BranchName, b.Fk_FinancialYearId, f.Financial_Year
                                    FROM BranchFinancialYears b
                                    INNER JOIN Branches br ON b.Fk_BranchId = br.BranchId
                                    INNER JOIN FinancialYears f ON b.Fk_FinancialYearId = f.FinancialYearId
                                    WHERE  b.IsActive = true""
                                ORDER BY br.BranchName DESC
                                LIMIT @PageSize OFFSET @Skip";
                Query = await _ctx.Set<BranchFinancialYearDto>()
                             .FromSqlRaw(sql,
                                 new NpgsqlParameter("@Skip", skip),
                                 new NpgsqlParameter("@PageSize", effectivePageSize))
                              .ToListAsync();
                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                    _Result.Count = Query.Count;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string checkSql = @" SELECT COUNT(1) FROM BranchFinancialYears 
                                     WHERE Fk_FinancialYearId = @FinancialYearId AND Fk_BranchId = @BranchId";
                var exists = await _ctx.Database.ExecuteSqlRawAsync(checkSql,new NpgsqlParameter("@FinancialYearId", data.Fk_FinancialYearId),new NpgsqlParameter("@BranchId", data.Fk_BranchId));
                if (exists == 0)
                {
                    string insertSql = @" INSERT INTO BranchFinancialYears 
                                        (BranchFinancialYearId, Fk_BranchId, Fk_FinancialYearId, CreatedDate, CreatedBy, IsActive)
                                        VALUES (@Id, @BranchId, @FinancialYearId, @CreatedDate, @CreatedBy, true)";
                    var id = Guid.NewGuid();
                    int Count = await _ctx.Database.ExecuteSqlRawAsync(insertSql,
                        new NpgsqlParameter("@Id", id),
                        new NpgsqlParameter("@BranchId", data.Fk_BranchId),
                        new NpgsqlParameter("@FinancialYearId", data.Fk_FinancialYearId),
                        new NpgsqlParameter("@CreatedDate", DateTime.UtcNow),
                        new NpgsqlParameter("@CreatedBy", user.Name));
                    if (Count > 0)
                    {
                        _Result.Id = id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string updateSql = @"UPDATE BranchFinancialYears
                                     SET Fk_BranchId = @BranchId,
                                        Fk_FinancialYearId = @FinancialYearId,
                                        ModifyDate = @ModifyDate,
                                        ModifyBy = @ModifyBy
                                     WHERE BranchFinancialYearId = @Id AND IsActive = true";
                int Count = await _ctx.Database.ExecuteSqlRawAsync(updateSql,
                    new NpgsqlParameter("@Id", Id),
                    new NpgsqlParameter("@BranchId", data.Fk_BranchId),
                    new NpgsqlParameter("@FinancialYearId", data.Fk_FinancialYearId),
                    new NpgsqlParameter("@ModifyDate", DateTime.UtcNow),
                    new NpgsqlParameter("@ModifyBy", user.Name));
                if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
                    }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string deleteSql = @" UPDATE BranchFinancialYears
                                        SET IsActive = false, ModifyDate = @ModifyDate, ModifyBy = @ModifyBy
                                       WHERE BranchFinancialYearId = @Id  AND IsActive = true";
                int Count = await _ctx.Database.ExecuteSqlRawAsync(deleteSql,
                    new NpgsqlParameter("@Id", Id),
                    new NpgsqlParameter("@ModifyDate", DateTime.UtcNow),
                    new NpgsqlParameter("@ModifyBy", user.Name));
                if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("BranchFinancialYear");
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
        public async Task<Result<BranchFinancialYearDto>> GetRemovedBranchFinancialYears(PaginationParams pagination)
        {
            Result<BranchFinancialYearDto> _Result = new();
            List<BranchFinancialYearDto> Query = [];
            try
            {
                _Result.IsSucess = false;
                int effectivePageSize = pagination.PageSize > 0 ? pagination.PageSize : int.MaxValue;
                int skip = pagination.PageNumber * effectivePageSize;

                string sql = @"SELECT b.Fk_BranchId, br.BranchName, b.Fk_FinancialYearId, f.Financial_Year
                                  FROM BranchFinancialYears b
                                  INNER JOIN Branches br ON b.Fk_BranchId = br.BranchId
                                  INNER JOIN FinancialYears f ON b.Fk_FinancialYearId = f.FinancialYearId
                            WHERE b.IsActive = false
                            ORDER BY br.BranchName DESC
                            LIMIT @PageSize OFFSET @Skip";
                Query = await _ctx.Set<BranchFinancialYearDto>()
                    .FromSqlRaw(sql,
                        new NpgsqlParameter("@Skip", skip),
                        new NpgsqlParameter("@PageSize", effectivePageSize))
                    .ToListAsync();

                if (Query.Count > 0)
                {
                    _Result.CollectionObjData = Query;
                    _Result.IsSucess = true;
                    _Result.Count = Query.Count;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string updateSql = @" UPDATE BranchFinancialYears
                                        SET IsActive = true, ModifyDate = @ModifyDate, ModifyBy = @ModifyBy
                                       WHERE BranchFinancialYearId = @Id AND IsActive = false";
                int Count = await _ctx.Database.ExecuteSqlRawAsync(updateSql,
                    new NpgsqlParameter("@Id", Id),
                    new NpgsqlParameter("@ModifyDate", DateTime.UtcNow),
                    new NpgsqlParameter("@ModifyBy", user.Name));
                if (Count > 0)
                {
                    _Result.Id = Id.ToString();
                    _Result.Count = Count.ToString();
                    _Result.IsSucess = true;
                    _cache.RemoveByPrefix("BranchFinancialYear");
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteBranchFinancialYear(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                string deleteSql = @" DELETE FROM BranchFinancialYears WHERE BranchFinancialYearId = @Id AND IsActive = false";
                int Count = await _ctx.Database.ExecuteSqlRawAsync(deleteSql, new NpgsqlParameter("@Id", Id));
                if (Count > 0)
                {
                    _Result.Id = Id.ToString();
                    _Result.Count = Count.ToString();
                    _Result.IsSucess = true;
                    _cache.RemoveByPrefix("BranchFinancialYear");
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            await using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;

                string updateSql = @"UPDATE BranchFinancialYears
                                    SET IsActive = true, ModifyDate = @ModifyDate, ModifyBy = @ModifyBy
                                    WHERE BranchFinancialYearId = ANY(@Ids) AND IsActive = false";
                var guidIds = Ids.Select(id => Guid.Parse(id)).ToList();
                int Count = await _ctx.Database.ExecuteSqlRawAsync(updateSql,
                    new NpgsqlParameter("@Ids", guidIds),
                    new NpgsqlParameter("@ModifyDate", DateTime.UtcNow),
                    new NpgsqlParameter("@ModifyBy", user.Name));
                if (Count > 0)
                {
                    _Result.Ids = Ids;
                    _Result.Count = Count.ToString();
                    _Result.IsSucess = true;
                    await transaction.CommitAsync();
                    _cache.RemoveByPrefix("BranchFinancialYear");
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            await using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                string deleteSql = @"DELETE FROM BranchFinancialYears WHERE BranchFinancialYearId = ANY(@Ids) AND IsActive = false";
                var guidIds = Ids.Select(id => Guid.Parse(id)).ToList();
                int Count = await _ctx.Database.ExecuteSqlRawAsync(deleteSql, new NpgsqlParameter("@Ids", guidIds));
                if (Count > 0)
                {
                    _Result.Ids = Ids;
                    _Result.Count = Count.ToString();
                    _Result.IsSucess = true;
                    await transaction.CommitAsync();
                    _cache.RemoveByPrefix("BranchFinancialYear");
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
        #endregion
    }
}
