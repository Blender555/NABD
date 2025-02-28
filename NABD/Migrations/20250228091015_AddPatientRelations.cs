using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NABD.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctor_MedicalStaff_DoctorId",
                table: "PatientDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctor_Patients_PatientId",
                table: "PatientDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientGuardian_Guardians_GuardianId",
                table: "PatientGuardian");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientGuardian_Patients_PatientId",
                table: "PatientGuardian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientGuardian",
                table: "PatientGuardian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientDoctor",
                table: "PatientDoctor");

            migrationBuilder.RenameTable(
                name: "PatientGuardian",
                newName: "PatientGuardians");

            migrationBuilder.RenameTable(
                name: "PatientDoctor",
                newName: "PatientDoctors");

            migrationBuilder.RenameIndex(
                name: "IX_PatientGuardian_GuardianId",
                table: "PatientGuardians",
                newName: "IX_PatientGuardians_GuardianId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientDoctor_DoctorId",
                table: "PatientDoctors",
                newName: "IX_PatientDoctors_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientGuardians",
                table: "PatientGuardians",
                columns: new[] { "PatientId", "GuardianId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientDoctors",
                table: "PatientDoctors",
                columns: new[] { "PatientId", "DoctorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_MedicalStaff_DoctorId",
                table: "PatientDoctors",
                column: "DoctorId",
                principalTable: "MedicalStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Patients_PatientId",
                table: "PatientDoctors",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientGuardians_Guardians_GuardianId",
                table: "PatientGuardians",
                column: "GuardianId",
                principalTable: "Guardians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientGuardians_Patients_PatientId",
                table: "PatientGuardians",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_MedicalStaff_DoctorId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Patients_PatientId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientGuardians_Guardians_GuardianId",
                table: "PatientGuardians");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientGuardians_Patients_PatientId",
                table: "PatientGuardians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientGuardians",
                table: "PatientGuardians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientDoctors",
                table: "PatientDoctors");

            migrationBuilder.RenameTable(
                name: "PatientGuardians",
                newName: "PatientGuardian");

            migrationBuilder.RenameTable(
                name: "PatientDoctors",
                newName: "PatientDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_PatientGuardians_GuardianId",
                table: "PatientGuardian",
                newName: "IX_PatientGuardian_GuardianId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientDoctors_DoctorId",
                table: "PatientDoctor",
                newName: "IX_PatientDoctor_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientGuardian",
                table: "PatientGuardian",
                columns: new[] { "PatientId", "GuardianId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientDoctor",
                table: "PatientDoctor",
                columns: new[] { "PatientId", "DoctorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctor_MedicalStaff_DoctorId",
                table: "PatientDoctor",
                column: "DoctorId",
                principalTable: "MedicalStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctor_Patients_PatientId",
                table: "PatientDoctor",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientGuardian_Guardians_GuardianId",
                table: "PatientGuardian",
                column: "GuardianId",
                principalTable: "Guardians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientGuardian_Patients_PatientId",
                table: "PatientGuardian",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
