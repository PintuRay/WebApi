using AutoMapper;
using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Model.Admin;
using FMS.Model.Devloper;

namespace FMS.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserModel>().ReverseMap();
            CreateMap<AppUser, UserDbModel>().ReverseMap();
            CreateMap<AppRole, RoleDbModel>().ReverseMap();
            CreateMap<AppRole, RoleModel>().ReverseMap();
            CreateMap<Branch, BranchModel>().ReverseMap();
            CreateMap<Branch, BranchViewModel>().ReverseMap();
            CreateMap<FinancialYear, FinancialYearModel>().ReverseMap();
            CreateMap<FinancialYear, FinancialYearViewModel>().ReverseMap();
            CreateMap<BranchFinancialYear, BranchFinancialYearModel>().ReverseMap();
            CreateMap<BranchFinancialYear, BranchFinancialYearViewModel>().ReverseMap();
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            CreateMap<RegisterToken, RegisterTokenViewModel>().ReverseMap();
        }
    }
}
