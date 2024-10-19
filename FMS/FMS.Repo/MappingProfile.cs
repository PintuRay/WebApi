using AutoMapper;
using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
namespace FMS.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegisterModel>().ReverseMap();
            //Devloper
            CreateMap<Branch, BranchModel>().ReverseMap();
            CreateMap<FinancialYear, FinancialYearModel>().ReverseMap();
            CreateMap<BranchFinancialYear, BranchFinancialYearModel>().ReverseMap();
            //admin
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<UserBranch, UserBranchModel>().ReverseMap();
            CreateMap<ProductType,ProductTypeModel>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupModel>().ReverseMap();
            CreateMap<ProductSubGroup,ProductSubGroup>().ReverseMap();
            CreateMap<Unit, UnitModel>().ReverseMap();
            CreateMap<AlternateUnit, AlternateUnitModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
