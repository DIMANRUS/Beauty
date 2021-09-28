using Microsoft.EntityFrameworkCore.Migrations;

namespace Beauty.EFDataAccessLibrary.Migrations
{
    public partial class AddServiceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeviceCategoryId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SeviceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeviceCategory", x => x.Id);
                });

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
                name: "IX_Services_SeviceCategoryId",
                table: "Services",
                column: "SeviceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_SeviceCategory_SeviceCategoryId",
                table: "Services",
                column: "SeviceCategoryId",
                principalTable: "SeviceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_SeviceCategory_SeviceCategoryId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "SeviceCategory");

            migrationBuilder.DropIndex(
                name: "IX_Services_SeviceCategoryId",
                table: "Services");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SeviceCategoryId",
                table: "Services");

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
        }
    }
}
