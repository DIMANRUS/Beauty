using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class AddRolesToUpper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d234c1d5-d834-4e98-b82d-8029091448d4", "4de02e77-2e1e-4b99-85c1-3cc75dee34ad", "ADMIN", "ADMIN" },
                    { "c39a8472-a73e-43b3-a3d0-e4fd8bfdff3f", "486833e5-b156-4c15-83de-9bb298f5bab3", "USER", "USER" },
                    { "73de23f0-a6bd-43d8-b411-fc7612e1556e", "0bfe9d0f-4b7e-4c0b-99d8-3ee538e32b6b", "SALON", "SALON" },
                    { "73a1c2e1-28b0-4531-9561-32a813c49354", "2fc0b3ad-4b96-4e1f-8429-8ef2a269a6c8", "WORKER", "WORKER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a1c2e1-28b0-4531-9561-32a813c49354");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73de23f0-a6bd-43d8-b411-fc7612e1556e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c39a8472-a73e-43b3-a3d0-e4fd8bfdff3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d234c1d5-d834-4e98-b82d-8029091448d4");
        }
    }
}
