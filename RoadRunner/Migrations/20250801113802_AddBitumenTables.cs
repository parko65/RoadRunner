using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoadRunner.Migrations
{
    /// <inheritdoc />
    public partial class AddBitumenTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BitumenTanks",
                columns: table => new
                {
                    BitumenTankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitumenTanks", x => x.BitumenTankId);
                });

            migrationBuilder.CreateTable(
                name: "Bitumens",
                columns: table => new
                {
                    BitumenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BitumenTankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitumens", x => x.BitumenId);
                    table.ForeignKey(
                        name: "FK_Bitumens_BitumenTanks_BitumenTankId",
                        column: x => x.BitumenTankId,
                        principalTable: "BitumenTanks",
                        principalColumn: "BitumenTankId");
                });

            migrationBuilder.CreateTable(
                name: "RecipeBitumenTanks",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    BitumenTankId = table.Column<int>(type: "int", nullable: false),
                    Take = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBitumenTanks", x => new { x.RecipeId, x.BitumenTankId });
                    table.ForeignKey(
                        name: "FK_RecipeBitumenTanks_BitumenTanks_BitumenTankId",
                        column: x => x.BitumenTankId,
                        principalTable: "BitumenTanks",
                        principalColumn: "BitumenTankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeBitumenTanks_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitumens_BitumenTankId",
                table: "Bitumens",
                column: "BitumenTankId",
                unique: true,
                filter: "[BitumenTankId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeBitumenTanks_BitumenTankId",
                table: "RecipeBitumenTanks",
                column: "BitumenTankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitumens");

            migrationBuilder.DropTable(
                name: "RecipeBitumenTanks");

            migrationBuilder.DropTable(
                name: "BitumenTanks");
        }
    }
}
