using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class modelsv18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "medicalHistories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "medicalHistories");
        }
    }
}
