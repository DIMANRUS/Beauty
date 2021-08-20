using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.API.Migrations
{
    public partial class AddSaleForServiceWorker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79e1ec2c-92e4-4423-892c-1cf8cee6f2e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5f51e2-5177-4562-ab5f-ef3e169a531f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2f7f78-6073-459b-94c3-353b8cdec07f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecc473db-510e-4c1f-aad0-08ca1aa2bee5");

            migrationBuilder.AddColumn<int>(
                name: "SalePercent",
                table: "ServicesWorkers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "SalePercent",
                table: "ServicesWorkers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ecc473db-510e-4c1f-aad0-08ca1aa2bee5", "b03f34ca-53f3-4717-a088-16b25fc3f632", "Admin", "ADMIN" },
                    { "bd5f51e2-5177-4562-ab5f-ef3e169a531f", "5c8a52bb-6025-4c10-85cc-4262e03883ed", "User", "USER" },
                    { "cb2f7f78-6073-459b-94c3-353b8cdec07f", "5f2b3f5b-9919-4e19-ae32-1178d900b3f6", "Salon", "SALON" },
                    { "79e1ec2c-92e4-4423-892c-1cf8cee6f2e2", "130f7f36-e1db-4baf-a02f-cb66edc447b8", "Worker", "WORKER" }
                });
        }
    }
}
