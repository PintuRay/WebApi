using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "public");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "public",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BranchAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContactNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BranchCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "public",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYears",
                schema: "public",
                columns: table => new
                {
                    FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Financial_Year = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYears", x => x.FinancialYearId);
                });

            migrationBuilder.CreateTable(
                name: "LabourTypes",
                schema: "public",
                columns: table => new
                {
                    LabourTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Labour_Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourTypes", x => x.LabourTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerGroups",
                schema: "public",
                columns: table => new
                {
                    LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    GroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GroupAlias = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerGroups", x => x.LedgerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "public",
                columns: table => new
                {
                    ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Product_Type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RegisterTokens",
                schema: "public",
                columns: table => new
                {
                    TokenId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    TokenValue = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTokens", x => x.TokenId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "public",
                columns: table => new
                {
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UnitName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "public",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "public",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNo = table.Column<string>(type: "text", nullable: false),
                    GSTIN = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "public",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    StateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Country_Fk_CountryId",
                        column: x => x.Fk_CountryId,
                        principalSchema: "public",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchFinancialYears",
                schema: "public",
                columns: table => new
                {
                    BranchFinancialYearId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchFinancialYears", x => x.BranchFinancialYearId);
                    table.ForeignKey(
                        name: "FK_BranchFinancialYears_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchFinancialYears_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalOrders",
                schema: "public",
                columns: table => new
                {
                    JournalOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VouvherNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalOrders", x => x.JournalOrderId);
                    table.ForeignKey(
                        name: "FK_JournalOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgerSubGroupDevs",
                schema: "public",
                columns: table => new
                {
                    LedgerSubGroupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubGroupName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerSubGroupDevs", x => x.LedgerSubGroupId);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroupDevs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_LedgerSubGroupDevs_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgerSubGroups",
                schema: "public",
                columns: table => new
                {
                    LedgerSubGroupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubGroupName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerSubGroups", x => x.LedgerSubGroupId);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroups_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgerSubGroups_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InwardSupplyOrders",
                schema: "public",
                columns: table => new
                {
                    InwardSupplyOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    FromBranch = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardSupplyOrders", x => x.InwardSupplyOrderId);
                    table.ForeignKey(
                        name: "FK_InwardSupplyOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardSupplyOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardSupplyOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutwardSupplyOrders",
                schema: "public",
                columns: table => new
                {
                    OutwardSupplyOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    ToBranch = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwardSupplyOrders", x => x.OutwardSupplyOrderId);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                schema: "public",
                columns: table => new
                {
                    ProductGroupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ProductGroupName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupId);
                    table.ForeignKey(
                        name: "FK_ProductGroups_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dists",
                schema: "public",
                columns: table => new
                {
                    DistId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dists", x => x.DistId);
                    table.ForeignKey(
                        name: "FK_Dists_Country_Fk_CountryId",
                        column: x => x.Fk_CountryId,
                        principalSchema: "public",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dists_States_Fk_StateId",
                        column: x => x.Fk_StateId,
                        principalSchema: "public",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgersDev",
                schema: "public",
                columns: table => new
                {
                    LedgerId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    LedgerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LedgerType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    HasSubLedger = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerSubGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgersDev", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_LedgersDev_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
                        column: x => x.Fk_LedgerSubGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerSubGroupDevs",
                        principalColumn: "LedgerSubGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ledgers",
                schema: "public",
                columns: table => new
                {
                    LedgerId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LedgerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LedgerType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    HasSubLedger = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerSubGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_Ledgers_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ledgers_LedgerSubGroups_Fk_LedgerSubGroupId",
                        column: x => x.Fk_LedgerSubGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerSubGroups",
                        principalColumn: "LedgerSubGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubGroups",
                schema: "public",
                columns: table => new
                {
                    ProductSubGroupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_ProductGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductSubGroupName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubGroups", x => x.ProductSubGroupId);
                    table.ForeignKey(
                        name: "FK_ProductSubGroups_ProductGroups_Fk_ProductGroupId",
                        column: x => x.Fk_ProductGroupId,
                        principalSchema: "public",
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "public",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValue: new DateTime(2025, 1, 13, 5, 9, 49, 126, DateTimeKind.Utc).AddTicks(2433)),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValue: new DateTime(2025, 1, 13, 5, 9, 49, 126, DateTimeKind.Utc).AddTicks(4516)),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    DistId = table.Column<Guid>(type: "uuid", nullable: true),
                    StateId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_DistId = table.Column<Guid>(type: "uuid", nullable: false),
                    At = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Post = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PinCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "Country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Address_Dists_DistId",
                        column: x => x.DistId,
                        principalSchema: "public",
                        principalTable: "Dists",
                        principalColumn: "DistId");
                    table.ForeignKey(
                        name: "FK_Address_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "public",
                        principalTable: "States",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentOrders",
                schema: "public",
                columns: table => new
                {
                    PaymentOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VouvherNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Fk_CashBankLedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChequeNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ChequeDate = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DrCr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrders", x => x.PaymentOrderId);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_LedgersDev_Fk_CashBankLedgerId",
                        column: x => x.Fk_CashBankLedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptOrders",
                schema: "public",
                columns: table => new
                {
                    ReceiptOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VouvherNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Fk_CashBankLedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChequeNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ChequeDate = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptOrders", x => x.ReceiptOrderId);
                    table.ForeignKey(
                        name: "FK_ReceiptOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptOrders_LedgersDev_Fk_CashBankLedgerId",
                        column: x => x.Fk_CashBankLedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgerBalances",
                schema: "public",
                columns: table => new
                {
                    LedgerBalanceId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_LedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    OpeningBalanceType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    RunningBalance = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    RunningBalanceType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerBalances", x => x.LedgerBalanceId);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_LedgersDev_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgerBalances_Ledgers_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubLedgers",
                schema: "public",
                columns: table => new
                {
                    SubLedgerId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_LedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubLedgerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgers", x => x.SubLedgerId);
                    table.ForeignKey(
                        name: "FK_SubLedgers_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubLedgers_LedgersDev_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubLedgers_Ledgers_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "public",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ProductName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RetailPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    WholeSalePrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GST = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductStockUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductSubGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_Fk_ProductGroupId",
                        column: x => x.Fk_ProductGroupId,
                        principalSchema: "public",
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductSubGroups_Fk_ProductSubGroupId",
                        column: x => x.Fk_ProductSubGroupId,
                        principalSchema: "public",
                        principalTable: "ProductSubGroups",
                        principalColumn: "ProductSubGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_Fk_ProductStockUnitId",
                        column: x => x.Fk_ProductStockUnitId,
                        principalSchema: "public",
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fk_TokenId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    MaratialStatus = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    TermCondition = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_Fk_AddressId",
                        column: x => x.Fk_AddressId,
                        principalSchema: "public",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_RegisterTokens_Fk_TokenId",
                        column: x => x.Fk_TokenId,
                        principalSchema: "public",
                        principalTable: "RegisterTokens",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalTransactions",
                schema: "public",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_JournalOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_JournalOrders_Fk_JournalOrderId",
                        column: x => x.Fk_JournalOrderId,
                        principalSchema: "public",
                        principalTable: "JournalOrders",
                        principalColumn: "JournalOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_LedgersDev_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_Ledgers_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalTransactions_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labours",
                schema: "public",
                columns: table => new
                {
                    LabourId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LabourName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Fk_AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_Labour_TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labours", x => x.LabourId);
                    table.ForeignKey(
                        name: "FK_Labours_Address_Fk_AddressId",
                        column: x => x.Fk_AddressId,
                        principalSchema: "public",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labours_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labours_LabourTypes_Fk_Labour_TypeId",
                        column: x => x.Fk_Labour_TypeId,
                        principalSchema: "public",
                        principalTable: "LabourTypes",
                        principalColumn: "LabourTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labours_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                schema: "public",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_PartyType = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubledgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    GstNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Parties_Address_Fk_AddressId",
                        column: x => x.Fk_AddressId,
                        principalSchema: "public",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parties_LedgersDev_Fk_PartyType",
                        column: x => x.Fk_PartyType,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parties_SubLedgers_Fk_SubledgerId",
                        column: x => x.Fk_SubledgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                schema: "public",
                columns: table => new
                {
                    PaymentTransactionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_PaymentOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.PaymentTransactionId);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_LedgersDev_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Ledgers_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_PaymentOrders_Fk_PaymentOrderId",
                        column: x => x.Fk_PaymentOrderId,
                        principalSchema: "public",
                        principalTable: "PaymentOrders",
                        principalColumn: "PaymentOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "public",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    InvoiceNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TransportationCharges = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TranspoterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VehicleNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ReceivingPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnOrders",
                schema: "public",
                columns: table => new
                {
                    PurchaseReturnOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    InvoiceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    TranspoterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VehicleNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReceivingPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TransportationCharges = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    SubTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnOrders", x => x.PurchaseReturnOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptTransactions",
                schema: "public",
                columns: table => new
                {
                    ReceiptTransactiontId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_ReceiptOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    DrCr = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptTransactions", x => x.ReceiptTransactiontId);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_LedgersDev_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "LedgersDev",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_Ledgers_Fk_LedgerId",
                        column: x => x.Fk_LedgerId,
                        principalSchema: "public",
                        principalTable: "Ledgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_ReceiptOrders_Fk_ReceiptOrderId",
                        column: x => x.Fk_ReceiptOrderId,
                        principalSchema: "public",
                        principalTable: "ReceiptOrders",
                        principalColumn: "ReceiptOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTransactions_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                schema: "public",
                columns: table => new
                {
                    SalesOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    TransactionType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    PriceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TranspoterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VehicleNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReceivingPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnOrders",
                schema: "public",
                columns: table => new
                {
                    SalesReturnOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    TransactionType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PriceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GrandTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    TranspoterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VehicleNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReceivingPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Narration = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnOrders", x => x.SalesReturnOrderId);
                    table.ForeignKey(
                        name: "FK_SalesReturnOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnOrders_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubLedgerBalances",
                schema: "public",
                columns: table => new
                {
                    SubLedgerBalanceId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_LedgerBalanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubLedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    OpeningBalanceType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    RunningBalance = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    RunningBalanceType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgerBalances", x => x.SubLedgerBalanceId);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_LedgerBalances_Fk_LedgerBalanceId",
                        column: x => x.Fk_LedgerBalanceId,
                        principalSchema: "public",
                        principalTable: "LedgerBalances",
                        principalColumn: "LedgerBalanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubLedgerBalances_SubLedgers_Fk_SubLedgerId",
                        column: x => x.Fk_SubLedgerId,
                        principalSchema: "public",
                        principalTable: "SubLedgers",
                        principalColumn: "SubLedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternateUnits",
                schema: "public",
                columns: table => new
                {
                    AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FK_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitQuantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Fk_UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlternateQuantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Fk_ProductStockUnitId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternateUnits", x => x.AlternateUnitId);
                    table.ForeignKey(
                        name: "FK_AlternateUnits_Products_FK_ProductId",
                        column: x => x.FK_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlternateUnits_Units_Fk_UnitId",
                        column: x => x.Fk_UnitId,
                        principalSchema: "public",
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InwardSupplyTransactions",
                schema: "public",
                columns: table => new
                {
                    InwardSupplyTransactionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_InwardSupplyOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Fk_UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardSupplyTransactions", x => x.InwardSupplyTransactionId);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_InwardSupplyOrders_Fk_InwardSupply~",
                        column: x => x.Fk_InwardSupplyOrderId,
                        principalSchema: "public",
                        principalTable: "InwardSupplyOrders",
                        principalColumn: "InwardSupplyOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardSupplyTransactions_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "public",
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "LabourRates",
                schema: "public",
                columns: table => new
                {
                    LabourRateId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    Rate = table.Column<decimal>(type: "numeric(18,4)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourRates", x => x.LabourRateId);
                    table.ForeignKey(
                        name: "FK_LabourRates_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourRates_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourRates_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourRates_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutwardSupplyTransactions",
                schema: "public",
                columns: table => new
                {
                    OutwardSupplyTransactionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: true),
                    Fk_OutwardSupplyOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Fk_UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwardSupplyTransactions", x => x.OutwardSupplyTransactionId);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_OutwardSupplyOrders_Fk_OutwardSup~",
                        column: x => x.Fk_OutwardSupplyOrderId,
                        principalSchema: "public",
                        principalTable: "OutwardSupplyOrders",
                        principalColumn: "OutwardSupplyOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwardSupplyTransactions_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "public",
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrderSetups",
                schema: "public",
                columns: table => new
                {
                    ProductionOrderSetupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_FinishedGoodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrderSetups", x => x.ProductionOrderSetupId);
                    table.ForeignKey(
                        name: "FK_ProductionOrderSetups_Products_Fk_FinishedGoodId",
                        column: x => x.Fk_FinishedGoodId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderSetups",
                schema: "public",
                columns: table => new
                {
                    SalesOrderSetupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_FinishedGoodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderSetups", x => x.SalesOrderSetupId);
                    table.ForeignKey(
                        name: "FK_SalesOrderSetups_Products_Fk_FinishedGoodId",
                        column: x => x.Fk_FinishedGoodId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "public",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    MinQty = table.Column<decimal>(type: "numeric(18,5)", nullable: false, defaultValue: 0m),
                    MaxQty = table.Column<decimal>(type: "numeric(18,5)", nullable: false, defaultValue: 0m),
                    OpeningStock = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    AvilableStock = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "public",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "public",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranches",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_UserId = table.Column<string>(type: "text", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBranches_AspNetUsers_Fk_UserId",
                        column: x => x.Fk_UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranches_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamageOrders",
                schema: "public",
                columns: table => new
                {
                    DamageOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Fk_ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_LabourId = table.Column<string>(type: "text", nullable: true),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageOrders", x => x.DamageOrderId);
                    table.ForeignKey(
                        name: "FK_DamageOrders_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageOrders_Labours_Fk_LabourId",
                        column: x => x.Fk_LabourId,
                        principalSchema: "public",
                        principalTable: "Labours",
                        principalColumn: "LabourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageOrders_ProductTypes_Fk_ProductTypeId",
                        column: x => x.Fk_ProductTypeId,
                        principalSchema: "public",
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                schema: "public",
                columns: table => new
                {
                    ProductionOrderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TransactionNo = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Fk_LabourId = table.Column<string>(type: "text", nullable: false),
                    OTAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Narration = table.Column<string>(type: "text", nullable: true),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    FK_BranchId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.ProductionOrderId);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Branches_FK_BranchId",
                        column: x => x.FK_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Labours_Fk_LabourId",
                        column: x => x.Fk_LabourId,
                        principalSchema: "public",
                        principalTable: "Labours",
                        principalColumn: "LabourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnTransactions",
                schema: "public",
                columns: table => new
                {
                    PurchaseReturnId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_PurchaseReturnOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlternateQuantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false, defaultValue: 0m),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitQuantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false, defaultValue: 0m),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    DiscountAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    GstAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnTransactions", x => x.PurchaseReturnId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTransactions_PurchaseReturnOrders_Fk_Purchase~",
                        column: x => x.Fk_PurchaseReturnOrderId,
                        principalSchema: "public",
                        principalTable: "PurchaseReturnOrders",
                        principalColumn: "PurchaseReturnOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions",
                schema: "public",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_PurchaseOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_PurchaseOrders_Fk_PurchaseOrderId",
                        column: x => x.Fk_PurchaseOrderId,
                        principalSchema: "public",
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnTransactions",
                schema: "public",
                columns: table => new
                {
                    SalesReturnId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_SalesReturnOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnTransactions", x => x.SalesReturnId);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnTransactions_SalesReturnOrders_Fk_SalesReturnOrd~",
                        column: x => x.Fk_SalesReturnOrderId,
                        principalSchema: "public",
                        principalTable: "SalesReturnOrders",
                        principalColumn: "SalesReturnOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTransaction",
                schema: "public",
                columns: table => new
                {
                    SalesId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_SalesOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Gst = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTransaction", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTransaction_SalesOrders_Fk_SalesOrderId",
                        column: x => x.Fk_SalesOrderId,
                        principalSchema: "public",
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTransactionSetups",
                schema: "public",
                columns: table => new
                {
                    ProductionTransactionSetupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_ProductionOrderSetupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_RawMaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTransactionSetups", x => x.ProductionTransactionSetupId);
                    table.ForeignKey(
                        name: "FK_ProductionTransactionSetups_AlternateUnits_Fk_AlternateUnit~",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTransactionSetups_ProductionOrderSetups_Fk_Produc~",
                        column: x => x.Fk_ProductionOrderSetupId,
                        principalSchema: "public",
                        principalTable: "ProductionOrderSetups",
                        principalColumn: "ProductionOrderSetupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTransactionSetups_Products_Fk_RawMaterialId",
                        column: x => x.Fk_RawMaterialId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTransactionSetups",
                schema: "public",
                columns: table => new
                {
                    SalesTransactionSetupId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_SalesOrderSetupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_SubFinishedGoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTransactionSetups", x => x.SalesTransactionSetupId);
                    table.ForeignKey(
                        name: "FK_SalesTransactionSetups_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTransactionSetups_Products_Fk_SubFinishedGoodId",
                        column: x => x.Fk_SubFinishedGoodId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTransactionSetups_SalesOrderSetups_Fk_SalesOrderSetupId",
                        column: x => x.Fk_SalesOrderSetupId,
                        principalSchema: "public",
                        principalTable: "SalesOrderSetups",
                        principalColumn: "SalesOrderSetupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamageTransactions",
                schema: "public",
                columns: table => new
                {
                    DamageTransactionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_DamageOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTransactions", x => x.DamageTransactionId);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_DamageOrders_Fk_DamageOrderId",
                        column: x => x.Fk_DamageOrderId,
                        principalSchema: "public",
                        principalTable: "DamageOrders",
                        principalColumn: "DamageOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabourTransactions",
                schema: "public",
                columns: table => new
                {
                    ProductionTransactionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Fk_ProductionOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Fk_AlternateUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,4)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourTransactions", x => x.ProductionTransactionId);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_AlternateUnits_Fk_AlternateUnitId",
                        column: x => x.Fk_AlternateUnitId,
                        principalSchema: "public",
                        principalTable: "AlternateUnits",
                        principalColumn: "AlternateUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_Branches_Fk_BranchId",
                        column: x => x.Fk_BranchId,
                        principalSchema: "public",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_FinancialYears_Fk_FinancialYearId",
                        column: x => x.Fk_FinancialYearId,
                        principalSchema: "public",
                        principalTable: "FinancialYears",
                        principalColumn: "FinancialYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_ProductionOrders_Fk_ProductionOrderId",
                        column: x => x.Fk_ProductionOrderId,
                        principalSchema: "public",
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourTransactions_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Address",
                columns: new[] { "AddressId", "At", "City", "CountryId", "CreatedBy", "DistId", "Fk_CountryId", "Fk_DistId", "Fk_StateId", "ModifyBy", "PinCode", "Post", "StateId" },
                values: new object[] { new Guid("c9b62c55-1b06-485d-a71b-d92fee4f4428"), "DHANAMANDAL", "CUTTACK", null, null, null, new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), null, "754018", "BRAHMANSAILO", null });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "438df919-342f-4ddf-87c4-6d7a16e64651", null, "User", "USER" },
                    { "5c3a5755-95c7-4f51-84c7-6d7a16e64651", null, "Admin", "ADMIN" },
                    { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", null, "Devloper", "DEVLOPER" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Country",
                columns: new[] { "CountryId", "CountryCode", "CountryName", "CreatedBy", "CreatedDate", "IsActive", "ModifyBy" },
                values: new object[] { new Guid("e02eb064-def5-434a-8798-6f144a54003c"), "IN", "India", null, new DateTime(2025, 1, 13, 5, 9, 49, 129, DateTimeKind.Utc).AddTicks(6556), true, null });

            migrationBuilder.InsertData(
                schema: "public",
                table: "LabourTypes",
                columns: new[] { "LabourTypeId", "Labour_Type" },
                values: new object[,]
                {
                    { new Guid("5e514855-55a0-459c-8b8b-def7696d9ad0"), "PRODUCTION" },
                    { new Guid("6c2758a2-79b5-43a6-8851-c6f975433b0f"), "SERVICE" }
                });

            migrationBuilder.InsertData(
                schema: "public",
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
                schema: "public",
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
                schema: "public",
                table: "RegisterTokens",
                columns: new[] { "TokenId", "IsActive", "TokenValue" },
                values: new object[] { new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), true, "123-123-1234" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fk_AddressId", "Fk_TokenId", "Gender", "LockoutEnabled", "LockoutEnd", "MaratialStatus", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TermCondition", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4431f16a-6bc7-4e9b-bada-c491fcc81a58", 0, new DateTime(1993, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "65a37859-d054-4a68-a817-1669d83c598a", "raypintu959@gmail.com", true, new Guid("c9b62c55-1b06-485d-a71b-d92fee4f4428"), new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), "male", true, null, "unmarred", "Pintu Ray", "RAYPINTU959@GMAIL.COM", "RAYPINTU959@GMAIL.COM", "AQAAAAIAAYagAAAAEGCZJkRuuaN5s6jesxs7zm4NBR99KorCbeWBm6yVLgn2JCBVFEKr5ui4hLYFkhQWCA==", "8249486590", true, null, "ZCKN4FWVQMFYYU3JWBLJN7UUN2CBOZMF", true, true, "raypintu959@gmail.com" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "LedgersDev",
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
                schema: "public",
                table: "States",
                columns: new[] { "StateId", "CreatedBy", "CreatedDate", "Fk_CountryId", "IsActive", "ModifyBy", "StateName" },
                values: new object[,]
                {
                    { new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9995), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Delhi (UT)" },
                    { new Guid("188ab651-af96-41d2-adc4-0af044e6d056"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9823), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Chhattisgarh" },
                    { new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9886), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Manipur" },
                    { new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9832), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Gujarat" },
                    { new Guid("2898a196-c192-40b6-9865-f7aa4018681c"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9956), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Tripura" },
                    { new Guid("2b525373-afcc-4fb1-9525-495db02029f8"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9910), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Rajasthan" },
                    { new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9903), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Odisha" },
                    { new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9922), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Telangana" },
                    { new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9964), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Uttarakhand" },
                    { new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"), null, new DateTime(2025, 1, 13, 5, 9, 49, 136, DateTimeKind.Utc).AddTicks(3), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Lakshadweep (UT)" },
                    { new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9968), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "West Bengal" },
                    { new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9855), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Madhya Pradesh" },
                    { new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9907), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Punjab" },
                    { new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9387), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Andhra Pradesh" },
                    { new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9899), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Nagaland" },
                    { new Guid("77536c53-345c-48f5-a175-07a7b4044754"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9981), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Jammu & Kashmir (UT)" },
                    { new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9882), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Maharashtra" },
                    { new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9779), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Assam" },
                    { new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9895), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Mizoram" },
                    { new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9819), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Bihar" },
                    { new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9892), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Meghalaya" },
                    { new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"), null, new DateTime(2025, 1, 13, 5, 9, 49, 136, DateTimeKind.Utc).AddTicks(6), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Andaman and Nicobar Islands (UT)" },
                    { new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9914), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Sikkim" },
                    { new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9844), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Jharkhand" },
                    { new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9848), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Karnataka" },
                    { new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9827), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Goa" },
                    { new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9918), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Tamil Nadu" },
                    { new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9985), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Ladakh (UT)" },
                    { new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9837), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Haryana" },
                    { new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9851), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Kerala" },
                    { new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9991), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Chandigarh (UT)" },
                    { new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9998), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Puducherry (UT)" },
                    { new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9774), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Arunachal Pradesh" },
                    { new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9840), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Himachal Pradesh" },
                    { new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9977), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Daman & Diu (UT)" },
                    { new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9961), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Uttar Pradesh" },
                    { new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"), null, new DateTime(2025, 1, 13, 5, 9, 49, 135, DateTimeKind.Utc).AddTicks(9972), new Guid("e02eb064-def5-434a-8798-6f144a54003c"), true, null, "Dadra and Nagar Haveli (UT)" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "UserId" },
                values: new object[,]
                {
                    { 1, "Create", "Create", "AppUserClaim", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                    { 2, "Update", "Update", "AppUserClaim", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                    { 3, "Delete", "Delete", "AppUserClaim", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedDate", "Discriminator", "ModifyBy", "ModifyDate" },
                values: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58", "System", new DateTime(2025, 1, 13, 5, 9, 49, 7, DateTimeKind.Utc).AddTicks(4746), "AppUserRole", "System", new DateTime(2025, 1, 13, 5, 9, 49, 7, DateTimeKind.Utc).AddTicks(5849) });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Dists",
                columns: new[] { "DistId", "CreatedBy", "CreatedDate", "DistName", "Fk_CountryId", "Fk_StateId", "IsActive", "ModifyBy" },
                values: new object[,]
                {
                    { new Guid("00191050-6e42-4aec-8df4-5a4dda8479ee"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(3951), "Angul", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("05111caa-801f-4201-8169-ceaa54a74e51"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4360), "Balangir", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("061206dc-39d7-4d0e-a72a-3c058014347b"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4368), "Balasore", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("1aaf6c72-3308-4c01-8caf-b9fdfb79e964"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4374), "Bargarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("2cc4b79c-ea4c-4433-86a5-f8d1ca1b22d3"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4378), "Bhadrak", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("2f95b1ff-8ddc-415e-9617-b7ccecfaf595"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4383), "Boudh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4388), "Cuttack", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("4f6f5c1f-8cd9-4cfa-9fbc-4cf2baf9af37"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4392), "Debagarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("545de00f-a0d8-4e26-a028-b871849523a0"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4397), "Dhenkanal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("5b458db9-4fb2-47fd-b22f-e931b5c403fc"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4402), "Gajapati", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("5d7bd772-5210-4790-8ab2-45b1282b8b70"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4501), "Ganjam", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("5e9856e9-f413-4bfc-b18c-33d2d95bee8f"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4506), "Jagatsinghapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("63ed7f68-2550-4f5a-b5f8-edd290ff4a43"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4511), "Jajpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("651b4906-a3c0-4085-a995-d95557ce4fe9"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4515), "Jharsuguda", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("655f35d9-d2aa-4c62-95b2-eb95cf5480e4"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4520), "Kalahandi", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("6fa770a9-5ba3-4cee-9b9d-67f4d70c558c"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4524), "Kandhamal", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("7244c798-e695-4edc-9894-87e5ff4944e2"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4613), "Sundargarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("a00b3a52-cdb5-4e6e-afc5-474f66614a8c"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4609), "Subarnapur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("a266f1cb-cbd1-4d3e-9c09-2c13cd85c19a"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4604), "Sambalpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("b4e62c5b-42db-4eb6-b120-cb0d15ca8f48"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4600), "Rayagada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("ca257efa-7b94-4e20-8938-bbb810185d8e"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4595), "Puri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("d4b11083-8f76-4ff9-86c6-56719c6762f0"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4589), "Nuapada", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("d71bbbc0-f66c-4951-b27b-5b6536f03fa8"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4584), "Nayagarh", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("d77c8178-6678-4f4b-961e-a167a3681efd"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4579), "Nabarangpur", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("d979569b-cf54-4861-b9fd-7c36921237d4"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4575), "Mayurbhanj", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("dd205972-117a-4a46-9727-6cad22ce7ebe"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4570), "Malkangiri", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("e1e34023-313b-4c1b-a72d-e0895a9ce87a"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4542), "Koraput", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("f25f937c-30e3-4d30-b54e-fc4377257987"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4538), "Khordha", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("f270c1c1-82c5-4171-a491-6c89eec056ec"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4533), "Kendujhar", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null },
                    { new Guid("f4a67a44-27b9-44f9-9f29-f75a3bf6c625"), null, new DateTime(2025, 1, 13, 5, 9, 49, 143, DateTimeKind.Utc).AddTicks(4529), "Kendrapara", new Guid("e02eb064-def5-434a-8798-6f144a54003c"), new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"), true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                schema: "public",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistId",
                schema: "public",
                table: "Address",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                schema: "public",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternateUnits_FK_ProductId",
                schema: "public",
                table: "AlternateUnits",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternateUnits_Fk_UnitId",
                schema: "public",
                table: "AlternateUnits",
                column: "Fk_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "public",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "public",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "public",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "public",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "public",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Fk_AddressId",
                schema: "public",
                table: "AspNetUsers",
                column: "Fk_AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Fk_TokenId",
                schema: "public",
                table: "AspNetUsers",
                column: "Fk_TokenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchFinancialYears_Fk_BranchId",
                schema: "public",
                table: "BranchFinancialYears",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFinancialYears_Fk_FinancialYearId",
                schema: "public",
                table: "BranchFinancialYears",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Fk_BranchId",
                schema: "public",
                table: "Company",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_BranchId",
                schema: "public",
                table: "DamageOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_FinancialYearId",
                schema: "public",
                table: "DamageOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_LabourId",
                schema: "public",
                table: "DamageOrders",
                column: "Fk_LabourId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageOrders_Fk_ProductTypeId",
                schema: "public",
                table: "DamageOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_AlternateUnitId",
                schema: "public",
                table: "DamageTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_BranchId",
                schema: "public",
                table: "DamageTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_DamageOrderId",
                schema: "public",
                table: "DamageTransactions",
                column: "Fk_DamageOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "DamageTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTransactions_Fk_ProductId",
                schema: "public",
                table: "DamageTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Dists_Fk_CountryId",
                schema: "public",
                table: "Dists",
                column: "Fk_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dists_Fk_StateId",
                schema: "public",
                table: "Dists",
                column: "Fk_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyOrders_Fk_BranchId",
                schema: "public",
                table: "InwardSupplyOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyOrders_Fk_FinancialYearId",
                schema: "public",
                table: "InwardSupplyOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyOrders_Fk_ProductTypeId",
                schema: "public",
                table: "InwardSupplyOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_BranchId",
                schema: "public",
                table: "InwardSupplyTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "InwardSupplyTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_InwardSupplyOrderId",
                schema: "public",
                table: "InwardSupplyTransactions",
                column: "Fk_InwardSupplyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_Fk_ProductId",
                schema: "public",
                table: "InwardSupplyTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardSupplyTransactions_UnitId",
                schema: "public",
                table: "InwardSupplyTransactions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalOrders_Fk_BranchId",
                schema: "public",
                table: "JournalOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalOrders_Fk_FinancialYearId",
                schema: "public",
                table: "JournalOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_BranchId",
                schema: "public",
                table: "JournalTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "JournalTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_JournalOrderId",
                schema: "public",
                table: "JournalTransactions",
                column: "Fk_JournalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_LedgerGroupId",
                schema: "public",
                table: "JournalTransactions",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_LedgerId",
                schema: "public",
                table: "JournalTransactions",
                column: "Fk_LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalTransactions_Fk_SubLedgerId",
                schema: "public",
                table: "JournalTransactions",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_BranchId",
                schema: "public",
                table: "LabourRates",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_FinancialYearId",
                schema: "public",
                table: "LabourRates",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_ProductId",
                schema: "public",
                table: "LabourRates",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourRates_Fk_ProductTypeId",
                schema: "public",
                table: "LabourRates",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_AddressId",
                schema: "public",
                table: "Labours",
                column: "Fk_AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_BranchId",
                schema: "public",
                table: "Labours",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_Labour_TypeId",
                schema: "public",
                table: "Labours",
                column: "Fk_Labour_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_Fk_SubLedgerId",
                schema: "public",
                table: "Labours",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_AlternateUnitId",
                schema: "public",
                table: "LabourTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_BranchId",
                schema: "public",
                table: "LabourTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "LabourTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_ProductId",
                schema: "public",
                table: "LabourTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourTransactions_Fk_ProductionOrderId",
                schema: "public",
                table: "LabourTransactions",
                column: "Fk_ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_Fk_BranchId",
                schema: "public",
                table: "LedgerBalances",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_Fk_FinancialYearId",
                schema: "public",
                table: "LedgerBalances",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerBalances_Fk_LedgerId",
                schema: "public",
                table: "LedgerBalances",
                column: "Fk_LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Fk_LedgerGroupId",
                schema: "public",
                table: "Ledgers",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Fk_LedgerSubGroupId",
                schema: "public",
                table: "Ledgers",
                column: "Fk_LedgerSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgersDev_Fk_LedgerGroupId",
                schema: "public",
                table: "LedgersDev",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgersDev_Fk_LedgerSubGroupId",
                schema: "public",
                table: "LedgersDev",
                column: "Fk_LedgerSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroupDevs_BranchId",
                schema: "public",
                table: "LedgerSubGroupDevs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroupDevs_Fk_LedgerGroupId",
                schema: "public",
                table: "LedgerSubGroupDevs",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroups_Fk_BranchId",
                schema: "public",
                table: "LedgerSubGroups",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerSubGroups_Fk_LedgerGroupId",
                schema: "public",
                table: "LedgerSubGroups",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyOrders_Fk_BranchId",
                schema: "public",
                table: "OutwardSupplyOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyOrders_Fk_FinancialYearId",
                schema: "public",
                table: "OutwardSupplyOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyOrders_Fk_ProductTypeId",
                schema: "public",
                table: "OutwardSupplyOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_BranchId",
                schema: "public",
                table: "OutwardSupplyTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "OutwardSupplyTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_OutwardSupplyOrderId",
                schema: "public",
                table: "OutwardSupplyTransactions",
                column: "Fk_OutwardSupplyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_Fk_ProductId",
                schema: "public",
                table: "OutwardSupplyTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardSupplyTransactions_UnitId",
                schema: "public",
                table: "OutwardSupplyTransactions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_AddressId",
                schema: "public",
                table: "Parties",
                column: "Fk_AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_PartyType",
                schema: "public",
                table: "Parties",
                column: "Fk_PartyType");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Fk_SubledgerId",
                schema: "public",
                table: "Parties",
                column: "Fk_SubledgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_Fk_BranchId",
                schema: "public",
                table: "PaymentOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_Fk_CashBankLedgerId",
                schema: "public",
                table: "PaymentOrders",
                column: "Fk_CashBankLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_Fk_FinancialYearId",
                schema: "public",
                table: "PaymentOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Fk_BranchId",
                schema: "public",
                table: "PaymentTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "PaymentTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Fk_LedgerGroupId",
                schema: "public",
                table: "PaymentTransactions",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Fk_LedgerId",
                schema: "public",
                table: "PaymentTransactions",
                column: "Fk_LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Fk_PaymentOrderId",
                schema: "public",
                table: "PaymentTransactions",
                column: "Fk_PaymentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Fk_SubLedgerId",
                schema: "public",
                table: "PaymentTransactions",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_Fk_ProductTypeId",
                schema: "public",
                table: "ProductGroups",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_FK_BranchId",
                schema: "public",
                table: "ProductionOrders",
                column: "FK_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_Fk_FinancialYearId",
                schema: "public",
                table: "ProductionOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_Fk_LabourId",
                schema: "public",
                table: "ProductionOrders",
                column: "Fk_LabourId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderSetups_Fk_FinishedGoodId",
                schema: "public",
                table: "ProductionOrderSetups",
                column: "Fk_FinishedGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactionSetups_Fk_AlternateUnitId",
                schema: "public",
                table: "ProductionTransactionSetups",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactionSetups_Fk_ProductionOrderSetupId",
                schema: "public",
                table: "ProductionTransactionSetups",
                column: "Fk_ProductionOrderSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactionSetups_Fk_RawMaterialId",
                schema: "public",
                table: "ProductionTransactionSetups",
                column: "Fk_RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductGroupId",
                schema: "public",
                table: "Products",
                column: "Fk_ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductStockUnitId",
                schema: "public",
                table: "Products",
                column: "Fk_ProductStockUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductSubGroupId",
                schema: "public",
                table: "Products",
                column: "Fk_ProductSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ProductTypeId",
                schema: "public",
                table: "Products",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubGroups_Fk_ProductGroupId",
                schema: "public",
                table: "ProductSubGroups",
                column: "Fk_ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_BranchId",
                schema: "public",
                table: "PurchaseOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_FinancialYearId",
                schema: "public",
                table: "PurchaseOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_ProductTypeId",
                schema: "public",
                table: "PurchaseOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_Fk_SubLedgerId",
                schema: "public",
                table: "PurchaseOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_BranchId",
                schema: "public",
                table: "PurchaseReturnOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_FinancialYearId",
                schema: "public",
                table: "PurchaseReturnOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_ProductTypeId",
                schema: "public",
                table: "PurchaseReturnOrders",
                column: "Fk_ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnOrders_Fk_SubLedgerId",
                schema: "public",
                table: "PurchaseReturnOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_AlternateUnitId",
                schema: "public",
                table: "PurchaseReturnTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_BranchId",
                schema: "public",
                table: "PurchaseReturnTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "PurchaseReturnTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_ProductId",
                schema: "public",
                table: "PurchaseReturnTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTransactions_Fk_PurchaseReturnOrderId",
                schema: "public",
                table: "PurchaseReturnTransactions",
                column: "Fk_PurchaseReturnOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_AlternateUnitId",
                schema: "public",
                table: "PurchaseTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_BranchId",
                schema: "public",
                table: "PurchaseTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "PurchaseTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_ProductId",
                schema: "public",
                table: "PurchaseTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Fk_PurchaseOrderId",
                schema: "public",
                table: "PurchaseTransactions",
                column: "Fk_PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptOrders_Fk_BranchId",
                schema: "public",
                table: "ReceiptOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptOrders_Fk_CashBankLedgerId",
                schema: "public",
                table: "ReceiptOrders",
                column: "Fk_CashBankLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptOrders_Fk_FinancialYearId",
                schema: "public",
                table: "ReceiptOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_BranchId",
                schema: "public",
                table: "ReceiptTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "ReceiptTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_LedgerGroupId",
                schema: "public",
                table: "ReceiptTransactions",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_LedgerId",
                schema: "public",
                table: "ReceiptTransactions",
                column: "Fk_LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_ReceiptOrderId",
                schema: "public",
                table: "ReceiptTransactions",
                column: "Fk_ReceiptOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTransactions_Fk_SubLedgerId",
                schema: "public",
                table: "ReceiptTransactions",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Fk_BranchId",
                schema: "public",
                table: "SalesOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Fk_FinancialYearId",
                schema: "public",
                table: "SalesOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_Fk_SubLedgerId",
                schema: "public",
                table: "SalesOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderSetups_Fk_FinishedGoodId",
                schema: "public",
                table: "SalesOrderSetups",
                column: "Fk_FinishedGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnOrders_Fk_BranchId",
                schema: "public",
                table: "SalesReturnOrders",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnOrders_Fk_FinancialYearId",
                schema: "public",
                table: "SalesReturnOrders",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnOrders_Fk_SubLedgerId",
                schema: "public",
                table: "SalesReturnOrders",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_AlternateUnitId",
                schema: "public",
                table: "SalesReturnTransactions",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_BranchId",
                schema: "public",
                table: "SalesReturnTransactions",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_FinancialYearId",
                schema: "public",
                table: "SalesReturnTransactions",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_ProductId",
                schema: "public",
                table: "SalesReturnTransactions",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTransactions_Fk_SalesReturnOrderId",
                schema: "public",
                table: "SalesReturnTransactions",
                column: "Fk_SalesReturnOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_AlternateUnitId",
                schema: "public",
                table: "SalesTransaction",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_BranchId",
                schema: "public",
                table: "SalesTransaction",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_FinancialYearId",
                schema: "public",
                table: "SalesTransaction",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_ProductId",
                schema: "public",
                table: "SalesTransaction",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransaction_Fk_SalesOrderId",
                schema: "public",
                table: "SalesTransaction",
                column: "Fk_SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransactionSetups_Fk_AlternateUnitId",
                schema: "public",
                table: "SalesTransactionSetups",
                column: "Fk_AlternateUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransactionSetups_Fk_SalesOrderSetupId",
                schema: "public",
                table: "SalesTransactionSetups",
                column: "Fk_SalesOrderSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransactionSetups_Fk_SubFinishedGoodId",
                schema: "public",
                table: "SalesTransactionSetups",
                column: "Fk_SubFinishedGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Fk_CountryId",
                schema: "public",
                table: "States",
                column: "Fk_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Fk_BranchId",
                schema: "public",
                table: "Stocks",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Fk_FinancialYearId",
                schema: "public",
                table: "Stocks",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Fk_ProductId",
                schema: "public",
                table: "Stocks",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_BranchId",
                schema: "public",
                table: "SubLedgerBalances",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_FinancialYearId",
                schema: "public",
                table: "SubLedgerBalances",
                column: "Fk_FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_LedgerBalanceId",
                schema: "public",
                table: "SubLedgerBalances",
                column: "Fk_LedgerBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerBalances_Fk_SubLedgerId",
                schema: "public",
                table: "SubLedgerBalances",
                column: "Fk_SubLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgers_Fk_BranchId",
                schema: "public",
                table: "SubLedgers",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgers_Fk_LedgerId",
                schema: "public",
                table: "SubLedgers",
                column: "Fk_LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_Fk_BranchId",
                schema: "public",
                table: "UserBranches",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_Fk_UserId",
                schema: "public",
                table: "UserBranches",
                column: "Fk_UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "public");

            migrationBuilder.DropTable(
                name: "BranchFinancialYears",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DamageTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "InwardSupplyTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "JournalTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LabourRates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LabourTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OutwardSupplyTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Parties",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PaymentTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductionTransactionSetups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PurchaseReturnTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReceiptTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesReturnTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesTransaction",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesTransactionSetups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SubLedgerBalances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UserBranches",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DamageOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "InwardSupplyOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "JournalOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductionOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OutwardSupplyOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PaymentOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductionOrderSetups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PurchaseReturnOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PurchaseOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReceiptOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesReturnOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AlternateUnits",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesOrderSetups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerBalances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Labours",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "FinancialYears",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RegisterTokens",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LabourTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SubLedgers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductSubGroups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Dists",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgersDev",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Ledgers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductGroups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "States",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerSubGroupDevs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerSubGroups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerGroups",
                schema: "public");
        }
    }
}
