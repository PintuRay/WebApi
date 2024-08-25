using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.AdminSetting
{
    public class AdminSettingRepo(Context ctx, IMapper mapper) : IAdminSettingRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Generate SignUp Token
        public async Task<RepoBase> CreateToken(RegisterTokenModel model)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var isExistToken = await (from s in _ctx.RegisterTokens where s.TokenValue == model.TokenValue select s).SingleOrDefaultAsync();
                if (isExistToken == null)
                {
                    var regToken = _mapper.Map<RegisterToken>(model);
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
        #region Company Details
        #region Crud
        public async Task<Result<Company>> GetCompany(string BranchId)
        {
            Result<Company> _Result = new();
            try
            {
                _Result.IsSucess = false;
                if (BranchId != "All")
                {
                    var Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == true).SingleOrDefaultAsync();
                    if (Query != null)
                    {
                        var Company = _mapper.Map<Company>(Query);
                        _Result.SingleObjData = Company;
                        _Result.IsSucess = true;
                    }
                }
                else
                {
                    var Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == true).ToListAsync();
                    if (Query != null)
                    {
                        var Companies = _mapper.Map<List<Company>>(Query);
                        _Result.CollectionObjData = Companies;
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
        public async Task<Result<Company>> GetRemovedCompanies(string BranchId)
        {
            Result<Company> _Result = new();
            try
            {
                _Result.IsSucess = false;
                if (BranchId != "All")
                {
                    var Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == false).SingleOrDefaultAsync();
                    if (Query != null)
                    {
                        var Company = _mapper.Map<Company>(Query);
                        _Result.SingleObjData = Company;
                        _Result.IsSucess = true;
                    }
                }
                else
                {
                    var Query = await _ctx.Companies.Where(s => s.Fk_BranchId == Guid.Parse(BranchId) && s.IsActive == false).ToListAsync();
                    if (Query != null)
                    {
                        var Companies = _mapper.Map<List<Company>>(Query);
                        _Result.CollectionObjData = Companies;
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
        public async Task<RepoBase> RecoverAllCompany(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Guid.Parse(item) && x.IsActive == false);
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
        public async Task<RepoBase> DeleteAllCompany(List<string> Ids, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                int Count = 0;
                _Result.IsSucess = false;
                foreach (var item in Ids)
                {
                    var Query = await _ctx.Companies.SingleOrDefaultAsync(x => x.CompanyId == Guid.Parse(item) && x.IsActive == false);
                    if (Query != null)
                    {
                        _ctx.Companies.Remove(Query);
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
        #region User Branch Allocation
        #region Crud
        public async Task<Result<UserBranch>> GetBranchAlloctions()
        {
            Result<UserBranch> _Result = new();
            try
            {
                _Result.IsSucess = false;     
                var AllUserAllocatedBranch = await (from s in _ctx.UserBranches
                                                    select new UserBranch
                                                    {
                                                        Id = s.Id,
                                                        Branch = s.Branch != null ? new Branch { BranchName = s.Branch.BranchName } : null,
                                                        User = s.User != null ? new AppUser { UserName = s.User.Name} : null
                                                    }).ToListAsync();
                if (AllUserAllocatedBranch.Count > 0)
                {

                    _Result.IsSucess = true;
                }
                
            }
            catch 
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> CreateBranchAlloction(UserBranchModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateBranchAlloction(Guid Id, UserBranchModel model, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveBranchAlloction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<UserBranch>> GetRemovedBranchAlloction()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverBranchAlloction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteBranchAlloction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllBranchAlloction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllBranchAlloction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Unit
        #region Crud
        public async Task<RepoBase> CreateUnit(UnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<Unit>> GetAllUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateUnit(Guid Id, UnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<Unit>> GetRemovedUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Alternate Units
        #region Crud
        public async Task<RepoBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<AlternateUnit>> GetAlternateUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveAlternateUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<AlternateUnit>> GetRemovedAlternateUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAlternateUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAlternateUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Product Group
        #region Crud
        public async Task<RepoBase> CreateProductGroup(ProductGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<ProductGroup>> GetProductGroups()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveProductGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductGroup>> GetRemovedProductGroup()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverProductGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteProductGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllProductGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllProductGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        public async Task<Result<ProductSubGroup>> GetProductSubGroups()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveProductSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductSubGroup>> GetRemovedProductSubGroup()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverProductSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteProductSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Product
        public async Task<Result<ProductType>> GetProductTypes()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Result<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateProduct(ProductModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateProduct(Guid Id, ProductModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveProduct(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<Product>> GetRemovedProduct()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverProduct(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteProduct(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllProduct(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllProduct(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Production Configuration
        #region Crud
        public async Task<Result<ProductionOrder>> GetProductionConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateProductionConfig(ProductionOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateProductionConfig(Guid Id, ProductionOrderModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveProductionConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductionOrder>> GetRemovedProductionConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverProductionConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteProductionConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllProductionConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllProductionConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region  Sales Config
        #region Crud
        public async Task<Result<SalesOrderSetup>> GetSalesConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateSalesConfig(SalesOrderSetupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateSalesConfig(Guid Id, SalesOrderSetupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveSalesConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<SalesOrderSetup>> GetRemovedSalesConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverSalesConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteSalesConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllSalesConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllSalesConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Labour Rate Configration
        #region Crud
        public async Task<Result<LabourRate>> GetAllLabourRates()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateLabourRate(LabourRateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveLabourRate(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<LabourRate>> GetRemovedLabourRate()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverLabourRate(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteLabourRate(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllLabourRate(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllLabourRate(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Account Configuration
        #region Group
        public async Task<Result<LedgerGroup>> GetGroups()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region SubGroup
        #region Crud
        public async Task<Result<LedgerSubGroup>> GetSubGroups()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateSubGroup(LedgerSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<LedgerSubGroup>> GetRemovedSubGroup()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Ledger
        #region Crud
        public async Task<Result<Ledger>> GetLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> CreateLedger(LedgerModel listData, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> UpdateLedger(Guid Id, LedgerModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RemoveLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<Ledger>> GetRemovedLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> RecoverAllLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<RepoBase> DeleteAllLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #endregion
    }
}
