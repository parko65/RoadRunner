using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoadRunner.Migrations
{
    /// <inheritdoc />
    public partial class ADExtraPropsToRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchSize",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "FixedBatchSize",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LowerTemperatureDeviation",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MixTemperature",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MixTime",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperTemperatureDeviation",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VersionNumber",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchSize",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FixedBatchSize",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "LowerTemperatureDeviation",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MixTemperature",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MixTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UpperTemperatureDeviation",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "Recipes");
        }
    }
}
