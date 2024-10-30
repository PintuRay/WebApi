using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FMS.Db;
using FMS.Db.CustomVaidator;
using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Model.Email;
using FMS.Model.SMS;
using FMS.Repo;
using FMS.Repo.Account.Authentication;
using FMS.Repo.Account.AutherIzation;
using FMS.Repo.Accounting;
using FMS.Repo.Admin;
using FMS.Repo.Devloper;
using FMS.Repo.Transaction;
using FMS.Repo.User;
using FMS.Svcs.Account.Authentication;
using FMS.Svcs.Account.Autherization;
using FMS.Svcs.Accounting;
using FMS.Svcs.Admin;
using FMS.Svcs.Devloper;
using FMS.Svcs.Email;
using FMS.Svcs.SMS;
using FMS.Svcs.Transaction;
using FMS.Svcs.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
);
builder.Services.AddEndpointsApiExplorer();
//***************************************************Add Connection to Db**************************************//
builder.Services.AddDbContext<Context>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DBCS"))
.EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
);
//****************************************************Email & SMS setup************************************************//
builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));
builder.Services.Configure<SmsConfigModel>(builder.Configuration.GetSection("TwilioSMS"));
builder.Services.AddScoped<IEmailSvcs, EmailSvcs>();
builder.Services.AddScoped<ISmsSvcs, SmsSvcs>();
//**************************************************** Model Validation ************************************************//
// Register FluentValidation services
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<CustomValidation>();
// Register your validators
builder.Services.AddTransient<IValidator<RegisterTokenModel>, RegisterTokenValidator>();
builder.Services.AddTransient<IValidator<RegisterModel>, RegisterValidator>();
//*************************************************Dependancy Injection***************************************// 
builder.Services.AddScoped<IAuthentication, AuthenticationRepo>();
builder.Services.AddScoped<IAuthenticationSvcs, AuthenticationSvcs>();
builder.Services.AddScoped<IAutherizationRepo, AutherizationRepo>();
builder.Services.AddScoped<IAutherizationSvcs, AutherizationSvcs>();
builder.Services.AddScoped<IDevloperSvcs, DevloperSvcs>();
builder.Services.AddScoped<IDevloperRepo, DevloperRepo>();
builder.Services.AddScoped<IAdminSvcs, AdminSvcs>();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IUserSvcs, UserSvcs>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ITransactionSvcs, TransactionSvcs>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<IAccountingSvcs, AccountingSvcs>();
builder.Services.AddScoped<IAccountingRepo, AccountingRepo>();
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
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICustomCache, CustomCache>();
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
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
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
