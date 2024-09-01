using AutoMapper;
using FMS.Db.Entity;
using FMS.Model.Account.Autherization;
namespace FMS.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Devloper
            CreateMap<Branch, BranchModel>().ReverseMap();
            CreateMap<FinancialYear, FinancialYearModel>().ReverseMap();
            CreateMap<BranchFinancialYear, BranchFinancialYearModel>().ReverseMap();
            //admin
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<UserBranch, UserBranchModel>().ReverseMap();
        }
    }
}
