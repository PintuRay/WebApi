using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class MgInitil : Migration
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
                name: "Dists",
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
                    table.PrimaryKey("PK_Dists", x => x.DistId);
                    table.ForeignKey(
                        name: "FK_Dists_Country_Fk_CountryId",
                        column: x => x.Fk_CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dists_States_Fk_StateId",
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
                        name: "FK_Address_Country_Fk_CountryId",
                        column: x => x.Fk_CountryId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Dists_Fk_DistId",
                        column: x => x.Fk_DistId,
                        principalSchema: "dbo",
                        principalTable: "Dists",
                        principalColumn: "DistId",
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
                        name: "FK_Parties_Country_Fk_StateId",
                        column: x => x.Fk_StateId,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parties_Dists_Fk_CityId",
                        column: x => x.Fk_CityId,
                        principalSchema: "dbo",
                        principalTable: "Dists",
                        principalColumn: "DistId",
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
                values: new object[] { new Guid("e02eb064-def5-434a-8798-6f144a54003c"), "IN", "India", null, new DateTime(2024, 12, 14, 17, 54, 6, 57, DateTimeKind.Utc).AddTicks(2528), true, null, null });

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
                values: new object[] { new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), "System", new DateTime(2024, 12, 14, 17, 54, 6, 50, DateTimeKind.Utc).AddTicks(1452), true, "System", new DateTime(2024, 12, 14, 17, 54, 6, 50, DateTimeKind.Utc).AddTicks(1457), "123-123-1234" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fk_TokenId", "Gender", "LockoutEnabled", "LockoutEnd", "MaratialStatus", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TermCondition", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4431f16a-6bc7-4e9b-bada-c491fcc81a58", 0, new DateTime(1993, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "65a37859-d054-4a68-a817-1669d83c598a", "raypintu959@gmail.com", true, new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), "male", true, null, "unmarred", "Pintu Ray", "RAYPINTU959@GMAIL.COM", "RAYPINTU959@GMAIL.COM", "AQAAAAIAAYagAAAAEGCZJkRuuaN5s6jesxs7zm4NBR99KorCbeWBm6yVLgn2JCBVFEKr5ui4hLYFkhQWCA==", "8249486590", true, null, "ZCKN4FWVQMFYYU3JWBLJN7UUN2CBOZMF", true, true, "raypintu959@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "States",
                columns: new[] { "StateId", "CreatedBy", "CreatedDate", "Fk_CounryId", "IsActive", "ModifyBy", "ModifyDate", "StateName" },
                values: new object[,]
                {
                    { new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1679), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Delhi (UT)" },
                    { new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1569), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Chhattisgarh" },
                    { new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1609), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Manipur" },
                    { new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1577), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Gujarat" },
                    { new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1644), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Tripura" },
                    { new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1630), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Rajasthan" },
                    { new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1623), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Odisha" },
                    { new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1641), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Telangana" },
                    { new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1652), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Uttarakhand" },
                    { new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1685), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Lakshadweep (UT)" },
                    { new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1655), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "West Bengal" },
                    { new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1601), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Madhya Pradesh" },
                    { new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1627), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Punjab" },
                    { new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1547), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Andhra Pradesh" },
                    { new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1620), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Nagaland" },
                    { new Guid("77536c53-345c-48f5-a175-07a7b4044754"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1667), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Jammu & Kashmir (UT)" },
                    { new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1605), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Maharashtra" },
                    { new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1559), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Assam" },
                    { new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1616), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Mizoram" },
                    { new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1564), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Bihar" },
                    { new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1612), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Meghalaya" },
                    { new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1689), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Andaman and Nicobar Islands (UT)" },
                    { new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1634), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Sikkim" },
                    { new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1589), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Jharkhand" },
                    { new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1593), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Karnataka" },
                    { new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1573), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Goa" },
                    { new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1637), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Tamil Nadu" },
                    { new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1671), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Ladakh (UT)" },
                    { new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1582), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Haryana" },
                    { new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1597), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Kerala" },
                    { new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1675), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Chandigarh (UT)" },
                    { new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1682), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Puducherry (UT)" },
                    { new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1553), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Arunachal Pradesh" },
                    { new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1586), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Himachal Pradesh" },
                    { new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1663), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Daman & Diu (UT)" },
                    { new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1649), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Uttar Pradesh" },
                    { new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 58, DateTimeKind.Utc).AddTicks(1659), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, null, "Dadra and Nagar Haveli (UT)" }
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
                values: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58", "System", new DateTime(2024, 12, 14, 17, 54, 6, 51, DateTimeKind.Utc).AddTicks(4470), "AppUserRole", "System", new DateTime(2024, 12, 14, 17, 54, 6, 51, DateTimeKind.Utc).AddTicks(4477) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Dists",
                columns: new[] { "DistId", "CreatedBy", "CreatedDate", "DistName", "Fk_CountryId", "Fk_StateId", "IsActive", "ModifyBy", "ModifyDate" },
                values: new object[,]
                {
                    { new Guid("002054e6-0304-4b91-95ae-a78875aa8626"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1740), "Sant Ravidas Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("00277a4c-4684-499a-9b4f-17141933d0f7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2109), "Kupwara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("003ee745-beac-4e3a-9cd0-454c3fb8d494"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9312), "Chikkamagaluru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("005709b9-798f-4091-b92b-cc3b931971cc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8892), "Navsari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("00720e33-4c27-4048-b794-e82ef85442b5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1386), "West Tripura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("00e82d92-17fe-4bc9-a829-20b2cb171a62"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8987), "Jhajjar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("015e6815-6f17-41eb-92b6-edc5c758f7df"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1907), "Hooghly", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("01ba4e32-156a-4165-82d0-fead02c4b811"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1582), "Hathras", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("01ca0176-6c1d-4a77-9358-06e01b69806b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(584), "Mansa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("02056ef9-8c97-4f2b-9ca5-3fe1072ede81"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8066), "Bichom", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("02389dc5-caea-4b3d-b737-4d8a57bfd7c1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(743), "Hanumangarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("029a3638-fa24-4de8-b21c-8bed28286f0d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9942), "Parbhani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("02cdd233-fc1f-472c-a67c-bb16611768e7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1782), "Sultanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("034d14a2-72c5-42ce-855d-53c9ae844177"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9557), "Wayanad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("041bd63c-a14c-4386-a00c-e2fa2c99490c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8723), "Raigarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("041bf975-6bd3-467e-af31-1dd36543802f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(599), "Sri Muktsar Sahib", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("0446022c-35e4-44db-b276-dc59e1123a43"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9875), "Kolhapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("047de064-8d88-49eb-8b17-94193c67ac48"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1410), "Ayodhya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("049b5515-8a79-4cfe-be0b-870bb1bcd749"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8557), "Sheikhpura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("04d16a5b-ba69-4148-9e1b-06da72aa9a42"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(609), "Patiala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("052d4efc-368e-4c1f-a7b3-8e658567ea08"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8201), "Baksa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("054f066b-7e26-4475-b894-086ea3c5bf48"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1846), "Rudraprayag", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("0558ab7e-e7ab-49ff-88b0-13439f9f8053"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9808), "Anuppur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("057bcc35-9a05-49d6-b4cb-292796717471"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8951), "Ambala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("05ab0519-7f3c-49c8-811e-8b70638b9872"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8699), "Mahasamund", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("067fc333-bd86-48ef-a8cc-0a300a1e242d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9599), "Bhind", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("06857cf6-2319-4ac5-856c-13c3210d7b66"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9007), "Kurukshetra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("074811cc-3616-460e-95e2-5927199cce00"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(864), "Sirohi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("0752471e-66a2-43f4-a007-fa54b89b58b1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8485), "Lakhisarai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("0758e4c6-cf98-406a-b794-e1c06c525735"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9844), "Ratlam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("087f607c-3645-44c1-993b-4ebb89d9d07c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9526), "Kozhikode", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("08c8a043-1498-4a05-94c7-75acb8c8b397"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1831), "Nainital", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("08f44baf-0291-4163-82bd-df73fbabf50c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8827), "Dahod", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("093cb1b8-b452-4db6-8f17-bd8110b1b10c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1550), "Ghazipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("09cb4198-e54d-45d1-9e38-86f0dd09834e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9577), "Sehore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("0a2d2e9f-d5a4-4c81-a947-066b69a839cc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9713), "Seoni", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("0a5fc36e-09fe-4da7-852c-c547ff4ff223"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2030), "Reasi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("0a8dc213-58d4-47ca-9a2f-2bdf19b90c61"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1649), "Lucknow", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("0bf8ba4a-1792-44e1-88d7-29b5d82d858b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8132), "Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("0c6591e5-17d4-4714-974e-663957d0d044"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(337), "Wokha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("0cf3ae49-fd05-4f10-b604-7f53328f4fb8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9339), "Gadag", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("0d0f3d4c-bda1-485a-8390-b931250b91f6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8094), "Kra Daadi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("0d7f5334-2951-461c-bea5-c274f95371ea"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9163), "Dumka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("0daad625-3520-4c99-8677-6a6cedd6fcc9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(753), "Alwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("0e081da0-f204-4764-89fb-29dd10be4602"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8806), "Bharuch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("0e4d114e-d108-4a37-a3ee-a20082077186"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(532), "Faridkot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("10bdd4cf-ef70-4b8a-b167-69e49bda9979"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(738), "Bikaner", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("10f2ca7c-fbc1-4521-9dda-7354065a8b3c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8636), "Dhamtari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("1138edfc-fb65-471b-b81b-47e063fbf831"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8288), "Hailakandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("12905b0f-10c5-4a25-bd03-88634ed57366"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(98), "Pherzawl", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("12a12944-b2bd-4d28-a7fa-bbc775383426"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9572), "Rajgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("12caace6-cf76-4321-9d1c-140ad9f8c884"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1628), "Kushinagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("12cb880e-bd03-4d36-b09d-e12919b657cf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(650), "Bhilwara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("134c00fd-25aa-4e68-88e5-a92e6d1f9584"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9632), "Barwani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("13731135-0036-46ea-bf72-15f8de795a1d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8196), "Longding", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("13868b5f-93f6-4943-8003-fe68467464f9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9355), "Hassan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("142c5a0d-376a-46cf-ae3e-b290e0814e96"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1453), "Ballia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("145ef74d-88a5-4c3e-95f8-9e34f59e04e6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8575), "Supaul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("14b70d89-95c9-49d2-a694-d1d679ea1730"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9396), "Bengaluru South", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("14ba7f9e-466a-44ec-a994-88dd1cb27c0f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(984), "Erode", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("15065f44-bcbe-467a-b061-018fd93d022d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1882), "Purba Bardhaman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("1523f4e7-7e1b-43c2-9550-c319243d8224"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1697), "Muzaffarnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("15c9fd2d-c97e-45f6-8ef8-939f3e71ab7b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1248), "Hanumakonda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("15da4245-8d77-4bbc-b4c2-f6d746433c28"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8206), "Bajali", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("1655abfc-f94f-4853-80d9-a1963dd730d8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1211), "Sircilla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("16579ff9-7997-407f-8bbf-9751e16ffb53"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(79), "Kakching", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("1698e60f-ddef-45de-bea4-e7169ed1d1f5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8983), "Hisar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("16aa7480-a8da-48c4-a7ab-9acf798d0137"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1299), "Hyderabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("16e9f375-6070-4f74-99fc-fb99aa81a723"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(295), "Mon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("1704adc2-3434-425a-a64b-02bb03817d54"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8781), "Amreli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("17087c4b-9307-4b36-a270-33d354f56c19"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9036), "Panipat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("17090546-bd7d-4d3e-bcd6-51fe86297fd9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9849), "Shajapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("173804b8-6d5b-4765-983d-7ce44b5180d7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(916), "Gangtok", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("17423117-8731-4efe-931a-9a8074c0f22d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8662), "Jashpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("1749ac71-d30a-40cb-8ecc-d988f0e9e897"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2104), "Baramulla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("178b2b00-8365-48ab-aab3-fdaa1664b6d1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(841), "Jhalawar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("179a310b-0536-49d6-95dd-3195ae664a9e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9184), "Godda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("17a77600-ef32-49cd-81e9-ca927a1b5aef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1495), "Chandauli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("185203ab-ec53-4a8e-b5c2-88b35c9cfa3e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8315), "Karbi Anglong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("1875cbca-19de-4992-a933-611deca56548"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8410), "Begusarai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("192db5fc-2285-4e2e-ad32-ed8d1b5cd767"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(315), "Phek", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("1a6b7809-3cd8-4258-8dc0-c704ac41b75a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8594), "Balod", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("1a82e441-339a-474b-8b29-6777535f8a65"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2094), "Ganderbal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("1aaef1f0-a210-48df-b61d-f00ebc661da6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8599), "Baloda Bazar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("1b9c73de-8307-4374-a566-d96fd55910c3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8406), "Banka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("1c295431-7ac8-4c32-b7c7-6da972f330b6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9540), "Pathanamthitta", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("1d51441c-b81d-42e0-9b32-f568edea7411"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9155), "Dhanbad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("1d998041-391d-4370-8eac-4da926fdd389"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(434), "Kendrapara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("1da0bee4-e337-44c2-8379-11a6a3ec0bf9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1887), "Birbhum", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("1da54aa1-d47f-47c7-a8a4-3aa922018d4d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(453), "Malkangiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("1e0cf229-49fa-4bb6-ba74-087e10ac6f54"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8789), "Aravalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("1e340e7a-1c3a-46c1-8ca6-e359242dfa6a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7979), "Krishna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("1e6c4a0f-73b3-45e5-b9db-3a80b597ab68"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9330), "Davanagere", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("1e90a7bf-69b0-4495-a223-e2eae1b21e4c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2125), "Changthang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("1ebc5c2c-0352-4d34-8f57-ca15cb53fc73"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9728), "Betul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("1ed0ee6c-68c5-4922-bb9e-380f6e0bfb7d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9784), "Damoh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("1ef4ad7a-f783-4053-8d9f-2c8c6bebddce"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(201), "Champhai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("1f1edce3-5eeb-42bc-862d-5bb696416920"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2147), "Zanskar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("20c7a9d1-71b2-47d6-b6fa-0a503348e64b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8505), "Muzaffarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("2200a5ad-aa37-40aa-872e-0a4248bc9b86"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(449), "Koraput", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("22cd62f7-86f3-4f9f-844c-5c4e4ce985d5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1327), "Nagarkurnool", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("22e347c7-6653-4e84-bd19-d991da57ca28"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8071), "East Kameng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("23390422-b3d0-4c45-996b-568c5c3c7ab9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1716), "Prayagraj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("23596f4b-c596-499c-9040-9328034ebc52"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9041), "Rewari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("235c0bc2-936c-4cda-a6c9-6ae43d6a758d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(969), "Cuddalore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("236de6c9-a322-417e-80fd-251b5d10bd22"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(780), "Khairthal–Tijara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("23c36dc2-c2ef-4f7c-b721-024f8e6b440a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8617), "Bemetara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("23fcd931-f48f-479b-8b1b-24d41c6916f4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(993), "Kallakurichi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("247acd3b-6066-4245-815c-0f4c23cbac87"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9978), "Nagpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("247f02b9-33a1-4dba-bc28-1f63250c59d0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8648), "Gariaband", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("24b5ca0e-fc52-4ea5-bcf8-a797d8071813"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(728), "Sawai Madhopur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("24bc4196-c54a-4999-bcd7-991eba49f3e6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(492), "Sambalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("24cbd902-4c5e-4365-aeef-e770142cc574"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9248), "Sahibganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("24ed413e-cdb4-4469-a173-94693948dc01"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8191), "Tirap", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("250fd1cd-7971-4686-a59e-5e2fc5f24dc5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1468), "Barabanki", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("25acd1f1-d49d-4dba-bb1e-dd87fc423296"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2071), "Pulwama", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("25f05b49-d63c-4a8e-84de-a36a00549e5e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9996), "Dhule", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("25f4f145-4bfe-4f66-a799-42530cc88170"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8763), "North Goa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), true, null, null },
                    { new Guid("25f7b73b-bab3-41f0-913c-9c21b55a6acc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2010), "Kathua", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("267631ac-1064-4929-8aaa-a1bd44bcdfd7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(954), "Chengalpattu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("2686c15c-3e4b-442f-acd7-181314f41ebf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8956), "Bhiwani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("268ce5b8-0fe2-42ee-8f0a-d4189c8875f4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(206), "Hnahthial", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("26dcf931-ef52-4bb2-a7a4-9dfd1388398b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8565), "Saran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("26fd99ba-70f4-49c9-80a2-0bda69dc24fb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2302), "Sri Vijaya Puram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), true, null, null },
                    { new Guid("279de48d-356e-414a-b3ef-09ae741d33a1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8224), "Bongaigaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("27a78e35-9b34-46ea-827e-599e055f8f1b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8690), "Korba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("2969a092-3e0a-4ccd-b2cd-39ed2466683a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9051), "Sirsa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("29dd673e-ef72-4c72-a48e-69336e07f479"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(62), "Imphal East", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("2a0d7ebe-76db-44aa-9b22-3bf48f6c9666"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(466), "Nabarangpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("2a463bc7-d1fd-4668-8228-b8c30156cdd5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9820), "Umaria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("2a926de9-87b8-474b-b1bf-c63054f45e85"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(675), "Tonk", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("2abfa246-3ca7-4fe1-88db-e0e7c3f165bf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8904), "Patan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("2af14d3f-7ba4-4fb8-93c4-b87af195bc21"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1003), "Kanyakumari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("2af62be3-114e-4cc8-a660-4c70f8718471"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9145), "Chatra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("2b0cb45a-517c-44a6-a411-e704747bf53d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(351), "Balangir", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("2b102a5b-b9cc-492c-b5b7-1c156339b9f8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9934), "Latur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("2b48ef63-9c66-4225-8f11-eb061938d582"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1009), "Karur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("2b501905-e4da-4e8e-b619-7f458f298d80"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2039), "Poonch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("2b9ee4a5-b023-4c7b-a161-b85df3d8d6ee"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(641), "Ajmer", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("2bae9382-0a49-477d-a20e-a39af22a6bb7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9766), "Mauganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("2c619d4a-fe00-4013-8a2d-3f41a7cf3afd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(341), "Zünheboto", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("2c701697-e243-438b-8d98-76249ff6c5ae"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1173), "Asifabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("2c8aff2b-dd6f-4fb7-8a3f-d1d7b5c2e5f8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(806), "Jaisalmer", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("2cdd3362-a008-4c5b-8576-880f9bf1a2de"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(579), "Malerkotla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("2da1a621-c636-46ca-8cce-e1e2f97b4fdb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1381), "South Tripura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("2dadd970-e461-4adb-86e7-18a5d8a5798d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8946), "Valsad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("2de098e1-b08f-4c91-9b45-cff908d310ca"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2194), "Shahdara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("2e48c5e2-9484-4f53-b05f-afd206138d42"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7942), "Dr. B. R. Ambedkar Konaseema", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("2ebb1fe0-83cd-4f3f-a680-e7711cfd05bc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9308), "Chikkaballapura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("2f0e32cd-3035-4947-b0f9-b5d7e8348da6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9911), "Aurangabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("2f30cbc7-7107-46f9-8459-86d2dd7604a2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9866), "Satara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("2f5786e6-161c-4076-a5a7-d038162300a4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9654), "Jhabua", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("2f7468bc-6ac8-4ec8-8697-92602a490a33"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(633), "Tarn Taran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("2fcfcbd0-4138-4699-984e-73e568959b7c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9825), "Agar Malwa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("30176e17-76e9-4fee-9a76-64de07bb8915"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1873), "Bankura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("311d5923-4af1-4542-97df-c35870332ce4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1855), "Udham Singh Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("317385f8-b542-4727-9deb-be34e7d46de2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2158), "Central Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("319f0972-abe8-45d8-9a05-a7e795beacc5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(770), "Jaipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("31ec51a9-4f86-4d83-b6ca-e897122778a0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(686), "Banswara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("3295c539-4715-4b1b-a0a9-651453e344c3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8361), "Sonitpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("331f81d7-1df4-4731-a4b6-8ac04cc5fce1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9930), "Nanded", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("340ef5c4-4527-4f7b-837a-4d08ecafac8c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7974), "Kakinada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("354562fc-4ca8-4c3b-ba04-5facc9351450"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2133), "Drass", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("3552565b-d8d5-47b6-9526-c2aba600b737"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(824), "Phalodi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("36302ecb-571d-4eb8-b3ff-12038464921e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(846), "Kota", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("36df8181-a071-4a74-b875-480ebff0a2ca"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9550), "Thrissur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("37ac691c-58ae-4fab-96ec-8f9133f40451"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8851), "Jamnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("37cc0c8f-6e34-4040-b797-ec8e8abed657"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9082), "Chamba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("37f522ad-4fa7-483a-93d2-17732d0940a7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(949), "Ariyalur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("380a7891-81da-40c8-b836-404c166e06ff"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9281), "Belagavi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("3832bba4-8296-45c1-8f89-21752def24d1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8425), "Buxar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("3966b617-eae5-4f80-9ed3-8bff40ab077f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9536), "Palakkad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("3a775246-746d-474d-a2f2-cf03d5e0bc60"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9056), "Sonipat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("3a802de1-b53f-48f0-ac2b-771649ea6f9a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1201), "Peddapalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("3a9b4275-b5e4-4247-b110-744d06ae5937"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2162), "East Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("3aa2e548-ff9b-4844-85aa-0a481ebc2e23"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8745), "Sakti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("3ad7046c-1561-419b-9af6-3bd11cd201d0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1113), "Tirunelveli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("3b5238ea-5263-49fe-ae28-be0cd4ac7c92"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(216), "Kolasib", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("3b6a7b41-3e5f-4463-9bcb-9b7c13dd8b47"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9562), "Bhopal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3b962060-be75-467a-af31-95605bf6a1bc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1677), "Mau", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("3bca4d1d-e82a-469f-8b65-1f5b2e3b2228"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8329), "Lakhimpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("3c1826ea-2222-4274-95c1-ca0c971a1da0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(278), "Kohima", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("3c5ec84f-f5d3-45a4-a8be-6db37dd21949"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(547), "Fazilka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("3ccb89f5-824a-42e9-8b11-e400f597fdc4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9793), "Sagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3cdc5d5b-b97b-4d78-8c53-7a8615c580ec"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9240), "Ranchi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("3cf2de63-81cc-44f0-a498-feddcff9f750"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1977), "South 24 Parganas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("3d313b37-f00f-4bf0-8068-db55dbc5d6a7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9708), "Narsinghpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3d6442ea-cc5f-481d-84c2-990347683654"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9789), "Panna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3e3a64c6-8be7-4404-80ad-e85b9fadac33"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9830), "Dewas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("3ee5148a-aca5-436f-9642-8ecf6bcb6748"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8119), "Shi-Yomi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("3f2627dd-35a9-4b6e-83b5-68142e183f61"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8420), "Bhojpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("3f475801-84d0-4020-bd1d-ad1f3cad70ca"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(691), "Dungarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("3fed703c-af1b-4d7e-a266-dbc4cc712af9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1294), "Shamirpet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("40b351ca-04fe-4b81-86e5-5522b1ffaa65"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9659), "Khandwa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("417842bd-815c-4989-a643-02dadec92ad2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9212), "Kodarma", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("41ad6bd1-73bb-42d8-a022-0a8a736c7d6e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(193), "Aizawl", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("41c3a2d9-8f7b-4de6-85a7-99e85a0b8f6a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8837), "Devbhoomi Dwarka", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("4258abc5-0646-464e-9d94-70ad8cf66390"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(147), "West Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("4260c08b-a49e-474f-b2f7-0b7d182b13be"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1510), "Etah", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("42851af2-cfa2-47b4-8087-ac5425fe45c0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8909), "Porbandar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("42c82bc6-760d-489c-b252-37b55896e9c6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8401), "Aurangabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("42c9759c-b885-4948-a65b-cb0c297d6f6e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1311), "Vikarabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("43937cb3-27e8-4c7b-b083-81c252d73541"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1275), "Mahabubabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("43a1c5ac-3b68-4ee6-a4ec-23dde4e0b949"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8124), "West Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("44816c2c-0807-4e24-a733-a80d10bf8aa2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(210), "Khawzawl", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("44a5081c-0df9-43c3-94cf-13830c01d9d9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2256), "West Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("44f27acd-4451-4348-b778-232fb4979186"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9591), "Sheopur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("44f6c9a8-b39b-4383-afc0-ea8dc522b6ed"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(268), "Dimapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("4504c986-f29e-46e8-ba34-74082470ea76"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(797), "Balotra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("450ab48d-924a-4ff1-86b5-305691940e52"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8900), "Panchmahal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("45165e28-25bc-4316-8c4d-5d2113df5b0f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1376), "North Tripura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("4549df70-f837-485d-8814-90105e1bfdf9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8740), "Sarangarh-Bilaigarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("45a18117-3675-4cfc-9cb1-b8386f232847"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9889), "Amravati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("45b714b7-3ebf-4d0d-8ccb-89aebcd2ad25"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(273), "Kiphire", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("45d0cc8d-e7f5-4139-a7e2-f24c520ed4bd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9440), "Yadgiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("46176e79-c87d-43df-a449-019ef94151ab"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(103), "Senapati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("4641fd4a-70ed-40e5-baeb-6406fafd1bc5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9150), "Deoghar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("474eb45f-dac3-48f7-b83e-fb17e6b7f240"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8433), "Darbhanga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("49465839-1a37-48e2-a4c5-c6109b1d0537"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1123), "Tiruppur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("49475249-e24e-4dde-a970-5d6b008d198b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(290), "Mokokchung", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("49735898-4d39-4619-9193-eeb29253b772"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1996), "Daman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), true, null, null },
                    { new Guid("49b2b3b6-e55a-49df-a3bc-e3e7d378433c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8076), "Pakke-Kessang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("49d08106-a0dc-42cf-a765-27ab7833155b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9334), "Dharwad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("49e5f50e-d510-4e0b-9e3d-1442c03a91c9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1541), "Gautam Buddha Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("4a7c827f-7e16-4beb-b120-8d124f42cf6e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8776), "Ahmedabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("4b06d156-d48e-4b45-ad40-853db507646f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1132), "Tiruvallur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("4b1428ff-1a72-40f4-a137-ed08dae113b4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9920), "Jalna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("4b1d3774-5a50-4f39-ba59-3b6c980cbca8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1156), "Viluppuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("4b270059-11c5-4749-bc43-fc0eb8c62c9a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8584), "Vaishali", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("4b9d38e5-47ba-4781-9359-29073fb99099"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8046), "Sri Sathya Sai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("4bcabf90-cded-4cb1-9edf-f896d91047d5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(645), "Beawar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4c341ce7-72da-42e9-a96c-311bbdee671d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8653), "Gaurella-Pendra-Marwahi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("4c84ece4-2e95-41ab-8b9d-6e31ab95b61d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8104), "Kamle", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("4c8db82d-680a-4467-93b4-2771dc1dd1b1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8975), "Gurugram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("4d063f65-2af2-495e-9e33-cfb2906ea698"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9416), "Udupi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("4d0b25d5-d1a6-4d70-b355-dadca10423f7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1216), "Karimnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("4d4dc1c6-5ed2-4346-b800-3d6c47b6da31"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9752), "Satna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("4dd2e27d-79bb-441d-b9e0-5a20a9960d74"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1967), "Nadia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("4e10817d-150d-4fd1-aa70-1e53e965ae63"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1486), "Bijnor", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("4e151ca9-8733-43b3-8ae8-3d7e61e50090"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(132), "North Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("4e61dd6a-b1b9-4221-ad12-3b6911b433ff"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8370), "Tamulpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("4e6ac894-43fd-4fc9-b30a-da940e25819f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8089), "Papum Pare", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("4e924943-5080-449c-95f6-3644b05738e5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8014), "Anantapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("4ed3a647-72dd-45a2-b3ea-8a6fb3837e4a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(906), "Salumbar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4ee8522a-7c49-4d62-8fa6-26bfe90a00da"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(879), "Jhunjhunu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4f4cb55e-8a59-4fbe-bb75-6c59e0ce9100"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(375), "Boudh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("4f6a5512-3451-4ccb-93c7-84c54cd2a98c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9968), "Gadchiroli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("4f6fddfe-87f2-4d28-bdea-785494a907be"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(911), "Udaipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("4f720b8b-f0d1-410d-ba28-c8fd2ad96625"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9135), "Una", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("4f9f362e-eb47-40db-819b-7c78dc594abe"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1614), "Kanpur Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("4ff452ce-50ea-4bc6-8340-8396d51b7c9f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9531), "Malappuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("500e41f8-5e28-45aa-b396-254f5736eb05"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9853), "Ujjain", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("5029a5ef-2142-4a58-9592-4bb051f6b43d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1355), "Khowai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("508f8c7a-9aa3-4a6e-a88d-651621e0e677"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1531), "Fatehpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("50d0581b-d94a-4800-bdcd-6e543e8801a5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9779), "Chhatarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("510345d0-5ebf-4e05-8925-ac8311d7369b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1763), "Shravasti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("5131457b-7b2c-46c7-9089-b2b4a18fa109"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1897), "Darjeeling", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("51705b3d-c755-4481-bd83-fdc88eb98724"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8180), "Namsai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("519c5264-391a-4992-be86-6a341885d072"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8713), "Mungeli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("51bd8435-1c27-458e-9e92-ee55e4d34847"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8801), "Banaskantha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("51ec3352-6fdb-4d64-b9c2-4528bbef3c3e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(623), "Sangrur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("52adff9b-74d3-4559-bfed-564fb69d8ea0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2239), "South Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("52ccb44e-34ae-4a69-967f-0f8788de4e33"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8162), "Lower Dibang Valley", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("533432d2-1a88-427d-ae37-46b91ad8faa4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1735), "Sant Kabir Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("542f618a-3825-4655-ba6e-925764961589"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(346), "Angul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("5481d56f-1175-4a49-8068-85083cb4e4f5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9322), "Dakshina Kannada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("548462b7-2c86-4d7b-9ab2-1940aa08bd4f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1206), "Kamareddy", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("5493e086-e796-4455-b4ae-55f543a6d4ee"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1790), "Unnao", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("54c21925-cc91-4c87-9f92-2414a03ec92e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2025), "Udhampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("552a0acc-8e5c-43ea-9763-a3437afe720f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(19), "Mumbai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("55cba1e6-b27d-425a-bd0e-46639a1cc2db"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(356), "Balasore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("56b1a096-f7fc-4f38-a19a-e22f0b5c08d9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(188), "Ri-Bhoi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("56bdc691-ec58-4d44-ad5d-21772d984cb4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1878), "Paschim Bardhaman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("573c3763-7073-4616-9182-5a905f06be23"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1726), "Rampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("579d293c-b97c-477d-9493-c7bb5ec2c46f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1097), "Theni", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("57c0d477-a364-4895-b2c6-b6be6fcc855a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9669), "Balaghat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("57f4dd60-1244-4cb5-9cbb-e915c2dc0df9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9835), "Mandsaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("581167c6-1fd8-4130-b605-41d4a567e04f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8842), "Gandhinagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("593bc63a-1f91-4fc8-9dc8-830f089985c7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9627), "Alirajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("59986716-9689-417d-a1f5-06a6da7bb463"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(429), "Kandhamal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("5a90b55a-4d3b-4b2f-98c5-7a667da8573b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(998), "Kancheepuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("5a993b15-49ef-4f2e-8b6a-060e47b5d027"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9618), "Datia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("5b10cee6-2090-46f6-912b-060749ec8dba"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1987), "Uttar Dinajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("5b6c6b8d-cfc5-45f0-b403-603cc117613d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9221), "Lohardaga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("5ba13c96-ba8d-4324-8025-5d74b8418bcb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8273), "Dima Hasao", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("5bc6eb97-1637-448a-970b-11da82ad9b1e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8771), "South Goa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), true, null, null },
                    { new Guid("5c11f898-4d2e-4078-a9df-c85d9f23c6b9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(591), "Moga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("5c35039b-23f9-4e0a-845f-43298a449ed0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1316), "Narayanpet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("5cfb0ce5-283a-4351-aea1-997dc8793015"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(811), "Jodhpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("5d0c4202-cf28-4571-aa88-7f40c296bfba"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(819), "Jodhpur Rural", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("5e38bfd0-f820-4ec5-9243-f6a1ce7c28af"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1560), "Gorakhpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("5e8f07f6-d910-473d-b63e-361751d07dda"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1500), "Chitrakoot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("5e9fa9b1-be15-4768-b4fd-879e1402fa43"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(390), "Dhenkanal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("5eb5c190-5567-4938-856b-3f3a6d3fd856"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9803), "Niwari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("5ec71f31-fc7b-496f-9ef0-69af02b490b8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9906), "Washim", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("5ecc1b22-7d3a-4962-b1ea-f161972b6c66"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1597), "Jhansi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("5f9a2497-9519-4ec4-beeb-5a92e3bd5a0d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(47), "Bishnupur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("5fc75b62-fe59-421a-8258-a3b5a716ec24"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1545), "Ghaziabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("60460ae0-6ad3-4406-9026-eb68eb2ce8b9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1601), "Kannauj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("605c60f9-f5a9-4477-bc64-48a977f807d4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8081), "Kurung Kumey", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("60981891-5c53-4f2b-bebf-f38432af50e7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8580), "Siwan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("613f3fef-9a64-4299-873a-b952f3eb2aef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8818), "Botad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("616cff8d-14d2-4997-8824-43ce6ab8297c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7962), "Guntur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("61d955cd-f519-4864-a1e4-0c3716511286"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(974), "Dharmapuri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("625da6d6-65ed-414c-b5ae-0b57b4364c30"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(84), "Kamjong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("63468a10-914e-4ba6-bcdd-03220e95abed"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2277), "Pondicherry", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("6381b99a-7b1a-413d-98f3-77c18fedeac9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1841), "Pithoragarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("6395e36c-e5d2-4858-b156-ded46aea7f4c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9901), "Yavatmal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("63c95ba7-ee16-4ea1-9b7b-9f6502617d62"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8343), "Nagaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("63e90742-471d-4d86-a6e2-f4c3a444aa1a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9603), "Gwalior", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("64607d8b-7217-4e47-af8c-8826f13eadcc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8589), "West Champaran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("646a155d-35a2-4ba6-8ef8-6d5288de8f5f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2077), "Shopian", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("64df21f2-54ad-4361-a82a-6bcad6067a91"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1057), "Ramanathapuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("6524a855-f5cd-4b78-8da3-10fad67c5870"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9207), "Khunti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("6567c822-c85c-401f-86f7-27be34264f88"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(775), "Jaipur Rural", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("6579cad2-4177-4663-9832-1ea5c1d28aa0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8463), "Khagaria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("65b39b11-23ae-42c1-a00d-50ac43624d00"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9723), "Pandhurna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("662fd87c-0c10-4910-80ca-06b5c17c481e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9640), "Burhanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("663cf498-82a4-48f6-a0aa-ebaa8d9ca983"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1196), "Jagtial", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("665c599e-6864-4b51-a557-993b350981c7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9521), "Kottayam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("6683e80d-d298-4df0-b60b-b0a58b06df3e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2282), "Yanam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("67459ad4-bbcc-4865-a34a-75eaed8ea701"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(964), "Coimbatore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("675401a7-b8c8-4719-a367-26e57344f223"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1463), "Banda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("67b5dfcd-8ab9-4056-83b1-904c840ede7b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7903), "Alluri Sitharama Raju", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("6848d62e-1ca7-44ed-a002-69b4c06490b2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2251), "South West Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("68bc85f6-3860-4c79-bbb1-afe246738eae"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9092), "Kangra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("68e9d52f-8d37-43f2-977a-a0aeae419089"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2099), "Bandipore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("68eecdf9-4668-4086-a4f1-ed91207b4317"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9703), "Mandla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("68f982c6-b309-487e-8001-50bef09bfc64"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9503), "Kannur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("69017367-3b17-4a97-9769-3634410588da"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2271), "Mahé", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("6933e114-b4ee-485e-9dd8-ab8fe4299558"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9360), "Haveri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("69fb8073-d21f-4f51-8aa3-615ee6aa5e5b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1086), "Tenkasi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("6a74e32c-4b7d-43a9-b829-8f66daf6edd2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1587), "Jalaun", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("6a774962-206e-48e4-ade9-be30f50b14fc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(411), "Jajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("6a8ff83a-ab61-4274-a2f4-3c1531fcd06a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9017), "Nuh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("6ada2880-8e65-474d-8a3e-aaec944425f8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1265), "Kothagudem", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("6bb2894b-2a90-486f-904c-357534763dc9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(758), "Dausa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("6bf184c0-a79a-4d59-b0f7-2af40972b3f4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8847), "Gir Somnath", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("6c2a4513-2b23-4389-8878-ed83976ef70a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1167), "Adilabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("6c5ef5a6-7bb3-4baa-9607-028ebc7c5db7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1523), "Farrukhabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("6d4e0be1-9dda-473b-af62-4d4133351551"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2082), "Budgam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("6dbb6c3f-ab17-4c90-864d-68021c654d7f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1233), "Medak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("6dce64c7-d74b-4108-aa04-dd794254ff5b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1683), "Meerut", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("6df33c48-02d1-44e9-bcce-6fa8c0b0c580"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8298), "Jorhat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("6e295d5a-ded3-4ab5-87de-29ac0b2edbf0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9741), "Narmadapuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("6e4833ec-87e9-4b89-b7db-5c1383a0c4e3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(300), "Niuland", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("6eb72f92-f419-49d6-a520-af2970ad99c3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(109), "Tamenglong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("6f07a4ec-7d53-424c-815c-5be23a3152d6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2120), "Leh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("6f0eba05-cdbf-4cb0-802d-64282cbe5e04"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9195), "Hazaribagh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("6f0edff1-436f-442a-a009-d694ee345cf5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(628), "Shaheed Bhagat Singh Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("6f736ada-5973-4274-ae52-6f1de39e70e8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8877), "Mehsana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("6f873a77-3bc2-4c1d-9fbf-28da8f611a80"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8453), "Jamui", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("7028f9af-d9f8-4173-939f-89e2acf7b10f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8481), "Katihar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("708f5ee4-8bb3-4ac6-961b-18ea9582daff"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(898), "Rajsamand", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("7091023d-4d6b-4fbc-94f4-1d5b43180ef9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9272), "Bengaluru Urban", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("70bb10c1-8412-4e88-b213-a2cfcd582311"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(715), "Gangapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("712dc246-d993-4d42-aac4-3e23ed31aae7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(220), "Lawngtlai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("71e4db46-16f8-4047-8e06-99f47aca7359"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1051), "Pudukkottai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("71f7f8aa-5f86-473b-bc32-65bef37da925"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8785), "Anand", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("7283afa4-1a26-40a0-b2e2-597500519e54"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8736), "Rajnandgaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("72f60000-9215-49fa-bf87-0bf58bfdd4af"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1322), "Mahabubnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("7326a103-f0db-4606-815f-0f6728909bff"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1138), "Tiruvannamalai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("73751eb0-a1ec-4cc9-afc0-82da8afe6a1e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1091), "Thanjavur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("737a009c-8497-441d-803d-411c76e92c40"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8887), "Narmada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("7380fb4e-b1d8-47c9-a12c-074721dab18e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(733), "Anupgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("7428f71e-2428-4590-a03c-8371058b909e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9179), "Giridih", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("7470db1b-347d-4458-8610-1a39617c329e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8351), "Nalbari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("749a5687-ad80-4edc-b2cf-16c1f9a5a113"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2015), "Jammu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("74c3d1c0-6162-4f46-85f3-e338ad00097b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8621), "Bijapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("76364574-5c54-428d-b175-328ec859cc1f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(523), "Barnala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("7757ad7f-dca5-4719-aee6-72681a3beb80"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8137), "Lower Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("77b49ce6-51ef-4ae4-873e-ee0859687cf9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1191), "Nizamabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("77b93e89-182c-4f16-ab71-0caad7144080"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1777), "Sonbhadra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("77e1e6e9-12bf-4334-880d-a611a71e8c6d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(829), "Baran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("78574a13-c399-4508-96e9-12eb5bea2276"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(122), "Thoubal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("7858bd26-133a-4e13-94a2-3251dafd5b08"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(89), "Kangpokpi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("78944055-cc98-4102-bdc1-67ca35ccb3e6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1795), "Varanasi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("78bc3419-6906-4474-9aa4-c360206ebb73"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1809), "Chamoli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("78d74868-dcb5-48c3-b0e8-518b46356e87"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9622), "Guna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("7940bb4b-f719-4751-9819-7fe3c9e34a61"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1804), "Bageshwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("79509905-0094-41eb-9406-29a0f8be8aba"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1962), "Murshidabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("7954a1ad-caf4-4148-95f1-d03fe969238a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(461), "Mayurbhanj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("797d2301-523c-44a4-b9e7-b941d8ba649e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9894), "Buldhana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("7987968d-eea0-4c38-a470-5aa5f13f87ee"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8547), "Samastipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("79a73a05-16dd-45e3-b2ae-a6f149332615"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(856), "Pali", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("79b0f54e-7667-4f6e-9a0a-6881c825b9a6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8396), "Arwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("7a10f067-ce1f-4cc8-ab38-d12bf140e6e5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8379), "Udalguri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("7b15bfb0-95c3-4636-9c17-2b7b51381f36"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9253), "Saraikela-Kharsawan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("7b1d5a78-f982-4748-831a-057786ec6fe1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8109), "Keyi Panyor", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("7b1eea5a-b49d-434b-a00f-7bce0a69be31"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1392), "Agra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("7b4bbd83-3b68-4f9c-be8d-65457f47b7ec"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1915), "Howrah", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("7b6952ba-84b2-41d7-9df7-c70cf9119d0e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8018), "Annamayya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("7b8d3729-c9c1-40fd-b2c0-ed7bfea6e604"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(395), "Gajapati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("7c4538e5-62a2-49aa-bb62-85f9ba89c386"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7916), "Parvathipuram Manyam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("7c887697-b72b-4a39-82f1-364b01a95416"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9097), "Kinnaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("7d27ceb8-2d4e-4813-902a-771ed6040e8a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8325), "Kokrajhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("7d3398a8-1edc-4d13-98ea-48b2762d17ef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1982), "Purulia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("7d6ce8d5-1406-4d16-901a-f125a461be2e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8754), "Surajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("7d6d507c-2953-43ba-b75a-ec21f4a3a945"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1935), "Kolkata", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("7ddab862-0b66-4b7e-8426-2d7f018337dd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1814), "Champawat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("7e01b5c7-9e5a-4795-b372-2c5a342c9534"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(264), "Meluri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("7e0a2363-dd82-47e6-a6ad-029301c75216"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1515), "Etawah", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("7e24980a-2b28-4ab8-aa80-9925a54835ab"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2035), "Rajouri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("7e62e690-2a1d-4eee-9df3-dc7796d75f97"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(696), "Pratapgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("7ef88780-a16d-499b-b101-14e8098ab3c4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9586), "Morena", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("7fb31dca-e1db-4acf-aea2-914639d265f7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1940), "Kalimpong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("80715334-c15b-47c6-8b7e-896971fe027f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(538), "Fatehgarh Sahib", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("80ac4c70-7784-48f6-a636-aee5b02a3ad5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1430), "Azamgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("80bc00e6-d17e-4cfb-81ca-6471b8443598"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1490), "Bulandshahr", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("80f1dcff-1d63-4116-ae97-9bf846db7b24"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8924), "Surat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("80f76c1e-7426-4aef-9eb8-8b7fc5f306e8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(254), "Serchhip", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("8108e944-095f-439c-a9ee-9ef91a4be069"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8186), "Changlang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("819eb742-05bf-4918-83ef-795bed78a309"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9427), "Uttara Kannada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("81f87ee5-cccc-4559-a52e-2e5ceb9b08d5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8458), "Jehanabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("8271102b-a7b6-4afb-aecf-be00af762a47"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8100), "Lower Subansiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("82d4b401-66d6-40b3-912e-0c6effece789"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1693), "Moradabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("8339bfa3-c10e-4621-a992-966e36f0f74a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8448), "Gopalganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("83e0f9f7-cbbd-4667-9af6-64148b085642"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1150), "Vellore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("84128ed9-edf6-4f00-b201-da6a484b2290"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8152), "East Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("843675c4-0f85-4ca9-ba20-f3092f15c543"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1037), "Namakkal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("8443fd95-7bbc-4c1a-8528-b1bfab7ec7f9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1042), "Nilgiris", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("84f3312a-e1ab-4d2b-9a68-f00c676b712d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(710), "Dholpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("85170fdd-6a0a-49d7-aa36-a76ee1a1f5e4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(179), "South West Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("852d9e50-7f2c-4e48-ab7d-8f91c28717ef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8147), "Upper Siang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("866bc0b6-53d5-4785-be36-95dbfb8437e9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2066), "Kulgam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("8728b962-2a99-4c42-9305-f2ccad170f06"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9983), "Wardha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("8767e185-6bf3-4ab9-bbfc-f6e231edaceb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8998), "Kaithal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("87b12b59-b88c-417e-8582-afbec26bd51c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2052), "Ramban", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("87d0a964-8b50-4fd2-96b0-ed572d223059"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1102), "Thoothukudi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("884a983e-50dc-4942-a003-045945a3961a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8672), "Kanker", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("88b0ecc6-402f-4ac5-bfc6-87061af40299"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(940), "Gyalshing", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("88ccac7c-5c1c-4445-8b28-921439d677bc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2115), "Kargil", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("890ce161-14cd-464c-9573-fa4b95262cc0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(310), "Peren", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("89e0d207-dfe9-41b7-b58d-85b7bc504822"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(361), "Bargarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("89f04a5b-df99-468e-9933-2935dbb9954c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9226), "Pakur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("8a0349b9-8576-4c2c-bd88-485ad6adfc7c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8114), "Upper Subansiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("8a3a23ef-1446-4c03-8328-6cae8a43d00c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9174), "Garhwa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("8adadc1b-1a90-4019-a4fa-4c8aea2d5db8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(700), "Bharatpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("8b32a07b-627d-4a7f-a358-bf0577300536"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9861), "Sangli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("8ba5afe8-1742-430a-98fb-a49eed3d45c2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9025), "Palwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("8bc0f3b2-740f-4b0c-8f49-5d65047d4e30"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9697), "Katni", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("8c363b03-52e4-4b0a-adf7-2394821fd9c1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(405), "Jagatsinghapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("8c91da1d-8902-4f8d-981b-e5c9646c0f0a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8293), "Hojai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("8e772d4f-8592-4e17-8515-f704beda798e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8033), "Kurnool", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("8ea08773-e6a1-4370-87e9-7bf563b9060b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9125), "Sirmaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("8ed508e2-76da-4953-84e4-0f4ec91f55c2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(565), "Jalandhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("8ef08522-4ae5-481e-a7b8-f6bd503df958"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1400), "Aligarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("8f059244-da5b-4ec0-9d11-45c82a0adb55"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1931), "Jhargram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("8f2df141-82e4-4d6f-ad76-90ff6eb72808"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1573), "Hapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("8fbe880e-a2a1-4016-9d2b-1914d0991439"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(259), "Chümoukedima", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("8ff50103-95df-4180-aff8-305ca6f6228b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(380), "Cuttack", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("9045c217-26cd-4fb8-957e-744b0096cbbd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(117), "Tengnoupal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("90785084-11e9-4de9-8a61-ba448ef3ce76"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(94), "Noney", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("90873da4-5c59-46b6-ab98-830ca744aa51"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9370), "Kolar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("91bd7bf3-2495-463f-9c27-2dd43a6fced9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9839), "Neemuch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("91ddab4a-185a-456c-8c19-09c832147bca"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1289), "Bhuvanagiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("91e021ab-ce1d-4a65-bdd9-bb8f1ad592d9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(15), "Thane", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("92da5536-aabc-4ba7-8c54-d48c5f0e869e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(152), "South West Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("92e70e12-3b0d-4cbd-aae2-0bf2563b5edd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2089), "Srinagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("9301e8f3-78b0-473b-9879-77bc7eb1b25a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9947), "Hingoli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("9350960d-35b3-48a2-bd48-13e6be88489e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9718), "Dindori", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("9355723f-3bf5-4dd0-a45f-6649f4c01efe"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2292), "Malacca", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), true, null, null },
                    { new Guid("9371b4ef-83f2-46c0-b08a-94ea756c7a3e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(705), "Deeg", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("93a01e0c-d80d-43ab-87f1-713a078723a3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(720), "Karauli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("93e57d59-c020-4233-9f97-e38f28b266e4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(319), "Shamator", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("94467d8d-c498-4246-b693-d6b7049461a4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8334), "Majuli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("94bb493b-ff47-4eed-847c-51c7929dd3d4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(480), "Puri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("94bb9823-e509-40b2-b4fd-9ea2eae15e32"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1892), "Cooch Behar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("94d5517f-584b-45d5-a091-f1fbd4b8579b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8941), "Vadodara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("94e8202d-a16d-407a-ae8b-2e8bf72c56d7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8476), "Kaimur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("95071266-8cfa-4636-bca3-3a0dbc986e1b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8443), "Gaya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("950da488-dee7-4f00-b5a3-1a1dfe4d8cf9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1618), "Kasganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("95501eb9-2821-4110-b047-63278d969a60"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8859), "Junagadh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("956095c3-1073-438c-9e56-9c8a7c111b46"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8490), "Madhubani", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("95b913fe-ea1d-4106-bf87-4dddca1f9f44"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1162), "Virudhunagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("95bff59c-c0bb-49ed-9157-98829add1f68"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1950), "Paschim Medinipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("95ff9a1b-ccae-43f8-860f-a854a55c4a60"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1332), "Wanaparthy", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("96668db5-e22d-4ead-9ab9-cea8efd3ecd2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8718), "Narayanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("973711ca-941e-4671-9df3-40bc947c90e4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8822), "Chhota Udaipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("9844e75b-a478-473e-9b94-bce9b6d8279a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1145), "Tiruvarur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("98537a7d-c71e-449e-8e02-692386c4f436"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8677), "Kondagaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("9937dd8d-8da5-434e-b99f-3ac66f2e8a5d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9645), "Indore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("99bdb06f-dea1-4123-9137-8019452d6154"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(52), "Chandel", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("9a7d3dce-8492-426b-9111-514bdc566807"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8023), "Chittoor", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("9a8ba0e2-cb7a-4ad5-84e4-8dd9e082acfd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2182), "North East Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("9accbde3-b2e4-40ab-990e-76a118657239"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(517), "Amritsar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("9b6e6c23-a721-44f6-9c94-c2257a6deb1e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8641), "Durg", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("9b98c154-c4c4-43a2-ab69-5bf1c13148a5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9377), "Koppal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("9bb45e9c-11d4-4c3e-869b-a05cb84aa657"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1667), "Mainpuri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9bce8dd1-c91d-42de-a49e-159edcafd3d8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8510), "Nalanda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("9c2b015a-4b11-44e9-9fbc-7145305bb266"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1706), "Pilibhit", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9c52e7c0-21fe-4ad5-a57b-25d817371380"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(851), "Jalore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("9c890b62-aadd-4861-87e3-c74a621f853b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2047), "Doda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("9cfcfcd3-8edb-45d7-a593-cad77b0f4d42"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9403), "Shivamogga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("9d22958e-d3c0-49a0-9bd3-008663914b79"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8311), "Kamrup", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("9db3db84-7317-456b-b3dd-019699c90bc1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1623), "Kaushambi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("9e5fe643-a167-4705-ab89-330844d88e5d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(424), "Kalahandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("9e792780-efef-4495-a67e-c98c29dd526f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8695), "Koriya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("9eff3ff8-19f6-4bf6-a63c-89cb782ad31d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(542), "Firozpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("9f2010ac-089c-42e9-bf9b-4c7fc327b4d4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8384), "West Karbi Anglong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("a0b3f27d-34dc-452f-86de-9fae9893fe8a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(439), "Kendujhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("a0c95ae5-a0bc-46d6-b033-e0e401d03de5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8355), "Sivasagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("a1056e80-d7b8-4a65-a702-e3c0c2f09a15"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2020), "Samba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("a12fac32-9a2d-4840-962f-9431e25dc0ec"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8873), "Mahisagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("a299ef4d-28cc-4c45-8144-f3a4cd7bbe9e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9231), "Palamu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("a3230ea1-6772-4d52-bac8-8ba3b9f6a9c0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1954), "Purba Medinipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("a33d05b6-f77b-461b-9c44-8dc45e66254c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1350), "Gomati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("a3912ab4-1ebb-42ad-9091-decb94a355af"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8339), "Morigaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("a3bb9188-6230-4ee0-a027-99aa139ffeaf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9498), "Idukki", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("a3ee129a-27a4-4d55-b4d3-765071af856b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9078), "Bilaspur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("a411b4ac-2ac8-4af8-8d05-1cbde38fb61e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1228), "Sangareddy", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("a425f0c3-2f1e-47ca-96ad-38dfaae11b7a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8518), "Nawada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("a4a8e444-bb60-4fb8-9e97-c2a33f271c31"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1014), "Krishnagiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("a4adcce8-0ddd-4835-897f-ba4070b1f19d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(569), "Kapurthala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("a4b99141-6120-4871-a3fe-e66c56917233"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2287), "Lakshadweep", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"), true, null, null },
                    { new Guid("a507ac4c-a005-4ab6-87be-bc48ce09bcd7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1186), "Nirmal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("a50a6355-4ef7-437c-93d4-0cad4067f471"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1860), "Uttarkashi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("a648d571-06ef-46c4-9c1d-5318825972c5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1536), "Firozabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("a6bdbe45-6d6d-496d-9729-4b8b619a48f6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9813), "Shahdol", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("a6c7d6a1-3f0b-49e1-a2b6-f2b5e4301370"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8626), "Bilaspur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("a7740d4e-bcbb-4834-ba3f-a4ba43d3d502"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(237), "Mamit", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("a7939bc8-4dac-4569-a286-155971ce6e1f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1720), "Rae Bareli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("a7ec437b-1d99-4c61-9e57-c28172e7ac7c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8731), "Raipur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("a7f1d4ea-535a-43a2-af63-9e3aeea41869"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(930), "Soreng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("a84265a4-8398-458b-ba2e-03a5d8088965"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(32), "Raigad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("a8b3b2b8-e734-408a-ab6c-41904f4a8670"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8966), "Faridabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("a8e4d6c7-b8e4-4bb5-a2b0-a9b189705c4b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8003), "Sri Potti Sriramulu Nellore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("a8f2b98d-0c61-4356-b1fc-684e5fd66206"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7932), "Vizianagaram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("a93dfc6c-f939-49f8-b41b-da241e568963"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9046), "Rohtak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("a95bab71-5fbd-4fff-abdc-390abfffdccf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(527), "Bathinda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("a9d36f88-65d0-41df-9ed2-ccd23d3e8f8f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(833), "Bundi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("a9d521fd-7cf1-45cf-a0e7-92a6a4ad2e15"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1730), "Saharanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("aa0e59c9-a9a0-4a7b-9937-1df4bf9fa897"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9762), "Singrauli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("aa9fb1f4-b6a1-45e8-8935-77a3ee968023"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8283), "Golaghat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("aaa1a1f2-127a-4c57-931d-121e45f827fa"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(10), "Nashik", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("aac69250-9c9a-433c-b322-aa8da758f5fa"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8500), "Madhepura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("ab12e5dc-4078-4300-871f-2fc1516e1d2d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1644), "Lalitpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("abd2945f-082e-4ac5-9683-51f9c9cb0ecd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9608), "Ashoknagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("abebc95a-e844-44a6-a6ad-d0a470aedcff"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(486), "Rayagada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("abfd73f7-b9c3-4642-a70d-4ec85994ac12"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(42), "Sindhudurg", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("ac976704-011e-4ac7-87a2-343349c184b2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1415), "Amethi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ad230629-9a5d-4d0d-b2fd-26c7dc968128"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(935), "Namchi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("adcb752a-b5c1-42bf-be09-726f1e53bc18"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9991), "Ahmednagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("aeddd472-323e-44b4-a02a-ee169f1f75a1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8211), "Barpeta", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("af3d331e-91c6-47ae-8826-7b52a148b7af"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9107), "Lahaul and Spiti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("af9299da-33cd-4229-baba-5f0d22bf26c9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(655), "Didwana–Kuchaman", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("afa58e5e-8072-44e3-a5aa-d3cd632f0629"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9409), "Tumakuru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("b09067a1-aa6a-4b47-88ca-c2736b9a7290"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1307), "Shamshabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("b09efdca-76d6-46f5-97d2-45bb14d49746"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1578), "Hardoi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("b0e75f80-2d66-4e7e-bfac-bd598406e6c8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(660), "Kekri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("b0fcc33e-9074-4158-91f2-4c19fb375f46"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8038), "Nandyal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("b1552d3d-94e1-40d9-beb4-b3cecc6fe2bf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8538), "Rohtas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b1b6386b-6d97-408e-9ceb-fe939a8f54c0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1181), "Mancherial", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("b1b82543-f7e2-4159-b83d-124b9ebdc347"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1902), "Dakshin Dinajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("b1ee7f27-865b-458d-9fe2-8fc197a7d4d9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2177), "North Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("b21e68aa-8353-4168-8133-6d3e3f1707da"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1029), "Nagapattinam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("b23a1a15-9553-430a-aa08-601b4e525fed"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9289), "Ballari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("b282d870-09a4-4c14-86a6-b662cf42144b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9684), "Chhindwara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("b297e62f-6c3a-4493-8e84-820d4be2c83d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1473), "Bareilly", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("b349c8aa-4128-48dd-adf7-74c4b7aebfdc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1024), "Mayiladuthurai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("b3b5fbce-7421-4160-b6d0-5f1db20b747d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9130), "Solan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("b3d4b703-dea2-49e1-993e-02f7e67b8d19"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8667), "Kabirdham", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("b3df70e6-36f5-4ded-9a26-ed819077a1ef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1224), "Bhupalpally", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("b402eb65-ff0f-4f21-8b6e-69e585729d23"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9189), "Gumla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("b44981da-381c-4631-a282-29ef20828e56"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8229), "Cachar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("b44d16d2-a3ce-4ab6-9fac-bf8bfc6e5f93"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1405), "Ambedkar Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("b497eadb-cea0-4eda-bc2c-da10254e7f65"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9365), "Kodagu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("b49bd1af-bd49-44d3-ba5c-23f2a12ec232"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8810), "Bhavnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("b67e64d1-10bd-4abb-b19d-22cf6fdb6fc6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8028), "YSR (Kadapa)", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("b6ea4db7-29c4-410f-b319-62e3416e874e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1280), "Suryapet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("b6eb62e9-02fe-49b3-b6b2-4ac56841f929"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1019), "Madurai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("b6ebbd82-3528-4f03-a23b-c92932c00421"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8238), "Chirang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("b6f05a18-df24-452e-b683-611fe56a9db4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8543), "Saharsa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("b7699c1a-4b0a-4869-9e34-cf34dc1d755d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(574), "Ludhiana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("b777ea52-014f-409f-8cd2-536cd7b5aaf8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2169), "New Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("b78e44c0-09d0-4ff3-9e1c-26bac3682362"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7911), "Anakapalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("b7bd87c8-83e1-45d2-b38a-d159eaeb6246"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(142), "South Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("b7fbe34c-5a59-4dda-83c8-8ec02cc9ebe6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8709), "Mohla-Manpur- Ambagarh Chowki", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("b81e7fdc-1985-49d3-aa6a-31e37f2cae41"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8375), "Tinsukia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("b8bc1b22-2410-4bc8-9986-732863cb1db6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9964), "Chandrapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("b911edcc-51f6-481d-a2ee-dd3b5c14e833"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(884), "Neem Ka Thana", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("b92a9231-ce7b-40d0-abc0-99503efc9d6c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(385), "Debagarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("ba1f6270-574d-4c04-bbe6-63958ac748bf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(889), "Sikar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("ba20f14c-931e-469c-9ea2-7b1cf7ade0b8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(925), "Pakyong", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("ba567cae-8194-4263-a150-cebc2ab80e77"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2245), "South East Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("ba59b85c-0040-474b-a13c-1a3b71f2af84"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8495), "Munger", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("bad100ac-a4ec-4e2a-9dfd-6bd2901345f1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8533), "Purnia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("bb235b51-4e58-4fa4-b14c-83a21ad3a44d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8243), "Darrang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("bb5fc993-5a16-488d-8492-76da5ea3bd49"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(57), "Churachandpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("bb6fcfdc-25dc-4df2-8c56-830970a00960"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9112), "Mandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("bba3cd47-dd44-44e9-a98a-f3ae748c8ec0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8366), "South Salmara-Mankachar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("bc322c6c-9871-4403-b8b1-7ef234cfaf18"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(400), "Ganjam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("bc707c4a-7740-4d39-b638-cc230318c76d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1865), "Alipurduar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("bd293225-db58-4070-a59c-5c4c532212ef"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9581), "Vidisha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("bdc0ba54-d1b4-430e-a5e3-986953576143"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1565), "Hamirpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("bdcb277f-9987-47dd-9b57-847479877c98"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(137), "East Garo Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("be6ab549-710c-453e-bbba-eb010c11ef18"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9692), "Jabalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("bed69891-a47e-4b08-b5a6-96b158748aaf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9298), "Vijayapura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("bede5eed-352a-438b-93ac-f4a7af56fc50"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7985), "NTR", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("bf26a579-425c-4c92-8b36-78ecfc008a23"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(670), "Shahpura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("bfe46de2-1172-4214-bcd2-6d73fc58f529"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9516), "Kollam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("bffdd5be-bf14-4a75-a58b-f6e94a80ff04"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1711), "Pratapgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("c01161a2-4dbe-401c-b707-6aec7ab303e0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7957), "Eluru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("c0a8c0e2-40e1-4dab-b1eb-899deaef50f4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(332), "Tuensang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("c0bcdc5b-19cd-4dfa-a7b4-60f9e9f75d0e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(38), "Ratnagiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("c104354a-c6b3-42ac-929b-97dbeb62b755"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1337), "Gadwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("c111a785-e0d5-4b9b-86c0-e09777cc14e9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9102), "Kullu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("c135c302-d512-4397-a80d-dba791abab0a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(444), "Khordha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("c2046417-2a5a-426c-b22e-0c195900ddb7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1366), "Sipahijala", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("c237b133-910b-4bc4-8556-3c08d5a9cb27"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1672), "Mathura", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("c2573f2c-a5cc-4e8d-9f96-da9a9e7d8e2f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(512), "Sundargarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("c3e553dd-6cd2-494a-8593-b0a01af9ece3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(604), "Pathankot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("c40b9912-7805-4f43-8af3-a03f7d35717a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9884), "Akola", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("c46fc300-f265-4985-9de8-d04f24c69a6e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(241), "Saiha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("c471b241-ded2-4f93-ac05-259fe003b80f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2057), "Kishtwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("c48979fd-2415-4c16-a24a-1ee8915becca"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(67), "Imphal West", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("c4d1df0d-fc26-44a0-bfe6-4e6bd0ba09f9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9482), "Alappuzha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("c50b4531-7b90-4541-b35d-9c87170ca062"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(748), "Sri Ganganagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("c591a96d-1483-479d-a036-e79ea5c7759c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8255), "Dhemaji", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("c5df0164-1147-4695-93f9-66b2d7e6b1a7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(232), "Lunglei", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("c604383f-ed8b-48ab-8328-bcdd044b943c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(249), "Saitual", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), true, null, null },
                    { new Guid("c611076e-ba34-4f24-889a-06deaf7ff6df"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1850), "Tehri Garhwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("c65e7031-1c86-4696-8958-0a768f7eec48"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8631), "Dantewada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("c73056a5-c43a-40db-8c2c-85754c4cfa48"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9649), "Dhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("c7a06f6e-ceb9-4182-8911-7edbb9ce7653"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc), "Jalgaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("c7af233a-d422-4ba2-a0ec-23153ca0bb7d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2143), "Sham", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("c7c84b39-c67e-4934-ab6f-028ec8fccb99"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1371), "Unakoti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("c81a9a78-2b40-4730-b53c-8c1e509624af"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9120), "Shimla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("c85fbf54-98e9-4ea2-b7ce-d9eae10ffb5b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(785), "Kotputli–Behror", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("c864aef6-c223-456b-8a61-1149a9e5e3d7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9736), "Harda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("c878679d-c8ed-4eb3-add4-f97a84a62a43"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1926), "Jalpaiguri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("c893a844-fb9f-453a-8d7f-60382f874df5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(283), "Longleng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("c89a4364-7776-4dd1-81f2-87f4910d20fb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(184), "Eastern West Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("c8ff8974-db33-4b3c-bf4e-45db2fc1ebf2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9771), "Maihar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("c92d136a-a298-4088-b0de-37395614b26c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9002), "Karnal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("c94dfba2-42fe-4120-acc9-3a038bae2104"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(160), "West Jaintia Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("caa78c4b-cdfa-41a3-a54e-2c5ab6a530d3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1592), "Jaunpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("cb26b007-f173-4c71-87b7-377950199f25"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2188), "North West Delhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), true, null, null },
                    { new Guid("cb4c9486-6bb3-458e-a35f-bb40b32045a3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8607), "Balrampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("cbb06de5-da24-417e-ac88-1b8c1b5bf644"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9492), "Ernakulam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("cc27e731-a60b-4077-8391-c0ac6154fcdf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1257), "Mulugu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("cc756f34-c6b6-429e-bb4d-036921f98daf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1800), "Almora", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("cc9cb6b5-1724-40af-b295-a3f9db6d03cd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(324), "Tseminyü", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("cceb230f-5638-4876-8726-5fab98a9489c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8882), "Morbi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("cd808e18-4389-4f75-9516-d9566fe06c8c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7927), "Visakhapatnam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("cdab97c8-5d8d-4641-b910-908478c55509"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(920), "Mangan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), true, null, null },
                    { new Guid("cdae418d-4378-4ca7-b8ad-4c3f272f3bae"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8061), "West Kameng", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("ce38b193-8a7f-455e-a2d7-9dc961157359"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7922), "Srikakulam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("cf040f40-8dcf-41b9-bea5-a27fc3969577"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(305), "Noklak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), true, null, null },
                    { new Guid("cf4578c0-2a95-45ce-ab1e-5e554bc4ebf8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(5), "Nandurbar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("cff380a9-dc37-4838-8c91-0d074c1219b2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(560), "Hoshiarpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("cffe9445-5de5-4fa0-9711-413a668d148f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(763), "Dudu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("d027ac5e-1ce8-4d21-b7ff-e7becf05303e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9317), "Chitradurga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("d05b2700-7d5e-4f58-ae27-f5c96db2f46b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9236), "Ramgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("d06f6440-a320-4c4f-8cb0-5111082dd36a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(979), "Dindigul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("d0995af8-928c-4eaa-b476-b952f5cd2583"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1555), "Gonda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d0a3fb33-66e3-466b-b49d-5df6382443c1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1243), "Jangaon", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("d0ada5b0-ac5c-4ae8-82ea-fb7d5cbfb37e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1420), "Amroha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d0ae3059-3b72-41b5-b0c1-e3b91bdb18e0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8863), "Kutch", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("d0fabffe-a043-4092-87cf-7049bb2d081d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1757), "Shamli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d148d643-c873-4e39-bd44-84daeb8f4d65"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8552), "Sheohar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("d15828b7-6c89-478f-8066-940028b07689"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8704), "Manendragarh-Chirmiri-Bharatpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("d1a509e8-10fc-4f73-a410-19818b0f6f61"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1768), "Siddharthnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d1aa7b1c-c1a0-4d1c-8cad-cff81f92cc5a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2062), "Anantnag", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("77536c53-345c-48f5-a175-07a7b4044754"), true, null, null },
                    { new Guid("d1c0fae8-e519-4f06-b0e1-3a92615a92c9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1342), "Dhalai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), true, null, null },
                    { new Guid("d1fd0fd6-93d9-4455-82be-666a933e8603"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9012), "Mahendragarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("d255aedb-a6e9-44cd-b98d-a060ba52df07"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8919), "Sabarkantha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("d316b452-e159-4b1c-a37c-868df00c6779"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2138), "Nubra", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), true, null, null },
                    { new Guid("d4261c4b-ffbe-47db-8ef0-9a0bd5e39f79"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9030), "Panchkula", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("d4296cd6-f89e-4cd3-82bf-b6dda81a43c1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9508), "Kasaragod", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("d4934649-5359-4622-bd40-6313d8806f1c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1108), "Tiruchirappalli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("d4d863c1-be83-45c1-b3a5-323ad0232a53"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8570), "Sitamarhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("d4ec1227-fbb5-4f82-a51c-c381def81466"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9925), "Osmanabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("d516842a-9d61-4569-a016-35313bbf4f08"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8970), "Fatehabad", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("d5451c7b-4e56-4bd7-a958-6f075c6345af"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9169), "East Singhbhum", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("d5721462-bc6b-417d-beb8-1f9a6292a1c0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1748), "Sambhal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("d64d812a-27a4-4315-842a-de129905d0f5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9747), "Rewa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("d69b4c35-afeb-4ef3-b83a-bcc84080c43e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(126), "Ukhrul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("d7578278-e9e5-452b-938b-79cbf2bc059a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8167), "Lohit", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("d7b6d07e-1191-4f11-9e98-ad80bdae918f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7990), "Palnadu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("d7ba6054-ae88-4dea-90cc-24d836c388cb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8612), "Bastar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("d7ce980c-c5eb-4228-ba75-fd69c65f0269"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1270), "Khammam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("d800bbed-c928-48d0-a2a6-645bd0bc5825"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8259), "Dhubri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("d8069d63-2346-4a5e-9ff9-6734cf67a2da"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(801), "Barmer", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("d867fe52-b22e-4337-b825-891aa3c9d33f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8468), "Kishanganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("d8d139ee-440a-45ae-87d8-6f5b5885451e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1819), "Dehradun", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("d94afd35-13a9-4aa9-a60f-919680b37181"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(874), "Churu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("d9bddb89-14e5-4590-92c2-cb9d2f1fa136"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(164), "East Jaintia Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("d9f8ccd8-bd6e-4aab-8fbc-2e0a052899fa"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9973), "Gondia", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("dac9c8e7-5e7d-43e6-b3b2-b4d9292b8482"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9350), "Kalaburagi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("dba464e3-05cf-4ef3-9117-633aef42fa09"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(169), "East Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("dbe24220-917b-4ba6-a705-32ce6c34ca33"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8914), "Rajkot", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("dcbdba55-a9bd-40dd-85a2-d5bfd4668587"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1688), "Mirzapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("dcce4774-cf73-41db-a362-1436adf12367"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8993), "Jind", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("dd4a10fb-36d4-4421-be6b-28fd6f70b728"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9199), "Jamtara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("dd57c863-7377-47ee-b4ef-94ba6a8ba72a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8320), "Karimganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("dd5bf54a-1dc2-4e39-a3e9-033b5bb9fa9c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1443), "Bagpat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("de144cb2-deec-4008-ad6b-ad02f3738ed9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9382), "Mandya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("deea8e74-28a5-4119-a887-10a3ed1c39e4"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(959), "Chennai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("df382860-3140-4f88-91fd-8dfdde7b6879"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8868), "Kheda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("df73e8b6-aa60-4db0-86e5-376a9518b3e9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(419), "Jharsuguda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("dfc65df0-93dd-4f22-a813-3e7dd5d92791"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2265), "Karaikal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), true, null, null },
                    { new Guid("dff9f204-3e1f-4225-a270-45965f48b15c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9613), "Shivpuri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("dffa4c34-9f25-4e2a-b432-7079de290e37"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1118), "Tirupathur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("e025245e-57d7-4746-990b-1b6ee3414d29"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8233), "Charaideo", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("e0db475f-9155-4738-98ca-9e068d3f6009"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1252), "Warangal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("e15ba366-7fc8-4ca2-94e8-010e0018832f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1662), "Mahoba", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("e2360085-599e-41fc-a1a6-e487473fd757"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8142), "Lepa-Rada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("e24b8563-b143-4dcd-8f7b-b936f8f92829"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(367), "Bhadrak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("e2cdffad-c4fd-4b26-97e9-54763b2b04c9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9392), "Raichur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("e2f752cc-77c6-485a-981b-3d57a5bacd65"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8657), "Janjgir-Champa", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("e30b4502-0bcc-45ab-81f5-478b103f7102"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1284), "Nalgonda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("e334a95a-d267-4eb4-addd-5c3d5b04a15e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2152), "Chandigarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"), true, null, null },
                    { new Guid("e3937073-49f0-48f1-93bc-1f3d0806cb89"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8051), "Tirupati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("e3c821b8-76a7-4764-ab60-79c6f46de8dd"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8219), "Biswanath", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("e3dfb1a3-893c-4bdf-a489-5c352118edf1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(893), "Chittorgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("e4570b0d-073b-4b17-a206-904703fc5edf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9664), "Khargone", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("e4cb4c32-1bb0-476d-87b6-8d84f0a203ca"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1972), "North 24 Parganas", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("e4d64f6b-69a0-48de-b66c-aa6598bcc4e3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(869), "Sanchore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("e5423aeb-7b9c-4686-a620-40f746921313"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1823), "Haridwar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("e59289be-698a-41d0-bc63-d4d784e5cca6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1606), "Kanpur Dehat", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("e6053043-9ebf-4b1a-bc38-34738e015323"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9293), "Bidar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("e6dfee52-268c-4544-9bf5-70eb844fb27e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2297), "Mayabunder", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), true, null, null },
                    { new Guid("e72d8db8-532c-4723-aa2a-e6506c3dc52b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8759), "Surguja", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("e736758c-8a98-4c6c-b1c5-70be3d316dc7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(497), "Subarnapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("e7a208a2-5f13-4942-b497-b4cc198fa62d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(24), "Palghar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("e7c8afb1-d731-4c04-9539-15266f5ab5ec"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9258), "Simdega", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("e86db8d3-d251-4759-b05a-9b270bd07b65"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8750), "Sukma", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("e89a5188-d901-420b-b596-628bd7cd4a95"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9545), "Thiruvananthapuram", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), true, null, null },
                    { new Guid("e8a2d0ed-0954-4bf5-8330-f739c1aebd73"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8929), "Surendranagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("e8c0c10f-b60e-4d82-b642-d51b31b9ac70"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9798), "Tikamgarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("e8d0b5ca-3f93-4b21-aa35-984d7d3c9be2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8961), "Charkhi Dadri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("e90f4aea-3a30-4a74-a1bd-e494e312041c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9880), "Pune", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("e975a71c-9c7e-4000-98c0-5b4e0397b981"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8934), "Tapi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("ea248d1c-db4e-4b2b-bb80-26783486832b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9915), "Beed", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("ea6ae903-2811-4b72-b3e4-e2a0e527e09a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1632), "Lakhimpur Kheri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ea7da325-7bae-4c1e-bc15-095542b12337"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9567), "Raisen", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("ea97a0a4-026b-4f39-b259-150b8a50b0cf"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1836), "Pauri Garhwal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), true, null, null },
                    { new Guid("eaa1c9ac-62a1-4916-9221-4b4630ddc10d"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9303), "Chamarajanagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("eaa23945-a846-4517-bde7-c1b754928d28"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(75), "Jiribam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), true, null, null },
                    { new Guid("eab9242c-5d6a-46b8-8152-6100b1f3e3cc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9087), "Hamirpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), true, null, null },
                    { new Guid("eadf5fb0-7147-4b54-93f7-d8e55592b302"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9262), "West Singhbhum", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("eb24e610-1588-4926-9698-034d060136e7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(555), "Gurdaspur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("ebbba797-3eb7-4606-bbe6-ea19482a5269"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1991), "Dadra and Nagar Haveli", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"), true, null, null },
                    { new Guid("ec3ef786-9e5c-44c8-9480-80ed9aed7103"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9433), "Vijayanagara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("eca0ed0b-5933-4fee-9732-1843be66715b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1752), "Shahjahanpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ed5df976-88b6-44fa-8776-3d3414522d41"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1458), "Balrampur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ed76fb54-9b25-4564-94a7-54ac280a824b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9870), "Solapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("ed84b732-6f9f-463b-923e-43a33c8f7d88"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8278), "Goalpara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("edea9d85-ea2f-419c-926a-09e6f16547c5"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(2005), "Diu", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), true, null, null },
                    { new Guid("ee9acbca-d58a-4b24-ac89-e9f113270cba"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1238), "Siddipet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), true, null, null },
                    { new Guid("eec61139-3ea4-446d-a165-6e6e90c3cf58"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8682), "Khairagarh-Chhuikhadan-Gandai", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), true, null, null },
                    { new Guid("eed28826-0683-4476-8c88-981264bd9d8b"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8157), "Dibang Valley", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("efe47138-6b10-4653-b532-50b1a58cd3a0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8269), "Dibrugarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("f0581893-ce68-4193-b4e9-7cdd37d021e8"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1062), "Ranipet", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("f0762d58-c03e-4d2d-bcf4-5087fa2f24c9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(614), "Rupnagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("f12ecaea-6a15-43d5-b02e-6166511d7425"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(471), "Nayagarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("f1f42217-022a-43cc-a3a8-62abc79f2fcb"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9959), "Bhandara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), true, null, null },
                    { new Guid("f2db8566-226c-4cda-8eed-d56fbc7ad43a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1505), "Deoria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f2e123b3-c210-454d-bed3-37c7a78f0ca0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1478), "Basti", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f341ac89-791d-4be0-b06e-e7a539dc5425"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7995), "Prakasam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("f444b15d-17f6-433c-b89c-0f29ea33c03c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8438), "East Champaran", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("f4aac3d3-3f3f-41a1-be35-1ee10ce58864"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1435), "Budaun", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f5498521-7192-4be4-9029-b2fe68b5eaa2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9217), "Latehar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("f56f6f4b-69ff-48ae-8b67-15c4926c06f3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9140), "Bokaro", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), true, null, null },
                    { new Guid("f58cc09e-80ef-4b51-a200-969a8ba308f0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1078), "Sivaganga", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("f5f0e501-61f0-446c-9207-9a09d44d6cac"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1654), "Maharajganj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f6aa9789-e27b-417c-9cbc-4dcc57391640"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1448), "Bahraich", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("f6abf53d-c797-4602-8441-e8a631e697d3"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8303), "Kamrup Metropolitan", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), true, null, null },
                    { new Guid("f705e2ef-c45a-4edc-8b56-e7aee0bdfd5e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8175), "Anjaw", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("f7fd9e45-9254-41e4-82d6-9e8ffd655ff6"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8832), "Dang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), true, null, null },
                    { new Guid("f8067c63-d1ed-4207-85d6-88b38aef1b07"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(476), "Nuapada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null, null },
                    { new Guid("f8c3c12a-ed3e-4766-a594-42e669ba447c"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1046), "Perambalur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("f91d3713-1ad1-443c-a27a-518a67a61e03"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7937), "Bapatla", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("f9325b10-225b-488a-af58-627042fc513a"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9267), "Bagalkote", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("f98249d5-9345-4d38-8cd3-c893b0b4e82e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1066), "Salem", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), true, null, null },
                    { new Guid("f9dc3f21-5f73-4c1e-860f-8bfe7c46480e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9387), "Mysuru", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("faf18d16-c8b6-4fe7-8336-2d4705190c60"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8415), "Bhagalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("fb345007-83e1-4c8d-b9ea-65b1e6e1c0bc"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9757), "Sidhi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), true, null, null },
                    { new Guid("fbac25f0-f929-4c8e-a730-7360e33a0d4e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9061), "Yamunanagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), true, null, null },
                    { new Guid("fc18bdc0-8c71-4198-ab17-77aa0198a9e1"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(665), "Nagaur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), true, null, null },
                    { new Guid("fc30ccc4-d8bf-4a28-8163-b868d04236c7"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1772), "Sitapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("fce19284-afcd-4442-b867-d12e7d2082a0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(174), "West Khasi Hills", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), true, null, null },
                    { new Guid("fd6c5ad5-9eb9-4455-bfc7-b867168073ac"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8008), "West Godavari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null },
                    { new Guid("fd94e624-ee06-4929-8d57-8a7b8226551e"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8056), "Tawang", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), true, null, null },
                    { new Guid("fe411f97-1f08-40a9-a22d-a995f3814fb9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(619), "Sahibzada Ajit Singh Nagar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), true, null, null },
                    { new Guid("fe458bcb-9d03-45a7-8cba-74bda7cc40aa"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8391), "Araria", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("febdb681-a7de-4d2c-86d9-5b314527615f"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1945), "Malda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), true, null, null },
                    { new Guid("fedffd9c-ba9d-4e96-a7f5-207997285e45"), null, new DateTime(2024, 12, 14, 17, 54, 6, 60, DateTimeKind.Utc).AddTicks(1425), "Auraiya", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), true, null, null },
                    { new Guid("ff124c8b-2e2f-453a-b33f-a627bab429d2"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(8523), "Patna", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), true, null, null },
                    { new Guid("ff3420e1-b35e-41a4-aa4f-1002961426e0"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(9277), "Bengaluru Rural", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), true, null, null },
                    { new Guid("fff969e7-4fa1-4d05-9ab0-5f9bfa6e58c9"), null, new DateTime(2024, 12, 14, 17, 54, 6, 59, DateTimeKind.Utc).AddTicks(7951), "East Godavari", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), true, null, null }
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
                name: "IX_Dists_Fk_CountryId",
                schema: "dbo",
                table: "Dists",
                column: "Fk_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dists_Fk_StateId",
                schema: "dbo",
                table: "Dists",
                column: "Fk_StateId");

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
                name: "Dists",
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
