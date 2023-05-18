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
                    SnowWhiteId = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SnowWhiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_SnowWhites_SnowWhiteId",
                        column: x => x.SnowWhiteId,
                        principalTable: "SnowWhites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DungeonMasterSnowWhiteId = table.Column<int>(type: "int", nullable: true),
                    DwarfId = table.Column<int>(type: "int", nullable: false),
                    CreatedRequestSnowWhiteId = table.Column<int>(type: "int", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Dwarfs_DwarfId",
                        column: x => x.DwarfId,
                        principalTable: "Dwarfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_SnowWhites_CreatedRequestSnowWhiteId",
                        column: x => x.CreatedRequestSnowWhiteId,
                        principalTable: "SnowWhites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_SnowWhites_DungeonMasterSnowWhiteId",
                        column: x => x.DungeonMasterSnowWhiteId,
                        principalTable: "SnowWhites",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SnowWhites",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 1, "Белоснежка" });

            migrationBuilder.CreateIndex(
                name: "IX_Dwarfs_SnowWhiteId",
                table: "Dwarfs",
                column: "SnowWhiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CreatedRequestSnowWhiteId",
                table: "Requests",
                column: "CreatedRequestSnowWhiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DungeonMasterSnowWhiteId",
                table: "Requests",
                column: "DungeonMasterSnowWhiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DwarfId",
                table: "Requests",
                column: "DwarfId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SnowWhiteId",
                table: "Users",
                column: "SnowWhiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dwarfs");

            migrationBuilder.DropTable(
                name: "SnowWhites");
        }
    }
}
