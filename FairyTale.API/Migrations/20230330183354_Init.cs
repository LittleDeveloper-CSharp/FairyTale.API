using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairyTale.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnowWhites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnowWhites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dwarfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SnowWhiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwarfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dwarfs_SnowWhites_SnowWhiteId",
                        column: x => x.SnowWhiteId,
                        principalTable: "SnowWhites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SnowWhites",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 1, "Белоснежка" });

            migrationBuilder.CreateIndex(
                name: "IX_Dwarfs_SnowWhiteId",
                table: "Dwarfs",
                column: "SnowWhiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dwarfs");

            migrationBuilder.DropTable(
                name: "SnowWhites");
        }
    }
}
