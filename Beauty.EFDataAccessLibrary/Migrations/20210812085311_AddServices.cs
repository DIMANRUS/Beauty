using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class AddServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3924d708-669b-4450-90bb-ed3df5909bc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d63d0994-18ff-4007-a5d0-30e84e730d06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8c2e9b2-8b53-445f-ae5f-d778cc11dc07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6d2b92-977e-4b11-8b63-0799745f63ad");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "AspNetUsers");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsWednasday",
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

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesWorkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesWorkers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesWorkers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Стрижка" },
                    { 2, "Маникюр" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_Id",
                table: "Services",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesWorkers_ServiceId",
                table: "ServicesWorkers",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesWorkers_UserId1",
                table: "ServicesWorkers",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesWorkers");

            migrationBuilder.DropTable(
                name: "Services");

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
                name: "IsWednasday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScheduleEndTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScheduleStartTime",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d63d0994-18ff-4007-a5d0-30e84e730d06", "99d6c7d2-b7d4-4347-90c2-272349169c93", "Admin", "ADMIN" },
                    { "3924d708-669b-4450-90bb-ed3df5909bc9", "59140792-d6fe-4b01-a8fb-0a39205fe02b", "User", "USER" },
                    { "ee6d2b92-977e-4b11-8b63-0799745f63ad", "0df00038-5228-46e4-8c9c-9af30f8f2d5c", "Salon", "SALON" },
                    { "d8c2e9b2-8b53-445f-ae5f-d778cc11dc07", "a1d0b365-ee2e-4125-bd68-727525368284", "Worker", "WORKER" }
                });
        }
    }
}
