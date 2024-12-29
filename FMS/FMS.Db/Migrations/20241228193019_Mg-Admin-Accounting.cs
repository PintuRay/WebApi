using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class MgAdminAccounting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ledgersDev",
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
                    table.PrimaryKey("PK_ledgersDev", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_ledgersDev_LedgerGroups_Fk_LedgerGroupId",
                        column: x => x.Fk_LedgerGroupId,
                        principalSchema: "public",
                        principalTable: "LedgerGroups",
                        principalColumn: "LedgerGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ledgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
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

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 30, 17, 439, DateTimeKind.Utc).AddTicks(4988), new DateTime(2024, 12, 28, 19, 30, 17, 439, DateTimeKind.Utc).AddTicks(6900) });

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
                name: "IX_ledgersDev_Fk_LedgerGroupId",
                schema: "public",
                table: "ledgersDev",
                column: "Fk_LedgerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgersDev_Fk_LedgerSubGroupId",
                schema: "public",
                table: "ledgersDev",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledgers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ledgersDev",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerSubGroups",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerSubGroupDevs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "LedgerGroups",
                schema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 12, 28, 18, 42, 4, 971, DateTimeKind.Utc).AddTicks(2403), new DateTime(2024, 12, 28, 18, 42, 4, 971, DateTimeKind.Utc).AddTicks(3506) });
        }
    }
}
