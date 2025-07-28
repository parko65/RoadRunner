using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoadRunner.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipJobDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationType",
                table: "Destination",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Destination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DestinationId",
                table: "Jobs",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Destination_DestinationId",
                table: "Jobs",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Destination_DestinationId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_DestinationId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DestinationType",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Destination");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "DestinationId");
        }
    }
}
