using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.API.Migrations
{
    public partial class UpdateRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4035a3c3-e1f8-40f7-9911-1a9632018358");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e29a6913-4695-4606-9235-b605373269fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ce098db-9d36-4ae9-8224-28174a02fbbe", "93d01847-7bfe-4d54-97ff-68131706926e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b0037d5-bae1-426c-90e9-ea643b62c7dc", "10b641fc-440b-401b-beeb-ae4b9b54ab63", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf2290c3-c2c0-4ceb-b0d4-0afb70c84ff6", "2db35b73-c9ce-4a8a-8993-85667cfe31d2", "Salon", "SALON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ce098db-9d36-4ae9-8224-28174a02fbbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b0037d5-bae1-426c-90e9-ea643b62c7dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf2290c3-c2c0-4ceb-b0d4-0afb70c84ff6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4035a3c3-e1f8-40f7-9911-1a9632018358", "6f0c212d-0f90-4a5f-b624-ed36845f97f1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e29a6913-4695-4606-9235-b605373269fe", "13ab9684-2d29-497b-8e62-ac0ca56d88b9", "User", "USER" });
        }
    }
}
