using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class MgInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "dbo",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "dbo",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYears",
                schema: "dbo",
                columns: table => new
                {
                    FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Financial_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYears", x => x.FinancialYearId);
                });

            migrationBuilder.CreateTable(
                name: "LabourTypes",
                schema: "dbo",
                columns: table => new
                {
                    LabourTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Labour_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourTypes", x => x.LabourTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerGroups",
                schema: "dbo",
                columns: table => new
                {
                    LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                schema: "dbo",
                columns: table => new
                {
                    ProductionOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_FinishedGoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.ProductionOrderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "dbo",
                columns: table => new
                {
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Product_Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RegisterTokens",
                schema: "dbo",
                columns: table => new
                {
                    TokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TokenValue = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTokens", x => x.TokenId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderSetups",
                schema: "dbo",
                columns: table => new
                {
                    SalesOrderSetupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_FinishedGoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderSetups", x => x.SalesOrderSetupId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "dbo",
                columns: table => new
                {
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "dbo",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_CounryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Country_Fk_CounryId",
                        column: x => x.Fk_CounryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchFinancialYears",
                schema: "dbo",
                columns: table => new
                {
                    BranchFinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchFinancialYears", x => x.BranchFinancialYearId);
                    table.ForeignKey(
                        name: "FK_BranchFinancialYears_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BranchFinancialYears_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalOrders",
                schema: "dbo",
                columns: table => new
                {
                    JournalOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VouvherNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalOrders", x => x.JournalOrderId);
                    table.ForeignKey(
                        name: "FK_JournalOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOrders",
                schema: "dbo",
                columns: table => new
                {
                    PaymentOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CashBank = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChequeNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChequeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CashBankLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VouvherNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DrCr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrders", x => x.PaymentOrderId);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptOrders",
                schema: "dbo",
                columns: table => new
                {
                    ReceiptOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VouvherNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChequeNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChequeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CashBank = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CashBankLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptOrders", x => x.ReceiptOrderId);
                    table.ForeignKey(
                        name: "FK_ReceiptOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LedgerSubGroupDevs",
                schema: "dbo",
                columns: table => new
                {
                    LedgerSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerSubGroupDevs", x => x.LedgerSubGroupId);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroupDevs_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroupDevs_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LedgerSubGroups",
                schema: "dbo",
                columns: table => new
                {
                    LedgerSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerSubGroups", x => x.LedgerSubGroupId);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroups_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroups_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTransactions",
                schema: "dbo",
                columns: table => new
                {
                    ProductionTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_ProductionOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_RawMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTransactions", x => x.ProductionTransactionId);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductionOrders_Fk_ProductionOrderId",
                        column: x => x.Fk_ProductionOrderId,
                        principalSchema: "dbo",
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InwardSupplyOrders",
                schema: "dbo",
                columns: table => new
                {
                    InwardSupplyOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FromBranch = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardSupplyOrders", x => x.InwardSupplyOrderId);
                    table.ForeignKey(
                        name: "FK_InwardSupplyOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InwardSupplyOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InwardSupplyOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutwardSupplyOrders",
                schema: "dbo",
                columns: table => new
                {
                    OutwardSupplyOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToBranch = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwardSupplyOrders", x => x.OutwardSupplyOrderId);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                schema: "dbo",
                columns: table => new
                {
                    ProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductGroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupId);
                    table.ForeignKey(
                        name: "FK_ProductGroups_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fk_TokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaratialStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermCondition = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_RegisterTokens_Fk_TokenId",
                        column: x => x.Fk_TokenId,
                        principalSchema: "dbo",
                        principalTable: "RegisterTokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTransactionSetups",
                schema: "dbo",
                columns: table => new
                {
                    SalesTransactionSetupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_SalesOrderSetupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubFinishedGoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTransactionSetups", x => x.SalesTransactionSetupId);
                    table.ForeignKey(
                        name: "FK_SalesTransactionSetups_SalesOrderSetups_Fk_SalesOrderSetupId",
                        column: x => x.Fk_SalesOrderSetupId,
                        principalSchema: "dbo",
                        principalTable: "SalesOrderSetups",
                        principalColumn: "SalesOrderSetupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "dbo",
                columns: table => new
                {
                    DistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.DistId);
                    table.ForeignKey(
                        name: "FK_Cities_Country_Fk_CountryId",
                        column: x => x.Fk_CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_States_Fk_StateId",
                        column: x => x.Fk_StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ledgersDev",
                schema: "dbo",
                columns: table => new
                {
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LedgerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LedgerType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HasSubLedger = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ledgersDev", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_ledgersDev_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId");
                    table.ForeignKey(
                        name: "FK_ledgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
                        column: x => x.Fk_LedgerSubGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerSubGroupDevs",
                        principalColumn: "LedgerSubGroupId");
                });

            migrationBuilder.CreateTable(
                name: "Ledgers",
                schema: "dbo",
                columns: table => new
                {
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LedgerType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HasSubLedger = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_Ledgers_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ledgers_LedgerSubGroups_Fk_LedgerSubGroupId",
                        column: x => x.Fk_LedgerSubGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerSubGroups",
                        principalColumn: "LedgerSubGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubGroups",
                schema: "dbo",
                columns: table => new
                {
                    ProductSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_ProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSubGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubGroups", x => x.ProductSubGroupId);
                    table.ForeignKey(
                        name: "FK_ProductSubGroups_ProductGroups_Fk_ProductGroupId",
                        column: x => x.Fk_ProductGroupId,
                        principalSchema: "dbo",
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBranches_AspNetUsers_Fk_UserId",
                        column: x => x.Fk_UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBranches_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_DistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    At = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Cities_Fk_DistId",
                        column: x => x.Fk_DistId,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Country_Fk_CountryId",
                        column: x => x.Fk_CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_States_Fk_StateId",
                        column: x => x.Fk_StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LedgerBalances",
                schema: "dbo",
                columns: table => new
                {
                    LedgerBalanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LedgerDevLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYear = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    OpeningBalanceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RunningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    RunningBalanceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerBalances", x => x.LedgerBalanceId);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_FinancialYears_Fk_FinancialYear",
                        column: x => x.Fk_FinancialYear,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "dbo",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId");
                    table.ForeignKey(
                        name: "FK_LedgerBalances_ledgersDev_LedgerDevLedgerId",
                        column: x => x.LedgerDevLedgerId,
                        principalSchema: "dbo",
                        principalTable: "ledgersDev",
                        principalColumn: "LedgerId");
                });

            migrationBuilder.CreateTable(
                name: "SubLedgers",
                schema: "dbo",
                columns: table => new
                {
                    SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LedgerDevLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubLedgerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgers", x => x.SubLedgerId);
                    table.ForeignKey(
                        name: "FK_SubLedgers_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubLedgers_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "dbo",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId");
                    table.ForeignKey(
                        name: "FK_SubLedgers_ledgersDev_LedgerDevLedgerId",
                        column: x => x.LedgerDevLedgerId,
                        principalSchema: "dbo",
                        principalTable: "ledgersDev",
                        principalColumn: "LedgerId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    WholeSalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GST = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_Fk_ProductGroupId",
                        column: x => x.Fk_ProductGroupId,
                        principalSchema: "dbo",
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductSubGroups_Fk_ProductSubGroupId",
                        column: x => x.Fk_ProductSubGroupId,
                        principalSchema: "dbo",
                        principalTable: "ProductSubGroups",
                        principalColumn: "ProductSubGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Units_Fk_UnitId",
                        column: x => x.Fk_UnitId,
                        principalSchema: "dbo",
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalTransactions",
                schema: "dbo",
                columns: table => new
                {
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LedgerDevLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_JournalOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalTransactions", x => x.JournalId);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_JournalOrders_Fk_JournalOrderId",
                        column: x => x.Fk_JournalOrderId,
                        principalSchema: "dbo",
                        principalTable: "JournalOrders",
                        principalColumn: "JournalOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "dbo",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId");
                    table.ForeignKey(
                        name: "FK_JournalTransactions_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_ledgersDev_LedgerDevLedgerId",
                        column: x => x.LedgerDevLedgerId,
                        principalSchema: "dbo",
                        principalTable: "ledgersDev",
                        principalColumn: "LedgerId");
                });

            migrationBuilder.CreateTable(
                name: "Labours",
                schema: "dbo",
                columns: table => new
                {
                    LabourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LabourName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fk_Labour_TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labours", x => x.LabourId);
                    table.ForeignKey(
                        name: "FK_Labours_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Labours_LabourTypes_Fk_Labour_TypeId",
                        column: x => x.Fk_Labour_TypeId,
                        principalSchema: "dbo",
                        principalTable: "LabourTypes",
                        principalColumn: "LabourTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Labours_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                schema: "dbo",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_PartyType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubledgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GstNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Parties_Cities_Fk_CityId",
                        column: x => x.Fk_CityId,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parties_Country_Fk_StateId",
                        column: x => x.Fk_StateId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parties_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "dbo",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId");
                    table.ForeignKey(
                        name: "FK_Parties_States_Fk_StateId",
                        column: x => x.Fk_StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parties_SubLedgers_Fk_SubledgerId",
                        column: x => x.Fk_SubledgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parties_ledgersDev_Fk_PartyType",
                        column: x => x.Fk_PartyType,
                        principalSchema: "dbo",
                        principalTable: "ledgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransaction",
                schema: "dbo",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LedgerDevLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_PaymentOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransaction", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "dbo",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId");
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_PaymentOrders_Fk_PaymentOrderId",
                        column: x => x.Fk_PaymentOrderId,
                        principalSchema: "dbo",
                        principalTable: "PaymentOrders",
                        principalColumn: "PaymentOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_ledgersDev_LedgerDevLedgerId",
                        column: x => x.LedgerDevLedgerId,
                        principalSchema: "dbo",
                        principalTable: "ledgersDev",
                        principalColumn: "LedgerId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "dbo",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportationCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TranspoterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VehicleNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReceivingPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnOrders",
                schema: "dbo",
                columns: table => new
                {
                    PurchaseReturnOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransportationCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TranspoterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceivingPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnOrders", x => x.PurchaseReturnOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptTransactions",
                schema: "dbo",
                columns: table => new
                {
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LedgerDevLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_ReceiptOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptTransactions", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "dbo",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "dbo",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId");
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_ReceiptOrders_Fk_ReceiptOrderId",
                        column: x => x.Fk_ReceiptOrderId,
                        principalSchema: "dbo",
                        principalTable: "ReceiptOrders",
                        principalColumn: "ReceiptOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_ledgersDev_LedgerDevLedgerId",
                        column: x => x.LedgerDevLedgerId,
                        principalSchema: "dbo",
                        principalTable: "ledgersDev",
                        principalColumn: "LedgerId");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                schema: "dbo",
                columns: table => new
                {
                    SalesOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PriceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TranspoterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceivingPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnOrders",
                schema: "dbo",
                columns: table => new
                {
                    SalesReturnOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PriceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TranspoterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceivingPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnOrders", x => x.SalesReturnOrderId);
                    table.ForeignKey(
                        name: "FK_SalesReturnOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubLedgerBalances",
                schema: "dbo",
                columns: table => new
                {
                    SubLedgerBalanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_LedgerBalanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    OpeningBalanceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RunningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    RunningBalanceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgerBalances", x => x.SubLedgerBalanceId);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_LedgerBalances_Fk_LedgerBalanceId",
                        column: x => x.Fk_LedgerBalanceId,
                        principalSchema: "dbo",
                        principalTable: "LedgerBalances",
                        principalColumn: "LedgerBalanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "dbo",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlternateUnits",
                schema: "dbo",
                columns: table => new
                {
                    AlternateUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AlternateUnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlternateQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FK_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternateUnits", x => x.AlternateUnitId);
                    table.ForeignKey(
                        name: "FK_AlternateUnits_Products_FK_ProductId",
                        column: x => x.FK_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlternateUnits_Units_Fk_UnitId",
                        column: x => x.Fk_UnitId,
                        principalSchema: "dbo",
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InwardSupplyTransactions",
                schema: "dbo",
                columns: table => new
                {
                    InwardSupplyTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_InwardSupplyOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardSupplyTransactions", x => x.InwardSupplyTransactionId);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_InwardSupplyOrders_Fk_InwardSupplyOrderId",
                        column: x => x.Fk_InwardSupplyOrderId,
                        principalSchema: "dbo",
                        principalTable: "InwardSupplyOrders",
                        principalColumn: "InwardSupplyOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourRates",
                schema: "dbo",
                columns: table => new
                {
                    LabourRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourRates", x => x.LabourRateId);
                    table.ForeignKey(
                        name: "FK_LabourRates_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourRates_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourRates_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourRates_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutwardSupplyTransactions",
                schema: "dbo",
                columns: table => new
                {
                    OutwardSupplyTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_OutwardSupplyOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwardSupplyTransactions", x => x.OutwardSupplyTransactionId);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_OutwardSupplyOrders_Fk_OutwardSupplyOrderId",
                        column: x => x.Fk_OutwardSupplyOrderId,
                        principalSchema: "dbo",
                        principalTable: "OutwardSupplyOrders",
                        principalColumn: "OutwardSupplyOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "dbo",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYear = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinQty = table.Column<decimal>(type: "decimal(18,5)", nullable: false, defaultValue: 0m),
                    MaxQty = table.Column<decimal>(type: "decimal(18,5)", nullable: false, defaultValue: 0m),
                    OpeningStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    AvilableStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_FinancialYears_Fk_FinancialYear",
                        column: x => x.Fk_FinancialYear,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DamageOrders",
                schema: "dbo",
                columns: table => new
                {
                    DamageOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LabourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageOrders", x => x.DamageOrderId);
                    table.ForeignKey(
                        name: "FK_DamageOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageOrders_Labours_Fk_LabourId",
                        column: x => x.Fk_LabourId,
                        principalSchema: "dbo",
                        principalTable: "Labours",
                        principalColumn: "LabourId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourOrders",
                schema: "dbo",
                columns: table => new
                {
                    LabourOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", maxLength: 10, nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LabourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_LabourTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    OTAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourOrders", x => x.LabourOrderId);
                    table.ForeignKey(
                        name: "FK_LabourOrders_Branches_FK_BranchId",
                        column: x => x.FK_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourOrders_LabourTypes_Fk_LabourTypeId",
                        column: x => x.Fk_LabourTypeId,
                        principalSchema: "dbo",
                        principalTable: "LabourTypes",
                        principalColumn: "LabourTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourOrders_Labours_Fk_LabourId",
                        column: x => x.Fk_LabourId,
                        principalSchema: "dbo",
                        principalTable: "Labours",
                        principalColumn: "LabourId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourOrders_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTransaction",
                schema: "dbo",
                columns: table => new
                {
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_SalesOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTransaction", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_SalesOrders_Fk_SalesOrderId",
                        column: x => x.Fk_SalesOrderId,
                        principalSchema: "dbo",
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnTransactions",
                schema: "dbo",
                columns: table => new
                {
                    SalesReturnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_SalesReturnOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnTransactions", x => x.SalesReturnId);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_SalesReturnOrders_Fk_SalesReturnOrderId",
                        column: x => x.Fk_SalesReturnOrderId,
                        principalSchema: "dbo",
                        principalTable: "SalesReturnOrders",
                        principalColumn: "SalesReturnOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnTransactions",
                schema: "dbo",
                columns: table => new
                {
                    PurchaseReturnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_PurchaseReturnOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlternateQuantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false, defaultValue: 0m),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitQuantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false, defaultValue: 0m),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnTransactions", x => x.PurchaseReturnId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "dbo",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_PurchaseReturnOrders_Fk_PurchaseReturnOrderId",
                        column: x => x.Fk_PurchaseReturnOrderId,
                        principalSchema: "dbo",
                        principalTable: "PurchaseReturnOrders",
                        principalColumn: "PurchaseReturnOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions",
                schema: "dbo",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlternateQuantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitQuantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "dbo",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_PurchaseOrders_Fk_PurchaseOrderId",
                        column: x => x.Fk_PurchaseOrderId,
                        principalSchema: "dbo",
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DamageTransactions",
                schema: "dbo",
                columns: table => new
                {
                    DamageTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_DamageOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTransactions", x => x.DamageTransactionId);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_DamageOrders_Fk_DamageOrderId",
                        column: x => x.Fk_DamageOrderId,
                        principalSchema: "dbo",
                        principalTable: "DamageOrders",
                        principalColumn: "DamageOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourTransactions",
                schema: "dbo",
                columns: table => new
                {
                    LabourTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fk_LabourOdrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourTransactions", x => x.LabourTransactionId);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "dbo",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_LabourOrders_Fk_LabourOdrId",
                        column: x => x.Fk_LabourOdrId,
                        principalSchema: "dbo",
                        principalTable: "LabourOrders",
                        principalColumn: "LabourOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "438df919-342f-4ddf-87c4-6d7a16e64651", null, "User", "USER" },
                    { "5c3a5755-95c7-4f51-84c7-6d7a16e64651", null, "Admin", "ADMIN" },
                    { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", null, "Devloper", "DEVLOPER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Country",
                columns: new[] { "CountryId", "CountryCode", "CountryName", "CreatedBy", "CreatedDate", "IsActive", "ModifyBy", "ModifyDate" },
                values: new object[] { new Guid("e02eb064-def5-434a-8798-6f144a54003c"), "IN", "India", null, new DateTime(2024, 12, 13, 5, 43, 17, 444, DateTimeKind.Utc).AddTicks(3490), true, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "LabourTypes",
                columns: new[] { "LabourTypeId", "Labour_Type" },
                values: new object[,]
                {
                    { new Guid("5e514855-55a0-459c-8b8b-def7696d9ad0"), "PRODUCTION" },
                    { new Guid("6c2758a2-79b5-43a6-8851-c6f975433b0f"), "SERVICE" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "LedgerGroups",
                columns: new[] { "LedgerGroupId", "GroupAlias", "GroupName" },
                values: new object[,]
                {
                    { new Guid("01548ef6-3fe2-4c0f-9a5f-ceed35066136"), "PLTR-DR", "Direct Expenses" },
                    { new Guid("15fe2512-d922-45c5-9e03-64c32b903a5b"), "PLTR-CR", "Sales" },
                    { new Guid("23d58228-db08-4c3d-9177-343b1cfdcf7a"), "LB", "Liability for Expenses" },
                    { new Guid("2fc89e45-7365-46b7-933c-9abae2e5967a"), "AS", "Current Assets" },
                    { new Guid("345b0d2a-8fca-414f-a6f2-c5f7fd9246ac"), "PL-CR", "Indirect Income" },
                    { new Guid("39b5514a-9359-46f3-8c3e-0eabd6880cf6"), "LB", "Unsecured Loan" },
                    { new Guid("4458bce5-4546-4120-a7de-03acefd07b85"), "PLTR-DR", "Purchase" },
                    { new Guid("4d80e68f-ff00-486a-945a-3941761441d9"), "AS", "Fixed Assets" },
                    { new Guid("58639324-2180-4e0b-932d-33024aa3fc5f"), "PL-DR", "Indirect Expenses" },
                    { new Guid("68eeffe7-02f7-4ffc-81b3-aeb0cadc764b"), "LB", "Duties & Taxes" },
                    { new Guid("84a336c6-e48a-43e8-984e-f45b0bf2984f"), "LB", "Secured Loan" },
                    { new Guid("9bbc2c1f-ffa4-44b8-9916-6edf0a47d8db"), "PL-DR", "Capital A/c" },
                    { new Guid("aca9caf1-ea9b-4602-bb60-6c354eac5ce6"), "LB", "Current liabilities & Provisions" },
                    { new Guid("bdcf2ee2-8aab-44f6-bd1e-77b53074389a"), "PLTR-DR", "Opening Stock" },
                    { new Guid("c3c725d0-a502-4275-b0f9-1585ab6edcc7"), "PL-DR", "Depreciation" },
                    { new Guid("ea3f21ad-b0d4-4c27-9f9d-3c36a7a585c2"), "PLTR-CR", "Direct Income" },
                    { new Guid("f3eef2dd-09bb-4e21-b036-1e5bba920efe"), "AS", "Cash & Bank Balance" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "Product_Type" },
                values: new object[,]
                {
                    { new Guid("66ada405-1229-45df-9598-90b602078933"), "MOULD & MECHINARY" },
                    { new Guid("a4ab180b-acc7-44ce-aef7-c588d41edd5c"), "FINISHED GOODS" },
                    { new Guid("b504237f-af5f-485a-bec9-0906c50df3c6"), "SERVICE GOODS" },
                    { new Guid("b524f4a7-1bb2-4347-84ae-e0da56eb4a31"), "RAW MATERIALS" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RegisterTokens",
                columns: new[] { "TokenId", "CreatedBy", "CreatedDate", "IsActive", "ModifyBy", "ModifyDate", "TokenValue" },
                values: new object[] { new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), "System", new DateTime(2024, 12, 13, 5, 43, 17, 438, DateTimeKind.Utc).AddTicks(2570), true, "System", new DateTime(2024, 12, 13, 5, 43, 17, 438, DateTimeKind.Utc).AddTicks(2575), "123-123-1234" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fk_TokenId", "Gender", "LockoutEnabled", "LockoutEnd", "MaratialStatus", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4431f16a-6bc7-4e9b-bada-c491fcc81a58", 0, new DateTime(1993, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "65a37859-d054-4a68-a817-1669d83c598a", "raypintu959@gmail.com", true, new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), "male", true, null, "unmarred", "Pintu Ray", "RAYPINTU959@GMAIL.COM", "RAYPINTU959@GMAIL.COM", "AQAAAAIAAYagAAAAEGCZJkRuuaN5s6jesxs7zm4NBR99KorCbeWBm6yVLgn2JCBVFEKr5ui4hLYFkhQWCA==", "8249486590", true, null, "ZCKN4FWVQMFYYU3JWBLJN7UUN2CBOZMF", true, "raypintu959@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "States",
                columns: new[] { "StateId", "CreatedBy", "CreatedDate", "Fk_CounryId", "IsActive", "ModifyBy", "ModifyDate", "StateName" },
                values: new object[,]
                {
                    { new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2667), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Delhi (UT)" },
                    { new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2549), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Chhattisgarh" },
                    { new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2585), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Manipur" },
                    { new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2556), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Gujarat" },
                    { new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2635), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Tripura" },
                    { new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2620), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Rajasthan" },
                    { new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2613), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Odisha" },
                    { new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2632), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Telangana" },
                    { new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2642), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Uttarakhand" },
                    { new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2673), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Lakshadweep (UT)" },
                    { new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2645), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "West Bengal" },
                    { new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2578), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Madhya Pradesh" },
                    { new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2617), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Punjab" },
                    { new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2531), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Andhra Pradesh" },
                    { new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2610), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Nagaland" },
                    { new Guid("77536c53-345c-48f5-a175-07a7b4044754"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2655), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Jammu & Kashmir (UT)" },
                    { new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2581), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Maharashtra" },
                    { new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2542), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Assam" },
                    { new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2591), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Mizoram" },
                    { new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2545), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Bihar" },
                    { new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2588), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Meghalaya" },
                    { new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2677), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Andaman and Nicobar Islands (UT)" },
                    { new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2624), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Sikkim" },
                    { new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2567), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Jharkhand" },
                    { new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2571), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Karnataka" },
                    { new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2553), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Goa" },
                    { new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2628), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Tamil Nadu" },
                    { new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2660), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Ladakh (UT)" },
                    { new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2560), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Haryana" },
                    { new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2574), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Kerala" },
                    { new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2663), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Chandigarh (UT)" },
                    { new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2670), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Puducherry (UT)" },
                    { new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2537), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Arunachal Pradesh" },
                    { new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2564), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Himachal Pradesh" },
                    { new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2652), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Daman & Diu (UT)" },
                    { new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2639), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Uttar Pradesh" },
                    { new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 445, DateTimeKind.Utc).AddTicks(2649), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Dadra and Nagar Haveli (UT)" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ledgersDev",
                columns: new[] { "LedgerId", "Fk_LedgerGroupId", "Fk_LedgerSubGroupId", "HasSubLedger", "LedgerName", "LedgerType" },
                values: new object[,]
                {
                    { new Guid("1ecff7d8-702b-4dcd-93c5-b95a67e36fc9"), new Guid("15fe2512-d922-45c5-9e03-64c32b903a5b"), null, "No", "Sales A/c", "None" },
                    { new Guid("701c663e-dac3-4a39-8d2a-36eb68426b54"), new Guid("f3eef2dd-09bb-4e21-b036-1e5bba920efe"), null, "No", "Cash A/c", "None" },
                    { new Guid("712d600b-dfd6-4704-9e32-317fe62499a9"), new Guid("4458bce5-4546-4120-a7de-03acefd07b85"), null, "No", "Purchase Return A/c", "None" },
                    { new Guid("75e1fe3d-047d-41ad-a138-f0bb5bbc8b1f"), new Guid("4458bce5-4546-4120-a7de-03acefd07b85"), null, "No", "Purchase A/c", "None" },
                    { new Guid("7f740148-ed36-48ad-b194-031bc717842c"), new Guid("01548ef6-3fe2-4c0f-9a5f-ceed35066136"), null, "No", "Labour Charges", "None" },
                    { new Guid("80025398-c02f-4a1a-9db7-8a21f9efd9ef"), new Guid("15fe2512-d922-45c5-9e03-64c32b903a5b"), null, "No", "Sales Return A/c", "None" },
                    { new Guid("9bfa6931-977f-4a3d-a582-da5f1f4ab773"), new Guid("f3eef2dd-09bb-4e21-b036-1e5bba920efe"), null, "No", "Bank A/c", "None" },
                    { new Guid("9efd7830-125a-40e3-8f44-68ab03f52591"), new Guid("15fe2512-d922-45c5-9e03-64c32b903a5b"), null, "No", "Transporting Charges Recive", "None" },
                    { new Guid("d281cbfb-3cac-4c6a-8ce1-7b51973b8ca4"), new Guid("4458bce5-4546-4120-a7de-03acefd07b85"), null, "No", "Transporting Charges Payment", "None" },
                    { new Guid("d982b189-3326-430d-acde-13c12bba7992"), new Guid("aca9caf1-ea9b-4602-bb60-6c354eac5ce6"), null, "Yes", "Sundry Creditors", "None" },
                    { new Guid("f07a3165-d63b-4dae-a820-ec79d83363b1"), new Guid("01548ef6-3fe2-4c0f-9a5f-ceed35066136"), null, "Yes", "Labour A/c", "None" },
                    { new Guid("fbf4a6c7-c33d-4ad0-b7a5-abb319cc1b93"), new Guid("2fc89e45-7365-46b7-933c-9abae2e5967a"), null, "Yes", "Sundry Debtors", "None" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "UserId" },
                values: new object[,]
                {
                    { 1, "Create", "Create", "AppUserClaim", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                    { 2, "Update", "Update", "AppUserClaim", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                    { 3, "Delete", "Delete", "AppUserClaim", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedDate", "Discriminator", "ModifyBy", "ModifyDate" },
                values: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58", "System", new DateTime(2024, 12, 13, 5, 43, 17, 439, DateTimeKind.Utc).AddTicks(5545), "AppUserRole", "System", new DateTime(2024, 12, 13, 5, 43, 17, 439, DateTimeKind.Utc).AddTicks(5549) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Cities",
                columns: new[] { "DistId", "CreatedBy", "CreatedDate", "DistName", "Fk_CountryId", "Fk_StateId", "IsActive", "ModifyBy", "ModifyDate" },
                values: new object[,]
                {
                    { new Guid("000973b0-4cfa-49e5-8003-515f5654e596"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1609), "Jagatsinghapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("02273688-59d2-4bf9-b33c-48030d18b1b9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(61), "Anand", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("023cd061-48db-46f3-b98a-ac0519d05e81"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1449), "Saiha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("0257f629-c0a6-45b6-9538-aa5b15a1f632"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(83), "Bhavnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("0262ef1a-bf52-4de8-9fae-9405ce184d17"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(386), "Shimla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("027567e1-97fe-4a02-bed1-8aa19f7a8f6f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2312), "Tiruvarur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("02812593-2b92-4460-97a0-98426036d693"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1750), "Gurdaspur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("02c36c79-1160-49cd-b10c-18babe81de0b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2682), "Fatehpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("02c7c70b-a4ea-4ccd-be65-b7667d10fd08"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3120), "North 24 Parganas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("035648a0-7de8-4168-b08e-75e2a63fb6c6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(983), "Chhatarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("036f6591-90f4-4c09-ac7d-185ea09f22c9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2517), "Gomati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("049d680b-4fc8-4987-9c70-bf716e090c8e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1362), "South West Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("04a56fdd-ac32-4ee2-9d13-df220220220f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(995), "Panna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("04bf13e9-e471-4ee0-976f-16c73433c817"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9612), "Arwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("056fcfa7-dfaa-4301-a993-63189b1eb39e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(226), "Bhiwani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("0641b6e8-e300-48d5-a0c1-af781d4c0d76"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9413), "Tirap", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("06d7e177-fec0-4e27-b632-786288ee8bd0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2849), "Muzaffarnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("070ecb22-2e8e-4fff-8d60-013901d243fe"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(326), "Rohtak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("07f480a0-9626-4c34-8520-8771e99955a5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9534), "Karimganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("08aeb441-230b-481b-aa0d-31b6f74e9528"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2471), "Hyderabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("08f5ac62-2cf6-4a1e-9320-b396c2940aad"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(256), "Jhajjar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("09f10578-5b8c-4318-b620-d179984777c5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(56), "Amreli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("0a673e1a-1792-4a82-8a77-3de0c3f15db6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9464), "Chirang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("0a7285d6-acf4-4281-abf9-e70a29830d93"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(463), "Jamtara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("0ba551ca-e49c-4c71-911a-17c890751eca"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3091), "Kalimpong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("0bea9e64-d9b0-42cd-a1b1-d01a6836a1cc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9857), "Dhamtari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("0c5488ec-d421-47aa-bb24-7453921c1e43"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1459), "Serchhip", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("0ca031e2-af61-4fc3-b9c5-18e9975cdbe4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9621), "Banka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("0cc2e219-8481-45f8-bda9-cbdda390ce78"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(698), "Alappuzha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("0cd2e19f-0bfb-4a81-9572-e75e418198fb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3036), "Purba Bardhaman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("0d1587ea-35f0-4494-bd34-ee4d7f57fca9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9213), "Palnadu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("0d46d606-653c-4578-971b-307ed6b59173"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2585), "Auraiya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("0d761cfd-cc55-487b-854d-01950ca1366e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9493), "Goalpara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("0d77b13c-9bc6-4585-b974-f379926cd5f2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(964), "Sidhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("0e1eb9f2-6379-44e2-9e83-76e6e34a7c66"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9295), "Pakke-Kessang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("0f0bc252-dca3-43a7-a2ec-fadabed48c42"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9607), "Araria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("0f1148dd-944c-4794-acfd-a9b319760aa0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1007), "Tikamgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("0f16dbf9-4ecc-47f4-b22d-aaa010d34c19"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(165), "Navsari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("0f1f5068-1070-4daa-95f2-182d7d98dd8f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1164), "Hingoli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("0f95d852-a342-46e2-abf0-52a8cb7e1dec"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1545), "Zünheboto", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("0fe8fa7e-96bd-4b39-a584-822a15f95996"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2854), "Pilibhit", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("10751a91-3856-414c-91f7-3ca3ceb6170f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9474), "Dhemaji", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("109f7209-6fc6-4f12-aba0-1dc08b1de06b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9903), "Khairagarh-Chhuikhadan-Gandai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("10ff5bb6-cb67-4515-b43a-70ecafce9ff2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1704), "Subarnapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("119d837a-8161-4dc9-8a09-efc7e6354e40"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1149), "Nanded", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("1219a7f7-e08a-4a0a-bca5-d95ecbc696a1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2127), "Ariyalur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("12534b4c-5013-47c0-afe2-19d98c8d088a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2945), "Almora", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("1268aa82-262e-4054-98d2-a9f1a24cb986"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(739), "Malappuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("126aa9ec-172b-4561-bb0d-ccc732b4ec50"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3105), "Purba Medinipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("12adfe48-e04f-42a3-81b5-807cbbf58ec6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(797), "Morena", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("12bd7efe-079c-45c3-a536-398f6d4954df"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2353), "Nizamabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("12f04fcf-d94b-4c6d-a00c-1f10c1734be5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(459), "Hazaribagh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("1321d564-4094-40d9-9c5d-ae01f616d812"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2756), "Jhansi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("132d1380-8b84-48a7-9982-739a5d91daa1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2117), "Namchi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("13e1ef0b-b4c9-41dc-afab-cac0e39605e7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9274), "Tawang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("13e519da-bef9-4278-ba76-f350f529c32e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(418), "Deoghar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("14582cd4-ba2f-4b84-9699-4d324654a055"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(395), "Solan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("159889e4-f507-4366-bd7b-d20360d6d6d7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1336), "Ukhrul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("15b5cef2-9500-4567-8cdb-ee1507ae8faf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(706), "Ernakulam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("15e191ee-2b2e-4743-8f02-1a232646b71a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1567), "Bargarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("160ca1ae-87ed-405c-a2df-08ed308d3366"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9479), "Dhubri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("161f5fc1-e417-400b-9f3e-40f74d1f06a7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3399), "Mayabunder", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), true, null, null },
                    { new Guid("16abf613-24ed-460a-9b3a-c2bfc663267c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2358), "Jagtial", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("16c0c020-0b0d-423f-a613-a6efff693ed8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(359), "Kangra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("16fa1483-56f8-4cca-8fc4-bf154874700f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(155), "Morbi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("17157376-74f2-495b-bf8a-3d3525e1137a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1074), "Satara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("17b78b9e-7e73-4050-8c01-a6b66028fb21"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9446), "Bongaigaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("184ca9ef-9df6-4990-9f50-e14fddc1d35b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9566), "Nalbari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("18aad261-6e77-4030-ad99-9487ef109364"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9576), "Sonitpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("19c4dd33-54d4-4702-87dc-9e788848277d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(837), "Datia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("19d1c938-c808-4903-ad91-0e00c328716b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3263), "Kargil", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("1a230a6e-ec7d-4b53-8a45-75a3e5615045"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2905), "Shamli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("1a515de4-2427-4ab3-9065-d28d96476f2e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1118), "Yavatmal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("1a951074-a0a9-469a-b752-5d222b450906"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1830), "Ajmer", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("1aac26f6-7f92-4d2a-b1de-3d94b3889812"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3147), "Daman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), true, null, null },
                    { new Guid("1ab1a101-147d-467e-9fa1-b90dc46bf32e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1821), "Shaheed Bhagat Singh Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("1b7013b9-4b7f-4cf1-ac7c-7d1682866b18"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2869), "Rae Bareli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("1bfa9e61-f180-4458-b51a-d87c07b74362"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3292), "Nubra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("1ca78f8f-94d9-449d-9419-33dbd6b95240"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(595), "Chitradurga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("1cdb60ed-0a25-4315-ace5-d3aa56709eda"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1265), "Chandel", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("1d1c3f3e-c2b3-460e-80ac-2e9a17d1f84e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9510), "Hojai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("1d7275c4-e507-4505-aaa2-0a4342652aa5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(184), "Rajkot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("1d90499c-c93e-4032-ba8e-1b71a3033320"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9363), "Upper Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("1d9a8014-16b7-478e-af8e-cf986c15f1f1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1423), "Khawzawl", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("1e2da49d-057a-458e-a3a0-65a6af0dfb9b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2626), "Barabanki", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("1e39a3d2-4f35-4707-b373-134dc7c4d09a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2385), "Bhupalpally", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("1e4fa25c-f32d-4437-94f0-6a23a1c4e19c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1238), "Palghar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("1e73b10c-6da3-438f-978e-f1fef88e12ec"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9686), "Jehanabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("1e8c6c89-ab82-45ea-9166-09dee78c7ca2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9208), "NTR", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("1f98c592-7bb3-4fd5-ac38-ef6703428f04"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1857), "Nagaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("2009c37c-c080-4483-b073-9ed7f2b290c5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(729), "Kottayam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("20617374-c054-48f9-ab1b-969ed6c29e26"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2467), "Shamirpet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("20c02c2b-01f9-4759-9f08-8178edc439d1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9469), "Darrang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("213d68ba-c770-448b-99d3-c5555ce17d02"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9436), "Barpeta", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("217b5806-4a00-4bf4-9fae-3c8a5920fbf0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1785), "Moga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("21922dc1-cfc7-4b85-99f4-d5d21b6a04c3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2909), "Shravasti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("21cfd111-b2de-45e8-9fa1-3112ade6bafe"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1158), "Parbhani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("221263ec-f031-4403-ab2a-ff233a360bbc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(880), "Khandwa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("221c104d-6997-4223-b43a-fc83ef6d97e1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1108), "Amravati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("22a85316-4f35-4b42-829e-a426c2382ba5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(37), "Surguja", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("22b0199c-32b8-4d21-b904-b09b0170687a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1690), "Puri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("23177b32-3e0f-49c2-9944-cc315b7922f0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(119), "Gir Somnath", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("2333dd85-5aca-4bf5-b381-fb6e47ef6b34"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9934), "Mungeli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("234c64b4-ac25-492e-9315-1efe27dade07"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1790), "Sri Muktsar Sahib", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("23b7c164-c7d9-4c8b-9324-608c7c4d10b0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3240), "Ganderbal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("23eebb45-a6e7-4849-bbb3-d7b724fae401"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2672), "Etawah", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("23fb8b61-f039-48e1-8af8-74c1263b57ca"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2990), "Rudraprayag", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("2432a9cd-8ccb-4d88-a9da-b7fa33e43f15"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2840), "Mirzapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("2471486a-1aaa-475b-96d6-1b02906969ea"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9839), "Bijapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("2484fa1f-1c3c-49b7-9928-6bc92a4bdd3a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(895), "Chhindwara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("24878660-9109-419d-b12a-885933f30575"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(134), "Kutch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("248bd1f0-bd4a-47c2-b471-0f60a2d88a6d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1055), "Ratlam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("248c873b-ac64-49b9-9424-7abf883f76b1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3314), "Central Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("249ca420-06c1-4a6a-aae9-e37a9bff11ed"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3208), "Anantnag", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("24a445e7-cc12-4321-bb92-73c1316ee9e6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(32), "Surajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("259e253e-8d98-47de-a9dc-b97189d8a924"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3327), "North Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("25e5b9e6-a9c2-4e3f-ab88-bd9c2b60e368"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(313), "Panipat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("26024b47-7de9-4619-afb0-b158d3a10948"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9539), "Kokrajhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("273a54cd-d849-445b-be09-024ad6e5a8ad"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(160), "Narmada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("27fa2d13-f373-43ba-87aa-95bf5f40e8f4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(872), "Jhabua", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("28177874-e6fd-4007-b1ce-30b80470d87e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1027), "Umaria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("28248239-f3e2-4fd7-9adc-f9035fca098c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1978), "Kotputli–Behror", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("28604591-02e3-4b26-8222-0aa57f616185"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1494), "Mokokchung", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("28e93fdf-3b27-4366-ad91-90fd4f904e38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2417), "Warangal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("29419023-af00-4c61-a0ea-ea9dc4ee3036"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2761), "Kannauj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("2952ca6c-2a4f-4355-bb44-f64519de172d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(400), "Una", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("29534553-6210-4515-90aa-50343f91ae4e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1628), "Kandhamal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("296a61f8-6b96-42cb-a928-a1843d7af6b5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2453), "Bhuvanagiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("297aaa21-54a0-4bdc-83ae-d28fab09cd69"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2009), "Phalodi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("297ddd1f-b007-4524-94d7-2be3b33bfa95"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3063), "Hooghly", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("29c9642f-6afe-4762-833a-75126e17d744"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1755), "Hoshiarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("2a0226f0-b08c-4a8e-8b9e-c76a785c6ab4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1127), "Aurangabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("2a2ad464-44b8-49c4-b277-46a4d49c3632"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2481), "Vikarabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("2ad7a0be-3a2c-4e3c-8fff-9fbe1c474594"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1718), "Barnala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("2b3aaa75-0e42-4b2f-a776-3fbc71e04cc1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1192), "Nagpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("2b8e0451-a7ee-43eb-a8ea-abf9081c221c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(910), "Mandla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("2bed2e54-a1c2-4d0c-94e3-9908a6725274"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9520), "Kamrup Metropolitan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("2cb93672-1b64-4816-84f1-22d35fb38724"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1224), "Nashik", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("2d9ad9e9-6dff-4a4a-ba06-72a35249d80d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(139), "Kheda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("2da734e0-ffbf-4fe2-9e9a-cf4cfa215349"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(102), "Dang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("2e55b666-8691-43e3-b226-d8ef0fbf5374"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2249), "Salem", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("2e66a37b-15c7-46eb-88aa-e79c1e42f07b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(330), "Sirsa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("2e8e94dc-3337-4099-b3b7-b92ca6e464b6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9232), "Anantapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("2f20bf61-763f-4b57-838e-329f56cbb79c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2743), "Jalaun", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("2f5ca281-c3b9-49c5-8d9b-8db17312d211"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2317), "Vellore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("2f705184-1b4f-4cf6-bf1b-42601d9605d2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(734), "Kozhikode", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("3008e94c-3c5b-447c-b875-3a1df9ef4233"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9529), "Karbi Anglong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("300c6209-926f-4495-a6b2-650bf5a433db"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(449), "Godda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("304c19a5-241c-4152-b5d0-a8654bb3338a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9161), "Visakhapatnam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("3127d043-79e5-47fa-943d-cc12e49b0b7e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9358), "Lepa-Rada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("3139cc3b-f85e-45c2-b35f-68754289bbe1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2436), "Mahabubabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("31796304-e058-47f1-9c31-b49cc7c95696"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1521), "Phek", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("31b812e9-1d85-4780-a378-c9f0e4ccec27"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2380), "Karimnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("31c7bdc6-5051-4500-9a7d-6462d19376f8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2600), "Bagpat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("32ae5990-ea6d-4bf1-a811-494d72651f17"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9852), "Dantewada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("32d84ab4-15ec-4206-a272-ab7ca266a58d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3301), "Zanskar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("3333c03e-bd46-4da8-838a-d9dd325018f8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2149), "Cuddalore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("33385802-cbdd-4164-861d-bcdfbfdaaf0e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3318), "East Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("334e66ca-c480-4e7f-b285-dbf7a6c8ce75"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(572), "Vijayapura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("33ff8497-836f-464f-a782-d4545f173d1c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3353), "South East Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("34417d47-aa15-48db-9657-6e0ce79fb7aa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2091), "Udaipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("344bf06a-c500-41ba-9fd5-7052b606e090"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3341), "Shahdara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("348bad64-455b-43b6-8b47-694c5a6db9a6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9658), "Gaya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("34f46c70-0a4b-4eec-be05-220cd921da20"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2163), "Erode", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("34f5d653-dca3-41db-bbee-7af488db11e5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(376), "Lahaul and Spiti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("350e6e76-f95a-4308-a806-3e65b7514a10"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3184), "Rajouri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("352fa974-73f5-41ea-9525-791bbfd0afba"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1378), "East Jaintia Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("36594559-886a-450b-8ab3-06c937dbf9f2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9370), "East Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("37733e7f-d165-4a9b-acc7-69e2dc33e478"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2004), "Jodhpur Rural", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("37e1aac7-0dc7-483e-9b30-cedd4829f08e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2086), "Salumbar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("37e29e7f-64f2-48ec-ad83-912073e5012f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9728), "Madhepura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("39aaab16-6f16-4499-b4f6-cdb9df25f58e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1463), "Chümoukedima", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("39ac2409-b251-44bd-a55c-57701bdfc35d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9948), "Raipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("3a59a0b0-9d78-4e62-80ce-660ca0014b25"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2917), "Siddharthnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("3ae564b7-c093-4cca-80d7-caa9ad5ae6f2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1410), "Aizawl", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("3b65b082-9174-4532-851f-b48012d9c00a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1835), "Beawar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("3bde3e18-f05b-488c-80e3-72904867dacf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(951), "Rewa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3c000914-0641-494e-bec8-b8498ebfef02"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1526), "Shamator", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("3c36a8bc-44f4-4ecf-a564-075a9237225b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1050), "Neemuch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3c7e6735-63de-4fcd-ab38-98b57bc45ebb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9451), "Cachar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("3ccfca13-3ecd-456c-868a-6a44d1ed770e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(862), "Indore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3d0ab0c1-fb36-40c5-8878-410703526196"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1576), "Boudh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("3d1be4dc-75be-4715-a220-71f79e218f76"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9847), "Bilaspur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("3d69e578-6c9a-480b-b034-5881d1aa9d21"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1658), "Koraput", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("3da5b771-5354-495b-9961-f044d3afa6b0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(942), "Harda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3dd3e7e0-14d7-467c-818b-b2c483dc9019"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9834), "Bemetara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("3ddc572e-4ba0-40df-a443-e300f6bf38f9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1217), "Nandurbar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("3e20e4c4-75fe-4548-89ac-ab1ee029e988"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(283), "Karnal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("3e2f564a-ae76-45b7-9581-9204874dd225"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(124), "Jamnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("3e7e08b1-5ffa-4c83-ac9f-dfbe84bae2aa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(900), "Jabalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3f317517-2d0f-4140-b2d0-6c88f5f288d7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(751), "Pathanamthitta", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("400a64ba-aa31-41af-94f1-6625d7ed2b90"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1872), "Banswara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4051c158-68d3-4327-86d1-cd9d21e78274"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2264), "Thanjavur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("40a9193b-b0e9-43da-ba30-7d2c83d6852c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1289), "Kakching", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("4164fb5f-485c-419a-b649-780852ac62c2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2394), "Medak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("41957e90-b045-4699-80d4-39fff01705d7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3272), "Changthang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("41caebfe-a3a9-4e0b-ac7f-7ac36034efbd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2244), "Ranipet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("41fbd584-93b1-4ff4-bc48-37f777ad0d8d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1781), "Mansa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("42201965-6b3d-4d58-80d9-adc7d904112c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2040), "Pali", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("42d09ceb-c997-459b-be6d-b89cb9b1b694"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1862), "Shahpura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("435aa397-c3d3-4aab-a114-fc7761d79064"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2877), "Rampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("4389ed7f-48de-438f-99da-a202eb8a4695"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(506), "Ranchi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("438b321c-87f4-46cd-83e6-841b71012f60"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(143), "Mahisagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("43d3a181-97b8-4073-bda8-8d3a80de700d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2365), "Peddapalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("43ed33e9-ae18-410a-829f-5ba8382e81cf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(937), "Betul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("44b42150-1a3f-4387-9da7-309d12702268"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3362), "West Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("4524f241-1792-4a97-a927-97fabf96979c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9279), "West Kameng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("452c6d2b-b559-4497-9b6e-8c2c152c27af"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(484), "Lohardaga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("459095ab-6605-46fc-9775-78d9253d56e1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3332), "North East Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("45a77212-4be7-4563-92ce-adf30dcbc603"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2641), "Bijnor", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("45f1f0be-7561-4ad6-8491-7a0014493e17"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3296), "Sham", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("45f49b48-0052-4e95-863b-e47dd0e5b353"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1933), "Bikaner", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4629f91d-0bf3-42d8-87dd-f7b4a0ea9770"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1096), "Akola", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("468cfca6-0d3c-4a32-ac24-a094488d1c2b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1586), "Debagarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("468f0b9d-2eaf-425c-842e-dbd3343797d5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2136), "Chennai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("46c48420-79df-44d9-a1e4-643384ad3f71"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2431), "Khammam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("4772dbbb-6558-434e-81fa-a74ba37941e9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(474), "Kodarma", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("47baf033-a4b0-4e81-8435-bcdc9eef200f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1419), "Hnahthial", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("4853bbd2-9c99-429e-aec5-7cbed642959f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3082), "Kolkata", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("4883cf97-4ca2-4db8-9041-fe248e753a5e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9515), "Jorhat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("489b5446-3399-47cd-994b-f47c23de2a6b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1060), "Shajapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("48c2efe7-2b5e-48ea-8f33-d182f2f97f4c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(990), "Damoh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("494953f6-4a3e-4feb-abc2-9f92f49b47d1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1951), "Alwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("495df73c-b0d5-4ee6-8c4e-c89ff4332dba"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9354), "Lower Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("4964b90d-5368-4d83-a848-756fde84a183"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2797), "Lalitpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("49924414-d074-41f1-817e-2754b6c904b0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1604), "Ganjam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("49aa2466-bf40-4fc1-a5dc-a33c5c04ffa3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(542), "Bengaluru Rural", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("4acc5306-f68b-4ecb-acbc-9326e2c9b328"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2167), "Kallakurichi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("4b005201-9904-4a67-989e-db3e019468af"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1623), "Kalahandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("4b5bc5e0-75c6-4a54-b3f9-758380c8724d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(19), "Sakti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("4b66dadd-0185-4bd8-90b1-4fe9938bf66a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3189), "Poonch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("4bed75ed-d6ed-4805-bfca-93e2b514f57b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2254), "Sivaganga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("4cc9c60f-6d81-43ab-a356-22f61523c726"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(501), "Ramgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("4cdfa0ba-2df7-4871-a291-f8fd67b22026"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9938), "Narayanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("4d03a71f-7b00-493f-95ff-f92a679889e9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(252), "Hisar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("4d24f73e-e756-468a-9878-38d04e8c9108"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2568), "Ayodhya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("4e3dd39a-8456-4b1a-82d2-d8159af7ec9e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9222), "Sri Potti Sriramulu Nellore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("4e4ee339-2650-4dba-8fc0-f403302a8c07"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1508), "Noklak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("4e9ae395-eda8-439f-9f1f-ee4b05f1a5d0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1845), "Didwana–Kuchaman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4ec194af-9126-4332-8153-1cc86c40ae06"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2957), "Chamoli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("4f0e5a29-c7f9-441e-906f-0228789d7559"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1032), "Agar Malwa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("4f2087d5-0726-448f-b6ab-3389d3eaca1f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(98), "Dahod", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("4f9071bb-c22b-4583-ab14-612e6db05942"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(515), "Saraikela-Kharsawan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("501d9267-4c68-4d9a-87f4-4305815e1873"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3231), "Budgam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("52ca0f4e-b8fb-437b-b713-970e728f67f9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2100), "Mangan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("52e0c82a-6431-461e-a212-26d0d89357da"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(216), "Valsad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("53f25654-2b68-4fd8-91c4-149b2cb94f10"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9305), "Papum Pare", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("542c6f31-6155-4130-9067-6a0e528b9688"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2281), "Tiruchirappalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("5445c7d8-5ef5-4c79-b03f-f3163c6da592"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1904), "Gangapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("5490abc3-4837-4f27-9e66-0d1c00f45b92"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2113), "Soreng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("54e5b4c4-f081-47e1-9aa9-fcb93d8857d5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9254), "Kurnool", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("5523634b-a5ae-4a96-85a8-ddcd392e1f45"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(170), "Panchmahal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("552e739a-d2f7-46ee-8de3-33569f3cf003"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(644), "Koppal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("55844bca-81b0-451d-8211-11d548ec1fba"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9330), "Keyi Panyor", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("55f827ef-e4ef-42db-8de5-c09684666562"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1202), "Ahmednagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("5619efe6-4e12-4054-a013-9cd3dbbf0fc3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1919), "Karauli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("566890ee-4ede-4cb9-98e2-c053eb16dcd5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9747), "Patna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("56be637e-aded-478b-aaa1-25358a18fc18"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1042), "Mandsaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("56c20277-6707-4d75-899e-21ab0a197db3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9380), "Lower Dibang Valley", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("5757f491-0a18-4003-87ed-7a38048f5036"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2691), "Gautam Buddha Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("579ad912-8088-48ef-bbd6-c941f28604fd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3336), "North West Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("57bac20c-0dfd-4653-bc5c-2a8fee373eb3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2966), "Dehradun", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("58dfe88b-b171-4800-9608-03317c80ae94"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1405), "Ri-Bhoi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("593d9ba2-d68f-4385-bffc-894bef77d2db"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1599), "Gajapati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("59682a8a-cdf1-47c1-9289-243cc80138af"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1140), "Jalna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("5987fe85-00aa-4928-836c-0eeb21f3af81"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9484), "Dibrugarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("59e2c2b1-458c-447c-b309-37f022e1017d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(242), "Fatehabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("59e2fac6-b8e2-4c60-bd0c-4d5f86cd6748"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9815), "Balod", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("5a3ffa23-37d9-4919-a20b-5af030193f66"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(746), "Palakkad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("5a4bfd0b-1d36-483a-b1e8-b2320dce1ca9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1816), "Sangrur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("5a63bba5-a1ad-4409-99f4-dfd24ef9567b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1853), "Kekri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("5a8c214c-1f78-437e-8781-201d090df9c0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9408), "Changlang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("5a9de892-e2a3-41a7-96d9-284d2d8c7528"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2886), "Sant Kabir Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("5baa9c90-2676-4f23-9a68-e0f6f1ebb07c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1759), "Jalandhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("5c2c1236-e821-439a-b8e7-8bd9c533c1aa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(659), "Raichur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("5c822b31-dc5e-4d9e-b8ff-5e691bc033f6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1771), "Ludhiana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("5caaf6a6-b869-4e07-9d0f-ee9c36baa9f3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2986), "Pithoragarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("5cb40e3d-489f-4489-847c-f3392a1ec656"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1069), "Sangli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("5cc0a897-cbee-4b31-b00b-fe43460c875e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2370), "Kamareddy", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("5cd094de-39bd-4e79-a877-69e811a1ba40"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(441), "Giridih", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("5d058e78-9bf1-45a4-b418-6985099244b6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9629), "Begusarai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("5d1dea42-19f1-4ea2-b316-7cc40481c71b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1064), "Ujjain", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("5d3e85c4-5995-4f6c-8313-0159855da57b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9195), "Kakinada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("5db0f399-5c8f-4384-859b-07febb08cd36"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2940), "Varanasi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("5e761b7a-c1e3-4206-bab7-83efa5d31f49"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(110), "Devbhoomi Dwarka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("60d66a66-bf3a-48d5-b966-1df95e0ee87c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1396), "South West Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("60dfb977-cece-41a1-b873-ae3fe6f30823"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2108), "Pakyong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("60f33ed0-0c09-48c0-b6ca-c1f26e8a78ea"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2512), "Dhalai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("612c0123-135a-4af7-9ea2-d7a1eb386493"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3372), "Mahé", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("61426a96-4f1e-466c-b6d0-6e9f03702948"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(468), "Khunti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("6197b31a-1cb3-4b63-8324-49437aea98b3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9561), "Nagaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("61a82ff6-ff85-41ac-8d8a-7049b1e093e8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(675), "Tumakuru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("61b47ccc-df22-4aa6-9326-49257a07d325"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2636), "Basti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("630c335b-bb10-4330-beb6-11c17b74de24"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2031), "Kota", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("633eca46-f7b3-4172-b58a-57dbcfe06267"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3174), "Udhampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("6362d8dc-0e2f-4352-be65-f7862702542f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3072), "Jalpaiguri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("6395a994-12a8-44e8-87d5-f3d82c2ec812"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9349), "Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("6403defb-7ab2-4b65-a4ea-0737eb1fd59f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(609), "Dharwad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("642e57b8-d3f2-4c87-b69c-307763631291"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9732), "Muzaffarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("64985fde-4a7d-45e3-afa0-11ef0aeccce1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2412), "Hanumakonda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("64fc8b07-8953-4d63-83aa-bcb9769be057"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(520), "Simdega", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("655a9a36-f488-4192-b9a8-d85c4b06c808"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2226), "Perambalur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("65a0ff98-94a3-4be2-962e-b31ffbcb87fb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2971), "Haridwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("65ac6128-e7f7-46b5-b415-a65085836fc0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1619), "Jharsuguda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("65e7166e-e0a0-47b9-a651-7f28d646ddc6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1571), "Bhadrak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("66353d1b-e473-4805-b377-d352a346a144"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2231), "Pudukkottai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("663b450c-7623-4db1-b65f-61878f82cc25"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(238), "Faridabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("66c0c250-586c-49d9-a3fb-5a4ef74012e5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1881), "Pratapgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("6725d944-83b6-4c5b-8b19-c8ae4368ce15"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2609), "Ballia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("6742cd88-d341-4316-af4e-1bdbbfdd7d2d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(408), "Bokaro", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("677d3fdc-a2ba-4c57-b46a-52a58120a889"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(725), "Kollam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("678ebd79-cb47-46bd-bb40-1b5ea2360fa7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9798), "Siwan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("67cc5a0a-13c0-4bf3-8995-fcb71d4e6995"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9929), "Mohla-Manpur- Ambagarh Chowki", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("67ec3c0f-a0f6-4400-acad-e299c8fb6fe9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(47), "South Goa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), true, null, null },
                    { new Guid("67fa0e20-5df0-40e3-b2b9-1030ad2355ae"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2239), "Ramanathapuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("6864a1a2-b9c8-42ba-8bc9-48a0f1db2268"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3216), "Kulgam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("686a40d1-e75d-4f11-ab1b-42de11768a03"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9227), "West Godavari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("687d8caa-c0e7-41a5-a973-62a1ec679015"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(41), "North Goa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), true, null, null },
                    { new Guid("68a879e5-c88a-410c-9250-056e836ccd0f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3377), "Pondicherry", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("68cc6e47-aeee-4b91-ad1d-4e951d9153f2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2558), "Aligarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("69338d44-13fb-4327-a897-b8774e30cb38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1174), "Chandrapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("6948b505-4d55-40b9-a488-71bfe6b5ee08"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2077), "Chittorgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("695d9135-dc96-473c-925a-33d389dcc9cb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1723), "Bathinda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("69a7b684-e322-427b-a86e-693cdde55966"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(247), "Gurugram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("6a4631f5-52a1-47c7-bf71-ffc7cd1d56ec"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(694), "Yadgiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("6a941893-e51d-445f-bdcc-d6e1cbe85066"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2784), "Kushinagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("6b5e699d-bc0b-47ad-a92d-faf6c8791ea4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2864), "Prayagraj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("6b774c8a-7b77-4e91-9d03-b91981e506c9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3404), "Sri Vijaya Puram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), true, null, null },
                    { new Guid("6b987710-943f-48a8-a2f7-74aadd763c0c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(9), "Rajnandgaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("6c48ccdb-fab9-45a8-8388-8821958a42f1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2448), "Nalgonda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("6d6afd59-621d-4d99-968b-04a7d4af76f3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(367), "Kinnaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("6df5e632-6b52-4a9d-bb4c-1194dc5c4e8c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1132), "Beed", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("6e869812-db39-46f4-bbd3-7f9ff4964531"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(69), "Aravalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("6ed83096-4f85-45c0-b99a-31acbe066800"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(427), "Dumka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("6ede9fc7-931b-428a-8e98-7ee368c67cac"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2287), "Tirunelveli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("6eff5760-a5df-457f-918d-91447ed0a2d6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(307), "Panchkula", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("6f213d1a-4064-4f86-952a-d7b0e316205c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(671), "Shivamogga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("6f2e0623-33d3-4609-a6b4-35322e2c0851"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1012), "Niwari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("6f5c3bc0-8778-4e62-a795-bd78248db8f6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9753), "Purnia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("6f85688d-d07a-4d32-a802-7bf46f9578a1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2981), "Pauri Garhwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("702dc550-97bb-4458-a4bf-d4faab130115"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(221), "Ambala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("7098fddf-32fb-4f9a-8fe6-56d8fd602a13"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(680), "Udupi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("70cb4833-b9b8-4a28-afce-ead2c651663d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9765), "Saharsa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("71f05291-b7ab-4637-aa7a-be6946aab549"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3179), "Reasi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("721b7a69-43d7-4baf-bde1-766852e07a54"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9166), "Vizianagaram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("72f5075e-602e-4a1f-84da-b7c2b2bc8390"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1384), "East Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("736f7452-f1f0-4c27-bb25-2e8d730a52b3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3249), "Baramulla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("739e524e-e6ef-4069-a9c5-f507c3ae0e10"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1995), "Jaisalmer", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("73d064a4-bb0c-49e9-8c8f-71956cfee1c2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2823), "Mathura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("7413a335-cf52-44a7-800b-bcfb65d4a1c3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(711), "Idukki", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("743df9a4-01ce-4e8d-8ac6-8b754418634e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9810), "West Champaran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("74a9e519-321e-4764-9f51-8f3af22e1783"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3309), "Chandigarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"), true, null, null },
                    { new Guid("74bd52f4-98ef-49ec-95c8-407da4eb896b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(562), "Ballari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("752b294a-5874-4d97-a64b-9754d31b9374"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2563), "Ambedkar Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("759dccd7-bd0f-4f64-8526-da2f9a7f9ce5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1122), "Washim", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("75b2e80b-52ef-4931-91b2-8c196a7fc82f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(590), "Chikkamagaluru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("763be70d-549f-4c65-9d24-6badf6a6777d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1358), "West Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("76a711f5-7161-4b00-8acc-868b3cf8e62f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1695), "Rayagada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("76fbc0db-8d40-42ee-bda8-63dc1b3a8862"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9597), "Udalguri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("771949c4-f1a9-47b2-9b78-002f3c3c0076"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9830), "Bastar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("774c8975-fff6-4047-835a-f6a0c0ba679f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2067), "Neem Ka Thana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("776ca1fa-0818-4f62-9473-bb1e585f3437"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9769), "Samastipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("77784e8a-e15b-4efa-810d-aae140896b81"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1038), "Dewas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("779ce39c-5816-4a69-bb94-7d2625b07838"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2259), "Tenkasi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("77e4bf36-d89f-46c2-af3d-48fb296197dd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2717), "Hamirpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("77ee450b-9083-48ac-9c08-216f38acdb48"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(233), "Charkhi Dadri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("786a4f75-3c59-42dd-a7ad-275ff68ac273"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2173), "Kancheepuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("78ab96b5-1c53-4423-8eee-b87aa85a8e83"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(197), "Surat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("78ee3585-4cc7-4ec0-b872-e48afcaa0143"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1414), "Champhai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("792278ed-c1c6-48e5-9f3a-fe0616232d01"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(792), "Vidisha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("7943e740-9af8-4545-95a9-2a7adbcab51c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1840), "Bhilwara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("7a6e2e01-5192-4281-b5e8-edadfa67c79f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(479), "Latehar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("7af52a2f-7b15-4941-9779-4549c5339452"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9711), "Lakhisarai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("7b2d3c7e-20dd-480d-b5d7-3223d67fe958"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(567), "Bidar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("7b4f22d1-60e4-49fc-b457-58a8914f458f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2544), "South Tripura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("7bbd52cd-c706-4096-aafd-993d97780ebf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9861), "Durg", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("7c49e7db-3098-4550-9c9e-d828984d2d02"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1257), "Bishnupur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("7c7c36da-d081-48ce-a6d1-21e3ff771584"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2375), "Sircilla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("7cefb327-91c9-4ab4-b087-1927d5ffed0c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1428), "Kolasib", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("7da15c43-145a-4970-bd72-61c329d4e21e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1340), "North Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("7dc725b3-e631-4d4a-84cf-1520536755b0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9244), "Chittoor", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("7e08aa18-acef-4dbf-b388-13d011e3568f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1531), "Tseminyü", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("7e27bbd2-ceb9-411e-bd5a-bdcbe9ca07c4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(340), "Yamunanagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("7ebc93ea-5830-4b82-bcf6-f5c905334938"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2026), "Jhalawar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("7ec3fe89-f63a-43df-bbb1-a026d60ddf82"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2202), "Madurai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("7ecbbeb1-8ada-42ef-8c67-5322f887faf8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9142), "Srikakulam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("7f8593e6-c5ba-47b8-bb56-36fb30c504bc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9617), "Aurangabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("803f3f02-cb78-43c8-9834-fe75c61ea33f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9263), "Sri Sathya Sai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("8090a63d-c936-4eb2-a2b0-b09903668d1f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2050), "Sanchore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("80a66c52-ec04-4211-8de2-5d596c9bb2ff"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2595), "Budaun", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("815862ec-bcd7-454d-943c-2859c8935f8f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(302), "Palwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("81772b4f-5723-4acc-b61f-cf8f974e682a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9505), "Hailakandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("819341d3-5fc1-4dac-a78c-7679b643e893"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(968), "Singrauli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("822265f9-d7b5-418d-9920-d3688d64f671"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1731), "Faridkot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("827c6081-ac7b-41af-ad07-9cb5f991acdd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1663), "Malkangiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("82d9d1a0-84e3-41ab-ba57-9c77267c2658"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1673), "Nabarangpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("832ae0b6-493b-4ab7-bbb3-fc114022f696"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(829), "Shivpuri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("832d7b25-ec8b-45e2-853f-169ee92baf5a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1480), "Kiphire", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("83592434-fe41-4a1b-9c23-9639eaf3ff2e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2696), "Ghaziabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("83f84468-6d3d-49fd-aa5e-89c11e62fefb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1348), "East Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("846e20e4-0b5d-4546-8d6c-9eaf74ff7340"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1436), "Lawngtlai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("8483221d-92f6-4c50-8752-d81df2dcafba"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9203), "Krishna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("848b2567-0bed-453f-943c-8f6ac3bd0327"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(811), "Gwalior", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("848c08fe-1b83-47d5-9aa3-0cf562e9d309"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1187), "Gondia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("84c548be-99ba-447c-a3b5-bf6f0b9fe336"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(825), "Ashoknagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("84cecb9d-c859-4f16-bdf7-4df7e4661ee7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2704), "Ghazipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("85415848-8869-4f9c-abcd-115ea0853532"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2808), "Maharajganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("85525061-60e7-4359-9b86-36e8f7c5803d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1924), "Sawai Madhopur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("85ae4b83-c1ca-42bc-8bbe-d33a3fb66a91"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(27), "Sukma", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("85d6110a-3ff5-4235-affb-a624afeb2cad"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1886), "Bharatpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("85f0b51f-f395-44cb-8b00-029e0b27b6f9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2081), "Rajsamand", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("861ed781-5b16-4937-8a6a-c3b968f3f4e0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1894), "Deeg", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("86ffe469-3fed-49ea-8644-7e29508c52de"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9218), "Prakasam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("878da2cf-65c9-4829-8bf3-a0f26a3d1b2e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1321), "Tamenglong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("878e6fa6-fd86-451e-a8a2-1d3168fb13f6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1326), "Tengnoupal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("879153f2-2481-4951-b7be-822b3ea6979c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2631), "Bareilly", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("87f3759e-41e2-4a60-93cc-d54f5889b95c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2950), "Bageshwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("88d3d920-062f-48a6-b094-ef2722649f0c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2426), "Kothagudem", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("88f2c4c2-3a99-444b-91cd-308ea4f3dd54"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2573), "Amethi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("892665b7-2c95-41a5-b1db-324371a9398e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1499), "Mon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("8965f575-c2cb-49f5-bd5c-9ae901691018"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(349), "Chamba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("8a45b584-cae0-425d-b5fb-b2019af8255d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9893), "Kanker", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("8adefe7b-a3cf-4db3-9d53-dced3fbfa7a2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(335), "Sonipat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("8ae34027-2fe5-4ff0-8085-8602e7ebbb70"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2813), "Mahoba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("8af90bd0-5799-48b1-a3d0-87e7fbf68445"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9181), "East Godavari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("8b189855-3827-423e-aa76-09bb0f108c03"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1440), "Lunglei", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("8b5d772a-7725-4fa8-8d72-72063829e807"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2212), "Nagapattinam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("8c93f775-0011-4f1d-9704-a383de3eb139"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(287), "Kurukshetra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("8cb28f2b-5935-4f59-9540-7b708641a0ed"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2217), "Namakkal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("8cc50a4a-5302-4d88-bae2-a5c7dac2b7c4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1445), "Mamit", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("8cd9437a-fd1e-46e3-8993-07f5f6603e71"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3026), "Bankura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("8d8785b5-3427-4cc7-8846-4c170499283e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1207), "Dhule", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("8da9145b-9e57-4594-ad9d-991f88f3f6fa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1299), "Kangpokpi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("8df8ad85-818f-40f8-8d16-52e4f13dd46d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9185), "Eluru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("8e0c2daa-2d33-4b47-9963-d2f2d020e15c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2859), "Pratapgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("8e6ef696-a794-4db0-a659-727a9e603228"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(211), "Vadodara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("8e71e2ca-25a1-4cb2-b339-c408a82835cc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1736), "Fatehgarh Sahib", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("8fa37a94-e023-454f-8515-7e39919432d4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2553), "Agra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("904d8062-7c84-4e97-bd82-cf818b632cfe"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1799), "Patiala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("90e06d9d-cc33-4f0d-a994-e1e54be1f1ca"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(666), "Bengaluru South", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("91473870-5547-411e-b07c-3c7a96852163"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3124), "South 24 Parganas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("919ac143-fc7f-4d85-801b-4db6ba3d1e88"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1401), "Eastern West Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("92519955-0e39-4137-8930-8baa53046170"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3031), "Paschim Bardhaman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("9253ac64-5ef0-4a3d-bfbb-92e0014a9d6e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9268), "Tirupati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("92b1654e-8981-4fe9-89ec-e1f43485ad39"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2096), "Gangtok", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("92c7d66d-115f-4554-9da2-f10f10fefe59"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1535), "Tuensang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("92d42f55-f5dc-498c-9cbd-572baf964a3d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1557), "Balangir", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("92d721ee-5315-4490-b64f-44734e96ce7f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1826), "Tarn Taran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("92dbc434-08ee-4386-a1af-ad0e1be9cd99"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(422), "Dhanbad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("92dcecbc-eeac-4c05-ac38-eb74f57fa413"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3011), "Udham Singh Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("935c2387-318f-4f90-a4ac-8102c31fec7d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(525), "West Singhbhum", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("938fbbde-6da7-4294-bd30-717c92e529fa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2828), "Mau", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("939a82ad-cbd2-433d-9ab4-b0d43b79497f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1649), "Kendujhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("93cd79b2-0624-4e64-a323-611f5cfe59d4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(635), "Kodagu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("93d5b880-561f-4ddf-b0dd-bb1f52fa89da"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9190), "Guntur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("93ea3e2b-3afc-4620-ae9d-6295c4bb4cb3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9322), "Kamle", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("94436a10-8897-4c1e-bf31-a9ed2d3cf495"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1999), "Jodhpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("94d0622b-815b-4f65-9da9-3b196ac34471"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9784), "Saran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("95699c06-fbc0-49e1-ba9f-2ad3ad37c422"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2881), "Saharanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("957e4115-6e2c-44b8-b0e9-efbfeee3e123"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2190), "Karur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("96999709-88d1-4bd2-b24e-6e2cf9e47c43"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2476), "Shamshabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("96e20dfd-2eb1-4ae2-8b36-bbcda3a41230"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3221), "Pulwama", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("96f77994-1a2e-4fb3-885a-0fc1d523667f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1795), "Pathankot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("97104c2f-3c7e-4520-97ba-920fb4ed4dd1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3199), "Ramban", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("9748a88e-101e-4f52-9725-0cb98a00adeb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3137), "Uttar Dinajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("9776dcee-f8f8-4057-9996-a04ab95d3794"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9441), "Biswanath", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("978fa973-6730-4d91-87d5-9029dce764f5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2532), "Unakoti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("97ad732f-ce07-4fe8-9d46-ff2589450e9b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(576), "Chamarajanagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("97adb500-d95b-4052-996d-58dc89088d49"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9593), "Tinsukia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("97faafd1-0ab0-465c-8b51-f3d6d245ad53"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(585), "Chikkaballapura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("98331f16-4fac-480b-a438-10a7623b280f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2734), "Hardoi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9867a55d-79be-4ada-9065-f5d4c802738c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3053), "Darjeeling", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("987eb309-228d-4a93-a46d-0e65e0d402ed"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2604), "Bahraich", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("98e7e9b3-f62c-4799-862e-490c7be7e178"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(129), "Junagadh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("98f27258-1aa9-41dc-9246-c6bc6af70669"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9313), "Kra Daadi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("98ffd9cb-5027-4de2-890e-b5b627e3d443"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3287), "Drass", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("993b93b1-17d7-470e-ae19-70f1b98c11f6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1211), "Jalgaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("9a482976-bdc2-418a-a5ce-c48ede5f8ba8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(720), "Kasaragod", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("9a484ec8-c704-4aa0-8cec-8eadc03611f2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9696), "Kishanganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("9aef2439-4d43-4e8a-b9d1-b074f7b45336"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3132), "Purulia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("9afcaa55-bc7f-4d2b-b39c-fbe36ff71c38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2922), "Sitapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9b01a63e-dd56-467f-a7dc-7b6b1a9e1f33"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9644), "Buxar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("9ba10b43-134a-4edd-a016-e2ef7ab2917c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2775), "Kasganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9ba343e6-c26e-482c-a352-c13dcbd35d3d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1969), "Jaipur Rural", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("9bc7af0d-9ea0-4ba2-a7ad-02ccada85eb5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(557), "Belagavi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("9c274741-c3a7-4e5c-a119-31476afb88c7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3204), "Kishtwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("9c75eb41-8de9-46a2-a8c8-95c3a51e7cea"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1876), "Dungarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("9c915ce3-7eeb-4cba-871e-1fc7446e72b6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9639), "Bhojpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("9c9d30bc-0cb9-44aa-99f6-a91156548e72"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1316), "Senapati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("9ca4e162-599d-43ee-8328-cc37e82f6848"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2486), "Narayanpet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("9da64bd4-1262-4353-aed6-1f86752e58ce"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1113), "Buldhana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("9dcc63ba-118b-4f40-acba-31ea3ea52d44"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2926), "Sonbhadra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9e469c51-fa0b-477b-9df9-2adae98e7471"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1946), "Sri Ganganagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("9e92836b-35ca-48d5-ac4e-d484842d58ea"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3067), "Howrah", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("9f258eac-d247-4dab-aa7e-0eee81e2e383"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(755), "Thiruvananthapuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("9fad7ffa-0a70-4dcb-9f31-573b89b29f91"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(626), "Hassan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("9fc1339e-7fa3-4b6a-9ccf-c318127eb816"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9258), "Nandyal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("9fc6ebcb-7f47-4a2a-9c51-402377f8f5fb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9742), "Nawada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("9fd0e2c4-ce39-4472-ba1a-a4744b4c7fe6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9291), "East Kameng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("a035c3b9-04e4-4139-a312-704ca9f1875b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2422), "Mulugu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("a03d1f8a-bd4f-4b34-b85a-d2daa3087807"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9524), "Kamrup", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("a0608443-46b4-494a-a89a-9f1f275ee263"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(372), "Kullu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("a0c80115-e5a7-4fe7-82ee-945e0b6ce8f5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9488), "Dima Hasao", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("a1c56090-8bc0-4911-a69b-6291ef24cd84"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(999), "Sagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("a21737c5-3aca-4414-8288-a259b08132a1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9176), "Dr. B. R. Ambedkar Konaseema", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("a23ab514-274d-477f-a0f7-974c63eacd38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(492), "Pakur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("a28ab28b-6845-49c4-a3af-ff2ebbf4c351"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(956), "Satna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("a2c40537-b5e9-4f62-9bdb-9fe954b7e830"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(775), "Raisen", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("a307603f-b69a-49a9-8200-e5990bf210e5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1699), "Sambalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("a3616620-8a94-41c4-b494-e4cd1a04d7fb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9774), "Sheohar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("a39da71d-0f90-49d8-88b7-4718055d719b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9335), "Upper Subansiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("a40979f8-10af-4d56-9b19-42aa8ebe70a2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(885), "Khargone", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("a4a26394-6777-46dd-9306-11e8ec98743d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9498), "Golaghat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("a4f55c28-8ec3-4400-a8ae-584038492dc4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2646), "Bulandshahr", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("a5d59250-633b-415b-a82b-a86985eda05c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1154), "Latur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("a68b07fc-3c85-46ae-9e9c-1783629d43d9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1540), "Wokha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("a7146389-d8ad-4ac3-963e-1a198c20dceb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9917), "Mahasamund", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("a7c30c88-b244-4715-af19-224c5cc90673"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2900), "Shahjahanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("a811ef46-8027-4826-a9fa-e04471ce9899"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2045), "Sirohi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("a907c32d-4bb9-4403-a639-2b941e2ddb94"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9571), "Sivasagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("aa0ef7ec-4995-4ddc-bb9a-7f47573d4596"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9390), "Anjaw", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("aa35a520-cdac-4ac9-84c5-d8ce2c82bc10"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2273), "Thoothukudi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("ab70282d-8c5f-402d-a02f-c5d398cad63c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2580), "Amroha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("abba258e-c69a-4627-b2d5-a458fd7f761f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9427), "Baksa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("abc638d3-f2c5-4d24-b482-ac3ab61a1866"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9870), "Gaurella-Pendra-Marwahi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("abe37e57-c224-4113-87a3-dd2990b34286"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3244), "Bandipore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("ac79eaaf-7907-4b34-b701-00435ddad60c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9806), "Vaishali", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("acd3f29b-7f22-4d1a-a4b1-d1b5fbcc45e4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3110), "Murshidabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("acf9cff7-bc30-4ffe-ae05-f892176cc27e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1764), "Kapurthala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("ad616529-e0f1-4140-a48b-910607e5ed30"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1960), "Dudu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("ada1c86a-fdee-4ae0-af05-0aa6b1bff9c4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2765), "Kanpur Dehat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ade9c5a8-1c5f-44fe-a57e-67ae2869aa10"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(413), "Chatra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("adeaf049-39c1-4808-94f8-f65a74e9f4e2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3323), "New Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("ae2a0ab5-50ca-4f9f-becf-651609f70a0a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1243), "Raigad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("ae3f7b78-944c-4b7f-bcb3-83a7fee9658c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2779), "Kaushambi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ae79b59e-5581-4b0e-b329-6e44b83cdced"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9715), "Madhubani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("aec2d118-5044-48c6-92d5-e080357e5dbb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1476), "Dimapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("aeebc066-f751-4218-b8c2-148c2f742fef"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1591), "Dhenkanal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("aefdd1ca-c9a6-4538-afdf-ea7c5908c3be"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(716), "Kannur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("af381b77-551b-4e31-95d0-d13f2b6923fe"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1562), "Balasore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("af67d5e6-b5e5-49ac-85d5-072f870cd6d7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1253), "Sindhudurg", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("afe0a341-dab2-49ff-9ead-b15a470ce1a0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9898), "Kondagaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("b05ab325-0c0c-4c7d-bda1-a428e2915f57"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9634), "Bhagalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b07bea01-34f3-4695-9090-d25ef9398fa1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9701), "Kaimur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b16733f1-2722-4810-9dbb-58abd73eab7f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1928), "Anupgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("b18d7d3b-05f3-4f58-ab5d-099aa1e3fe38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1653), "Khordha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("b288c8aa-e00d-4923-ac43-aec612b67225"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3349), "South Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("b2bc97d0-91dc-4a05-8a4d-b182181c793c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3235), "Srinagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("b3f7d910-f7ca-4207-a014-afd77e2672fc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1353), "South Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("b495ac4e-e226-463c-be91-779fad7a5f89"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(261), "Jind", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("b49c2d8b-228a-4c96-9b9f-c2499a2c572e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3152), "Diu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), true, null, null },
                    { new Guid("b4d0ddfe-fae3-4efc-8345-3b55cbb62a38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9653), "East Champaran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b4f6e647-a399-44d4-b1d6-89318539f90e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9588), "Tamulpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("b51a6452-b958-436e-a09b-7e0a1d558dda"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(437), "Garhwa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("b53d7088-0452-478c-aed8-1460dd5c91a9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2891), "Sant Ravidas Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("b581a89f-12e2-4cb6-95a2-ee9275a1d3d9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(317), "Rewari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("b5bcc04b-4586-40b6-942b-70cc603e9a27"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9876), "Janjgir-Champa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("b60d454f-7f24-435e-a6ff-ec32ced03ba5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9737), "Nalanda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b73d033a-b99c-4675-bc9c-b101c0777d6e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(689), "Vijayanagara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("b75aa14b-2798-4007-8283-6ed8a5d2c9db"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9866), "Gariaband", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("b7775d10-6996-46f9-bbe6-1caea7e4e2cc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3390), "Lakshadweep", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"), true, null, null },
                    { new Guid("b7e58bd1-371d-4850-be60-3807abfe1bd0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1454), "Saitual", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("b7f78193-09e3-4e8e-bb6e-82ef8ddfff60"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1708), "Sundargarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("b8ec0041-2165-4c0b-a7c2-7c99f6a1de3d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9648), "Darbhanga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b9196281-0ee7-4d8b-b44a-68050772c01e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1490), "Longleng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("b921d75f-d18b-400e-b95b-79ed43fad761"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2297), "Tiruppur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("b93ad77b-0da3-4f5a-9714-d4455d8471b9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9171), "Bapatla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("b9d9f4dc-4619-4777-939b-c6b9867d6fa1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(654), "Mysuru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("b9fb21c4-c97e-44da-862e-bf8c3463fc86"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9552), "Majuli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("ba8369ed-61a5-4ee5-8973-f51d0d0c3066"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(842), "Guna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("baa3e9f1-b44c-4161-ac6b-a958e9b1188d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2976), "Nainital", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("bac4d75e-0f55-4a59-9a6d-e2f945a95224"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2663), "Deoria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("bae8dd9d-21f5-40a7-8934-df41a00a7027"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2549), "West Tripura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("bb441c90-74ef-4f9b-a5d8-5f59a087cc8e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1367), "West Jaintia Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("bb8fc63c-0eba-4648-9a60-2674fc750b1d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9943), "Raigarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("bb931a74-e9c5-45a2-8486-3c424449acf7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1170), "Bhandara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("bc16cf1d-1772-4ef7-8053-01a0a36d77e1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(266), "Kaithal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("bc205a16-cdcb-448a-ad58-0b91fc0c4f54"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1633), "Kendrapara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("bcfa77a5-a832-40a7-905c-48a4da149eb1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9456), "Charaideo", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("bd521815-80a2-4143-b3aa-4303aa81cc46"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(454), "Gumla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("bd9afa94-e332-4a9e-bf12-1f8ba68ad229"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(432), "East Singhbhum", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("bdaae257-4948-4820-a55a-d91adce62b08"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1311), "Pherzawl", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("bdb4ff9c-4c86-4bef-b1d7-9440ca667abd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1955), "Dausa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("bdd693e3-9b29-4f79-8c97-517dd135e25e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9723), "Munger", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("bdeb2673-6d2f-40c1-9af7-bf8aececd38a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3048), "Cooch Behar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("be2215b0-0d5e-4dc2-a1a8-5b266aa5fb01"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(973), "Mauganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("be6a99ea-c96c-465a-be09-bc065735f573"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2330), "Virudhunagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("beb1f098-054c-45be-ae37-77763d4edb6e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(770), "Bhopal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("beb47228-ac06-41f5-8319-4c5d2819ddad"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(802), "Sheopur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("bf4bdff4-0b8a-4598-b8df-251ed6565740"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2498), "Nagarkurnool", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("bf65afba-9f87-4a57-a0e9-b941439f0363"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9706), "Katihar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("bfce6f01-802b-4e1e-8813-463e04c91167"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3016), "Uttarkashi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("bfd9f049-a0a0-4539-b471-81c62c0d8b6e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(496), "Palamu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("c162b730-9225-4d87-8822-83efaa48995b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3007), "Tehri Garhwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("c19092fb-1408-4b7c-8b55-8082bf61ea33"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9421), "Longding", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("c22e3feb-0b71-4949-9cb1-eec6c347372c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1229), "Thane", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("c32e3608-eee2-47ef-b92b-2761dc07c893"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9339), "Shi-Yomi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("c330167e-47ec-418c-ae0e-bb91fdc2836d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9394), "Namsai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("c34b3c7b-be59-4767-8e4e-df4d685016ee"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2686), "Firozabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("c360afd9-234c-465a-9dfd-38216f977b61"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2389), "Sangareddy", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("c367a3ac-bee6-481e-8634-cef5c01cf1e9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9788), "Sitamarhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("c44abe2b-bca7-4f78-a0fc-8580d67be335"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2803), "Lucknow", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("c56700f5-c08f-4e24-baf3-7300d9217738"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2440), "Suryapet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("c5772271-20ee-4f81-baca-65ae3c2a935d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9580), "South Salmara-Mankachar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("c57ce6e1-73ae-4507-a6dc-32fb89697160"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(852), "Barwani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("c5bac622-d209-4900-b3e2-4cb21b9647e9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(760), "Thrissur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("c5d63bb2-81d6-44eb-8074-1068f9ec684f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2198), "Krishnagiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("c5e0a46f-494b-4c4d-ae12-502ee93ae7d7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1678), "Nayagarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("c65b691e-3494-46e5-9018-d213c794a320"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2668), "Etah", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("c74ba30d-54c4-42e3-a891-992f72add401"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2677), "Farrukhabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("c7528018-9584-490f-bb6f-f5ce951c4465"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2178), "Kanyakumari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("c855b6e9-7b4d-4aaf-855b-042dc85c085b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1280), "Imphal West", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("c8855290-7fe0-40ac-9e56-b2c23d72f2bf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3367), "Karaikal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("c8d49f50-95ba-4c96-8095-c59820f8bbfb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9820), "Baloda Bazar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("c8d8544b-fedd-4bd2-b197-617796d85496"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(174), "Patan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("c92acb1b-d49f-4be3-8bc7-db3edcfab1a6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(915), "Narsinghpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("c96b9959-fd33-4d16-959f-a89fec547eaf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3156), "Kathua", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("c96f7230-5e3c-4c92-a51a-05d7c7031536"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2408), "Jangaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("c9c13f5b-714e-4418-b903-94526a6af626"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9249), "YSR (Kadapa)", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("c9db1296-d9b7-4cf2-9c99-60228e373b53"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2651), "Chandauli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ca1113db-7ab3-484e-b326-ea3500fe7d20"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2655), "Chitrakoot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ca27a444-76f3-4939-b84d-bcb7aa8cc987"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3226), "Shopian", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("ca5d116f-6088-4d43-8ced-97ca988cc616"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9889), "Kabirdham", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("caa5738a-fc5c-440f-841b-8471d214c8bd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1713), "Amritsar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("cb3a1d8c-2d74-4df7-8f81-dbc768f257c5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9881), "Jashpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("cb4d13b8-0fc6-4eb7-8ac8-53fcd1aa0d78"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(510), "Sahibganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("cb710200-de0c-4d1c-8f21-a8ae06878870"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(381), "Mandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("cb9562d3-827a-44ee-bce2-940c897eb587"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3268), "Leh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("cbbfab38-f082-4505-a580-e7ad267f84d6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2895), "Sambhal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("cbffa9ce-e7d2-45a7-822e-a2fc30694af4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1549), "Angul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("cc111329-4e7c-42e7-8647-63b4bb4f93c6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2708), "Gonda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ccaa473a-429a-4a82-b749-a213227db154"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(206), "Tapi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("ccf1d83d-4af1-43b8-b395-3a3fe875a881"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2141), "Coimbatore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("cd153be3-18ec-4ea0-a99b-2ab07b6f964a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9236), "Annamayya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("ce8710f5-8281-4993-9ebc-88ad76e81ee9"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1197), "Wardha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("cec3ea00-5519-48b6-a15a-22e93aa98e06"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1017), "Anuppur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("cf879b8b-0ee0-4500-81b1-0348120870f2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1144), "Osmanabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("d0474187-0861-419f-9f94-2ea12d6feec2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3382), "Yanam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("d0739ec7-5ddd-4b3e-b543-14bc669c5f4b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(640), "Kolar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("d0b532fe-b5e1-4351-a17b-1c5834116b81"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(604), "Davanagere", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("d1297060-c846-47dd-a0e8-6d68c14a823e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2508), "Gadwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("d1cb9f64-025c-4800-bada-6aac82a6faab"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2344), "Mancherial", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("d2a16db2-e24e-4205-80d9-a5568ef6f512"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9124), "Alluri Sitharama Raju", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("d2c2d5dc-0169-4a3b-aee9-5e08829b963e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9779), "Sheikhpura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("d3981e67-254e-4cf0-be18-f800b6b7882a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1503), "Niuland", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("d3d16bb5-fc01-4522-bcd3-b1c42080ed91"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1899), "Dholpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("d3eb751d-ced9-42c7-be18-5f747fe51945"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1285), "Jiribam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("d42a2317-65f6-4157-a8e4-3da63708ef1d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2222), "Nilgiris", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("d499f374-fb7d-4eaa-942a-ef389e43abc6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(946), "Narmadapuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("d4d63d2f-9d9d-4b54-b425-555b587f9f9c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2158), "Dindigul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("d6b9a409-1d7c-4315-a666-a16a484542fa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9691), "Khagaria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("d7a8ec3b-5ed5-4574-afd8-5d675020fa6e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(115), "Gandhinagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("d7b2b1b6-9359-4d9b-bd46-0d910ac9d925"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9137), "Parvathipuram Manyam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("d7b369de-99c6-4d8c-b39c-e77596974d57"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(890), "Balaghat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("d7bf642e-0077-46fb-b4f7-5dba4a86b6c0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2269), "Theni", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("d846bffd-ab2c-48d2-a33b-be00e46e3001"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2713), "Gorakhpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d887694d-c33a-43c5-9b06-d9f3708bb1c7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1331), "Thoubal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("d8afcfa8-2dc0-4763-b09d-5840d02381a6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2539), "North Tripura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("d8ccf5e1-df65-407c-b978-82f17dfb26fc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2770), "Kanpur Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d8e7468c-01b9-47ad-b292-8758ab62b15f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2792), "Lakhimpur Kheri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d9258ddb-fbd7-40c8-b2e1-6ba40420244c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9344), "West Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("d94410e9-6fff-4655-8aba-7f3d345c2c7b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1668), "Mayurbhanj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("d9a4d04d-0300-45ce-9cf1-ca20335dba76"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1485), "Kohima", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("d9b3b7a6-de59-44b7-857b-8f36f56b3531"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1986), "Balotra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("d9fbf31a-4608-4119-9882-ba35694ca714"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1973), "Khairthal–Tijara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("da366421-536f-44d0-82f9-83cad6a43942"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1804), "Rupnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("da6a370d-73ee-4146-b165-c79ebd51afa6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(927), "Dindori", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("db914abb-9b70-49ad-9e57-59257ceaa444"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1079), "Solapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("db9440a1-60fb-4a76-bdc9-d49744370f3e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3041), "Birbhum", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("dc35494f-f44d-4f95-b12a-376ab9efd518"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9908), "Korba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("dc57521f-2229-4981-afc6-d21cbef1440c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1964), "Jaipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("dcd6d600-f436-4d96-ad54-6085bc60a1cb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(292), "Mahendragarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("dce29785-a965-4fd1-b5db-24c9c0c7cdc5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1294), "Kamjong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("dce4c802-104b-4c4a-8a9d-5309d1389cac"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(922), "Seoni", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("dd19f681-7ade-46ae-9ef4-41afd4210f7d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(684), "Uttara Kannada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("dd20a73f-c22b-44b9-8266-bfdd8b748005"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2059), "Jhunjhunu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("dd4f40a9-5e4d-409f-a480-4075ca31a259"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(391), "Sirmaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("dd8f51e9-4a9c-4b78-b43c-f2a5defd49d2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3058), "Dakshin Dinajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("dda1f63d-aab1-48a4-a2f6-624d0b57f65a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9286), "Bichom", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("ded1a075-78b2-4766-8060-5b6c47e926ca"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9671), "Jamui", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("e00ebf10-d0b6-486a-946f-15a98b3d796a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1083), "Kolhapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("e01bd61b-d590-41a8-85e4-6fa8f4ee165e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(806), "Bhind", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("e10d50cc-2a08-4c0d-9c08-64e01a30f6a2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9825), "Balrampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("e14f1a22-5b13-4575-b488-c79f05b20e38"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9663), "Gopalganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("e1a31da5-eda5-4175-9905-93a858cbaf54"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(88), "Botad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("e1bc7036-830b-47b5-99f7-30c2a79bb8c3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9385), "Lohit", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("e25fac62-0dcc-4ea5-9549-98223e509db3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2019), "Bundi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("e29dad72-f06e-460a-afeb-d392565eb1fa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9757), "Rohtas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("e2a7a135-30ea-4967-8cf4-ef7f4cf52f7d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3394), "Malacca", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), true, null, null },
                    { new Guid("e2b3d1bc-ee17-42f7-9462-6454261ea2f8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(618), "Kalaburagi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("e322b46b-3a50-499b-974e-732c2b3b24db"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3166), "Samba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("e37ac409-0fc5-43b7-b0f1-bfaf438bc757"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2962), "Champawat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("e4bc7bcf-ad51-4f0c-a812-93eb287f4ac3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(74), "Banaskantha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("e5690953-064f-4219-8482-ff570b681285"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(297), "Nuh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("e575f1c3-1535-41de-8025-bf87b1fa5f7c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1682), "Nuapada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("e5a42c89-64d4-4e38-be79-92f984b40bf3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2153), "Dharmapuri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("e5c75a7d-cbfc-4b41-aa83-66dba1dbec36"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1776), "Malerkotla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("e5fbe30b-485e-4c85-b206-57672af1c446"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3115), "Nadia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("e600259f-92a5-4e0e-863a-e414ae5d423b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2292), "Tirupathur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("e68c876d-4ef0-4a9d-aec2-1423a14e19ac"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9132), "Anakapalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("e692d2c7-bfa1-43cc-af59-cd14fd19a5cc"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3142), "Dadra and Nagar Haveli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"), true, null, null },
                    { new Guid("e70b74fd-62d1-4abc-87c2-1820de1e657e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2751), "Jaunpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("e8413506-d324-4fe9-b741-d74e05cc9916"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2325), "Viluppuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("e8d442c1-7bca-428b-a64b-ce864c115f1b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3256), "Kupwara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("e959f3b6-130c-42e8-8597-f4cede741c59"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2614), "Balrampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("e963a36a-fe94-4ee8-b7b5-c002b4c578b8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1812), "Sahibzada Ajit Singh Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("e9a95d24-c672-4d38-bf5c-2c26af308ac2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(631), "Haveri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("e9b1f64b-1cff-49c4-982b-658019e33eb1"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2072), "Sikar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("e9ced055-7e55-4af1-a807-991a90ab53c6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1867), "Tonk", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("ea2fc4eb-b4f4-4c58-aad3-79a541379c92"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9922), "Manendragarh-Chirmiri-Bharatpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("ea870674-88c0-42f1-9c08-22ab4a86804e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9548), "Lakhimpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("ea87f438-dadf-4f0f-8f09-90f6adaf42d5"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1516), "Peren", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("eaa21189-522f-40af-a7d2-b94ef2af0ed2"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9300), "Kurung Kumey", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("eac8813f-b7f8-4e90-957c-56d8b149963e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1248), "Ratnagiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("eb2e88cb-ce94-49c9-895a-274c28189eba"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1183), "Gadchiroli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("ec2db9d3-7b16-4e5b-ac1f-5c5419198efa"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2935), "Unnao", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ec46e490-cfa5-4438-85e2-8af87e3b5ae0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2590), "Azamgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ed174c7f-1bdf-4c70-9e8b-76c35778d88a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2739), "Hathras", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("eda3ce79-92ad-45be-a656-a50c86489a58"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2522), "Khowai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("edd3661c-789f-4f71-90ec-7fa95a69d192"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1091), "Pune", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("ee20d9e1-d8f1-4afd-bab7-1675384ff402"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(614), "Gadag", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("ee9262c5-b0dc-4795-b574-5cf790f1fa7d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1234), "Mumbai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("eea0c7e5-161b-4f4b-b761-1fa32080ea4d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1745), "Fazilka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("ef69a790-e8d2-458d-b59a-cbb7fddcd3c3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(537), "Bengaluru Urban", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("ef778a4f-98a6-4ffe-9216-dd3e158d95b4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1938), "Hanumangarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("efa9fef2-7dea-44dc-adc0-90faa41448cf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(202), "Surendranagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f00d122f-b9f1-41d1-8d07-579628b53501"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(857), "Burhanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f052f607-120c-4ee2-ba6d-9aaa44c18237"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2349), "Nirmal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("f064653c-d1b7-4a41-9052-76a17948db1f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3358), "South West Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("f0ae79b6-b1bd-41f3-a389-aab57443987f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2931), "Sultanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f0be300b-2e55-431c-8e18-ea695abb9f5d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(532), "Bagalkote", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("f106865c-3749-4ffd-917e-6dbcbce34626"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2527), "Sipahijala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("f135235d-14b9-4b66-a92a-579bb66661b6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3021), "Alipurduar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("f1f44ade-1094-47a3-8937-090e10a23be8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(78), "Bharuch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f20e46d1-702d-4fad-92d7-00cd9e7b835d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2722), "Hapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f22a0760-5591-4267-a257-efc678308ca0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3194), "Doda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("f2c4c95b-9bd0-4157-9a50-8c6633cba3ba"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(765), "Wayanad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("f2d179b8-1c1b-4c1c-8c73-6fd836b2f8b0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2334), "Adilabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("f2d22600-cad8-4fed-b340-991b4c9b78f6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(599), "Dakshina Kannada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("f323fde4-5a93-4061-aa70-158c85014a88"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1307), "Noney", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("f34282fc-327d-46f0-b120-4c8470e443dd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1468), "Meluri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("f3489228-8984-48d6-a648-e0118c25a332"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(649), "Mandya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("f356aafa-c50d-4d30-bcef-e2736a3e2085"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(151), "Mehsana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f3a0a967-ef6b-4a7c-8f94-bed89a1d97c6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(932), "Pandhurna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f3e1e4a7-4f38-4753-8bac-259cbd9633a8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(847), "Alirajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f3fd63f3-1c7a-4704-bf60-7a7c325b4da0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9317), "Lower Subansiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("f41d1e5e-dae2-421e-a9ff-fcc9021d33f6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2307), "Tiruvannamalai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("f4489726-e06a-4645-8896-afa9a8aa8d9e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1275), "Imphal East", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("f581311d-0640-4cf1-839a-9b3af66ffdf4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2818), "Mainpuri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f5d18bf6-d6d8-470b-bfe9-6cf7ba9aec7a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2014), "Baran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("f5d2f527-3b1a-478e-9d3e-4c708e268e7e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2503), "Wanaparthy", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("f61a77df-525a-489c-ab5d-b5d09c4e3fa7"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(354), "Hamirpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("f6a2afb9-80be-4317-8a6a-69fc0fccef24"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2122), "Gyalshing", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("f6a4aad2-d67a-4ee1-857d-e173c714bf17"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9431), "Bajali", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("f6a94210-c33c-4a5e-a099-68154a732494"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(192), "Sabarkantha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f72d6efd-2831-4214-a75b-ceb82df1dc58"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2055), "Churu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("f732bc3c-3077-4625-be52-e2096cac5f82"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2490), "Mahabubnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("f7354f90-876c-44ef-82b6-3b865938e9e6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1270), "Churachandpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("f73568fe-7bd9-4e88-b213-9e55dd772c0c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(780), "Rajgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f786eaa3-58c8-4c77-9132-7d2705cb0283"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(93), "Chhota Udaipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f80c572f-a685-4db2-932e-d2629ff8eae0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(345), "Bilaspur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("f81df8fb-6bb8-41f2-9c11-d856900fb53a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(52), "Ahmedabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f827255d-d599-42d4-a7bc-65e18a36bafb"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1022), "Shahdol", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f8335fa6-b1a5-4574-a111-12128218f963"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2036), "Jalore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("f86cac36-8766-4562-8049-678217a8c7e0"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9376), "Dibang Valley", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("f873eb32-8319-4756-ba69-687a6d0d1e18"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(179), "Porbandar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f8ab5b09-99a4-4f2d-86d2-92b79ee87fb6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(978), "Maihar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f8da12e6-5c43-4436-b8da-75ebcdfc680a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(867), "Dhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("f91d2655-3b2c-427c-944e-428eaad55730"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2207), "Mayiladuthurai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("f9f37efa-95ed-4cb6-bed4-4dfa1bb1e2f3"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2400), "Siddipet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("fa2ddcc8-11b2-4668-a661-1fe38d4ad22c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2339), "Asifabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("fa8973f6-a0b9-4525-af8c-af21eca0e015"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1614), "Jajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("fa9020b7-25c8-4aa1-ac63-88c69015bccf"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3101), "Paschim Medinipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("fac8103f-4b78-48ed-92b9-41337dd32093"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9557), "Morigaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("faf3522f-e8e5-4ec0-9e72-49f9daaa943a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1388), "West Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("fbe7a122-9992-4fd9-b0b6-0bab5703292a"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1990), "Barmer", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("fbead730-75d1-44c8-8e34-e5bf08bb0fcd"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(14), "Sarangarh-Bilaigarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("fbf395ca-59a6-4bf4-8856-624abf05c92b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1741), "Firozpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("fc37fec7-d066-4af1-af26-efdc9cd3d83f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9602), "West Karbi Anglong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("fc5ee999-1a08-4bc6-83b0-ff3b10461b36"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9912), "Koriya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("fc88db9e-e0c9-4d60-a4a9-fbd1f67b4e4e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2132), "Chengalpattu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("fd532902-793d-4f3b-9cfd-70a69797eb7d"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2844), "Moradabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("fd77d3a7-7efa-4322-b3e4-de2fb754692e"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(1581), "Cuttack", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("fda097a3-409b-4dab-aa80-167985ff6f94"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2622), "Banda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("fdb5a6d1-4f1b-4a18-a7fd-075b1eaaa2c4"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2302), "Tiruvallur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("fddfa09a-2c34-429c-b1ea-96f6d822c61f"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3077), "Jhargram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("fe9ab24e-b821-4fa6-b5c4-647c1ccc2e73"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3161), "Jammu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("fecb9254-c2d7-495c-9e43-c97c2d5515e6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(787), "Sehore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("fed6c05f-e73d-4842-950f-3b5a0133e78c"), null, new DateTime(2024, 12, 13, 5, 43, 17, 446, DateTimeKind.Utc).AddTicks(9793), "Supaul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("ff1d89d9-975c-4223-aef0-92bce9e9528b"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(2835), "Meerut", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ff2ce6ef-5d8c-4ad3-bd55-7e6d00de53d6"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(905), "Katni", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("fff7ebcd-e7ad-494d-afac-56aec8e75fc8"), null, new DateTime(2024, 12, 13, 5, 43, 17, 447, DateTimeKind.Utc).AddTicks(3096), "Malda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Fk_CountryId",
                schema: "dbo",
                table: "Address",
                column: "Fk_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Fk_DistId",
                schema: "dbo",
                table: "Address",
                column: "Fk_DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Fk_StateId",
                schema: "dbo",
                table: "Address",
                column: "Fk_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternateUnits_FK_ProductId",
                schema: "dbo",
                table: "AlternateUnits",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternateUnits_Fk_UnitId",
                schema: "dbo",
                table: "AlternateUnits",
                column: "Fk_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Fk_TokenId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "Fk_TokenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFinancialYears_Fk_BranchId",
                schema: "dbo",
                table: "BranchFinancialYears",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFinancialYears_Fk_FinancialYearId",
                schema: "dbo",
                table: "BranchFinancialYears",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Fk_CountryId",
                schema: "dbo",
                table: "Cities",
                column: "Fk_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Fk_StateId",
                schema: "dbo",
                table: "Cities",
                column: "Fk_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Fk_BranchId",
                schema: "dbo",
                table: "Company",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_BranchId",
                schema: "dbo",
                table: "DamageOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "DamageOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_LabourId",
                schema: "dbo",
                table: "DamageOrders",
                column: "Fk_LabourId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_ProductTypeId",
                schema: "dbo",
                table: "DamageOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_BranchId",
                schema: "dbo",
                table: "DamageTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_DamageOrderId",
                schema: "dbo",
                table: "DamageTransactions",
                column: "Fk_DamageOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "DamageTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_ProductId",
                schema: "dbo",
                table: "DamageTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyOrders_Fk_BranchId",
                schema: "dbo",
                table: "InwardSupplyOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "InwardSupplyOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyOrders_Fk_ProductTypeId",
                schema: "dbo",
                table: "InwardSupplyOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_BranchId",
                schema: "dbo",
                table: "InwardSupplyTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "InwardSupplyTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_InwardSupplyOrderId",
                schema: "dbo",
                table: "InwardSupplyTransactions",
                column: "Fk_InwardSupplyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_ProductId",
                schema: "dbo",
                table: "InwardSupplyTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalOrders_Fk_BranchId",
                schema: "dbo",
                table: "JournalOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "JournalOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_BranchId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_JournalOrderId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "Fk_JournalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_LedgerGroupId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_SubLedgerId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_LedgerDevLedgerId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "LedgerDevLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_LedgerId",
                schema: "dbo",
                table: "JournalTransactions",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourOrders_FK_BranchId",
                schema: "dbo",
                table: "LabourOrders",
                column: "FK_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "LabourOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourOrders_Fk_LabourId",
                schema: "dbo",
                table: "LabourOrders",
                column: "Fk_LabourId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourOrders_Fk_LabourTypeId",
                schema: "dbo",
                table: "LabourOrders",
                column: "Fk_LabourTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourOrders_Fk_ProductId",
                schema: "dbo",
                table: "LabourOrders",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_BranchId",
                schema: "dbo",
                table: "LabourRates",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_FinancialYearId",
                schema: "dbo",
                table: "LabourRates",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_ProductId",
                schema: "dbo",
                table: "LabourRates",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_ProductTypeId",
                schema: "dbo",
                table: "LabourRates",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_BranchId",
                schema: "dbo",
                table: "Labours",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_Labour_TypeId",
                schema: "dbo",
                table: "Labours",
                column: "Fk_Labour_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_SubLedgerId",
                schema: "dbo",
                table: "Labours",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_BranchId",
                schema: "dbo",
                table: "LabourTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "LabourTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_LabourOdrId",
                schema: "dbo",
                table: "LabourTransactions",
                column: "Fk_LabourOdrId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_ProductId",
                schema: "dbo",
                table: "LabourTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_Fk_BranchId",
                schema: "dbo",
                table: "LedgerBalances",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_Fk_FinancialYear",
                schema: "dbo",
                table: "LedgerBalances",
                column: "Fk_FinancialYear");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_LedgerDevLedgerId",
                schema: "dbo",
                table: "LedgerBalances",
                column: "LedgerDevLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_LedgerId",
                schema: "dbo",
                table: "LedgerBalances",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Fk_LedgerGroupId",
                schema: "dbo",
                table: "Ledgers",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Fk_LedgerSubGroupId",
                schema: "dbo",
                table: "Ledgers",
                column: "Fk_LedgerSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgersDev_Fk_LedgerGroupId",
                schema: "dbo",
                table: "ledgersDev",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgersDev_Fk_LedgerSubGroupId",
                schema: "dbo",
                table: "ledgersDev",
                column: "Fk_LedgerSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroupDevs_Fk_BranchId",
                schema: "dbo",
                table: "LedgerSubGroupDevs",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroupDevs_Fk_LedgerGroupId",
                schema: "dbo",
                table: "LedgerSubGroupDevs",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroups_Fk_BranchId",
                schema: "dbo",
                table: "LedgerSubGroups",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroups_Fk_LedgerGroupId",
                schema: "dbo",
                table: "LedgerSubGroups",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyOrders_Fk_BranchId",
                schema: "dbo",
                table: "OutwardSupplyOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "OutwardSupplyOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyOrders_Fk_ProductTypeId",
                schema: "dbo",
                table: "OutwardSupplyOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_BranchId",
                schema: "dbo",
                table: "OutwardSupplyTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "OutwardSupplyTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_OutwardSupplyOrderId",
                schema: "dbo",
                table: "OutwardSupplyTransactions",
                column: "Fk_OutwardSupplyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_ProductId",
                schema: "dbo",
                table: "OutwardSupplyTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_CityId",
                schema: "dbo",
                table: "Parties",
                column: "Fk_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_PartyType",
                schema: "dbo",
                table: "Parties",
                column: "Fk_PartyType");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_StateId",
                schema: "dbo",
                table: "Parties",
                column: "Fk_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_SubledgerId",
                schema: "dbo",
                table: "Parties",
                column: "Fk_SubledgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_LedgerId",
                schema: "dbo",
                table: "Parties",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_Fk_BranchId",
                schema: "dbo",
                table: "PaymentOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "PaymentOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_Fk_BranchId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_Fk_FinancialYearId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_Fk_LedgerGroupId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_Fk_PaymentOrderId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "Fk_PaymentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_Fk_SubLedgerId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_LedgerDevLedgerId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "LedgerDevLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_LedgerId",
                schema: "dbo",
                table: "PaymentTransaction",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_Fk_ProductTypeId",
                schema: "dbo",
                table: "ProductGroups",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_Fk_ProductionOrderId",
                schema: "dbo",
                table: "ProductionTransactions",
                column: "Fk_ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductGroupId",
                schema: "dbo",
                table: "Products",
                column: "Fk_ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductSubGroupId",
                schema: "dbo",
                table: "Products",
                column: "Fk_ProductSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductTypeId",
                schema: "dbo",
                table: "Products",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_UnitId",
                schema: "dbo",
                table: "Products",
                column: "Fk_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubGroups_Fk_ProductGroupId",
                schema: "dbo",
                table: "ProductSubGroups",
                column: "Fk_ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_BranchId",
                schema: "dbo",
                table: "PurchaseOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "PurchaseOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_ProductTypeId",
                schema: "dbo",
                table: "PurchaseOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_SubLedgerId",
                schema: "dbo",
                table: "PurchaseOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_BranchId",
                schema: "dbo",
                table: "PurchaseReturnOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "PurchaseReturnOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_ProductTypeId",
                schema: "dbo",
                table: "PurchaseReturnOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_SubLedgerId",
                schema: "dbo",
                table: "PurchaseReturnOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_AlternateUnitId",
                schema: "dbo",
                table: "PurchaseReturnTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_BranchId",
                schema: "dbo",
                table: "PurchaseReturnTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "PurchaseReturnTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_ProductId",
                schema: "dbo",
                table: "PurchaseReturnTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_PurchaseReturnOrderId",
                schema: "dbo",
                table: "PurchaseReturnTransactions",
                column: "Fk_PurchaseReturnOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_AlternateUnitId",
                schema: "dbo",
                table: "PurchaseTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_BranchId",
                schema: "dbo",
                table: "PurchaseTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "PurchaseTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_ProductId",
                schema: "dbo",
                table: "PurchaseTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_PurchaseOrderId",
                schema: "dbo",
                table: "PurchaseTransactions",
                column: "Fk_PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptOrders_Fk_BranchId",
                schema: "dbo",
                table: "ReceiptOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "ReceiptOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_BranchId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_LedgerGroupId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_ReceiptOrderId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "Fk_ReceiptOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_SubLedgerId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_LedgerDevLedgerId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "LedgerDevLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_LedgerId",
                schema: "dbo",
                table: "ReceiptTransactions",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Fk_BranchId",
                schema: "dbo",
                table: "SalesOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "SalesOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Fk_SubLedgerId",
                schema: "dbo",
                table: "SalesOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnOrders_Fk_BranchId",
                schema: "dbo",
                table: "SalesReturnOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnOrders_Fk_FinancialYearId",
                schema: "dbo",
                table: "SalesReturnOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnOrders_Fk_SubLedgerId",
                schema: "dbo",
                table: "SalesReturnOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_BranchId",
                schema: "dbo",
                table: "SalesReturnTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_FinancialYearId",
                schema: "dbo",
                table: "SalesReturnTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_ProductId",
                schema: "dbo",
                table: "SalesReturnTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_SalesReturnOrderId",
                schema: "dbo",
                table: "SalesReturnTransactions",
                column: "Fk_SalesReturnOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_BranchId",
                schema: "dbo",
                table: "SalesTransaction",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_FinancialYearId",
                schema: "dbo",
                table: "SalesTransaction",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_ProductId",
                schema: "dbo",
                table: "SalesTransaction",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_SalesOrderId",
                schema: "dbo",
                table: "SalesTransaction",
                column: "Fk_SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransactionSetups_Fk_SalesOrderSetupId",
                schema: "dbo",
                table: "SalesTransactionSetups",
                column: "Fk_SalesOrderSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Fk_CounryId",
                schema: "dbo",
                table: "States",
                column: "Fk_CounryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Fk_BranchId",
                schema: "dbo",
                table: "Stocks",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Fk_FinancialYear",
                schema: "dbo",
                table: "Stocks",
                column: "Fk_FinancialYear");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Fk_ProductId",
                schema: "dbo",
                table: "Stocks",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_BranchId",
                schema: "dbo",
                table: "SubLedgerBalances",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_FinancialYearId",
                schema: "dbo",
                table: "SubLedgerBalances",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_LedgerBalanceId",
                schema: "dbo",
                table: "SubLedgerBalances",
                column: "Fk_LedgerBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_SubLedgerId",
                schema: "dbo",
                table: "SubLedgerBalances",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgers_Fk_BranchId",
                schema: "dbo",
                table: "SubLedgers",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgers_LedgerDevLedgerId",
                schema: "dbo",
                table: "SubLedgers",
                column: "LedgerDevLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgers_LedgerId",
                schema: "dbo",
                table: "SubLedgers",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_Fk_BranchId",
                schema: "dbo",
                table: "UserBranches",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_Fk_UserId",
                schema: "dbo",
                table: "UserBranches",
                column: "Fk_UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BranchFinancialYears",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DamageTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InwardSupplyTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JournalTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabourRates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabourTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OutwardSupplyTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Parties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentTransaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductionTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PurchaseReturnTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReceiptTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesReturnTransactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesTransaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesTransactionSetups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubLedgerBalances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBranches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DamageOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InwardSupplyOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JournalOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabourOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OutwardSupplyOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductionOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PurchaseReturnOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AlternateUnits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PurchaseOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReceiptOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesReturnOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesOrderSetups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LedgerBalances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Labours",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "States",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FinancialYears",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RegisterTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabourTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubLedgers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductSubGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ledgers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ledgersDev",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LedgerSubGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LedgerSubGroupDevs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LedgerGroups",
                schema: "dbo");
        }
    }
}
