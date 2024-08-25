using AutoMapper;
using FMS.Db.Entity;
using FMS.Model.Account.Autherization;
namespace FMS.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppRole, RoleDbModel>().ReverseMap();
            CreateMap<AppRole, RoleModel>().ReverseMap();
            CreateMap<Branch, BranchModel>().ReverseMap();
            CreateMap<FinancialYear, FinancialYearModel>().ReverseMap();
            CreateMap<BranchFinancialYear, BranchFinancialYearModel>().ReverseMap();
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<UserBranch, UserBranchModel>().ReverseMap();
        }
    }
}
