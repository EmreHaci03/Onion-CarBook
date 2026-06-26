using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_Fix_RentACar_Location_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RentACars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "RentACars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }
    }
}
