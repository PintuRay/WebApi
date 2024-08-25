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
        public async Task<BaseDb> CreateToken(RegisterTokenModel model)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> CreateCompany(CompanyModel data, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> UpdateCompany(Guid Id, CompanyModel model, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RemoveCompany(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RecoverCompany(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> DeleteCompany(Guid Id, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> RecoverAllCompany(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> DeleteAllCompany(List<string> Ids, AppUser user)
        {
            BaseDb _Result = new();
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
        public async Task<BaseDb> CreateBranchAlloction(UserBranchModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateBranchAlloction(Guid Id, UserBranchModel model, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveBranchAlloction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<UserBranch>> GetRemovedBranchAlloction()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverBranchAlloction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteBranchAlloction(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllBranchAlloction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllBranchAlloction(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Unit
        #region Crud
        public async Task<BaseDb> CreateUnit(UnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<UnitModel>> GetAllUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateUnit(Guid Id, UnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<UnitModel>> GetRemovedUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Alternate Units
        #region Crud
        public async Task<BaseDb> CreateAlternateUnit(AlternateUnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<AlternateUnitModel>> GetAlternateUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveAlternateUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<AlternateUnitModel>> GetRemovedAlternateUnits()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAlternateUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAlternateUnit(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllAlternateUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllAlternateUnit(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Product Group
        #region Crud
        public async Task<BaseDb> CreateProductGroup(ProductGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<ProductGroupModel>> GetProductGroups()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveProductGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductGroupModel>> GetRemovedProductGroup()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverProductGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteProductGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllProductGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllProductGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        public async Task<Result<ProductSubGroupModel>> GetProductSubGroups()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateProductSubGroup(ProductSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveProductSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductSubGroupModel>> GetRemovedProductSubGroup()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverProductSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteProductSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllProductSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllProductSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Product
        public async Task<Result<ProductTypeModel>> GetProductTypes()
        {
            throw new NotImplementedException();
        }
        #region Crud
        public async Task<Result<ProductModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateProduct(ProductModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateProduct(Guid Id, ProductModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveProduct(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductModel>> GetRemovedProduct()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverProduct(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteProduct(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllProduct(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllProduct(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Production Configuration
        #region Crud
        public async Task<Result<ProductionModel>> GetProductionConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateProductionConfig(ProductConfigDataRequest requestData, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateProductionConfig(Guid Id, ProductionModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveProductionConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<ProductionModel>> GetRemovedProductionConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverProductionConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteProductionConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllProductionConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllProductionConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region  Sales Config
        #region Crud
        public async Task<Result<SalesConfigModel>> GetSalesConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateSalesConfig(ProductConfigDataRequest requestData, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateSalesConfig(Guid Id, SalesConfigModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveSalesConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<SalesConfigModel>> GetRemovedSalesConfig()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverSalesConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteSalesConfig(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllSalesConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllSalesConfig(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Labour Rate Configration
        #region Crud
        public async Task<Result<LabourRateModel>> GetAllLabourRates()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateLabourRate(LabourRateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveLabourRate(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<LabourRateModel>> GetRemovedLabourRate()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverLabourRate(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteLabourRate(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllLabourRate(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllLabourRate(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Account Configuration
        #region Group
        public async Task<Result<LedgerGroupModel>> GetGroups()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region SubGroup
        #region Crud
        public async Task<Result<LedgerSubGroupModel>> GetSubGroups()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateSubGroup(LedgerSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateSubGroup(Guid Id, LedgerSubGroupModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<LedgerSubGroupModel>> GetRemovedSubGroup()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteSubGroup(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllSubGroup(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region Ledger
        #region Crud
        public async Task<Result<LedgerModel>> GetLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> CreateLedger(LedgerViewModel listData, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> UpdateLedger(Guid Id, LedgerModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RemoveLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<Result<LedgerModel>> GetRemovedLedgers()
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteLedger(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> RecoverAllLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseDb> DeleteAllLedger(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #endregion
    }
}
