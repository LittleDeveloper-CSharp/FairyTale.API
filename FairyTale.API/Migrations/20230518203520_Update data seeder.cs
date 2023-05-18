using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairyTale.API.Migrations
{
    public partial class Updatedataseeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_SnowWhiteId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "SnowWhites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SnowWhiteId",
                table: "Users",
                column: "SnowWhiteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_SnowWhiteId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "SnowWhites",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 1, "Белоснежка" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SnowWhiteId",
                table: "Users",
                column: "SnowWhiteId");
        }
    }
}
