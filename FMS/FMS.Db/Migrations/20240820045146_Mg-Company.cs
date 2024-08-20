using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class MgCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Fk_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438df919-342f-4ddf-87c4-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(4236), new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c3a5755-95c7-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(4248), new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(4274), new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(4276) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(5302), new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(5305) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(2489), new DateTime(2024, 8, 20, 4, 51, 45, 171, DateTimeKind.Utc).AddTicks(2494) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RegisterTokens",
                keyColumn: "TokenId",
                keyValue: new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 4, 51, 45, 169, DateTimeKind.Utc).AddTicks(4817), new DateTime(2024, 8, 20, 4, 51, 45, 169, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Fk_BranchId",
                schema: "dbo",
                table: "Company",
                column: "Fk_BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438df919-342f-4ddf-87c4-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(7599), new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(7601) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c3a5755-95c7-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(7606), new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(7607) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(7611), new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(8208), new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(8211) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(6614), new DateTime(2024, 8, 20, 2, 11, 7, 455, DateTimeKind.Utc).AddTicks(6616) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RegisterTokens",
                keyColumn: "TokenId",
                keyValue: new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 20, 2, 11, 7, 454, DateTimeKind.Utc).AddTicks(4770), new DateTime(2024, 8, 20, 2, 11, 7, 454, DateTimeKind.Utc).AddTicks(4776) });
        }
    }
}
