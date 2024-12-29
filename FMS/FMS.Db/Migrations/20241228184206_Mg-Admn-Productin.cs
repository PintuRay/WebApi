using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class MgAdmnProductin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Fk_FinishedGoodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.ProductionOrderId);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Products_Fk_FinishedGoodId",
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
                name: "ProductionTransactions",
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
                    Fk_RawMaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    Unit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTransactions", x => x.ProductionTransactionId);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductionOrders_Fk_ProductionOrderId",
                        column: x => x.Fk_ProductionOrderId,
                        principalSchema: "public",
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_Products_Fk_RawMaterialId",
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
                    Unit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTransactionSetups", x => x.SalesTransactionSetupId);
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

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 12, 28, 18, 42, 4, 971, DateTimeKind.Utc).AddTicks(2403), new DateTime(2024, 12, 28, 18, 42, 4, 971, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_Fk_FinishedGoodId",
                schema: "public",
                table: "ProductionOrders",
                column: "Fk_FinishedGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_Fk_ProductionOrderId",
                schema: "public",
                table: "ProductionTransactions",
                column: "Fk_ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_Fk_RawMaterialId",
                schema: "public",
                table: "ProductionTransactions",
                column: "Fk_RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderSetups_Fk_FinishedGoodId",
                schema: "public",
                table: "SalesOrderSetups",
                column: "Fk_FinishedGoodId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionTransactions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesTransactionSetups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductionOrders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SalesOrderSetups",
                schema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 12, 26, 20, 10, 54, 953, DateTimeKind.Utc).AddTicks(5104), new DateTime(2024, 12, 26, 20, 10, 54, 953, DateTimeKind.Utc).AddTicks(6604) });
        }
    }
}
