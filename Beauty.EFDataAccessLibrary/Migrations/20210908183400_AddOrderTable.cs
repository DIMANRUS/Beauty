using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    WorkerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceWorkerId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_ServicesWorkers_ServiceWorkerId",
                        column: x => x.ServiceWorkerId,
                        principalTable: "ServicesWorkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74bb00b7-e13d-4898-94a8-89bc894c6f39", "82aedbf9-77dc-4ff6-a103-c1772c1b7fa5", "Admin", "ADMIN" },
                    { "993c0cc2-187e-480f-9c38-4c3758b30233", "73b60eee-62a9-4db4-8da7-a0db8bef054a", "User", "USER" },
                    { "93863c51-cbe2-4b4b-892d-dc7f18a3febc", "17c5aaec-941f-48c2-895e-86f55840383e", "Salon", "SALON" },
                    { "2bd4233e-6ba2-4c8e-b4ca-f6c144ad56ef", "4b4d8965-7e07-4d1f-8413-7bc759be0714", "Worker", "WORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesWorkers_UserId1",
                table: "ServicesWorkers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceWorkerId",
                table: "Orders",
                column: "ServiceWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WorkerId1",
                table: "Orders",
                column: "WorkerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesWorkers_AspNetUsers_UserId1",
                table: "ServicesWorkers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesWorkers_AspNetUsers_UserId1",
                table: "ServicesWorkers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ServicesWorkers_UserId1",
                table: "ServicesWorkers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bd4233e-6ba2-4c8e-b4ca-f6c144ad56ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74bb00b7-e13d-4898-94a8-89bc894c6f39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93863c51-cbe2-4b4b-892d-dc7f18a3febc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993c0cc2-187e-480f-9c38-4c3758b30233");

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

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
    }
}
