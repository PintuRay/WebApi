using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class MgTableLeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ledgersDev_LedgerGroups_Fk_LedgerGroupId",
                schema: "public",
                table: "ledgersDev");

            migrationBuilder.DropForeignKey(
                name: "FK_ledgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
                schema: "public",
                table: "ledgersDev");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ledgersDev",
                schema: "public",
                table: "ledgersDev");

            migrationBuilder.RenameTable(
                name: "ledgersDev",
                schema: "public",
                newName: "LedgersDev",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_ledgersDev_Fk_LedgerSubGroupId",
                schema: "public",
                table: "LedgersDev",
                newName: "IX_LedgersDev_Fk_LedgerSubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ledgersDev_Fk_LedgerGroupId",
                schema: "public",
                table: "LedgersDev",
                newName: "IX_LedgersDev_Fk_LedgerGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LedgersDev",
                schema: "public",
                table: "LedgersDev",
                column: "LedgerId");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 12, 29, 3, 30, 20, 738, DateTimeKind.Utc).AddTicks(6719), new DateTime(2024, 12, 29, 3, 30, 20, 738, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.AddForeignKey(
                name: "FK_LedgersDev_LedgerGroups_Fk_LedgerGroupId",
                schema: "public",
                table: "LedgersDev",
                column: "Fk_LedgerGroupId",
                principalSchema: "public",
                principalTable: "LedgerGroups",
                principalColumn: "LedgerGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
                schema: "public",
                table: "LedgersDev",
                column: "Fk_LedgerSubGroupId",
                principalSchema: "public",
                principalTable: "LedgerSubGroupDevs",
                principalColumn: "LedgerSubGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgersDev_LedgerGroups_Fk_LedgerGroupId",
                schema: "public",
                table: "LedgersDev");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
                schema: "public",
                table: "LedgersDev");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LedgersDev",
                schema: "public",
                table: "LedgersDev");

            migrationBuilder.RenameTable(
                name: "LedgersDev",
                schema: "public",
                newName: "ledgersDev",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_LedgersDev_Fk_LedgerSubGroupId",
                schema: "public",
                table: "ledgersDev",
                newName: "IX_ledgersDev_Fk_LedgerSubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_LedgersDev_Fk_LedgerGroupId",
                schema: "public",
                table: "ledgersDev",
                newName: "IX_ledgersDev_Fk_LedgerGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ledgersDev",
                schema: "public",
                table: "ledgersDev",
                column: "LedgerId");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 30, 17, 439, DateTimeKind.Utc).AddTicks(4988), new DateTime(2024, 12, 28, 19, 30, 17, 439, DateTimeKind.Utc).AddTicks(6900) });

            migrationBuilder.AddForeignKey(
                name: "FK_ledgersDev_LedgerGroups_Fk_LedgerGroupId",
                schema: "public",
                table: "ledgersDev",
                column: "Fk_LedgerGroupId",
                principalSchema: "public",
                principalTable: "LedgerGroups",
                principalColumn: "LedgerGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ledgersDev_LedgerSubGroupDevs_Fk_LedgerSubGroupId",
                schema: "public",
                table: "ledgersDev",
                column: "Fk_LedgerSubGroupId",
                principalSchema: "public",
                principalTable: "LedgerSubGroupDevs",
                principalColumn: "LedgerSubGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
