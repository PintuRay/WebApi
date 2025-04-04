﻿using EFCore.BulkExtensions;
using FMS.Db.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace FMS.Db
{
    public partial class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        private readonly BulkConfig _defaultBulkConfig;
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            _defaultBulkConfig = BulkConfigurationSetup.DefaultConfig;
        }
        #region Entity
        /*-------------------------------Account---------------------------------*/
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUserClaim> AppUserClaims { get; set; }
        /*-----------------------------Devloper------------------------------------*/
        public DbSet<Branch> Branches { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        /*-------------------------------Admin-------------------------------------*/
        public DbSet<RegisterToken> RegisterTokens { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductSubGroup> ProductSubGroups { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<AlternateUnit> AlternateUnits { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LabourRate> LabourRates { get; set; }
        public DbSet<ProductionOrderSetup> ProductionOrderSetups { get; set; }
        public DbSet<ProductionTransactionSetup> ProductionTransactionSetups { get; set; }
        public DbSet<SalesOrderSetup> SalesOrderSetups { get; set; }
        public DbSet<SalesTransactionSetup> SalesTransactionSetups { get; set; }
        public DbSet<LedgerGroup> LedgerGroups { get; set; }
        public DbSet<LedgerSubGroup> LedgerSubGroups { get; set; }
        public DbSet<LedgerSubGroupDev> LedgerSubGroupDevs { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<LedgerDev> LedgersDev { get; set; }
        /*---------------------------------Common-----------------------------*/
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Dist> Dists { get; set; }
        /*---------------------------------Master----------------------------------*/
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<LabourType> LabourTypes { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<LedgerBalance> LedgerBalances { get; set; }
        public DbSet<SubLedger> SubLedgers { get; set; }
        public DbSet<SubLedgerBalance> SubLedgerBalances { get; set; }
        /*--------------------------------Transaction-----------------------------------*/
        public DbSet<InwardSupplyOrder> InwardSupplyOrders { get; set; }
        public DbSet<InwardSupplyTransaction> InwardSupplyTransactions { get; set; }
        public DbSet<OutwardSupplyOrder> OutwardSupplyOrders { get; set; }
        public DbSet<OutwardSupplyTransaction> OutwardSupplyTransactions { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionTransaction> ProductionTransactions { get; set; }
        public DbSet<DamageOrder> DamageOrders { get; set; }
        public DbSet<DamageTransaction> DamageTransactions { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseTransaction> PurchaseTransactions { get; set; }
        public DbSet<PurchaseReturnOrder> PurchaseReturnOrders { get; set; }
        public DbSet<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<SalesReturnOrder> SalesReturnOrders { get; set; }
        public DbSet<SalesReturnTransaction> SalesReturnTransactions { get; set; }
        /*----------------------------------Accounting-------------------------------------*/
        public DbSet<JournalOrder> JournalOrders { get; set; }
        public DbSet<JournalTransaction> JournalTransactions { get; set; }
        public DbSet<PaymentOrder> PaymentOrders { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<ReceiptOrder> ReceiptOrders { get; set; }
        public DbSet<ReceiptTransaction> ReceiptTransactions { get; set; }

        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            #region EntityConfig
            /*---------------------------Account----------------------------------*/
            new AppUserConfig().Configure(modelBuilder.Entity<AppUser>());
            new AppRoleConfig().Configure(modelBuilder.Entity<AppRole>());
            new AppUserRoleConfig().Configure(modelBuilder.Entity<AppUserRole>());
            new AppUserClaimConfig().Configure(modelBuilder.Entity<AppUserClaim>());
            /*----------------------------Devloper-------------------------------*/
            new FinancialYearConfig().Configure(modelBuilder.Entity<FinancialYear>());
            new BranchConfig().Configure(modelBuilder.Entity<Branch>());
            /*----------------------------Admin-------------------------------*/
            new RegisterTokenConfig().Configure(modelBuilder.Entity<RegisterToken>());
            new CompanyConfig().Configure(modelBuilder.Entity<Company>());
            new UserBranchConfig().Configure(modelBuilder.Entity<UserBranch>());
            new ProductTypeConfig().Configure(modelBuilder.Entity<ProductType>());
            new ProductGroupConfig().Configure(modelBuilder.Entity<ProductGroup>());
            new ProductSubGroupConfig().Configure(modelBuilder.Entity<ProductSubGroup>());
            new UnitConfig().Configure(modelBuilder.Entity<Unit>());
            new AlternateUnitConfig().Configure(modelBuilder.Entity<AlternateUnit>());
            new ProductConfig().Configure(modelBuilder.Entity<Product>());
            new LabourRateConfig().Configure(modelBuilder.Entity<LabourRate>());
            new ProductionOrderSetupConfig().Configure(modelBuilder.Entity<ProductionOrderSetup>());
            new ProductionTransactionSetupConfig().Configure(modelBuilder.Entity<ProductionTransactionSetup>());
            new SalesOrderSetupConfig().Configure(modelBuilder.Entity<SalesOrderSetup>());
            new SalesTransactionSetupConfig().Configure(modelBuilder.Entity<SalesTransactionSetup>());
            new LedgerGroupConfig().Configure(modelBuilder.Entity<LedgerGroup>());
            new LedgerSubGroupConfig().Configure(modelBuilder.Entity<LedgerSubGroup>());
            new LedgerSubGroupDevConfig().Configure(modelBuilder.Entity<LedgerSubGroupDev>());
            new LedgerConfig().Configure(modelBuilder.Entity<Ledger>());
            new LedgersDevConfig().Configure(modelBuilder.Entity<LedgerDev>());
            /*----------------------------------Address-------------------------------------*/
            new AddressConfig().Configure(modelBuilder.Entity<Address>());
            new CountryConfig().Configure(modelBuilder.Entity<Country>());
            new StateConfig().Configure(modelBuilder.Entity<State>());
            new DistConfig().Configure(modelBuilder.Entity<Dist>());
            /*--------------------------------Master--------------------------------------*/
            new StockConfig().Configure(modelBuilder.Entity<Stock>());
            new LabourTypeConfig().Configure(modelBuilder.Entity<LabourType>());
            new LabourConfig().Configure(modelBuilder.Entity<Labour>());
            new PartyConfig().Configure(modelBuilder.Entity<Party>());
            new LedgerBalanceConfig().Configure(modelBuilder.Entity<LedgerBalance>());
            new SubLedgerConfig().Configure(modelBuilder.Entity<SubLedger>());
            new SubLedgerBalanceConfig().Configure(modelBuilder.Entity<SubLedgerBalance>());
            /*--------------------------------Transaction-----------------------------*/
            new InwardSupplyOrderConfig().Configure(modelBuilder.Entity<InwardSupplyOrder>());
            new InwardSupplyTransactionConfig().Configure(modelBuilder.Entity<InwardSupplyTransaction>());
            new OutwardSupplyOrderConfig().Configure(modelBuilder.Entity<OutwardSupplyOrder>());
            new OutwardSupplyTransactionConfig().Configure(modelBuilder.Entity<OutwardSupplyTransaction>());
            new ProductionOrderConfig().Configure(modelBuilder.Entity<ProductionOrder>());
            new LabourTransactionConfig().Configure(modelBuilder.Entity<ProductionTransaction>());
            new DamageOrderConfig().Configure(modelBuilder.Entity<DamageOrder>());
            new DamageTransactionConfig().Configure(modelBuilder.Entity<DamageTransaction>());
            new PurchaseOrderConfig().Configure(modelBuilder.Entity<PurchaseOrder>());
            new PurchaseTransactionConfig().Configure(modelBuilder.Entity<PurchaseTransaction>());
            new PurchaseReturnOrderConfig().Configure(modelBuilder.Entity<PurchaseReturnOrder>());
            new PurchaseReturnTransactionConfig().Configure(modelBuilder.Entity<PurchaseReturnTransaction>());
            new SalesOrderConfig().Configure(modelBuilder.Entity<SalesOrder>());
            new SalesTransactionConfig().Configure(modelBuilder.Entity<SalesTransaction>());
            new SalesReturnOrderConfig().Configure(modelBuilder.Entity<SalesReturnOrder>());
            new SalesReturnTransactionConfig().Configure(modelBuilder.Entity<SalesReturnTransaction>());
            /*-----------------------------------Accounting----------------------------------*/
            new JournalOrderConfig().Configure(modelBuilder.Entity<JournalOrder>());
            new JournalTransactionConfig().Configure(modelBuilder.Entity<JournalTransaction>());
            new PaymentOrderConfig().Configure(modelBuilder.Entity<PaymentOrder>());
            new PaymentTransactionConfig().Configure(modelBuilder.Entity<PaymentTransaction>());
            new ReceiptOrderConfig().Configure(modelBuilder.Entity<ReceiptOrder>());
            new ReceiptTransactionConfig().Configure(modelBuilder.Entity<ReceiptTransaction>());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}

