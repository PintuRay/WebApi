using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class Mg002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438df919-342f-4ddf-87c4-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(1106), new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c3a5755-95c7-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(1118), new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate", "Name", "NormalizedName" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(1127), new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(1128), "Devloper", "DEVLOPER" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(2117), new DateTime(2024, 8, 11, 4, 33, 50, 842, DateTimeKind.Utc).AddTicks(2120) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 33, 50, 841, DateTimeKind.Utc).AddTicks(9494), new DateTime(2024, 8, 11, 4, 33, 50, 841, DateTimeKind.Utc).AddTicks(9497) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RegisterTokens",
                keyColumn: "TokenId",
                keyValue: new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 33, 50, 840, DateTimeKind.Utc).AddTicks(4327), new DateTime(2024, 8, 11, 4, 33, 50, 840, DateTimeKind.Utc).AddTicks(4334) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438df919-342f-4ddf-87c4-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(9324), new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c3a5755-95c7-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(9335), new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(9336) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                columns: new[] { "CreatedDate", "ModifyDate", "Name", "NormalizedName" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(9341), new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(9342), "Developer", "DEVELOPER" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 19, 57, 777, DateTimeKind.Utc).AddTicks(459), new DateTime(2024, 8, 11, 4, 19, 57, 777, DateTimeKind.Utc).AddTicks(464) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(8182), new DateTime(2024, 8, 11, 4, 19, 57, 776, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RegisterTokens",
                keyColumn: "TokenId",
                keyValue: new Guid("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2024, 8, 11, 4, 19, 57, 775, DateTimeKind.Utc).AddTicks(4927), new DateTime(2024, 8, 11, 4, 19, 57, 775, DateTimeKind.Utc).AddTicks(4936) });
        }
    }
}
