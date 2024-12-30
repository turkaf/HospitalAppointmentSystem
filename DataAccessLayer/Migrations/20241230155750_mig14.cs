using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAnswers_Patients_PatientID",
                table: "PatientAnswers");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "PatientAnswers",
                newName: "AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_PatientAnswers_PatientID",
                table: "PatientAnswers",
                newName: "IX_PatientAnswers_AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAnswers_Appointments_AppointmentID",
                table: "PatientAnswers",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAnswers_Appointments_AppointmentID",
                table: "PatientAnswers");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "PatientAnswers",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_PatientAnswers_AppointmentID",
                table: "PatientAnswers",
                newName: "IX_PatientAnswers_PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAnswers_Patients_PatientID",
                table: "PatientAnswers",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
