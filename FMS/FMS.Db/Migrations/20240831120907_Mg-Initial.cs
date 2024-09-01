﻿using System;
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
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
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
                    FkTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_AspNetUsers_RegisterTokens_FkTokenId",
                        column: x => x.FkTokenId,
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
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fk_StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
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
                        principalColumn: "CityId",
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
                values: new object[] { new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), "System", new DateTime(2024, 8, 31, 12, 9, 4, 328, DateTimeKind.Utc).AddTicks(126), true, "System", new DateTime(2024, 8, 31, 12, 9, 4, 328, DateTimeKind.Utc).AddTicks(133), "123-123-1234" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FkTokenId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4431f16a-6bc7-4e9b-bada-c491fcc81a58", 0, "65a37859-d054-4a68-a817-1669d83c598a", "raypintu959@gmail.com", true, new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"), true, null, "Pintu Ray", "RAYPINTU959@GMAIL.COM", "RAYPINTU959@GMAIL.COM", "AQAAAAIAAYagAAAAEGCZJkRuuaN5s6jesxs7zm4NBR99KorCbeWBm6yVLgn2JCBVFEKr5ui4hLYFkhQWCA==", "8249486590", true, "ZCKN4FWVQMFYYU3JWBLJN7UUN2CBOZMF", true, "raypintu959@gmail.com" });

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
                values: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58", "System", new DateTime(2024, 8, 31, 12, 9, 4, 329, DateTimeKind.Utc).AddTicks(2044), "AppUserRole", "System", new DateTime(2024, 8, 31, 12, 9, 4, 329, DateTimeKind.Utc).AddTicks(2049) });

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
                name: "IX_AspNetUsers_FkTokenId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "FkTokenId",
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
