using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicDataTransfer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(nullable: false),
                    CatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(nullable: false),
                    GameName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    CountryName = table.Column<string>(nullable: true),
                    GameID = table.Column<string>(nullable: true),
                    CategoryID = table.Column<string>(nullable: true),
                    FlagImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CatName" },
                values: new object[,]
                {
                    { "in", "Indoor Olympics" },
                    { "out", "Outdoor Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "GameName" },
                values: new object[,]
                {
                    { "win", "Winter Olympics" },
                    { "sum", "Summer Olympics" },
                    { "par", "Paralympic Games" },
                    { "yth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "CountryName", "FlagImage", "GameID" },
                values: new object[,]
                {
                    { "ca", "in", "Canada", "Canada.png", "win" },
                    { "fin", "out", "Finland", "Finland.png", "yth" },
                    { "rus", "in", "Russia", "Russia.png", "yth" },
                    { "cy", "in", "Cyprus", "Cyprus.png", "yth" },
                    { "fr", "in", "France", "France.png", "yth" },
                    { "zim", "out", "Zimbabwe", "Zimbabwe.png", "par" },
                    { "pa", "out", "Pakistan", "Pakistan.png", "par" },
                    { "au", "out", "Austria", "Austria.png", "par" },
                    { "uk", "in", "Ukraine", "Ukraine.png", "par" },
                    { "ur", "in", "Uruguay", "Uruguay.png", "par" },
                    { "th", "in", "Thailand", "Thailand.png", "par" },
                    { "usa", "out", "USA", "Usa.png", "sum" },
                    { "net", "out", "Netherlands", "Netherlands.png", "sum" },
                    { "bra", "out", "Brazil", "Brazil.png", "sum" },
                    { "mex", "in", "Mexico", "Mexico.png", "sum" },
                    { "ch", "in", "China", "China.png", "sum" },
                    { "ger", "in", "Germany", "Germany.png", "sum" },
                    { "jap", "out", "Japan", "Japan.png", "win" },
                    { "it", "out", "Italy", "Italy.png", "win" },
                    { "jam", "out", "Jamaica", "Jamaica.png", "win" },
                    { "gb", "in", "Great Britain", "GreatBritain.png", "win" },
                    { "sw", "in", "Sweden", "Sweden.png", "win" },
                    { "slo", "out", "Slovakia", "Slovakia.png", "yth" },
                    { "por", "out", "Portugal", "Portugal.png", "yth" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
