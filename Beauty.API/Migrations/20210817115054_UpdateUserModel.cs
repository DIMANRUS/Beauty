using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.API.Migrations
{
    public partial class UpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d833767-773c-42ca-834d-e3bcdc011201");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77430c3d-76b9-469a-9e9d-eefc4a903f56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ef5a683-2e35-4f12-9d86-14f443147e8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6224642-f8db-4a50-93c7-d338bf5058cf");

            migrationBuilder.DropColumn(
                name: "IsFriday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsMonday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSaturday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSunday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsThursday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTuesday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScheduleEndTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScheduleStartTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsWednasday",
                table: "AspNetUsers",
                newName: "IsSelfEmployed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc349f7c-4128-4d25-8d86-584edc567f8a", "4f512034-0900-4f72-a85c-02175f0dac1b", "Admin", "ADMIN" },
                    { "0bb8bdc9-d0f6-4264-bcae-e52cf1979c9f", "73511554-b06f-419a-8a8a-8ae653d37886", "User", "USER" },
                    { "49577823-b869-471e-ae1d-678a6572fd03", "b99756c3-1a3e-41fd-93cc-76d6bb5490a4", "Salon", "SALON" },
                    { "d4edf06c-875b-4be3-a6ec-40911d83a857", "c8e5d2a1-7e39-485b-b46d-47a6f3513c4e", "Worker", "WORKER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bb8bdc9-d0f6-4264-bcae-e52cf1979c9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49577823-b869-471e-ae1d-678a6572fd03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc349f7c-4128-4d25-8d86-584edc567f8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4edf06c-875b-4be3-a6ec-40911d83a857");

            migrationBuilder.RenameColumn(
                name: "IsSelfEmployed",
                table: "AspNetUsers",
                newName: "IsWednasday");

            migrationBuilder.AddColumn<bool>(
                name: "IsFriday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMonday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSaturday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSunday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsThursday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTuesday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleEndTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleStartTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ef5a683-2e35-4f12-9d86-14f443147e8a", "fe996dfc-e70e-4e5b-92b2-d262365f16db", "Admin", "ADMIN" },
                    { "d6224642-f8db-4a50-93c7-d338bf5058cf", "82a3bc20-c1a9-426c-97d2-975f90fd4c5e", "User", "USER" },
                    { "77430c3d-76b9-469a-9e9d-eefc4a903f56", "9ad62843-a73b-4d4d-9b98-172728ec63ad", "Salon", "SALON" },
                    { "6d833767-773c-42ca-834d-e3bcdc011201", "2613933e-0de5-44ee-8172-0af5f99aa8c8", "Worker", "WORKER" }
                });
        }
    }
}
