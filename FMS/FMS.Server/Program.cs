using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FMS.Db;
using FMS.Db.CustomVaidator;
using FMS.Db.Entity;
using FMS.Model.Email;
using FMS.Model.SMS;
using FMS.Repo;
using FMS.Repo.Account.Authentication;
using FMS.Repo.Account.AutherIzation;
using FMS.Repo.Account.User;
using FMS.Repo.Accounting.Journal;
using FMS.Repo.Accounting.Payment;
using FMS.Repo.Accounting.Receipt;
using FMS.Repo.Admin.Company;
using FMS.Repo.Admin.LabourRate;
using FMS.Repo.Admin.Product;
using FMS.Repo.Admin.Production;
using FMS.Repo.Admin.Sales;
using FMS.Repo.Admin.Token;
using FMS.Repo.Admin.UserBranch;
using FMS.Repo.Common.Address;
using FMS.Repo.Common.Country;
using FMS.Repo.Common.Dist;
using FMS.Repo.Common.State;
using FMS.Repo.Devloper.Branch;
using FMS.Repo.Devloper.FinancialYear;
using FMS.Repo.Transaction.Damage;
using FMS.Repo.Transaction.InwardSupply;
using FMS.Repo.Transaction.OutwardSupply;
using FMS.Repo.Transaction.Purchase;
using FMS.Repo.Transaction.PurchaseReturn;
using FMS.Repo.Transaction.SalesReturn;
using FMS.Repo.Transaction.ServiceLabour;
using FMS.Repo.User.Labour;
using FMS.Repo.User.LedgerBalance;
using FMS.Repo.User.Party;
using FMS.Repo.User.Stock;
using FMS.Repo.User.SubLedger;
using FMS.Repo.User.SubLedgerBalance;
using FMS.Svcs.Account.Authentication;
using FMS.Svcs.Account.Autherization;
using FMS.Svcs.Account.User;
using FMS.Svcs.Accounting.Journal;
using FMS.Svcs.Accounting.Payment;
using FMS.Svcs.Accounting.Receipt;
using FMS.Svcs.Admin.Company;
using FMS.Svcs.Admin.LabourRate;
using FMS.Svcs.Admin.Product;
using FMS.Svcs.Admin.Production;
using FMS.Svcs.Admin.Sales;
using FMS.Svcs.Admin.Token;
using FMS.Svcs.Admin.UserBranch;
using FMS.Svcs.Common.Address;
using FMS.Svcs.Common.Country;
using FMS.Svcs.Common.Dist;
using FMS.Svcs.Common.State;
using FMS.Svcs.Devloper.Branch;
using FMS.Svcs.Devloper.FinancialYear;
using FMS.Svcs.Email;
using FMS.Svcs.SMS;
using FMS.Svcs.Transaction.Damage;
using FMS.Svcs.Transaction.InwardSupply;
using FMS.Svcs.Transaction.OutwardSupply;
using FMS.Svcs.Transaction.Purchase;
using FMS.Svcs.Transaction.PurchaseReturn;
using FMS.Svcs.Transaction.SalesReturn;
using FMS.Svcs.Transaction.ServiceLabour;
using FMS.Svcs.User.Labour;
using FMS.Svcs.User.LedgerBalance;
using FMS.Svcs.User.Party;
using FMS.Svcs.User.Stock;
using FMS.Svcs.User.Subledger;
using FMS.Svcs.User.SubLedgerBalance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
);
builder.Services.AddEndpointsApiExplorer();
//***************************************************Add Connection to Db**************************************//
builder.Services.AddDbContext<Context>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("DBCS");
    option.UseNpgsql(connectionString, pgSqlAction =>
    {
        pgSqlAction.CommandTimeout(30);
    })
    .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
    .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

//****************************************************Email & SMS setup************************************************//
builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));
builder.Services.Configure<SmsConfigModel>(builder.Configuration.GetSection("TwilioSMS"));
builder.Services.AddScoped<IEmailSvcs, EmailSvcs>();
builder.Services.AddScoped<ISmsSvcs, SmsSvcs>();
//*************************************************Dependancy Injection***************************************// 
builder.Services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();
builder.Services.AddScoped<IAuthenticationSvcs, AuthenticationSvcs>();
builder.Services.AddScoped<IAutherizationRepo, AutherizationRepo>();
builder.Services.AddScoped<IAutherizationSvcs, AutherizationSvcs>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserSvcs, UserSvcs>();
//Devloper
builder.Services.AddScoped<IBranchSvcs, BranchSvcs>();
builder.Services.AddScoped<IBranchRepo, BranchRepo>();
builder.Services.AddScoped<IFinancialYearSvcs, FinancialYearSvcs>();
builder.Services.AddScoped<IFinancialYearRepo, FinancialYearRepo>();
//Admin
builder.Services.AddScoped<ITokenSvcs, TokenSvcs>();
builder.Services.AddScoped<ITokenRepo, TokenRepo>();
builder.Services.AddScoped<ICompanySvcs, CompanySvcs>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
builder.Services.AddScoped<IUserBranchSvcs, UserBranchSvcs>();
builder.Services.AddScoped<IUserBranchRepo, UserBranchRepo>();
builder.Services.AddScoped<IProductSvcs, ProductSvcs>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductionSvcs, ProductionSvcs>();
builder.Services.AddScoped<IProductionRepo, ProductionRepo>();
builder.Services.AddScoped<ILabourRateSvcs, LabourRateSvcs>();
builder.Services.AddScoped<ILabourRateRepo, LabourRateRepo>();
builder.Services.AddScoped<ISalesSvcs, SalesSvcs>();
builder.Services.AddScoped<ISalesRepo, SalesRepo>();
builder.Services.AddScoped<FMS.Svcs.Admin.Accounting.IAccountingSvcs, FMS.Svcs.Admin.Accounting.AccountingSvcs>();
builder.Services.AddScoped<FMS.Repo.Admin.Accounting.IAccountingRepo, FMS.Repo.Admin.Accounting.AccountingRepo>();
//User
builder.Services.AddScoped<IStockSvcs, StockSvcs>();
builder.Services.AddScoped<IStockRepo, StockRepo>();
builder.Services.AddScoped<ILabourSvcs, LabourSvcs>();
builder.Services.AddScoped<ILabourRepo, LabourRepo>();
builder.Services.AddScoped<IPartySvcs, PartySvcs>();
builder.Services.AddScoped<IPartyRepo, PartyRepo>();
builder.Services.AddScoped<ILedgerBalanceSvcs, LedgerBalanceSvcs>();
builder.Services.AddScoped<ILedgerBalanceRepo, LedgerBalanceRepo>();
builder.Services.AddScoped<ISubledgerSvcs, SubledgerSvcs>();
builder.Services.AddScoped<ISubLedgerRepo, SubLedgerRepo>();
builder.Services.AddScoped<ISubLedgerBalanceSvcs, SubLedgerBalanceSvcs>();
builder.Services.AddScoped<ISubLedgerBalanceRepo, SubLedgerBalanceRepo>();
//Transaction
builder.Services.AddScoped<IPurchaseSvcs, PurchaseSvcs>();
builder.Services.AddScoped<IPurchaseRepo, PurchaseRepo>();
builder.Services.AddScoped<IPurchaseReturnSvcs, PurchaseReturnSvcs>();
builder.Services.AddScoped<IPurchaseReturnRepo, PurchaseReturnRepo>();
builder.Services.AddScoped<IProductionSvcs, ProductionSvcs>();
builder.Services.AddScoped<IProductionRepo, ProductionRepo>();
builder.Services.AddScoped<IServiceLabourSvcs, ServiceLabourSvcs>();
builder.Services.AddScoped<IServiceLabourRepo, ServiceLabourRepo>();
builder.Services.AddScoped<ISalesSvcs, SalesSvcs>();
builder.Services.AddScoped<ISalesRepo, SalesRepo>();
builder.Services.AddScoped<ISalesReturnSvcs, SalesReturnSvcs>();
builder.Services.AddScoped<ISalesReturnRepo, SalesReturnRepo>();
builder.Services.AddScoped<IInwardSupplySvcs, InwardSupplySvcs>();
builder.Services.AddScoped<IInwardSupplyRepo, InwardSupplyRepo>();
builder.Services.AddScoped<IOutwardSupplySvcs, OutwardSupplySvcs>();
builder.Services.AddScoped<IOutwardSupplyRepo, OutwardSupplyRepo>();
builder.Services.AddScoped<IDamageSvcs, DamageSvcs>();
builder.Services.AddScoped<IDamageRepo, DamageRepo>();
//Accounting
builder.Services.AddScoped<IJournalSvcs, JournalSvcs>();
builder.Services.AddScoped<IJournalRepo, JournalRepo>();
builder.Services.AddScoped<IPaymentSvcs, PaymentSvcs>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IReceiptSvcs, ReceiptSvcs>();
builder.Services.AddScoped<IReceiptRepo, ReceiptRepo>();
//common
builder.Services.AddScoped<IAddressSvcs, AddressSvcs>();
builder.Services.AddScoped<IAddressRepo, AddressRepo>();
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<ICountrySvcs, CountrySvcs>();
builder.Services.AddScoped<IStateRepo, StateRepo>();
builder.Services.AddScoped<IStateSvcs, StateSvcs>();
builder.Services.AddScoped<IDistRepo, DistRepo>();
builder.Services.AddScoped<IDistSvcs, DistSvcs>();
//**************************************************** Model Validation ************************************************//
// Register FluentValidation services
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddScoped<CustomValidation>();
// Register Validators
builder.Services.AddScoped<RegisterTokenValidator>();
builder.Services.AddScoped<UserValidator>();
builder.Services.AddScoped<UserUpdateValidator>();
builder.Services.AddScoped<AddressValidator>();
builder.Services.AddScoped<AddressUpdateValidator>();
builder.Services.AddScoped<AlternateUnitValidator>();
builder.Services.AddScoped<AlternateUnitUpdateValidator>();
builder.Services.AddScoped<BranchValidator>();
builder.Services.AddScoped<BranchUpdateValidator>();
builder.Services.AddScoped<CompanyValidator>();
builder.Services.AddScoped<CompanyUpdateValidator>();
builder.Services.AddScoped<CountryValidator>();
builder.Services.AddScoped<CountryUpdateValidator>();
builder.Services.AddScoped<DamageOrderValidator>();
builder.Services.AddScoped<DamageOrderUpdateValidator>();
builder.Services.AddScoped<DamageTransactionValidator>();
builder.Services.AddScoped<DamageTransactionUpdateValidator>();
builder.Services.AddScoped<DistValidator>();
builder.Services.AddScoped<DistUpdateValidator>();
builder.Services.AddScoped<FinancialYearValidator>();
builder.Services.AddScoped<FinancialYearUpdateValidator>();
builder.Services.AddScoped<InwardSupplyOrderValidator>();
builder.Services.AddScoped<InwardSupplyOrderUpdateValidator>();
builder.Services.AddScoped<InwardSupplyTransactionValidator>();
builder.Services.AddScoped<InwardSupplyTransactionUpdateValidator>();
builder.Services.AddScoped<JournalOrderValidator>();
builder.Services.AddScoped<JournalOrderUpdateValidator>();
builder.Services.AddScoped<JournalTransactionValidator>();
builder.Services.AddScoped<JournalTransactionUpdateValidator>();
builder.Services.AddScoped<LabourValidator>();
builder.Services.AddScoped<LabourUpdateValidator>();
builder.Services.AddScoped<LabourRateValidator>();
builder.Services.AddScoped<LabourRateUpdateValidator>();
builder.Services.AddScoped<LedgerValidator>();
builder.Services.AddScoped<LedgerUpdateValidator>();
builder.Services.AddScoped<LedgerBalanceValidator>();
builder.Services.AddScoped<LedgerBalanceUpdateValidator>();
builder.Services.AddScoped<LedgerSubGroupValidator>();
builder.Services.AddScoped<LedgerSubGroupUpdateValidator>();
builder.Services.AddScoped<LedgerSubGroupDevValidator>();
builder.Services.AddScoped<LedgerSubGroupDevUpdateValidator>();
builder.Services.AddScoped<OutwardSupplyOrderValidator>();
builder.Services.AddScoped<OutwardSupplyOrderUpdateValidator>();
builder.Services.AddScoped<OutwardSupplyTransactionValidator>();
builder.Services.AddScoped<OutwardSupplyTransactionUpdateValidator>();
builder.Services.AddScoped<PartyValidator>();
builder.Services.AddScoped<PartyUpdateValidator>();
builder.Services.AddScoped<PaymentOrderValidator>();
builder.Services.AddScoped<PaymentOrderUpdateValidator>();
builder.Services.AddScoped<PaymentTransactionValidator>();
builder.Services.AddScoped<PaymentTransactionUpdateValidator>();
builder.Services.AddScoped<ProductValidator>();
builder.Services.AddScoped<ProductUpdateValidator>();
builder.Services.AddScoped<ProductGroupValidator>();
builder.Services.AddScoped<ProductGroupUpdateValidator>();
builder.Services.AddScoped<ProductionOrderValidator>();
builder.Services.AddScoped<ProductionOrderUpdateValidator>();
builder.Services.AddScoped<ProductionTransactionValidator>();
builder.Services.AddScoped<ProductionTransactionUpdateValidator>();
builder.Services.AddScoped<ProductionTransactionSetupValidator>();
builder.Services.AddScoped<ProductionTransactionSetupUpdateValidator>();
builder.Services.AddScoped<ProductSubGroupValidator>();
builder.Services.AddScoped<ProductSubGroupUpdateValidator>();
builder.Services.AddScoped<PurchaseOrderValidator>();
builder.Services.AddScoped<PurchaseOrderUpdateValidator>();
builder.Services.AddScoped<PurchaseReturnOrderValidator>();
builder.Services.AddScoped<PurchaseReturnOrderUpdateValidator>();
builder.Services.AddScoped<PurchaseReturnTransactionValidator>();
builder.Services.AddScoped<PurchaseReturnTransactionUpdateValidator>();
builder.Services.AddScoped<PurchaseTransactionValidator>();
builder.Services.AddScoped<PurchaseTransactionUpdateValidator>();
builder.Services.AddScoped<ReceiptOrderValidator>();
builder.Services.AddScoped<ReceiptOrderUpdateValidator>();
builder.Services.AddScoped<ReceiptTransactionValidator>();
builder.Services.AddScoped<ReceiptTransactionUpdateValidator>();
builder.Services.AddScoped<SalesOrderValidator>();
builder.Services.AddScoped<SalesOrderUpdateValidator>();
builder.Services.AddScoped<SalesReturnOrderValidator>();
builder.Services.AddScoped<SalesReturnOrderUpdateValidator>();
builder.Services.AddScoped<SalesReturnTransactionValidator>();
builder.Services.AddScoped<SalesReturnTransactionUpdateValidator>();
builder.Services.AddScoped<SalesTransactionValidator>();
builder.Services.AddScoped<SalesTransactionUpdateValidator>();
builder.Services.AddScoped<SalesTransactionSetupValidator>();
builder.Services.AddScoped<SalesTransactionSetupUpdateValidator>();
builder.Services.AddScoped<StateValidator>();
builder.Services.AddScoped<StateUpdateValidator>();
builder.Services.AddScoped<StockValidator>();
builder.Services.AddScoped<StockUpdateValidator>();
builder.Services.AddScoped<SubLedgerBalanceValidator>();
builder.Services.AddScoped<SubLedgerBalanceUpdateValidator>();
builder.Services.AddScoped<UnitValidator>();
builder.Services.AddScoped<UnitUpdateValidator>();
//*****************************************************AutoMapper*****************************************//
var automapper = new MapperConfiguration(option => option.AddProfile(new MappingProfile()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);
//*******************************************************Identity***********************************************//
builder.Services.AddIdentity<AppUser, AppRole>(
    options =>
    {
        #region Password
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        #endregion
        #region login attempt
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        #endregion
        #region email conformation
        options.SignIn.RequireConfirmedEmail = true;
        #endregion
    }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
//********************************************Authentication***************************************************//
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration.GetSection("Google:client_id").Value;
    options.ClientSecret = builder.Configuration.GetSection("Google:client_secret").Value; ;
});
//********************************************Autherization Policy***************************************************//
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Create", policy =>
    {
        policy.RequireClaim("Create", "Create");
    });
    options.AddPolicy("Update", policy =>
    {
        policy.RequireClaim("Update", "Update");
    });
    options.AddPolicy("Delete", policy =>
    {
        policy.RequireClaim("Delete", "Delete");
    });
});
//*******************************************************Caching******************************************************//
builder.Services.AddStackExchangeRedisCache(options => 
{ 
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    //options.InstanceName = "SampleInstance";
});
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("Redis");
    return ConnectionMultiplexer.Connect(connectionString);
});
builder.Services.AddSingleton<IRedisCache, RedisCache>();
//*********************************************************************************************************************//

builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Description = "Jwt Autentication"
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });
//******************************************************************************************************************************************//
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
  //  app.MigrateDatabase<Context>();
    app.UseDeveloperExceptionPage();
}
//app.UseExceptionHandler();
//app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
