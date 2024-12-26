using AutoMapper;
using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
namespace FMS.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            CreateMap<AppUser, RegisterModel>().ReverseMap();
           // CreateMap<AddressModel, Address>().ReverseMap();
            //Devloper
            //CreateMap<Branch, BranchModel>().ReverseMap();
            //CreateMap<FinancialYear, FinancialYearModel>().ReverseMap();
            //CreateMap<BranchFinancialYear, BranchFinancialYearModel>().ReverseMap();
            //admin
            
            //CreateMap<Company, CompanyModel>().ReverseMap();
            //CreateMap<UserBranch, UserBranchModel>().ReverseMap();
            //CreateMap<ProductType,ProductTypeModel>().ReverseMap();
            //CreateMap<ProductGroup, ProductGroupModel>().ReverseMap();
            //CreateMap<ProductSubGroup,ProductSubGroup>().ReverseMap();
            //CreateMap<Unit, UnitModel>().ReverseMap();
            //CreateMap<AlternateUnit, AlternateUnitModel>().ReverseMap();
            //CreateMap<Product, ProductModel>().ReverseMap();
            //common
            //CreateMap<CountryModel, Country>().ReverseMap();
            //CreateMap<StateModel, State>().ReverseMap();
            //CreateMap<DistModel, Dist>().ReverseMap();
        }
    }
}
