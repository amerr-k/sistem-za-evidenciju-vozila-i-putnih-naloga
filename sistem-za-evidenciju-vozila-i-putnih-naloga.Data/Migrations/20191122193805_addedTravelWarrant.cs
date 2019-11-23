using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Migrations
{
    public partial class addedTravelWarrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<int>(nullable: false),
                    Surname = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "TravelWarrant",
                columns: table => new
                {
                    TravelWarrantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    StartLocation = table.Column<string>(nullable: true),
                    EndLocation = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    NumberOfPassengers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelWarrant", x => x.TravelWarrantId);
                    table.ForeignKey(
                        name: "FK_TravelWarrant_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelWarrant_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelWarrant_CarId",
                table: "TravelWarrant",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelWarrant_DriverId",
                table: "TravelWarrant",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelWarrant");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
