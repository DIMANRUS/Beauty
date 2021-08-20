using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.API.Migrations
{
    public partial class ChangeTypeColumnUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesWorkers_AspNetUsers_UserId1",
                table: "ServicesWorkers");

            migrationBuilder.DropIndex(
                name: "IX_ServicesWorkers_UserId1",
                table: "ServicesWorkers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a5569f-a4e2-495a-9ea4-37d48e2782c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49b94142-4b9f-4ff9-802b-2a66f7cba71e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eda5b8d-d1dd-4a59-882b-40324932cd37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef85b5d-5026-4fc1-bbea-dd33e4f0aeae");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ServicesWorkers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ServicesWorkers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_ServicesWorkers_UserId",
                table: "ServicesWorkers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesWorkers_AspNetUsers_UserId",
                table: "ServicesWorkers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesWorkers_AspNetUsers_UserId",
                table: "ServicesWorkers");

            migrationBuilder.DropIndex(
                name: "IX_ServicesWorkers_UserId",
                table: "ServicesWorkers");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ServicesWorkers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ServicesWorkers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aef85b5d-5026-4fc1-bbea-dd33e4f0aeae", "37d12e49-629e-4ab1-8a9c-fe77f1bfba20", "Admin", "ADMIN" },
                    { "49b94142-4b9f-4ff9-802b-2a66f7cba71e", "ae31d3a2-5323-4394-8705-0f46dce9c3be", "User", "USER" },
                    { "27a5569f-a4e2-495a-9ea4-37d48e2782c4", "9b44ea3c-5d1b-4582-98a0-49c19d3c811d", "Salon", "SALON" },
                    { "4eda5b8d-d1dd-4a59-882b-40324932cd37", "304fe195-8808-4508-83ef-55e9ae8b12f3", "Worker", "WORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesWorkers_UserId1",
                table: "ServicesWorkers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesWorkers_AspNetUsers_UserId1",
                table: "ServicesWorkers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
