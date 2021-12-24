using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class modelsv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalHistories_Patients_PatientId",
                table: "medicalHistories");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "medicalHistories",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_medicalHistories_PatientId",
                table: "medicalHistories",
                newName: "IX_medicalHistories_PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalHistories_Patients_PatientID",
                table: "medicalHistories",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalHistories_Patients_PatientID",
                table: "medicalHistories");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "medicalHistories",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_medicalHistories_PatientID",
                table: "medicalHistories",
                newName: "IX_medicalHistories_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalHistories_Patients_PatientId",
                table: "medicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
