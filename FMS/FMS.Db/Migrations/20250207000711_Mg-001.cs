using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Db.Migrations
{
    /// <inheritdoc />
    public partial class Mg001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Company_Fk_CompanyId",
                schema: "public",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Branches_Fk_BranchId",
                schema: "public",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_Fk_BranchId",
                schema: "public",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Fk_BranchId",
                schema: "public",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "BranchAddress",
                schema: "public",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "Fk_CompanyId",
                schema: "public",
                table: "Address",
                newName: "Fk_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_Fk_CompanyId",
                schema: "public",
                table: "Address",
                newName: "IX_Address_Fk_BranchId");

            migrationBuilder.AlterColumn<string>(
                name: "TokenValue",
                schema: "public",
                table: "RegisterTokens",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 7, 0, 7, 8, 907, DateTimeKind.Utc).AddTicks(7767),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 29, 2, 28, 15, 888, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 7, 0, 7, 8, 907, DateTimeKind.Utc).AddTicks(5592),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 29, 2, 28, 15, 888, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Address",
                keyColumn: "AddressId",
                keyValue: new Guid("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 2, 7, 0, 7, 8, 907, DateTimeKind.Utc).AddTicks(5592), new DateTime(2025, 2, 7, 0, 7, 8, 907, DateTimeKind.Utc).AddTicks(7767) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 2, 7, 0, 7, 8, 794, DateTimeKind.Utc).AddTicks(4770), new DateTime(2025, 2, 7, 0, 7, 8, 794, DateTimeKind.Utc).AddTicks(6166) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: new Guid("e02eb064-def5-434a-8798-6f144a54003c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 915, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("00191050-6e42-4aec-8df4-5a4dda8479ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("05111caa-801f-4201-8169-ceaa54a74e51"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7036));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("061206dc-39d7-4d0e-a72a-3c058014347b"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("1aaf6c72-3308-4c01-8caf-b9fdfb79e964"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2cc4b79c-ea4c-4433-86a5-f8d1ca1b22d3"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2f95b1ff-8ddc-415e-9617-b7ccecfaf595"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7105));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("4f6f5c1f-8cd9-4cfa-9fbc-4cf2baf9af37"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("545de00f-a0d8-4e26-a028-b871849523a0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5b458db9-4fb2-47fd-b22f-e931b5c403fc"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5d7bd772-5210-4790-8ab2-45b1282b8b70"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7132));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5e9856e9-f413-4bfc-b18c-33d2d95bee8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7137));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("63ed7f68-2550-4f5a-b5f8-edd290ff4a43"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("651b4906-a3c0-4085-a995-d95557ce4fe9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7148));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("655f35d9-d2aa-4c62-95b2-eb95cf5480e4"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("6fa770a9-5ba3-4cee-9b9d-67f4d70c558c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("7244c798-e695-4edc-9894-87e5ff4944e2"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a00b3a52-cdb5-4e6e-afc5-474f66614a8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7260));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a266f1cb-cbd1-4d3e-9c09-2c13cd85c19a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7255));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("b4e62c5b-42db-4eb6-b120-cb0d15ca8f48"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7250));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("ca257efa-7b94-4e20-8938-bbb810185d8e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7245));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d4b11083-8f76-4ff9-86c6-56719c6762f0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7241));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d71bbbc0-f66c-4951-b27b-5b6536f03fa8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7236));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d77c8178-6678-4f4b-961e-a167a3681efd"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d979569b-cf54-4861-b9fd-7c36921237d4"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("dd205972-117a-4a46-9727-6cad22ce7ebe"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("e1e34023-313b-4c1b-a72d-e0895a9ce87a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f25f937c-30e3-4d30-b54e-fc4377257987"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f270c1c1-82c5-4171-a491-6c89eec056ec"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7190));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f4a67a44-27b9-44f9-9f29-f75a3bf6c625"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 929, DateTimeKind.Utc).AddTicks(7186));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("188ab651-af96-41d2-adc4-0af044e6d056"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8840));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2898a196-c192-40b6-9865-f7aa4018681c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2b525373-afcc-4fb1-9525-495db02029f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8959));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8891));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8345));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("77536c53-345c-48f5-a175-07a7b4044754"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9012));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9036));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8955));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9028));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8875));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 0, 7, 8, 921, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Branches_Fk_BranchId",
                schema: "public",
                table: "Address",
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
                name: "FK_Address_Branches_Fk_BranchId",
                schema: "public",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Fk_BranchId",
                schema: "public",
                table: "Address",
                newName: "Fk_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_Fk_BranchId",
                schema: "public",
                table: "Address",
                newName: "IX_Address_Fk_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "TokenValue",
                schema: "public",
                table: "RegisterTokens",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<Guid>(
                name: "Fk_BranchId",
                schema: "public",
                table: "Company",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "BranchAddress",
                schema: "public",
                table: "Branches",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 29, 2, 28, 15, 888, DateTimeKind.Utc).AddTicks(7417),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 7, 0, 7, 8, 907, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "Address",
                type: "timestamptz",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 29, 2, 28, 15, 888, DateTimeKind.Utc).AddTicks(3730),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 7, 0, 7, 8, 907, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Address",
                keyColumn: "AddressId",
                keyValue: new Guid("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 1, 29, 2, 28, 15, 888, DateTimeKind.Utc).AddTicks(3730), new DateTime(2025, 1, 29, 2, 28, 15, 888, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71f97dea-8c5f-4f51-84c7-6d7a16e64651", "4431f16a-6bc7-4e9b-bada-c491fcc81a58" },
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2025, 1, 29, 2, 28, 15, 752, DateTimeKind.Utc).AddTicks(2116), new DateTime(2025, 1, 29, 2, 28, 15, 752, DateTimeKind.Utc).AddTicks(3162) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: new Guid("e02eb064-def5-434a-8798-6f144a54003c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 906, DateTimeKind.Utc).AddTicks(6938));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("00191050-6e42-4aec-8df4-5a4dda8479ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("05111caa-801f-4201-8169-ceaa54a74e51"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("061206dc-39d7-4d0e-a72a-3c058014347b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("1aaf6c72-3308-4c01-8caf-b9fdfb79e964"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2cc4b79c-ea4c-4433-86a5-f8d1ca1b22d3"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3762));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("2f95b1ff-8ddc-415e-9617-b7ccecfaf595"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("4f6f5c1f-8cd9-4cfa-9fbc-4cf2baf9af37"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("545de00f-a0d8-4e26-a028-b871849523a0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5b458db9-4fb2-47fd-b22f-e931b5c403fc"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3842));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5d7bd772-5210-4790-8ab2-45b1282b8b70"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("5e9856e9-f413-4bfc-b18c-33d2d95bee8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("63ed7f68-2550-4f5a-b5f8-edd290ff4a43"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("651b4906-a3c0-4085-a995-d95557ce4fe9"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("655f35d9-d2aa-4c62-95b2-eb95cf5480e4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3865));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("6fa770a9-5ba3-4cee-9b9d-67f4d70c558c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3869));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("7244c798-e695-4edc-9894-87e5ff4944e2"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3979));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a00b3a52-cdb5-4e6e-afc5-474f66614a8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("a266f1cb-cbd1-4d3e-9c09-2c13cd85c19a"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("b4e62c5b-42db-4eb6-b120-cb0d15ca8f48"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("ca257efa-7b94-4e20-8938-bbb810185d8e"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d4b11083-8f76-4ff9-86c6-56719c6762f0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d71bbbc0-f66c-4951-b27b-5b6536f03fa8"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3931));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d77c8178-6678-4f4b-961e-a167a3681efd"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("d979569b-cf54-4861-b9fd-7c36921237d4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3922));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("dd205972-117a-4a46-9727-6cad22ce7ebe"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3917));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("e1e34023-313b-4c1b-a72d-e0895a9ce87a"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3913));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f25f937c-30e3-4d30-b54e-fc4377257987"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f270c1c1-82c5-4171-a491-6c89eec056ec"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Dists",
                keyColumn: "DistId",
                keyValue: new Guid("f4a67a44-27b9-44f9-9f29-f75a3bf6c625"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 924, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("022df470-aaa9-4f6d-895a-75f41906f76a"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("188ab651-af96-41d2-adc4-0af044e6d056"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6156));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("1f2ad09e-7095-4050-b653-ae2d5693fb22"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2316471c-4fc5-43ee-b20c-94e5c5775514"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2898a196-c192-40b6-9865-f7aa4018681c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2b525373-afcc-4fb1-9525-495db02029f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("43d58903-126e-4aca-8289-b3d09c7a1e14"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4a49b1dc-6f18-4de7-85ec-46563a4b5b56"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("4ecafa26-9eb1-47a6-a927-a23f8f3c4833"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("559b5985-bdd4-4dab-8aa7-1887ef7b2c98"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("5ed4f9b3-f38a-4ae9-a738-6f1b3ee50a88"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("65afd736-c385-4f57-b667-de4e77f4c9d5"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6256));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("67c9f3a9-9235-428a-8463-a743f711a5a3"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(5739));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("6ad24792-a695-43ba-89e3-eda8c1fd7a20"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("77536c53-345c-48f5-a175-07a7b4044754"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("802047bc-496c-4a69-a786-5ba566f8b06b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6231));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("970ec112-ce5e-4f5b-9707-be75c379d803"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9a41572b-ac7a-4234-af77-6d6e426e88ef"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("9f0240ba-79fa-47c5-86f6-e4f3d2ee10d8"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6152));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("a14644a8-9c2f-4aa6-8332-9cb576c4dc8c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("abe258b7-a358-42cc-8cce-657dfe4d6644"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("ad98660a-f208-4194-82fa-9e74747b2a02"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b176f1fe-daba-406f-9256-e6ee6ecd52ed"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b2d8b019-f729-4bac-8006-9b46a307153c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("b4b9acf3-87a2-4f5f-95a0-872c0680fb1e"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c2d0c6c5-6954-4921-9d64-90261de50f5e"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("c9fbd62c-a7fc-4f5e-a44e-2c9fffe94c8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d1459e60-a200-440a-9862-6a6c26bf37ea"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("d84eaae8-09fb-4d80-9303-d166529bde20"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("db5157fd-b616-418b-82e9-3d5f109d69f8"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("df18be70-0ba6-4918-8351-bf992e4ee17a"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e691660f-bb06-416a-a79c-9ef41e67ad11"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("e7c6a407-a7f8-4711-b8ff-e57d7b93cafa"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6171));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("eaf9a3cc-a650-429e-bcc5-406257614dfa"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("f20c53dc-ba9a-4fd6-82cd-63c76fb11cc5"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "States",
                keyColumn: "StateId",
                keyValue: new Guid("fc5486fe-aa06-46f0-9d93-b6a4f71429a2"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 2, 28, 15, 914, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.CreateIndex(
                name: "IX_Company_Fk_BranchId",
                schema: "public",
                table: "Company",
                column: "Fk_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Company_Fk_CompanyId",
                schema: "public",
                table: "Address",
                column: "Fk_CompanyId",
                principalSchema: "public",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Branches_Fk_BranchId",
                schema: "public",
                table: "Company",
                column: "Fk_BranchId",
                principalSchema: "public",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
