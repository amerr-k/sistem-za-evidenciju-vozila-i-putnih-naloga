using Microsoft.EntityFrameworkCore.Migrations;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Migrations
{
    public partial class triesFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductionYear",
                table: "Car",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "EnginPowerKW",
                table: "Car",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "EnginPowerKS",
                table: "Car",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductionYear",
                table: "Car",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EnginPowerKW",
                table: "Car",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "EnginPowerKS",
                table: "Car",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
