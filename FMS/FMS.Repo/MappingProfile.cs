using AutoMapper;
using FMS.Db.Entity;
namespace FMS.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserModel>();
            CreateMap<UserModel, AppUser>().ForMember(dest => dest.Address, opt => opt.Ignore());
            CreateMap<AppUser, UserUpdateModel>();
            CreateMap<UserUpdateModel, AppUser>().ForMember(dest => dest.Address, opt => opt.Ignore());
            /*--------------------------------------------Devloper---------------------------------------------------*/
            CreateMap<BranchDto,Branch>().ReverseMap();
            CreateMap<BranchModel, Branch>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)).ReverseMap();
            CreateMap<BranchUpdateModel, Branch>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)).ReverseMap();
            CreateMap<FinancialYear, FinancialYearModel>().ReverseMap()
                .ForMember(dest => dest.StartDate, opt =>
                    opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.EndDate, opt =>
                    opt.MapFrom(src => DateTime.SpecifyKind(src.EndDate, DateTimeKind.Utc)));
            CreateMap<FinancialYear, FinancialYearUpdateModel>().ReverseMap()
               .ForMember(dest => dest.StartDate, opt =>
                   opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
               .ForMember(dest => dest.EndDate, opt =>
                   opt.MapFrom(src => DateTime.SpecifyKind(src.EndDate, DateTimeKind.Utc)));
            /*-----------------------------------------Admin----------------------------------------------*/
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Company, CompanyUpdateModel>().ReverseMap();
            CreateMap<UserBranch, UserBranchModel>().ReverseMap();
            CreateMap<UserBranch, UserBranchUpdateModel>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupModel>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupUpdateModel>().ReverseMap();
            CreateMap<ProductSubGroup, ProductSubGroup>().ReverseMap();
            CreateMap<Unit, UnitModel>().ReverseMap();
            CreateMap<Unit, UnitUpdateModel>().ReverseMap();
            CreateMap<AlternateUnit, AlternateUnitModel>().ReverseMap();
            CreateMap<AlternateUnit, AlternateUnitUpdateModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Product, ProductUpdateModel>().ReverseMap();
            CreateMap<LabourRate, LabourRateModel>().ReverseMap();
            CreateMap<LabourRate, LabourRateUpdateModel>().ReverseMap();
            CreateMap<ProductionOrderSetup, ProductionOrderSetupModel>().ReverseMap();
            CreateMap<ProductionOrderSetup, ProductionOrderSetupUpdateModel>().ReverseMap();
            CreateMap<ProductionTransactionSetup, ProductionTransactionSetUpModel>().ReverseMap();
            CreateMap<ProductionTransactionSetup, ProductionTransactionSetUpUpdateModel>().ReverseMap();
            CreateMap<SalesOrderSetup, SalesOrderSetupModel>().ReverseMap();
            CreateMap<SalesOrderSetup, SalesOrderSetupUpdateModel>().ReverseMap();
            CreateMap<SalesTransactionSetup, SalesTransactionSetupModel>().ReverseMap();
            CreateMap<SalesTransactionSetup, SalesTransactionSetupUpdateModel>().ReverseMap();
            CreateMap<LedgerSubGroup, LedgerSubGroupModel>().ReverseMap();
            CreateMap<LedgerSubGroup, LedgerSubGroupUpdateModel>().ReverseMap();
            CreateMap<LedgerSubGroupDev, LedgerSubGroupDevModel>().ReverseMap();
            CreateMap<LedgerSubGroupDev, LedgerSubGroupDevUpdateModel>().ReverseMap();
            CreateMap<Ledger, LedgerModel>().ReverseMap();
            CreateMap<Ledger, LedgerUpdateModel>().ReverseMap();
            /*-----------------------------------------Common----------------------------------------------*/
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.StateName))
                .ForMember(dest => dest.DistName, opt => opt.MapFrom(src => src.Dist.DistName))
                .ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Address, AddressUpdateModel>().ReverseMap();
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Country, CountryUpdateModel>().ReverseMap();
            CreateMap<State, StateModel>().ReverseMap();
            CreateMap<State, StateUpdateModel>().ReverseMap();
            CreateMap<Dist, DistModel>().ReverseMap();
            CreateMap<Dist, DistUpdateModel>().ReverseMap();
            /*-----------------------------------------Master----------------------------------------------*/
            CreateMap<Stock, StockModel>().ReverseMap();
            CreateMap<Stock, StockUpdateModel>().ReverseMap();
            CreateMap<Labour, LabourModel>().ReverseMap();
            CreateMap<Labour, LabourUpdateModel>().ReverseMap();
            CreateMap<Party, PartyModel>().ReverseMap();
            CreateMap<Party, PartyUpdateModel>().ReverseMap();
            CreateMap<LedgerBalance, LedgerBalanceModel>().ReverseMap();
            CreateMap<LedgerBalance, LedgerBalanceUpdateModel>().ReverseMap();
            CreateMap<SubLedger, SubLedgerModel>().ReverseMap();
            CreateMap<SubLedger, SubLedgerUpdateModel>().ReverseMap();
            CreateMap<SubLedgerBalance, SubLedgerBalanceModel>().ReverseMap();
            CreateMap<SubLedgerBalance, SubLedgerBalanceUpdateModel>().ReverseMap();
            /*-----------------------------------------Transaction----------------------------------------------*/
            CreateMap<InwardSupplyOrder, InwardSupplyOrderModel>().ReverseMap();
            CreateMap<InwardSupplyOrder, InwardSupplyOrderUpdateModel>().ReverseMap();
            CreateMap<InwardSupplyTransaction, InwardSupplyTransactionModel>().ReverseMap();
            CreateMap<InwardSupplyTransaction, InwardSupplyTransactionUpdateModel>().ReverseMap();
            CreateMap<OutwardSupplyOrder, OutwardSupplyOrderModel>().ReverseMap();
            CreateMap<OutwardSupplyOrder, OutwardSupplyOrderUpdateModel>().ReverseMap();
            CreateMap<OutwardSupplyTransaction, OutwardSupplyTransactionModel>().ReverseMap();
            CreateMap<OutwardSupplyTransaction, OutwardSupplyTransactionUpdateModel>().ReverseMap();
            CreateMap<ProductionOrder, ProductionOrderModel>().ReverseMap();
            CreateMap<ProductionOrder, ProductionOrderUpdateModel>().ReverseMap();
            CreateMap<ProductionTransaction, ProductionTransactionModel>().ReverseMap();
            CreateMap<ProductionTransaction, ProductionTransactionUpdateModel>().ReverseMap();
            CreateMap<DamageOrder, DamageOrderModel>().ReverseMap();
            CreateMap<DamageOrder, DamageOrderUpdateModel>().ReverseMap();
            CreateMap<DamageTransaction, DamageTransactionModel>().ReverseMap();
            CreateMap<DamageTransaction, DamageTransactionUpdateModel>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderModel>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderUpdateModel>().ReverseMap();
            CreateMap<PurchaseTransaction, PurchaseTransactionModel>().ReverseMap();
            CreateMap<PurchaseTransaction, PurchaseTransactionUpdateModel>().ReverseMap();
            CreateMap<PurchaseReturnOrder, PurchaseReturnOrderModel>().ReverseMap();
            CreateMap<PurchaseReturnOrder, PurchaseReturnOrderUpdateModel>().ReverseMap();
            CreateMap<PurchaseReturnTransaction, PurchaseReturnTransactionModel>().ReverseMap();
            CreateMap<PurchaseReturnTransaction, PurchaseReturnTransactionUpdateModel>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderModel>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderUpdateModel>().ReverseMap();
            CreateMap<SalesTransaction, SalesTransactionModel>().ReverseMap();
            CreateMap<SalesTransaction, SalesTransactionUpdateModel>().ReverseMap();
            CreateMap<SalesReturnOrder, SalesReturnOrderModel>().ReverseMap();
            CreateMap<SalesReturnOrder, SalesReturnOrderUpdateModel>().ReverseMap();
            CreateMap<SalesReturnTransaction, SalesReturnTransactionModel>().ReverseMap();
            CreateMap<SalesReturnTransaction, SalesReturnTransactionUpdateModel>().ReverseMap();
            /*-----------------------------------------Accounting----------------------------------------------*/
            CreateMap<JournalOrder, JournalOrderModel>().ReverseMap();
            CreateMap<JournalOrder, JournalOrderUpdateModel>().ReverseMap();
            CreateMap<JournalTransaction, JournalTransactionModel>().ReverseMap();
            CreateMap<JournalTransaction, JournalTransactionUpdateModel>().ReverseMap();
            CreateMap<PaymentOrder, PaymentOrderModel>().ReverseMap();
            CreateMap<PaymentOrder, PaymentOrderUpdateModel>().ReverseMap();
            CreateMap<PaymentTransaction, PaymentTransactionModel>().ReverseMap();
            CreateMap<PaymentTransaction, PaymentTransactionUpdateModel>().ReverseMap();
            CreateMap<ReceiptOrder, ReceiptOrderModel>().ReverseMap();
            CreateMap<ReceiptOrder, ReceiptOrderUpdateModel>().ReverseMap();
            CreateMap<ReceiptTransaction, ReceiptTransactionModel>().ReverseMap();
            CreateMap<ReceiptTransaction, ReceiptTransactionUpdateModel>().ReverseMap();
        }
    }
}
