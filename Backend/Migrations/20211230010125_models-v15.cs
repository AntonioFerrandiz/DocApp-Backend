using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class modelsv15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
