using Microsoft.EntityFrameworkCore.Migrations;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Migrations
{
    public partial class pocetna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrand",
                columns: table => new
                {
                    CarBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrand", x => x.CarBrandId);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    CarModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CarBrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.CarModelId);
                    table.ForeignKey(
                        name: "FK_CarModel_CarBrand_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrand",
                        principalColumn: "CarBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelId = table.Column<int>(nullable: false),
                    ChassisNumber = table.Column<string>(nullable: true),
                    EngineNumber = table.Column<string>(nullable: true),
                    EnginPowerKS = table.Column<double>(nullable: false),
                    EnginPowerKW = table.Column<double>(nullable: false),
                    Fuel = table.Column<int>(nullable: false),
                    ProductionYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "CarModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarBrand",
                columns: new[] { "CarBrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "Peuget" },
                    { 3, "Mercedes" },
                    { 4, "BMW" },
                    { 5, "Citroen" },
                    { 6, "Renault" },
                    { 7, "VW" }
                });

            migrationBuilder.InsertData(
                table: "CarModel",
                columns: new[] { "CarModelId", "CarBrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "TT" },
                    { 2, 2, "306" },
                    { 5, 2, "r2" },
                    { 3, 3, "S" },
                    { 6, 3, "er2" },
                    { 4, 4, "X6" },
                    { 7, 7, "Golf 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarModelId",
                table: "Car",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrand_Name",
                table: "CarBrand",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarBrandId",
                table: "CarModel",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_Name_CarBrandId",
                table: "CarModel",
                columns: new[] { "Name", "CarBrandId" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "CarBrand");
        }
    }
}
