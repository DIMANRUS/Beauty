﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.API.Migrations
{
    public partial class AddSoneRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fde60a0b-d8ce-446e-91d8-7840c0f47757", "ed787b1d-8be1-4803-8258-bba9daedaa33", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c984c82b-2024-4751-948a-e7dde2b5d9f6", "ca445913-02dd-425b-b409-4400a33548f1", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c984c82b-2024-4751-948a-e7dde2b5d9f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fde60a0b-d8ce-446e-91d8-7840c0f47757");
        }
    }
}
