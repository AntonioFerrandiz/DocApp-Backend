using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class modelsv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrescribedMedication",
                table: "medicalHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimePeriod",
                table: "medicalHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrescribedMedication",
                table: "medicalHistories");

            migrationBuilder.DropColumn(
                name: "TimePeriod",
                table: "medicalHistories");
        }
    }
}
