using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class AddNormalizedNameForRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c984c82b-2024-4751-948a-e7dde2b5d9f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fde60a0b-d8ce-446e-91d8-7840c0f47757");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4035a3c3-e1f8-40f7-9911-1a9632018358", "6f0c212d-0f90-4a5f-b624-ed36845f97f1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e29a6913-4695-4606-9235-b605373269fe", "13ab9684-2d29-497b-8e62-ac0ca56d88b9", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "fde60a0b-d8ce-446e-91d8-7840c0f47757", "ed787b1d-8be1-4803-8258-bba9daedaa33", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c984c82b-2024-4751-948a-e7dde2b5d9f6", "ca445913-02dd-425b-b409-4400a33548f1", "User", null });
        }
    }
}
