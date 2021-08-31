using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class AddWorkerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "bd3b961f-c564-4c37-a1f2-c121fc4c1f05", "6d76ab59-8be2-4d56-8cfb-c2357aea7e4d", "Admin", "ADMIN" },
                    { "b850554e-cc3d-40c0-aa90-09883aab0ab5", "c742a9a3-1bb2-4fbb-8f32-1629c3a05f91", "User", "USER" },
                    { "516865d0-6048-48c6-9495-4dd5b12968f2", "88f79133-cc25-4b80-95e9-6367c0199140", "Salon", "SALON" },
                    { "5e0174c5-28fb-4248-85a2-83c28efe8511", "a2fada6d-3820-4848-b031-4be393251092", "Worker", "WORKER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "516865d0-6048-48c6-9495-4dd5b12968f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e0174c5-28fb-4248-85a2-83c28efe8511");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b850554e-cc3d-40c0-aa90-09883aab0ab5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd3b961f-c564-4c37-a1f2-c121fc4c1f05");

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
    }
}
