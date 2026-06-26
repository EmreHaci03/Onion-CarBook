using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_Add_Location_Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Customers_CustomerId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Locations_DropOffLocationId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_RentACars_RentACarId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationID",
                table: "RentACars");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "RentACars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: true),
                    DropOffLocationId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DriverLicenseYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_DropOffLocationId",
                        column: x => x.DropOffLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DropOffLocationId",
                table: "Reservations",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PickUpLocationId",
                table: "Reservations",
                column: "PickUpLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Customers_CustomerId",
                table: "RentACarProcesses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Locations_DropOffLocationId",
                table: "RentACarProcesses",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_RentACars_RentACarId",
                table: "RentACarProcesses",
                column: "RentACarId",
                principalTable: "RentACars",
                principalColumn: "RentACarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationID",
                table: "RentACars",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Customers_CustomerId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Locations_DropOffLocationId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_RentACars_RentACarId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationID",
                table: "RentACars");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RentACars");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Customers_CustomerId",
                table: "RentACarProcesses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Locations_DropOffLocationId",
                table: "RentACarProcesses",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_RentACars_RentACarId",
                table: "RentACarProcesses",
                column: "RentACarId",
                principalTable: "RentACars",
                principalColumn: "RentACarId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationID",
                table: "RentACars",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }
    }
}
