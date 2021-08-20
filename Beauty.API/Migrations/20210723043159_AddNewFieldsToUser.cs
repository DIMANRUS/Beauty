using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.API.Migrations
{
    public partial class AddNewFieldsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "AspNetUsers",
                type: "nvarchar(max)",
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
                    { "d63d0994-18ff-4007-a5d0-30e84e730d06", "99d6c7d2-b7d4-4347-90c2-272349169c93", "Admin", "ADMIN" },
                    { "3924d708-669b-4450-90bb-ed3df5909bc9", "59140792-d6fe-4b01-a8fb-0a39205fe02b", "User", "USER" },
                    { "ee6d2b92-977e-4b11-8b63-0799745f63ad", "0df00038-5228-46e4-8c9c-9af30f8f2d5c", "Salon", "SALON" },
                    { "d8c2e9b2-8b53-445f-ae5f-d778cc11dc07", "a1d0b365-ee2e-4125-bd68-727525368284", "Worker", "WORKER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

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
    }
}
