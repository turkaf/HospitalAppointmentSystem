using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicines");

            migrationBuilder.DropTable(
                name: "Medicines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicines",
                columns: table => new
                {
                    PrescriptionMedicineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicines", x => x.PrescriptionMedicineID);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Medicines_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicines",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_MedicineID",
                table: "PrescriptionMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_PrescriptionID",
                table: "PrescriptionMedicines",
                column: "PrescriptionID");
        }
    }
}
