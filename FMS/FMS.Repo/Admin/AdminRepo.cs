using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin
{
    public class AdminRepo(Context ctx, IMapper mapper, ICustomCache cache) : IAdminRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Generate SignUp Token
        public async Task<RepoBase> CreateToken(RegisterTokenModel model, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var isExistToken = await (from s in _ctx.RegisterTokens where s.TokenValue == model.TokenValue select s).SingleOrDefaultAsync();
                if (isExistToken == null)
                {
                    var regToken = _mapper.Map<RegisterToken>(model);
                    regToken.CreatedBy = user.Id;
                    regToken.CreatedDate = DateTime.Now;
                    await _ctx.RegisterTokens.AddAsync(regToken);
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.Id = regToken.TokenId.ToString();
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
        #region Company
        #region Crud
        public async Task<Result<Company>> GetCompany(string BranchId)
        {
            Result<Company> _Result = new();
            List<Company> Query = null;
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Company_{BranchId}";
                var cacheData = _cache.Get<Result<Company>>(cacheKey);
                if (cacheData == null)
                {
                    if (BranchId != "All")
                    {
                        Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == true).ToListAsync();
                    }
                    else
                    {
                        Query = await _ctx.Companies.Where(s => s.IsActive == true).ToListAsync();
                    }
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
        public async Task<RepoBase> CreateCompany(CompanyModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Companies where s.CompanyName == data.CompanyName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newCompany = _mapper.Map<Company>(data);
                    newCompany.CreatedDate = DateTime.UtcNow;
                    newCompany.CreatedBy = user.Name;
                    await _ctx.Companies.AddAsync(newCompany);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newCompany.CompanyId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove($"Company_{data.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.Companies where s.CompanyId == Id && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query != null)
                {
                    var updateCompany = _mapper.Map(model, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove($"Company_{model.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveCompany(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Id && x.IsActive == true);
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
                        _cache.Remove($"Company_{Query.Fk_BranchId}");
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
        public async Task<Result<Company>> GetRemovedCompanies(string BranchId)
        {
            Result<Company> _Result = new();
            List<Company> Query = null;
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"RemovedCompanies_{BranchId}";
                var cacheData = _cache.Get<Result<Company>>(cacheKey);
                if (cacheData == null)
                {
                    if (BranchId != "All")
                    {
                        Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == false).ToListAsync();
                    }
                    else
                    {
                        Query = await _ctx.Companies.Where(s => s.IsActive == false).ToListAsync();
                    }
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
        public async Task<RepoBase> RecoverCompany(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Id && x.IsActive == false);
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
                        _cache.Remove($"Company_{Query.Fk_BranchId}");
                        _cache.Remove($"RemovedCompanies_{Query.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteCompany(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.Companies.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove($"Company_{Query.Fk_BranchId}");
                        _cache.Remove($"RemovedCompanies_{Query.Fk_BranchId}");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllCompany(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var companyIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var companiesToRecover = await _ctx.Companies.Where(x => companyIds.Contains(x.CompanyId) && x.IsActive == false).ToListAsync();
                if (companiesToRecover.Any())
                {
                    foreach (var company in companiesToRecover)
                    {
                        company.ModifyDate = DateTime.UtcNow;
                        company.ModifyBy = user.Name;
                        company.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Company_");
                        _cache.RemoveByPrefix($"RemovedCompanies_");
                        transaction.Commit();
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
        public async Task<RepoBase> DeleteAllCompany(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var companyIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var companiesToDelete = await _ctx.Companies.Where(x => companyIds.Contains(x.CompanyId) && x.IsActive == false).ToListAsync();
                if (companiesToDelete.Any())
                {
                    _ctx.Companies.RemoveRange(companiesToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix($"Company_");
                        _cache.RemoveByPrefix($"RemovedCompanies_");
                        transaction.Commit();
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
        #region User Branch 
        #region Crud
        public async Task<Result<UserBranch>> GetUserBranches()
        {
            Result<UserBranch> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"UserBranches";
                var cacheData = _cache.Get<Result<UserBranch>>(cacheKey);
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
                    var newUserBranch = _mapper.Map<UserBranch>(data);
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
        public async Task<Result<UserBranch>> GetRemovedUserBranches()
        {
            Result<UserBranch> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedUserBranches";
                var cacheData = _cache.Get<Result<UserBranch>>(cacheKey);
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
        #region Product 
        #region Product Type
        public async Task<Result<ProductType>> GetProductTypes()
        {
            Result<ProductType> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "ProductTypes";
                var cacheData = _cache.Get<Result<ProductType>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductTypes.ToListAsync();
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
        #endregion
        #region Product Group
        #region Crud
        public async Task<Result<ProductGroup>> GetProductGroups()
        {
            Result<ProductGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "ProductGroups";
                var cacheData = _cache.Get<Result<ProductGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductGroups.Where(s => s.IsActive == true).ToListAsync();
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
        public async Task<Result<ProductGroup>> GetProductGroups(Guid ProdutTypeId)
        {
            Result<ProductGroup> _Result = new();
            try
            {
                var cacheKey = $"ProductGroups_{ProdutTypeId}";
                var cacheData = _cache.Get<Result<ProductGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductGroups.Where(p => p.Fk_ProductTypeId == ProdutTypeId && p.IsActive == true).ToListAsync();
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
        public async Task<RepoBase> CreateProductGroup(ProductGroupModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupName == data.ProductGroupName).FirstOrDefaultAsync();
                if (Query == null)
                {
                    ProductGroup newProductGroup = _mapper.Map<ProductGroup>(data);
                    newProductGroup.CreatedDate = DateTime.UtcNow;
                    newProductGroup.CreatedBy = user.Name;
                    await _ctx.ProductGroups.AddAsync(newProductGroup);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newProductGroup.ProductGroupId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("ProductGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupId == Id).SingleOrDefaultAsync();
                if (Query != null)
                {
                    ProductGroup updateProductGroup = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("ProductGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveProductGroup(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupId == Id && s.IsActive == true).SingleOrDefaultAsync();
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
                        _cache.RemoveByPrefix("ProductGroups");
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
        public async Task<Result<ProductGroup>> GetRemovedProductGroup()
        {
            Result<ProductGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedProductGroups";
                var cacheData = _cache.Get<Result<ProductGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductGroups.Where(s => s.IsActive == false).ToListAsync();
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
        public async Task<RepoBase> RecoverProductGroup(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductGroups.Where(s => s.ProductGroupId == Id && s.IsActive == false).SingleOrDefaultAsync();
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
                        _cache.RemoveByPrefix("ProductGroups");
                        _cache.Remove("RemovedProductGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteProductGroup(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductGroups.FirstOrDefaultAsync(x => x.ProductGroupId == Id && x.IsActive == false);
                if (Query != null)
                {
                    _ctx.ProductGroups.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("ProductGroups");
                        _cache.Remove("RemovedProductGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllProductGroup(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var productGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var productGroupToRecover = await _ctx.ProductGroups.Where(x => productGroupIds.Contains(x.ProductGroupId) && x.IsActive == false).ToListAsync();
                if (productGroupToRecover.Any())
                {
                    foreach (var productGroup in productGroupToRecover)
                    {
                        productGroup.ModifyDate = DateTime.UtcNow;
                        productGroup.ModifyBy = user.Name;
                        productGroup.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("ProductGroups");
                        _cache.Remove("RemovedProductGroups");
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
        public async Task<RepoBase> DeleteAllProductGroup(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var productGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var productGroupToRecover = await _ctx.ProductGroups.Where(x => productGroupIds.Contains(x.ProductGroupId) && x.IsActive == false).ToListAsync();
                if (productGroupToRecover.Any())
                {
                    _ctx.ProductGroups.RemoveRange(productGroupToRecover);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("ProductGroups");
                        _cache.Remove("RemovedProductGroups");
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
        #region Product SubGroup
        #region Crud
        public async Task<Result<ProductSubGroup>> GetProductSubGroups(Guid GroupId)
        {
            Result<ProductSubGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"ProductSubGroups_{GroupId}";
                var cacheData = _cache.Get<Result<ProductSubGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductSubGroups.Where(s => s.Fk_ProductGroupId == GroupId && s.IsActive == true).ToListAsync();
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
        public async Task<RepoBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.Fk_ProductGroupId == data.Fk_ProductGroupId && s.ProductSubGroupName == data.ProductSubGroupName && s.IsActive == true);
                if (Query == null)
                {
                    ProductSubGroup newSubGroup = _mapper.Map<ProductSubGroup>(data);
                    newSubGroup.CreatedDate = DateTime.UtcNow;
                    newSubGroup.CreatedBy = user.Name;
                    await _ctx.ProductSubGroups.AddAsync(newSubGroup);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newSubGroup.ProductSubGroupId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("ProductSubGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == true);
                if (Query != null)
                {
                    ProductSubGroup updateProductSubGroup = _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("ProductSubGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveProductSubGroup(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == true);
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
                        _cache.RemoveByPrefix("ProductSubGroups");
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
        public async Task<Result<ProductSubGroup>> GetRemovedProductSubGroup()
        {
            Result<ProductSubGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"RemovedProductSubGroup";
                var cacheData = _cache.Get<Result<ProductSubGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductSubGroups.Where(s => s.IsActive == false).ToListAsync();
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
        public async Task<RepoBase> RecoverProductSubGroup(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == false);
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
                        _cache.RemoveByPrefix("ProductSubGroups");
                        _cache.Remove("RemovedProductSubGroup");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteProductSubGroup(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductSubGroups.SingleOrDefaultAsync(s => s.ProductSubGroupId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.ProductSubGroups.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("ProductSubGroups");
                        _cache.Remove("RemovedProductSubGroup");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var subGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var subGroupToRecover = await _ctx.ProductSubGroups.Where(x => subGroupIds.Contains(x.ProductSubGroupId) && x.IsActive == false).ToListAsync();
                if (subGroupToRecover.Any())
                {
                    foreach (var subGroup in subGroupToRecover)
                    {
                        subGroup.ModifyDate = DateTime.UtcNow;
                        subGroup.ModifyBy = user.Name;
                        subGroup.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("ProductSubGroups");
                        _cache.Remove("RemovedProductSubGroup");
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
        public async Task<RepoBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var subGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var subGroupToDelete = await _ctx.ProductSubGroups.Where(x => subGroupIds.Contains(x.ProductSubGroupId) && x.IsActive == false).ToListAsync();
                if (subGroupToDelete.Any())
                {
                    _ctx.ProductSubGroups.RemoveRange(subGroupToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("ProductSubGroups");
                        _cache.Remove("RemovedProductSubGroup");
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
        #region Unit
        #region Crud
        public async Task<Result<Unit>> GetAllUnits()
        {
            Result<Unit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Units";
                var cacheData = _cache.Get<Result<Unit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Units where s.IsActive == true select s).OrderBy(s => s.UnitName).ToListAsync();
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
        public async Task<RepoBase> CreateUnit(UnitModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = _ctx.Units.Where(s => s.UnitName == data.UnitName && s.IsActive == true).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newUnit = _mapper.Map<Unit>(data);
                    newUnit.CreatedDate = DateTime.UtcNow;
                    newUnit.CreatedBy = user.Name;
                    await _ctx.Units.AddAsync(newUnit);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newUnit.UnitId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Units");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateUnit(Guid Id, UnitModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == true).SingleOrDefaultAsync();
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("Units");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveUnit(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == true).SingleOrDefaultAsync();
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
                        _cache.Remove("Units");
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
        public async Task<Result<Unit>> GetRemovedUnits()
        {
            Result<Unit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedUnits";
                var cacheData = _cache.Get<Result<Unit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from s in _ctx.Units where s.IsActive == true select s).OrderBy(s => s.UnitName).ToListAsync();
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
        public async Task<RepoBase> RecoverUnit(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == false).SingleOrDefaultAsync();
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
                        _cache.Remove("RemovedUnits");
                        _cache.Remove("Units");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteUnit(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Units.Where(s => s.UnitId == Id && s.IsActive == false).SingleOrDefaultAsync();
                if (Query != null)
                {
                    _ctx.Units.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("RemovedUnits");
                        _cache.Remove("Units");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllUnit(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var unitIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var unitToRecover = await _ctx.Units.Where(x => unitIds.Contains(x.UnitId) && x.IsActive == false).ToListAsync();
                if (unitToRecover.Any())
                {
                    foreach (var unit in unitToRecover)
                    {
                        unit.ModifyDate = DateTime.UtcNow;
                        unit.ModifyBy = user.Name;
                        unit.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("RemovedUnits");
                        _cache.Remove("Units");
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
        public async Task<RepoBase> DeleteAllUnit(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var unitIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var unitToDelete = await _ctx.Units.Where(x => unitIds.Contains(x.UnitId) && x.IsActive == false).ToListAsync();
                if (unitToDelete.Any())
                {
                    _ctx.Units.RemoveRange(unitToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("RemovedUnits");
                        _cache.Remove("Units");
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
        #region Alternate Units
        #region Crud
        public async Task<Result<AlternateUnit>> GetAlternateUnits()
        {
            Result<AlternateUnit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "AlternateUnits";
                var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.AlternateUnits.Where(s => s.IsActive == false).Select(s => new AlternateUnit
                    {
                        AlternateUnitId = s.AlternateUnitId,
                        AlternateUnitName = s.AlternateUnitName,
                        AlternateQuantity = s.AlternateQuantity,
                        Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null,
                        UnitQuantity = s.UnitQuantity,
                        Product = s.Product != null ? new Product() { ProductName = s.Product.ProductName } : null,
                    }).ToListAsync();

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
        public async Task<Result<AlternateUnit>> GetAlternateUnitByUnitId(Guid UnitId)
        {
            Result<AlternateUnit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"AlternateUnits_{UnitId}";
                var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.AlternateUnits.Where(s => s.Fk_UnitId == UnitId).Select(s => new AlternateUnit
                    {
                        AlternateUnitId = s.AlternateUnitId,
                        AlternateUnitName = s.AlternateUnitName,
                        AlternateQuantity = s.AlternateQuantity,
                        Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null,
                        UnitQuantity = s.UnitQuantity,
                        Product = s.Product != null ? new Product() { ProductName = s.Product.ProductName } : null,
                    }).ToListAsync();

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
        public async Task<Result<AlternateUnit>> GetAlternateUnitByProductId(Guid ProductId)
        {
            Result<AlternateUnit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"AlternateUnits_{ProductId}";
                var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.AlternateUnits.Where(s => s.FK_ProductId == ProductId).Select(s => new AlternateUnit
                    {
                        AlternateUnitId = s.AlternateUnitId,
                        AlternateUnitName = s.AlternateUnitName,
                    }).ToListAsync();

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
        public async Task<Result<AlternateUnit>> GetAlternateUnitByAlternateUnitId(Guid AlternateUnitId)
        {
            Result<AlternateUnit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"AlternateUnits_{AlternateUnitId}";
                var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.AlternateUnits.Where(s => s.AlternateUnitId == AlternateUnitId).Select(s => new AlternateUnit
                    {
                        Unit = new Unit { UnitName = s.Unit.UnitName },
                        UnitQuantity = s.UnitQuantity,
                    }).SingleOrDefaultAsync();

                    if (Query != null)
                    {
                        _Result.SingleObjData = Query;
                        //_Result.Count = Query.Count;
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
        public async Task<RepoBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from s in _ctx.AlternateUnits where s.Fk_UnitId == data.Fk_UnitId && s.AlternateUnitName == data.AlternateUnitName && s.IsActive == true select s).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newAlternateUnit = _mapper.Map<AlternateUnit>(data);
                    newAlternateUnit.CreatedDate = DateTime.UtcNow;
                    newAlternateUnit.CreatedBy = user.Name;
                    await _ctx.AlternateUnits.AddAsync(newAlternateUnit);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newAlternateUnit.AlternateUnitId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("AlternateUnits");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("AlternateUnits");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveAlternateUnit(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == true);
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
                        _cache.RemoveByPrefix("AlternateUnits");
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
        public async Task<Result<AlternateUnit>> GetRemovedAlternateUnits()
        {
            Result<AlternateUnit> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedAlternateUnits";
                var cacheData = _cache.Get<Result<AlternateUnit>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.AlternateUnits.Where(s => s.IsActive == false).Select(s => new AlternateUnit
                    {
                        AlternateUnitId = s.AlternateUnitId,
                        AlternateUnitName = s.AlternateUnitName,
                        AlternateQuantity = s.AlternateQuantity,
                        Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null,
                        UnitQuantity = s.UnitQuantity,
                        Product = s.Product != null ? new Product() { ProductName = s.Product.ProductName } : null,
                    }).ToListAsync();

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
        public async Task<RepoBase> RecoverAlternateUnit(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == false);
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
                        _cache.RemoveByPrefix("AlternateUnits");
                        _cache.Remove("RemovedAlternateUnits");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteAlternateUnit(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.AlternateUnits.SingleOrDefaultAsync(s => s.AlternateUnitId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.AlternateUnits.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("AlternateUnits");
                        _cache.Remove("RemovedAlternateUnits");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var alternateUnitIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var alternateUnitToRecover = await _ctx.AlternateUnits.Where(x => alternateUnitIds.Contains(x.AlternateUnitId) && x.IsActive == false).ToListAsync();
                if (alternateUnitToRecover.Any())
                {
                    foreach (var alternateUnit in alternateUnitToRecover)
                    {
                        alternateUnit.ModifyDate = DateTime.UtcNow;
                        alternateUnit.ModifyBy = user.Name;
                        alternateUnit.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("AlternateUnits");
                        _cache.Remove("RemovedAlternateUnits");
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
        public async Task<RepoBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var alternateUnitIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var alternateUnitToDelete = await _ctx.AlternateUnits.Where(x => alternateUnitIds.Contains(x.AlternateUnitId) && x.IsActive == false).ToListAsync();
                if (alternateUnitToDelete.Any())
                {
                    _ctx.AlternateUnits.RemoveRange(alternateUnitToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("AlternateUnits");
                        _cache.Remove("RemovedAlternateUnits");
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
        #region Product
        #region Crud
        public async Task<Result<Product>> GetAllProducts()
        {
            Result<Product> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Products";
                var cacheData = _cache.Get<Result<Product>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Products.Select(s =>
                                  new Product()
                                  {
                                      ProductId = s.ProductId,
                                      ProductName = s.ProductName,
                                      RetailPrice = s.RetailPrice,
                                      WholeSalePrice = s.WholeSalePrice,
                                      GST = s.GST,
                                      ProductGroup = s.ProductGroup != null ? new ProductGroup { ProductGroupName = s.ProductGroup.ProductGroupName } : null,
                                      ProductSubGroup = s.ProductSubGroup != null ? new ProductSubGroup { ProductSubGroupName = s.ProductSubGroup.ProductSubGroupName } : null,
                                      Unit = s.Unit != null ? new Unit { UnitName = s.Unit.UnitName } : null,
                                      ProductType = s.ProductType != null ? new ProductType { Product_Type = s.ProductType.Product_Type } : null,
                                  }).ToListAsync();
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
        public async Task<Result<Product>> GetProductById(Guid ProductId)
        {
            Result<Product> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Products_{ProductId}";
                var cacheData = _cache.Get<Result<Product>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Products.Where(s => s.ProductId == ProductId).Select(s => new Product
                    {
                        ProductId = s.ProductId,
                        ProductName = s.ProductName,
                        Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName, UnitId = s.Unit.UnitId } : null,
                    }).SingleOrDefaultAsync();

                    if (Query != null)
                    {
                        _Result.SingleObjData = Query;
                        //_Result.Count = Query.Count;
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
        public async Task<Result<Product>> GetProductByTypeId(Guid ProductTypeId)
        {
            Result<Product> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Products_{ProductTypeId}";
                var cacheData = _cache.Get<Result<Product>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Products.Where(s => s.Fk_ProductTypeId == ProductTypeId).Select(s => new Product { ProductId = s.ProductId, ProductName = s.ProductName }).ToListAsync();
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
        public async Task<Result<Product>> GetProductGstWithRate(Guid id, string RateType)
        {
            Result<Product> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Products_{RateType}";
                var cacheData = _cache.Get<Result<Product>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Products.Where(s => s.ProductId == id)
                           .Select(s => new Product
                           {
                               Price = RateType == "wholesalerate" ? Convert.ToDecimal(s.WholeSalePrice) : s.Price,
                               GST = s.GST,
                               ProductName = s.ProductName,
                               Unit = s.Unit != null ? new Unit() { UnitName = s.Unit.UnitName } : null
                           }).SingleOrDefaultAsync();
                    if (Query != null)
                    {
                        _Result.SingleObjData = Query;
                        // _Result.Count = Query.Count;
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
        public async Task<RepoBase> CreateProduct(ProductModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.Fk_ProductGroupId == data.Fk_ProductGroupId && s.Fk_ProductTypeId == data.Fk_ProductTypeId && s.ProductName == data.ProductName);
                if (Query == null)
                {
                    var newProduct = _mapper.Map<Product>(data);
                    newProduct.CreatedDate = DateTime.UtcNow;
                    newProduct.CreatedBy = user.Name;
                    await _ctx.Products.AddAsync(newProduct);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newProduct.ProductId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Products");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateProduct(Guid Id, ProductModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Products");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveProduct(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == true);
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
                        _cache.RemoveByPrefix("Products");
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
        public async Task<Result<Product>> GetRemovedProduct()
        {
            Result<Product> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedProducts";
                var cacheData = _cache.Get<Result<Product>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.Products.Select(s =>
                                  new Product()
                                  {
                                      ProductId = s.ProductId,
                                      ProductName = s.ProductName,
                                      RetailPrice = s.RetailPrice,
                                      WholeSalePrice = s.WholeSalePrice,
                                      GST = s.GST,
                                      ProductGroup = s.ProductGroup != null ? new ProductGroup { ProductGroupName = s.ProductGroup.ProductGroupName } : null,
                                      ProductSubGroup = s.ProductSubGroup != null ? new ProductSubGroup { ProductSubGroupName = s.ProductSubGroup.ProductSubGroupName } : null,
                                      Unit = s.Unit != null ? new Unit { UnitName = s.Unit.UnitName } : null,
                                      ProductType = s.ProductType != null ? new ProductType { Product_Type = s.ProductType.Product_Type } : null,
                                  }).ToListAsync();
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
        public async Task<RepoBase> RecoverProduct(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == false);
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
                        _cache.RemoveByPrefix("Products");
                        _cache.Remove("RemovedProducts");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteProduct(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Products.SingleOrDefaultAsync(s => s.ProductId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.Products.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Products");
                        _cache.Remove("RemovedProducts");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllProduct(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var productIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var productToRecover = await _ctx.Products.Where(x => productIds.Contains(x.ProductId) && x.IsActive == false).ToListAsync();
                if (productToRecover.Any())
                {
                    foreach (var product in productToRecover)
                    {
                        product.ModifyDate = DateTime.UtcNow;
                        product.ModifyBy = user.Name;
                        product.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Products");
                        _cache.Remove("RemovedProducts");
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
        public async Task<RepoBase> DeleteAllProduct(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var productIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var productToDelete = await _ctx.Products.Where(x => productIds.Contains(x.ProductId) && x.IsActive == false).ToListAsync();
                if (productToDelete.Any())
                {
                    _ctx.Products.RemoveRange(productToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Products");
                        _cache.Remove("RemovedProducts");
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
        #endregion
        #region Production
        #region Crud
        public async Task<Result<ProductionOrder>> GetProduction()
        {
            Result<ProductionOrder> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Production";
                var cacheData = _cache.Get<Result<ProductionOrder>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductionOrders.Where(s => s.IsActive == true).Select(s => new ProductionOrder
                    {
                        ProductionOrderId = s.ProductionOrderId,
                        Fk_FinishedGoodId = s.Fk_FinishedGoodId,
                        FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
                        ProductionTransactions = s.ProductionTransactions.Select(pt => new ProductionTransaction
                        {
                            ProductionTransactionId = pt.ProductionTransactionId,
                            RawMaterialName = _ctx.Products.Where(p => p.ProductId == pt.Fk_RawMaterialId).Select(s => s.ProductName).SingleOrDefault(),
                            Quantity = pt.Quantity,
                            Unit = pt.Unit,
                        }).ToList()
                    }).ToListAsync();
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
        public async Task<RepoBase> CreateProduction(ProductionOrderModel data, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductionOrders.SingleOrDefaultAsync(s => s.Fk_FinishedGoodId == data.Fk_FinishedGoodId && s.IsActive == true);
                if (Query == null)
                {
                    ProductionOrder newProduction = _mapper.Map<ProductionOrder>(data);
                    newProduction.CreatedDate = DateTime.UtcNow;
                    newProduction.CreatedBy = user.Name;
                    if (data.ProductionTransactions.Count > 0)
                    {
                        newProduction.ProductionTransactions = data.ProductionTransactions.Select(s =>
                        {
                            var newProductionTransaction = _mapper.Map<ProductionTransaction>(s);
                            newProductionTransaction.CreatedDate = DateTime.UtcNow;
                            newProductionTransaction.CreatedBy = user.Name;
                            return newProductionTransaction;
                        }).ToList();
                    }
                    await _ctx.ProductionOrders.AddAsync(newProduction);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newProduction.ProductionOrderId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
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
        public async Task<RepoBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    // Add new transactions and update existing ones
                    var existingTransactions = Query.ProductionTransactions.ToList();
                    var updatedTransactions = data.ProductionTransactions.ToList();
                    foreach (var updatedTransaction in updatedTransactions)
                    {
                        var existingTransaction = existingTransactions.FirstOrDefault(et => et.ProductionTransactionId == updatedTransaction.ProductionTransactionId);
                        if (existingTransaction != null)
                        { // Update existing transaction
                            _mapper.Map(updatedTransaction, existingTransaction);
                            existingTransaction.ModifyDate = DateTime.UtcNow;
                            existingTransaction.ModifyBy = user.Name;
                        }
                        else
                        {
                            // Add new transaction
                            var newTransaction = _mapper.Map<ProductionTransaction>(updatedTransaction);
                            newTransaction.CreatedDate = DateTime.UtcNow;
                            newTransaction.CreatedBy = user.Name;
                            Query.ProductionTransactions.Add(newTransaction);
                        }
                    }
                    // Remove deleted transactions
                    foreach (var existingTransaction in existingTransactions)
                    {
                        if (!updatedTransactions.Any(ut => ut.ProductionTransactionId == existingTransaction.ProductionTransactionId))
                        {
                            _ctx.ProductionTransactions.Remove(existingTransaction);
                        }
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
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
        public async Task<RepoBase> RemoveProduction(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    // Update related ProductionTransactions
                    foreach (var existingTransaction in Query.ProductionTransactions)
                    {
                        existingTransaction.ModifyDate = DateTime.UtcNow;
                        existingTransaction.ModifyBy = user.Name;
                        existingTransaction.IsActive = false;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
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
        #region Recover
        public async Task<Result<ProductionOrder>> GetRemovedProduction()
        {
            Result<ProductionOrder> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedProductions";
                var cacheData = _cache.Get<Result<ProductionOrder>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.ProductionOrders.Where(s => s.IsActive == false).Select(s => new ProductionOrder
                    {
                        ProductionOrderId = s.ProductionOrderId,
                        Fk_FinishedGoodId = s.Fk_FinishedGoodId,
                        FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
                        ProductionTransactions = s.ProductionTransactions.Select(pt => new ProductionTransaction
                        {
                            ProductionTransactionId = pt.ProductionTransactionId,
                            RawMaterialName = _ctx.Products.Where(p => p.ProductId == pt.Fk_RawMaterialId).Select(s => s.ProductName).SingleOrDefault(),
                            Quantity = pt.Quantity,
                            Unit = pt.Unit,
                        }).ToList()
                    }).ToListAsync();
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
        public async Task<RepoBase> RecoverProduction(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == false);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    // Update related ProductionTransactions
                    foreach (var existingTransaction in Query.ProductionTransactions)
                    {
                        existingTransaction.ModifyDate = DateTime.UtcNow;
                        existingTransaction.ModifyBy = user.Name;
                        existingTransaction.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
                        _cache.Remove("RemovedProductions");
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
        public async Task<RepoBase> DeleteProduction(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(po => po.ProductionOrderId == Id && po.IsActive == false);
                if (Query != null)
                {
                    _ctx.ProductionOrders.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
                        _cache.Remove("RemovedProductions");
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
        public async Task<RepoBase> RecoverAllProduction(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var ProductionIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var ProductionToRecover = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).Where(x => ProductionIds.Contains(x.ProductionOrderId) && x.IsActive == false).ToListAsync();
                if (ProductionToRecover.Any())
                {
                    foreach (var production in ProductionToRecover)
                    {
                        production.ModifyDate = DateTime.UtcNow;
                        production.ModifyBy = user.Name;
                        production.IsActive = true;
                        // Update related ProductionTransactions
                        foreach (var productionTransaction in production.ProductionTransactions)
                        {
                            productionTransaction.ModifyDate = DateTime.UtcNow;
                            productionTransaction.ModifyBy = user.Name;
                            productionTransaction.IsActive = true;
                        }
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
                        _cache.Remove("RemovedProductions");
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
        public async Task<RepoBase> DeleteAllProduction(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var ProductionIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var ProductionToDelete = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).Where(x => ProductionIds.Contains(x.ProductionOrderId) && x.IsActive == false).ToListAsync();
                if (ProductionToDelete.Any())
                {
                    _ctx.ProductionOrders.RemoveRange(ProductionToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Production");
                        _cache.Remove("RemovedProductions");
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
        #region  Sales 
        #region Crud
        public async Task<Result<SalesOrderSetup>> GetSales()
        {
            Result<SalesOrderSetup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Sales";
                var cacheData = _cache.Get<Result<SalesOrderSetup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.SalesOrderSetups.Where(s => s.IsActive == true).Select(s => new SalesOrderSetup
                    {
                        SalesOrderSetupId = s.SalesOrderSetupId,
                        FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
                        SalesTransactionSetups = s.SalesTransactionSetups.Select(st => new SalesTransactionSetup
                        {
                            SubFinishedGoodName = _ctx.Products.Where(p => p.ProductId == st.Fk_SubFinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
                            Quantity = st.Quantity,
                            Unit = st.Unit,
                        }).ToList()
                    }).ToListAsync();
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
        public async Task<RepoBase> CreateSales(SalesOrderSetupModel data, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.SalesOrderSetups.SingleOrDefaultAsync(s => s.Fk_FinishedGoodId == data.Fk_FinishedGoodId && s.IsActive == true);
                if (Query == null)
                {
                    var newSalesOrder = _mapper.Map<SalesOrderSetup>(data);
                    newSalesOrder.CreatedDate = DateTime.UtcNow;
                    newSalesOrder.CreatedBy = user.Name;
                    if (data.SalesTransactionSetups.Count > 0)
                    {
                        newSalesOrder.SalesTransactionSetups = data.SalesTransactionSetups.Select(s =>
                        {
                            var newSalesTransaction = _mapper.Map<SalesTransactionSetup>(s);
                            newSalesTransaction.CreatedDate = DateTime.UtcNow;
                            newSalesTransaction.CreatedBy = user.Name;
                            return newSalesTransaction;
                        }).ToList();
                    }
                    await _ctx.SalesOrderSetups.AddAsync(newSalesOrder);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newSalesOrder.SalesOrderSetupId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
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
        public async Task<RepoBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).SingleOrDefaultAsync(s => s.SalesOrderSetupId == Id && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    // Add new transactions and update existing ones
                    var existingTransactions = Query.SalesTransactionSetups.ToList();
                    var updatedTransactions = data.SalesTransactionSetups.ToList();
                    foreach (var updatedTransaction in updatedTransactions)
                    {
                        var existingTransaction = existingTransactions.SingleOrDefault(et => et.SalesTransactionSetupId == updatedTransaction.SalesTransactionSetupId);
                        if (existingTransaction != null)
                        {
                            // Update existing transaction
                            _mapper.Map(updatedTransaction, existingTransaction);
                            existingTransaction.ModifyDate = DateTime.UtcNow;
                            existingTransaction.ModifyBy = user.Name;
                        }
                        else
                        {
                            // Add new transaction
                            var newTransaction = _mapper.Map<SalesTransactionSetup>(updatedTransaction);
                            newTransaction.CreatedDate = DateTime.UtcNow;
                            newTransaction.CreatedBy = user.Name;
                            Query.SalesTransactionSetups.Add(newTransaction);
                        }
                    }
                    // Remove deleted transactions
                    foreach (var existingTransaction in existingTransactions)
                    {
                        if (!updatedTransactions.Any(ut => ut.SalesTransactionSetupId == existingTransaction.SalesTransactionSetupId))
                        {
                            _ctx.SalesTransactionSetups.Remove(existingTransaction);
                        }
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    _Result.Count = Count.ToString();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
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
        public async Task<RepoBase> RemoveSales(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).SingleOrDefaultAsync(s => s.SalesOrderSetupId == Id && s.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = false;
                    // Update related SalesTransactionSetups
                    foreach (var existingTransaction in Query.SalesTransactionSetups)
                    {
                        existingTransaction.ModifyDate = DateTime.UtcNow;
                        existingTransaction.ModifyBy = user.Name;
                        existingTransaction.IsActive = false;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
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
        #region Recover
        public async Task<Result<SalesOrderSetup>> GetRemovedSales()
        {
            Result<SalesOrderSetup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedSales";
                var cacheData = _cache.Get<Result<SalesOrderSetup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.SalesOrderSetups.Where(s => s.IsActive == true).Select(s => new SalesOrderSetup
                    {
                        SalesOrderSetupId = s.SalesOrderSetupId,
                        FinishedGoodName = _ctx.Products.Where(p => p.ProductId == s.Fk_FinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
                        SalesTransactionSetups = s.SalesTransactionSetups.Select(st => new SalesTransactionSetup
                        {
                            SubFinishedGoodName = _ctx.Products.Where(p => p.ProductId == st.Fk_SubFinishedGoodId).Select(s => s.ProductName).SingleOrDefault(),
                            Quantity = st.Quantity,
                            Unit = st.Unit,
                        }).ToList()
                    }).ToListAsync();
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
        public async Task<RepoBase> RecoverSales(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).SingleOrDefaultAsync(s => s.SalesOrderSetupId == Id && s.IsActive == true);
                if (Query != null)
                {
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    Query.IsActive = true;
                    // Update related SalesTransactionSetups
                    foreach (var existingTransaction in Query.SalesTransactionSetups)
                    {
                        existingTransaction.ModifyDate = DateTime.UtcNow;
                        existingTransaction.ModifyBy = user.Name;
                        existingTransaction.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
                        _cache.Remove("RemovedSales");
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
        public async Task<RepoBase> DeleteSales(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.ProductionOrders.Include(po => po.ProductionTransactions).SingleOrDefaultAsync(s => s.ProductionOrderId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.ProductionOrders.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
                        _cache.Remove("RemovedSales");
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
        public async Task<RepoBase> RecoverAllSales(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var SalesIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var SalesToRecover = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).Where(x => SalesIds.Contains(x.SalesOrderSetupId) && x.IsActive == false).ToListAsync();
                if (SalesToRecover.Any())
                {
                    foreach (var Sale in SalesToRecover)
                    {
                        Sale.ModifyDate = DateTime.UtcNow;
                        Sale.ModifyBy = user.Name;
                        Sale.IsActive = true;
                        // Update related SalesTransactionSetups
                        foreach (var SaleTransaction in Sale.SalesTransactionSetups)
                        {
                            SaleTransaction.ModifyDate = DateTime.UtcNow;
                            SaleTransaction.ModifyBy = user.Name;
                            SaleTransaction.IsActive = true;
                        }
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
                        _cache.Remove("RemovedSales");
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
        public async Task<RepoBase> DeleteAllSales(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var SalesIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var SalesToDelete = await _ctx.SalesOrderSetups.Include(po => po.SalesTransactionSetups).Where(x => SalesIds.Contains(x.SalesOrderSetupId) && x.IsActive == false).ToListAsync();
                if (SalesToDelete.Any())
                {
                    _ctx.SalesOrderSetups.RemoveRange(SalesToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("Sales");
                        _cache.Remove("RemovedSales");
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
        #region Labour Rate
        #region Crud
        public async Task<Result<LabourRate>> GetAllLabourRates(Guid FinancialYearId, Guid BranchId)
        {
            Result<LabourRate> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "LabourRates";
                var cacheData = _cache.Get<Result<LabourRate>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.LabourRates.Where(s => s.Fk_FinancialYearId == FinancialYearId && s.Fk_BranchId == BranchId && s.IsActive == true)
                               .Select(lr => new LabourRate
                               {
                                   LabourRateId = lr.LabourRateId,
                                   Date = lr.Date,
                                   ProductType = lr.ProductType ?? new ProductType { Product_Type = lr.ProductType.Product_Type },
                                   Product = lr.Product ?? new Product { ProductName = lr.Product.ProductName },
                                   Rate = lr.Rate
                               }).ToListAsync();
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
        public async Task<RepoBase> CreateLabourRate(LabourRateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var newLabourRate = _mapper.Map<LabourRate>(data);
                newLabourRate.CreatedDate = DateTime.UtcNow;
                newLabourRate.CreatedBy = user.Name;
                await _ctx.LabourRates.AddAsync(newLabourRate);
                int Count = await _ctx.SaveChangesAsync();
                if (Count > 0)
                {
                    _Result.Id = newLabourRate.LabourRateId.ToString();
                    _Result.Count = Count.ToString();
                    _Result.IsSucess = true;
                    _cache.Remove("LabourRates");
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("LabourRates");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveLabourRate(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == true);
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
                        _cache.Remove("LabourRates");
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
        public async Task<Result<LabourRate>> GetRemovedLabourRate(Guid FinancialYearId, Guid BranchId)
        {
            Result<LabourRate> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemoveLabourRates";
                var cacheData = _cache.Get<Result<LabourRate>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.LabourRates.Where(s => s.Fk_FinancialYearId == FinancialYearId && s.Fk_BranchId == BranchId && s.IsActive == true)
                               .Select(lr => new LabourRate
                               {
                                   LabourRateId = lr.LabourRateId,
                                   Date = lr.Date,
                                   ProductType = lr.ProductType ?? new ProductType { Product_Type = lr.ProductType.Product_Type },
                                   Product = lr.Product ?? new Product { ProductName = lr.Product.ProductName },
                                   Rate = lr.Rate
                               }).ToListAsync();
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
        public async Task<RepoBase> RecoverLabourRate(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == false);
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
                        _cache.Remove("LabourRates");
                        _cache.Remove("RemoveLabourRates");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteLabourRate(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LabourRates.SingleOrDefaultAsync(s => s.LabourRateId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.LabourRates.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.Remove("LabourRates");
                        _cache.Remove("RemoveLabourRates");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllLabourRate(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var labourRateIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var labourRateToRecover = await _ctx.LabourRates.Where(x => labourRateIds.Contains(x.LabourRateId) && x.IsActive == false).ToListAsync();
                if (labourRateToRecover.Any())
                {
                    foreach (var labourRate in labourRateToRecover)
                    {
                        labourRate.ModifyDate = DateTime.UtcNow;
                        labourRate.ModifyBy = user.Name;
                        labourRate.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("LabourRates");
                        _cache.Remove("RemoveLabourRates");
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
        public async Task<RepoBase> DeleteAllLabourRate(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var labourRateIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var labourRateToDelete = await _ctx.LabourRates.Where(x => labourRateIds.Contains(x.LabourRateId) && x.IsActive == false).ToListAsync();
                if (labourRateToDelete.Any())
                {
                    _ctx.LabourRates.RemoveRange(labourRateToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.Remove("LabourRates");
                        _cache.Remove("RemoveLabourRates");
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
        #region Account 
        #region Group
        public async Task<Result<LedgerGroup>> GetGroups()
        {
            Result<LedgerGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Groups";
                var cacheData = _cache.Get<Result<LedgerGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.LedgerGroups.
                                 Select(s => new LedgerGroup
                                 {
                                     LedgerGroupId = s.LedgerGroupId,
                                     GroupName = s.GroupName
                                 }).ToListAsync();
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
        #endregion
        #region SubGroup
        #region Crud
        public async Task<Result<LedgerSubGroup>> GetSubGroups(Guid GroupId, Guid BranchId)
        {
            Result<LedgerSubGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"SubGroups_{BranchId}";
                var cacheData = _cache.Get<Result<LedgerSubGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var defaultSubGroups = await _ctx.LedgerSubGroupDevs.
                                             Where(s => s.Fk_BranchId == BranchId && s.Fk_LedgerGroupId == GroupId).
                                             Select(s => new LedgerSubGroup
                                             {
                                                 LedgerSubGroupId = s.LedgerSubGroupId,
                                                 SubGroupName = s.SubGroupName
                                             }).ToListAsync();
                    var userCreatedSubGroups = await _ctx.LedgerSubGroups.
                                                 Where(s => s.Fk_BranchId == BranchId && s.Fk_LedgerGroupId == GroupId && s.IsActive == true)
                                                 .Select(s => new LedgerSubGroup
                                                 {
                                                     LedgerSubGroupId = s.LedgerSubGroupId,
                                                     SubGroupName = s.SubGroupName
                                                 }).ToListAsync();
                    defaultSubGroups.AddRange(userCreatedSubGroups);
                    if (defaultSubGroups.Any())
                    {
                        _Result.CollectionObjData = defaultSubGroups;
                        _Result.Count = defaultSubGroups.Count;
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
        public async Task<RepoBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LedgerSubGroups.Where(s => s.SubGroupName == data.SubGroupName && s.Fk_LedgerGroupId == data.Fk_LedgerGroupId && s.Fk_BranchId == data.Fk_BranchId && s.IsActive == true).SingleOrDefaultAsync();
                if (Query == null)
                {
                    var newLedgerSubGroup = _mapper.Map<LedgerSubGroup>(data);
                    newLedgerSubGroup.CreatedDate = DateTime.UtcNow;
                    newLedgerSubGroup.CreatedBy = user.Name;
                    await _ctx.LedgerSubGroups.AddAsync(newLedgerSubGroup);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newLedgerSubGroup.LedgerSubGroupId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("SubGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == data.Fk_BranchId && s.IsActive == true);
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("SubGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveSubGroup(Guid Id, Guid BranchId, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == BranchId && s.IsActive == true);
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
        #endregion
        #region Recover
        public async Task<Result<LedgerSubGroup>> GetRemovedSubGroups(Guid BranchId)
        {
            Result<LedgerSubGroup> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"RemovedSubGroups";
                var cacheData = _cache.Get<Result<LedgerSubGroup>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await _ctx.LedgerSubGroups.
                                                 Where(s => s.Fk_BranchId == BranchId && s.IsActive == false)
                                                 .Select(s => new LedgerSubGroup
                                                 {
                                                     LedgerSubGroupId = s.LedgerSubGroupId,
                                                     SubGroupName = s.SubGroupName
                                                 }).ToListAsync();
                    if (Query.Any())
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
        public async Task<RepoBase> RecoverSubGroup(Guid Id, Guid BranchId, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == BranchId && s.IsActive == false);
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
                        _cache.RemoveByPrefix("SubGroups");
                        _cache.Remove("RemovedSubGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteSubGroup(Guid Id, Guid BranchId, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.LedgerSubGroups.SingleOrDefaultAsync(s => s.LedgerSubGroupId == Id && s.Fk_BranchId == BranchId && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.LedgerSubGroups.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("SubGroups");
                        _cache.Remove("RemovedSubGroups");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllSubGroup(List<string> Ids, Guid BranchId, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var ledgerSubGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var ledgerSubGroupToRecover = await _ctx.LedgerSubGroups.Where(x => ledgerSubGroupIds.Contains(x.LedgerSubGroupId) && x.Fk_BranchId == BranchId && x.IsActive == false).ToListAsync();
                if (ledgerSubGroupToRecover.Any())
                {
                    foreach (var ledgerSubGroup in ledgerSubGroupToRecover)
                    {
                        ledgerSubGroup.ModifyDate = DateTime.UtcNow;
                        ledgerSubGroup.ModifyBy = user.Name;
                        ledgerSubGroup.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("SubGroups");
                        _cache.Remove("RemovedSubGroups");
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
        public async Task<RepoBase> DeleteAllSubGroup(List<string> Ids, Guid BranchId, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var ledgerSubGroupIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var ledgerSubGroupToDelete = await _ctx.LedgerSubGroups.Where(x => ledgerSubGroupIds.Contains(x.LedgerSubGroupId) && x.Fk_BranchId == BranchId && x.IsActive == false).ToListAsync();
                if (ledgerSubGroupToDelete.Any())
                {
                    _ctx.LedgerSubGroups.RemoveRange(ledgerSubGroupToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("SubGroups");
                        _cache.Remove("RemovedSubGroups");
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
        #region Ledger
        #region Crud
        public async Task<Result<Ledger>> GetLedgers()
        {
            Result<Ledger> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "Ledgers";
                var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
                if (cacheData == null)
                {
                    var ledgerDevs = await (from l in _ctx.LedgersDev
                                            select new Ledger
                                            {
                                                HasSubLedger = l.HasSubLedger,
                                                LedgerId = l.LedgerId,
                                                LedgerName = l.LedgerName,
                                                LedgerType = l.LedgerType,
                                                LedgerGroup = l.LedgerGroup != null ? new LedgerGroup { GroupName = l.LedgerGroup.GroupName } : null,
                                                LedgerSubGroup = l.LedgerSubGroup != null ? new LedgerSubGroup { SubGroupName = l.LedgerSubGroup.SubGroupName } : null

                                            }).ToListAsync();
                    var ledgers = await (from l in _ctx.Ledgers
                                         select new Ledger
                                         {
                                             HasSubLedger = l.HasSubLedger,
                                             LedgerId = l.LedgerId,
                                             LedgerName = l.LedgerName,
                                             LedgerType = l.LedgerType,
                                             LedgerGroup = l.LedgerGroup != null ? new LedgerGroup { GroupName = l.LedgerGroup.GroupName } : null,
                                             LedgerSubGroup = l.LedgerSubGroup != null ? new LedgerSubGroup { SubGroupName = l.LedgerSubGroup.SubGroupName } : null
                                         }).ToListAsync();
                    ledgers.AddRange(ledgerDevs);
                    if (ledgers.Count > 0)
                    {
                        _Result.CollectionObjData = ledgers;
                        _Result.Count = ledgers.Count;
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
        public async Task<Result<Ledger>> GetLedgerById(Guid Id)
        {
            Result<Ledger> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Ledgers_{Id}";
                var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
                if (cacheData == null)
                {
                    var ledDevs = await (from l in _ctx.LedgersDev.Where(x => x.LedgerId == Id)
                                         select new Ledger
                                         {
                                             HasSubLedger = l.HasSubLedger,
                                             LedgerId = l.LedgerId,
                                             LedgerType = l.LedgerType
                                         }).SingleOrDefaultAsync();

                    var led = await (from l in _ctx.Ledgers.Where(x => x.LedgerId == Id)
                                     select new Ledger
                                     {
                                         HasSubLedger = l.HasSubLedger,
                                         LedgerId = l.LedgerId,
                                         LedgerType = l.LedgerType
                                     }).SingleOrDefaultAsync();
                    var Ledger = ledDevs ?? led;
                    if (Ledger != null)
                    {
                        _Result.SingleObjData = Ledger;
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
        public async Task<Result<Ledger>> GetLedgersHasSubLedger(Guid BranchId)
        {
            Result<Ledger> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Ledgers_{BranchId}";
                var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
                if (cacheData == null)
                {
                    var ledgers = await (from l in _ctx.Ledgers.Where(x => x.HasSubLedger == "Yes")
                                         select new Ledger
                                         {
                                             LedgerId = l.LedgerId,
                                             LedgerName = l.LedgerName,
                                         }).ToListAsync();
                    if (ledgers.Count > 0)
                    {
                        _Result.CollectionObjData = ledgers;
                        _Result.Count = ledgers.Count;
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
        public async Task<Result<Ledger>> GetLedgersHasNoSubLedger(Guid BranchId)
        {
            Result<Ledger> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = $"Ledgers_NoSubLedger_{BranchId}";
                var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
                if (cacheData == null)
                {
                    var ledgerDevs = await (from l in _ctx.LedgersDev.Where(x => x.HasSubLedger == "No")
                                            select new Ledger
                                            {
                                                LedgerId = l.LedgerId,
                                                LedgerName = l.LedgerName,
                                            }).ToListAsync();
            
                    var ledgers = await (from l in _ctx.Ledgers.Where(x => x.HasSubLedger == "No")
                                         select new Ledger
                                         {
                                             LedgerId = l.LedgerId,
                                             LedgerName = l.LedgerName,
                                         }).ToListAsync();
                    ledgers.AddRange(ledgerDevs);
                    if (ledgers.Count > 0)
                    {
                        _Result.CollectionObjData = ledgers;
                        _Result.Count = ledgers.Count;
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
        public async Task<RepoBase> CreateLedger(LedgerModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.Fk_LedgerGroupId == data.Fk_LedgerGroupId && s.LedgerName == data.LedgerName);
                if (Query == null)
                {
                    var newLedger = _mapper.Map<Ledger>(data);
                    newLedger.CreatedDate = DateTime.UtcNow;
                    newLedger.CreatedBy = user.Name;
                    await _ctx.Ledgers.AddAsync(newLedger);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = newLedger.LedgerId.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Ledgers");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive ==true) ;
                if (Query != null)
                {
                    _mapper.Map(data, Query);
                    Query.ModifyDate = DateTime.UtcNow;
                    Query.ModifyBy = user.Name;
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Ledgers");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RemoveLedger(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == true);
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
                        _cache.RemoveByPrefix("Ledgers");
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
        public async Task<Result<Ledger>> GetRemovedLedgers()
        {
            Result<Ledger> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var cacheKey = "RemovedLedgers";
                var cacheData = _cache.Get<Result<Ledger>>(cacheKey);
                if (cacheData == null)
                {
                    var Query = await (from l in _ctx.Ledgers
                                         select new Ledger
                                         {
                                             HasSubLedger = l.HasSubLedger,
                                             LedgerId = l.LedgerId,
                                             LedgerName = l.LedgerName,
                                             LedgerType = l.LedgerType,
                                             LedgerGroup = l.LedgerGroup != null ? new LedgerGroup { GroupName = l.LedgerGroup.GroupName } : null,
                                             LedgerSubGroup = l.LedgerSubGroup != null ? new LedgerSubGroup { SubGroupName = l.LedgerSubGroup.SubGroupName } : null
                                         }).ToListAsync();
                 
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
        public async Task<RepoBase> RecoverLedger(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == false);
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
                        _cache.RemoveByPrefix("Ledgers");
                        _cache.Remove("RemovedLedgers");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> DeleteLedger(Guid Id, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Ledgers.SingleOrDefaultAsync(s => s.LedgerId == Id && s.IsActive == false);
                if (Query != null)
                {
                    _ctx.Ledgers.Remove(Query);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Id = Id.ToString();
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        _cache.RemoveByPrefix("Ledgers");
                        _cache.Remove("RemovedLedgers");
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> RecoverAllLedger(List<string> Ids, AppUser user)
        {

            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var ledgerIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var ledgerToRecover = await _ctx.Ledgers.Where(x => ledgerIds.Contains(x.LedgerId) && x.IsActive == false).ToListAsync();
                if (ledgerToRecover.Any())
                {
                    foreach (var ledger in ledgerToRecover)
                    {
                        ledger.ModifyDate = DateTime.UtcNow;
                        ledger.ModifyBy = user.Name;
                        ledger.IsActive = true;
                    }
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Ledgers");
                        _cache.Remove("RemovedLedgers");
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
        public async Task<RepoBase> DeleteAllLedger(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var ledgerIds = Ids.Select(id => Guid.Parse(id)).ToList();
                var ledgerToDelete = await _ctx.Ledgers.Where(x => ledgerIds.Contains(x.LedgerId) && x.IsActive == false).ToListAsync();
                if (ledgerToDelete.Any())
                {
                    _ctx.Ledgers.RemoveRange(ledgerToDelete);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.Ids = Ids;
                        _Result.Count = Count.ToString();
                        _Result.IsSucess = true;
                        transaction.Commit();
                        _cache.RemoveByPrefix("Ledgers");
                        _cache.Remove("RemovedLedgers");
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

        public Task<Result<AlternateUnit>> GetAlternateUnits(Guid UnitId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #endregion
    }
}
