using AutoMapper;
using FMS.Db.Entity;
namespace FMS.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<AppUser, UserModel>();
            CreateMap<UserModel, AppUser>().ForMember(dest => dest.Address, opt => opt.Ignore());
            CreateMap<AppUser, UserUpdateModel>();
            CreateMap<UserUpdateModel, AppUser>().ForMember(dest => dest.Address, opt => opt.Ignore());
            #endregion
            /*--------------------------------------------Devloper---------------------------------------------------*/
            #region Branch
            CreateMap<BranchDto, Branch>().ReverseMap();
            CreateMap<BranchModel, Branch>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            CreateMap<BranchUpdateModel, Branch>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            #endregion
            #region FinancialYear
            CreateMap<FinancialYear, FinancialYearDto>().ReverseMap();
            CreateMap<FinancialYearModel, FinancialYear>()
                .ForMember(dest => dest.StartDate, opt =>
                    opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.EndDate, opt =>
                    opt.MapFrom(src => DateTime.SpecifyKind(src.EndDate, DateTimeKind.Utc)));
            CreateMap<FinancialYearUpdateModel, FinancialYear>()
               .ForMember(dest => dest.StartDate, opt =>
                   opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
               .ForMember(dest => dest.EndDate, opt =>
                   opt.MapFrom(src => DateTime.SpecifyKind(src.EndDate, DateTimeKind.Utc)));
            #endregion
            /*-----------------------------------------Admin----------------------------------------------*/
            CreateMap<RegisterToken, RegisterTokenModel>().ReverseMap();
            #region Company
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyModel, Company>();
            CreateMap<CompanyUpdateModel, Company>();
            #endregion
            #region UserBranch
            CreateMap<UserBranch, UserBranchDto>().ReverseMap();
            CreateMap<UserBranchModel, UserBranch>();
            CreateMap<UserBranchUpdateModel, UserBranch>();
            #endregion
            #region ProductGroup
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<ProductGroupModel, ProductGroup>();
            CreateMap<ProductGroupUpdateModel, ProductGroup>();
            #endregion
            #region ProductSubGroup
            CreateMap<ProductSubGroup, ProductSubGroupDto>().ReverseMap();
            CreateMap<ProductSubGroupModel, ProductSubGroup>();
            CreateMap<ProductSubGroupUpdateModel, ProductSubGroup>();
            #endregion
            #region Unit
            CreateMap<Unit, UnitDto>().ReverseMap();
            CreateMap<UnitModel, Unit>();
            CreateMap<UnitUpdateModel, Unit>();
            #endregion
            #region AlternateUnit
            CreateMap<AlternateUnit, AlternateUnitDto>().ReverseMap();
            CreateMap<AlternateUnitModel, AlternateUnit>();
            CreateMap<AlternateUnitUpdateModel, AlternateUnit>();
            #endregion
            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductModel, Product>();
            CreateMap<ProductUpdateModel, Product>();
            #endregion
            #region LabourRate
            CreateMap<LabourRate, LabourRateDto>().ReverseMap();
            CreateMap<LabourRateModel, LabourRate>();
            CreateMap<LabourRateUpdateModel, LabourRate>();
            #endregion
            #region ProductionOrderSetup
            CreateMap<ProductionOrderSetup, ProductionOrderSetupDto>().ReverseMap();
            CreateMap<ProductionOrderSetupModel, ProductionOrderSetup>();
            CreateMap<ProductionOrderSetupUpdateModel, ProductionOrderSetup>();
            #endregion
            #region ProductionTransactionSetup
            CreateMap<ProductionTransactionSetup, ProductionTransactionSetupDto>().ReverseMap();
            CreateMap<ProductionTransactionSetUpUpdateModel, ProductionTransactionSetup>();
            CreateMap<ProductionTransactionSetUpUpdateModel, ProductionTransactionSetup>();
            #endregion
            #region SalesOrderSetup
            CreateMap<SalesOrderSetup, SalesOrderSetupDto>().ReverseMap();
            CreateMap<SalesOrderSetupModel, SalesOrderSetup>();
            CreateMap<SalesOrderSetupUpdateModel, SalesOrderSetup>();
            #endregion
            #region SalesTransactionSetup
            CreateMap<SalesTransactionSetup, SalesTransactionSetupDto>().ReverseMap();
            CreateMap<SalesTransactionSetupModel, SalesTransactionSetup>();
            CreateMap<SalesTransactionSetupUpdateModel, SalesTransactionSetup>();
            #endregion
            #region LedgerSubGroup
            CreateMap<LedgerSubGroup, LedgerSubGroupDto>().ReverseMap();
            CreateMap<LedgerSubGroupModel, LedgerSubGroup>();
            CreateMap<LedgerSubGroupUpdateModel, LedgerSubGroup>();
            #endregion
            #region LedgerSubGroupDev
            CreateMap<LedgerSubGroupDev, LedgerSubGroupDevDto>().ReverseMap();
            CreateMap<LedgerSubGroupDevModel, LedgerSubGroupDev>();
            CreateMap<LedgerSubGroupDevUpdateModel, LedgerSubGroupDev>();
            #endregion
            #region Ledger
            CreateMap<Ledger, LedgerDto>().ReverseMap();
            CreateMap<LedgerModel, Ledger>().ReverseMap();
            CreateMap<LedgerUpdateModel, Ledger>().ReverseMap();
            #endregion
            /*-----------------------------------------Common----------------------------------------------*/
            #region Address
            CreateMap<AddressModel, Address>().ReverseMap();
            CreateMap<AddressUpdateModel, Address>();
            CreateMap<Address, AddressDto>()
               .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
               .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.StateName))
               .ForMember(dest => dest.DistName, opt => opt.MapFrom(src => src.Dist.DistName))
               .ReverseMap();
            #endregion
            #region Country
            CreateMap<Country,CountryDto>().ReverseMap();
            CreateMap<CountryModel, Country>();
            CreateMap<CountryUpdateModel, Country>();
            #endregion
            #region State
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<StateModel, State>();
            CreateMap<StateUpdateModel, State>();
            #endregion
            #region Dist
            CreateMap<Dist, DistDto>().ReverseMap();
            CreateMap<DistModel, Dist>();
            CreateMap<DistUpdateModel, Dist>();
            #endregion
            /*-----------------------------------------Master----------------------------------------------*/
            #region Stock 
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<StockModel, Stock>();
            CreateMap<StockUpdateModel, Stock>();
            #endregion
            #region Labour 
            CreateMap<LabourDto, Labour>().ReverseMap();
            CreateMap<LabourModel, Labour>();
            CreateMap<LabourUpdateModel, Labour>();
            #endregion
            #region Party 
            CreateMap<PartyDto, Party>().ReverseMap();
            CreateMap<PartyModel, Party>();
            CreateMap<PartyUpdateModel, Party>();
            #endregion
            #region  LedgerBalance 
            CreateMap<LedgerBalanceDto, LedgerBalance>().ReverseMap();
            CreateMap<LedgerBalanceModel, LedgerBalance>();
            CreateMap<LedgerBalanceUpdateModel, LedgerBalance>();
            #endregion
            #region SubLedger
            CreateMap<SubLedgerDto, SubLedger>().ReverseMap();
            CreateMap<SubLedgerModel, SubLedger>();
            CreateMap<SubLedgerUpdateModel, SubLedger>();
            #endregion
            #region SubLedgerBalance
            CreateMap<SubLedgerBalanceDto, SubLedgerBalance>().ReverseMap();
            CreateMap<SubLedgerBalanceModel, SubLedgerBalance>();
            CreateMap<SubLedgerBalanceUpdateModel, SubLedgerBalance>();
            #endregion
            /*-----------------------------------------Transaction----------------------------------------------*/
            #region InwardSupplyOrder
            CreateMap<InwardSupplyOrderDto, InwardSupplyOrder>().ReverseMap();
            CreateMap<InwardSupplyOrderModel, InwardSupplyOrder>();
            CreateMap<InwardSupplyOrderUpdateModel, InwardSupplyOrder>();
            #endregion
            #region InwardSupplyTransaction
            CreateMap<InwardSupplyTransactionDto, InwardSupplyTransaction>().ReverseMap();
            CreateMap<InwardSupplyTransactionModel, InwardSupplyTransaction>();
            CreateMap<InwardSupplyTransactionUpdateModel, InwardSupplyTransaction>();
            #endregion
            #region  OutwardSupplyOrder
            CreateMap<OutwardSupplyOrderDto, OutwardSupplyOrder>().ReverseMap();
            CreateMap<OutwardSupplyOrderModel, OutwardSupplyOrder>();
            CreateMap<OutwardSupplyOrderUpdateModel, OutwardSupplyOrder>();
            #endregion
            #region  OutwardSupplyTransaction
            CreateMap<OutwardSupplyTransactionDto, OutwardSupplyTransaction>().ReverseMap();
            CreateMap<OutwardSupplyTransactionModel, OutwardSupplyTransaction>();
            CreateMap<OutwardSupplyTransactionUpdateModel, OutwardSupplyTransaction>();
            #endregion
            #region ProductionOrder
            CreateMap<ProductionOrderDto, ProductionOrder>().ReverseMap();
            CreateMap<ProductionOrderModel, ProductionOrder>();
            CreateMap<ProductionOrderUpdateModel, ProductionOrder>();
            #endregion
            #region ProductionTransaction
            CreateMap<ProductionTransactionDto, ProductionTransaction>().ReverseMap();
            CreateMap<ProductionTransactionModel, ProductionTransaction>();
            CreateMap<ProductionTransactionUpdateModel, ProductionTransaction>();
            #endregion
            #region DamageOrder
            CreateMap<DamageOrderDto, DamageOrder>().ReverseMap();
            CreateMap<DamageOrderModel, DamageOrder>();
            CreateMap<DamageOrderUpdateModel, DamageOrder>();
            #endregion
            #region DamageTransaction
            CreateMap<DamageTransactionDto, DamageTransaction>().ReverseMap();
            CreateMap<DamageTransactionModel, DamageTransaction>();
            CreateMap<DamageTransactionUpdateModel, DamageTransaction>();
            #endregion
            #region  PurchaseOrder
            CreateMap<PurchaseOrderDto, PurchaseOrder>().ReverseMap();
            CreateMap<PurchaseOrderModel, PurchaseOrder>();
            CreateMap<PurchaseOrderUpdateModel, PurchaseOrder>();
            #endregion
            #region  PurchaseTransaction
            CreateMap<PurchaseTransactionDto, PurchaseTransaction>().ReverseMap();
            CreateMap<PurchaseTransactionModel, PurchaseTransaction>();
            CreateMap<PurchaseTransactionUpdateModel, PurchaseTransaction>();
            #endregion
            #region PurchaseReturnOrder
            CreateMap<PurchaseReturnOrderDto, PurchaseReturnOrder>().ReverseMap();
            CreateMap<PurchaseReturnOrderModel, PurchaseReturnOrder>();
            CreateMap<PurchaseReturnOrderUpdateModel, PurchaseReturnOrder>();
            #endregion
            #region PurchaseReturnTransaction
            CreateMap<PurchaseReturnTransactionDto, PurchaseReturnTransaction>().ReverseMap();
            CreateMap<PurchaseReturnTransactionModel, PurchaseReturnTransaction>();
            CreateMap<PurchaseReturnTransactionUpdateModel, PurchaseReturnTransaction>();
            #endregion
            #region SalesOrder
            CreateMap<SalesOrderDto, SalesOrder>().ReverseMap();
            CreateMap<SalesOrderModel, SalesOrder>();
            CreateMap<SalesOrderUpdateModel, SalesOrder>();
            #endregion
            #region SalesTransaction
            CreateMap<SalesTransactionDto, SalesTransaction>().ReverseMap();
            CreateMap<SalesTransactionModel, SalesTransaction>();
            CreateMap<SalesTransactionUpdateModel, SalesTransaction>();
            #endregion
            #region SalesReturnOrder
            CreateMap<SalesReturnOrderDto, SalesReturnOrder>().ReverseMap();
            CreateMap<SalesReturnOrderModel, SalesReturnOrder>();
            CreateMap<SalesReturnOrderUpdateModel, SalesReturnOrder>();
            #endregion
            #region SalesReturnTransaction
            CreateMap<SalesReturnTransactionDto, SalesReturnTransaction>().ReverseMap();
            CreateMap<SalesReturnTransactionModel, SalesReturnTransaction>();
            CreateMap<SalesReturnTransactionUpdateModel, SalesReturnTransaction>();
            #endregion
            /*-----------------------------------------Accounting----------------------------------------------*/
            #region JournalOrder 
            CreateMap<JournalOrderDto, JournalOrder>().ReverseMap();
            CreateMap<JournalOrderModel, JournalOrder>();
            CreateMap<JournalOrderUpdateModel, JournalOrder>();
            #endregion
            #region JournalTransaction 
            CreateMap<JournalTransactionDto, JournalTransaction>().ReverseMap();
            CreateMap<JournalTransactionModel, JournalTransaction>();
            CreateMap<JournalTransactionUpdateModel, JournalTransaction>();
            #endregion
            #region PaymentOrder
            CreateMap<PaymentOrderDto, PaymentOrder>().ReverseMap();
            CreateMap<PaymentOrderModel, PaymentOrder>();
            CreateMap<PaymentOrderUpdateModel, PaymentOrder>();
            #endregion
            #region PaymentTransaction
            CreateMap<PaymentTransactionDto, PaymentTransaction>().ReverseMap();
            CreateMap<PaymentTransactionModel, PaymentTransaction>();
            CreateMap<PaymentTransactionUpdateModel, PaymentTransaction>();
            #endregion
            #region ReceiptOrder
            CreateMap<ReceiptOrderDto, ReceiptOrder>().ReverseMap();
            CreateMap<ReceiptOrderModel, ReceiptOrder>();
            CreateMap<ReceiptOrderUpdateModel, ReceiptOrder>();
            #endregion
            #region ReceiptTransaction
            CreateMap<ReceiptTransactionDto, ReceiptTransaction>().ReverseMap();
            CreateMap<ReceiptTransactionModel, ReceiptTransaction>();
            CreateMap<ReceiptTransactionUpdateModel, ReceiptTransaction>();
            #endregion
        }
    }
}
