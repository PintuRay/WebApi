using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class Mg003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_CountryId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Dists_DistId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_States_StateId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropTable(
                name: "BranchFinancialYears",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountryId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_DistId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StateId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DistId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StateId",
                schema: "public",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "Fk_BranchId",
                schema: "public",
                table: "FinancialYears",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 19, 2, 51, 52, 285, DateTimeKind.Utc).AddTicks(1164),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 7, 2, 36, 42, 797, DateTimeKind.Utc).AddTicks(7345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 19, 2, 51, 52, 284, DateTimeKind.Utc).AddTicks(8638),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 7, 2, 36, 42, 797, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Address",
                keyColumn: "AddressId",
                keyValue: new Guid("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 2, 19, 2, 51, 52, 284, DateTimeKind.Utc).AddTicks(8638), new DateTime(2025, 2, 19, 2, 51, 52, 285, DateTimeKind.Utc).AddTicks(1164) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 2, 19, 2, 51, 52, 159, DateTimeKind.Utc).AddTicks(7167), new DateTime(2025, 2, 19, 2, 51, 52, 159, DateTimeKind.Utc).AddTicks(8408) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: new Guid("e02eb064-def5-434a-8798-6f144a54003c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 299, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("00191050-6e42-4aec-8df4-5a4dda8479ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("05111caa-801f-4201-8169-ceaa54a74e51"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("061206dc-39d7-4d0e-a72a-3c058014347b"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("1aaf6c72-3308-4c01-8caf-b9fdfb79e964"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2cc4b79c-ea4c-4433-86a5-f8d1ca1b22d3"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2f95b1ff-8ddc-415e-9617-b7ccecfaf595"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("4f6f5c1f-8cd9-4cfa-9fbc-4cf2baf9af37"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("545de00f-a0d8-4e26-a028-b871849523a0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7801));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5b458db9-4fb2-47fd-b22f-e931b5c403fc"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5d7bd772-5210-4790-8ab2-45b1282b8b70"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5e9856e9-f413-4bfc-b18c-33d2d95bee8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7815));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("63ed7f68-2550-4f5a-b5f8-edd290ff4a43"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7819));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("651b4906-a3c0-4085-a995-d95557ce4fe9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("655f35d9-d2aa-4c62-95b2-eb95cf5480e4"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("6fa770a9-5ba3-4cee-9b9d-67f4d70c558c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("7244c798-e695-4edc-9894-87e5ff4944e2"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a00b3a52-cdb5-4e6e-afc5-474f66614a8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a266f1cb-cbd1-4d3e-9c09-2c13cd85c19a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7916));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("b4e62c5b-42db-4eb6-b120-cb0d15ca8f48"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7911));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("ca257efa-7b94-4e20-8938-bbb810185d8e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d4b11083-8f76-4ff9-86c6-56719c6762f0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d71bbbc0-f66c-4951-b27b-5b6536f03fa8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d77c8178-6678-4f4b-961e-a167a3681efd"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d979569b-cf54-4861-b9fd-7c36921237d4"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("dd205972-117a-4a46-9727-6cad22ce7ebe"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("e1e34023-313b-4c1b-a72d-e0895a9ce87a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7878));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f25f937c-30e3-4d30-b54e-fc4377257987"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7874));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f270c1c1-82c5-4171-a491-6c89eec056ec"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7869));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f4a67a44-27b9-44f9-9f29-f75a3bf6c625"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 314, DateTimeKind.Utc).AddTicks(7864));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(191));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("188ab651-af96-41d2-adc4-0af044e6d056"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(25));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2898a196-c192-40b6-9865-f7aa4018681c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2b525373-afcc-4fb1-9525-495db02029f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(126));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(12));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(51));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9316));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("77536c53-345c-48f5-a175-07a7b4044754"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(18));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(35));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9942));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(7));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(186));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 306, DateTimeKind.Utc).AddTicks(9947));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(148));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 2, 51, 52, 307, DateTimeKind.Utc).AddTicks(166));

            migrationBuilder.CreateIndex(
                name: "IX_FinancialYears_Fk_BranchId",
                schema: "public",
                table: "FinancialYears",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Fk_CountryId",
                schema: "public",
                table: "Address",
                column: "Fk_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Fk_DistId",
                schema: "public",
                table: "Address",
                column: "Fk_DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Fk_StateId",
                schema: "public",
                table: "Address",
                column: "Fk_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_Fk_CountryId",
                schema: "public",
                table: "Address",
                column: "Fk_CountryId",
                principalSchema: "public",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Dists_Fk_DistId",
                schema: "public",
                table: "Address",
                column: "Fk_DistId",
                principalSchema: "public",
                principalTable: "Dists",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_States_Fk_StateId",
                schema: "public",
                table: "Address",
                column: "Fk_StateId",
                principalSchema: "public",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialYears_Branches_Fk_BranchId",
                schema: "public",
                table: "FinancialYears",
                column: "Fk_BranchId",
                principalSchema: "public",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_Fk_CountryId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Dists_Fk_DistId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_States_Fk_StateId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialYears_Branches_Fk_BranchId",
                schema: "public",
                table: "FinancialYears");

            migrationBuilder.DropIndex(
                name: "IX_FinancialYears_Fk_BranchId",
                schema: "public",
                table: "FinancialYears");

            migrationBuilder.DropIndex(
                name: "IX_Address_Fk_CountryId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Fk_DistId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Fk_StateId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Fk_BranchId",
                schema: "public",
                table: "FinancialYears");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 7, 2, 36, 42, 797, DateTimeKind.Utc).AddTicks(7345),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 19, 2, 51, 52, 285, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 7, 2, 36, 42, 797, DateTimeKind.Utc).AddTicks(5124),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 19, 2, 51, 52, 284, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "public",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistId",
                schema: "public",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                schema: "public",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BranchFinancialYears",
                schema: "public",
                columns: table => new
                {
                    BranchFinancialYearId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Fk_BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fk_FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    ModifyBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
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

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Address",
                keyColumn: "AddressId",
                keyValue: new Guid("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                columns: new[] { "CountryId", "CreatedDate", "DistId", "ModifyDate", "StateId" },
                values: new object[] { null, new DateTime(2025, 2, 7, 2, 36, 42, 797, DateTimeKind.Utc).AddTicks(5124), null, new DateTime(2025, 2, 7, 2, 36, 42, 797, DateTimeKind.Utc).AddTicks(7345), null });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 2, 7, 2, 36, 42, 679, DateTimeKind.Utc).AddTicks(3310), new DateTime(2025, 2, 7, 2, 36, 42, 679, DateTimeKind.Utc).AddTicks(4442) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: new Guid("e02eb064-def5-434a-8798-6f144a54003c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 807, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("00191050-6e42-4aec-8df4-5a4dda8479ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("05111caa-801f-4201-8169-ceaa54a74e51"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5209));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("061206dc-39d7-4d0e-a72a-3c058014347b"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("1aaf6c72-3308-4c01-8caf-b9fdfb79e964"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2cc4b79c-ea4c-4433-86a5-f8d1ca1b22d3"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2f95b1ff-8ddc-415e-9617-b7ccecfaf595"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("4f6f5c1f-8cd9-4cfa-9fbc-4cf2baf9af37"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("545de00f-a0d8-4e26-a028-b871849523a0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5b458db9-4fb2-47fd-b22f-e931b5c403fc"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5d7bd772-5210-4790-8ab2-45b1282b8b70"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5299));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5e9856e9-f413-4bfc-b18c-33d2d95bee8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("63ed7f68-2550-4f5a-b5f8-edd290ff4a43"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("651b4906-a3c0-4085-a995-d95557ce4fe9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("655f35d9-d2aa-4c62-95b2-eb95cf5480e4"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5322));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("6fa770a9-5ba3-4cee-9b9d-67f4d70c558c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("7244c798-e695-4edc-9894-87e5ff4944e2"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a00b3a52-cdb5-4e6e-afc5-474f66614a8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a266f1cb-cbd1-4d3e-9c09-2c13cd85c19a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("b4e62c5b-42db-4eb6-b120-cb0d15ca8f48"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("ca257efa-7b94-4e20-8938-bbb810185d8e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d4b11083-8f76-4ff9-86c6-56719c6762f0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d71bbbc0-f66c-4951-b27b-5b6536f03fa8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d77c8178-6678-4f4b-961e-a167a3681efd"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5384));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d979569b-cf54-4861-b9fd-7c36921237d4"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("dd205972-117a-4a46-9727-6cad22ce7ebe"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5374));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("e1e34023-313b-4c1b-a72d-e0895a9ce87a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f25f937c-30e3-4d30-b54e-fc4377257987"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f270c1c1-82c5-4171-a491-6c89eec056ec"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5361));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f4a67a44-27b9-44f9-9f29-f75a3bf6c625"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 820, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("188ab651-af96-41d2-adc4-0af044e6d056"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1467));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1543));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2898a196-c192-40b6-9865-f7aa4018681c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2b525373-afcc-4fb1-9525-495db02029f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1606));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1678));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1535));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("77536c53-345c-48f5-a175-07a7b4044754"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1539));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1459));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1681));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1487));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1471));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1479));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1674));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1483));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 2, 36, 42, 813, DateTimeKind.Utc).AddTicks(1650));

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
                name: "IX_BranchFinancialYears_Fk_BranchId",
                schema: "public",
                table: "BranchFinancialYears",
                column: "Fk_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFinancialYears_Fk_FinancialYearId",
                schema: "public",
                table: "BranchFinancialYears",
                column: "Fk_FinancialYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_CountryId",
                schema: "public",
                table: "Address",
                column: "CountryId",
                principalSchema: "public",
                principalTable: "Country",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Dists_DistId",
                schema: "public",
                table: "Address",
                column: "DistId",
                principalSchema: "public",
                principalTable: "Dists",
                principalColumn: "DistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_States_StateId",
                schema: "public",
                table: "Address",
                column: "StateId",
                principalSchema: "public",
                principalTable: "States",
                principalColumn: "StateId");
        }
    }
}
