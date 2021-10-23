using Microsoft.EntityFrameworkCore.Migrations;

namespace LeavingALegacy.Data.Migrations
{
    public partial class AddedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceSecId",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    SecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.SecId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PlaceSecId",
                table: "Organizations",
                column: "PlaceSecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Locations_PlaceSecId",
                table: "Organizations",
                column: "PlaceSecId",
                principalTable: "Locations",
                principalColumn: "SecId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Locations_PlaceSecId",
                table: "Organizations");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_PlaceSecId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "PlaceSecId",
                table: "Organizations");
        }
    }
}
