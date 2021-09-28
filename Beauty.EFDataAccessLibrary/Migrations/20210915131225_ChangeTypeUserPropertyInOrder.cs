using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class ChangeTypeUserPropertyInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ServicesWorkers_ServiceWorkerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServiceWorkerId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424448d8-ec71-41c6-8e91-abe0b2ca6432");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6feab1e3-3e99-4db8-9e66-0b16db3ca7c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ed9f54a-c09d-474c-982e-1074e90f4e12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b791f6c4-d594-43f2-bb99-fdce905ffa9b");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceWorkerId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ServiceWorkerId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceWorkerId1",
                table: "Orders",
                column: "ServiceWorkerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ServicesWorkers_ServiceWorkerId1",
                table: "Orders",
                column: "ServiceWorkerId1",
                principalTable: "ServicesWorkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ServicesWorkers_ServiceWorkerId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServiceWorkerId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ServiceWorkerId1",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceWorkerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b791f6c4-d594-43f2-bb99-fdce905ffa9b", "ca9579c0-3026-41e1-8d08-1e880eb3eb14", "Admin", "ADMIN" },
                    { "7ed9f54a-c09d-474c-982e-1074e90f4e12", "2dcd0e47-9081-4914-a732-7c5c0e93b441", "User", "USER" },
                    { "6feab1e3-3e99-4db8-9e66-0b16db3ca7c8", "c4386dde-34bd-43cb-8950-ce26939ff7d6", "Salon", "SALON" },
                    { "424448d8-ec71-41c6-8e91-abe0b2ca6432", "2cc1f918-6481-46c5-ad5a-ace452423e40", "Worker", "WORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceWorkerId",
                table: "Orders",
                column: "ServiceWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ServicesWorkers_ServiceWorkerId",
                table: "Orders",
                column: "ServiceWorkerId",
                principalTable: "ServicesWorkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
