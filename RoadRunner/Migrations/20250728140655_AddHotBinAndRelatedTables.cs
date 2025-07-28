using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoadRunner.Migrations
{
    /// <inheritdoc />
    public partial class AddHotBinAndRelatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotBins",
                columns: table => new
                {
                    HotBinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBins", x => x.HotBinId);
                });

            migrationBuilder.CreateTable(
                name: "Aggregates",
                columns: table => new
                {
                    AggregateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HotBinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aggregates", x => x.AggregateId);
                    table.ForeignKey(
                        name: "FK_Aggregates_HotBins_HotBinId",
                        column: x => x.HotBinId,
                        principalTable: "HotBins",
                        principalColumn: "HotBinId");
                });

            migrationBuilder.CreateTable(
                name: "RecipeHotBins",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    HotBinId = table.Column<int>(type: "int", nullable: false),
                    Take = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeHotBins", x => new { x.RecipeId, x.HotBinId });
                    table.ForeignKey(
                        name: "FK_RecipeHotBins_HotBins_HotBinId",
                        column: x => x.HotBinId,
                        principalTable: "HotBins",
                        principalColumn: "HotBinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeHotBins_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aggregates_HotBinId",
                table: "Aggregates",
                column: "HotBinId",
                unique: true,
                filter: "[HotBinId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHotBins_HotBinId",
                table: "RecipeHotBins",
                column: "HotBinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aggregates");

            migrationBuilder.DropTable(
                name: "RecipeHotBins");

            migrationBuilder.DropTable(
                name: "HotBins");
        }
    }
}
