using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Data.Migrations
{
    public partial class update_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_AspNetUsers_userId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_nurses_AspNetUsers_userId",
                table: "nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_nurses_doctors_doctorId",
                table: "nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_AspNetUsers_userId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_nurses_nursesId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patientSchdules_patients_patientId",
                table: "patientSchdules");

            migrationBuilder.DropForeignKey(
                name: "FK_patientSchdules_schidules_schiduleId",
                table: "patientSchdules");

            migrationBuilder.DropForeignKey(
                name: "FK_patientTreatments_patients_patientId",
                table: "patientTreatments");

            migrationBuilder.DropForeignKey(
                name: "FK_patientTreatments_treatments_treatmentId",
                table: "patientTreatments");

            migrationBuilder.DropTable(
                name: "doctorSchidules");

            migrationBuilder.DropTable(
                name: "nurseSchidules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_treatments",
                table: "treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_schidules",
                table: "schidules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patientTreatments",
                table: "patientTreatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patientSchdules",
                table: "patientSchdules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patients",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nurses",
                table: "nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doctors",
                table: "doctors");

            migrationBuilder.RenameTable(
                name: "treatments",
                newName: "Treatments");

            migrationBuilder.RenameTable(
                name: "schidules",
                newName: "Schidules");

            migrationBuilder.RenameTable(
                name: "patientTreatments",
                newName: "PatientTreatments");

            migrationBuilder.RenameTable(
                name: "patientSchdules",
                newName: "PatientSchdules");

            migrationBuilder.RenameTable(
                name: "patients",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "nurses",
                newName: "Nurses");

            migrationBuilder.RenameTable(
                name: "doctors",
                newName: "Doctors");

            migrationBuilder.RenameColumn(
                name: "treatmentId",
                table: "PatientTreatments",
                newName: "TreatmentId");

            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "PatientTreatments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_patientTreatments_treatmentId",
                table: "PatientTreatments",
                newName: "IX_PatientTreatments_TreatmentId");

            migrationBuilder.RenameColumn(
                name: "schiduleId",
                table: "PatientSchdules",
                newName: "SchiduleId");

            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "PatientSchdules",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_patientSchdules_schiduleId",
                table: "PatientSchdules",
                newName: "IX_PatientSchdules_SchiduleId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Patients",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "nursesId",
                table: "Patients",
                newName: "NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_patients_userId",
                table: "Patients",
                newName: "IX_Patients_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_patients_nursesId",
                table: "Patients",
                newName: "IX_Patients_NurseId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Nurses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "Nurses",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_nurses_userId",
                table: "Nurses",
                newName: "IX_Nurses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_nurses_doctorId",
                table: "Nurses",
                newName: "IX_Nurses_DoctorId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Doctors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_doctors_userId",
                table: "Doctors",
                newName: "IX_Doctors_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasNurse",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Nurses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasDoctor",
                table: "Nurses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Nurses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPatients",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftsOfNurse",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Nurses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfNurses",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Doctors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "shiftsOfDoctor",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schidules",
                table: "Schidules",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientTreatments",
                table: "PatientTreatments",
                columns: new[] { "PatientId", "TreatmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientSchdules",
                table: "PatientSchdules",
                columns: new[] { "PatientId", "SchiduleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nurses",
                table: "Nurses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_AspNetUsers_UserId",
                table: "Nurses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Doctors_DoctorId",
                table: "Nurses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Nurses_NurseId",
                table: "Patients",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSchdules_Patients_PatientId",
                table: "PatientSchdules",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSchdules_Schidules_SchiduleId",
                table: "PatientSchdules",
                column: "SchiduleId",
                principalTable: "Schidules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTreatments_Patients_PatientId",
                table: "PatientTreatments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTreatments_Treatments_TreatmentId",
                table: "PatientTreatments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_AspNetUsers_UserId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Doctors_DoctorId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Nurses_NurseId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSchdules_Patients_PatientId",
                table: "PatientSchdules");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSchdules_Schidules_SchiduleId",
                table: "PatientSchdules");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientTreatments_Patients_PatientId",
                table: "PatientTreatments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientTreatments_Treatments_TreatmentId",
                table: "PatientTreatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schidules",
                table: "Schidules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientTreatments",
                table: "PatientTreatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientSchdules",
                table: "PatientSchdules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nurses",
                table: "Nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HasNurse",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "HasDoctor",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "NumberOfPatients",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "ShiftsOfNurse",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "NumberOfNurses",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "shiftsOfDoctor",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Treatments",
                newName: "treatments");

            migrationBuilder.RenameTable(
                name: "Schidules",
                newName: "schidules");

            migrationBuilder.RenameTable(
                name: "PatientTreatments",
                newName: "patientTreatments");

            migrationBuilder.RenameTable(
                name: "PatientSchdules",
                newName: "patientSchdules");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "patients");

            migrationBuilder.RenameTable(
                name: "Nurses",
                newName: "nurses");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "doctors");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                table: "patientTreatments",
                newName: "treatmentId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "patientTreatments",
                newName: "patientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientTreatments_TreatmentId",
                table: "patientTreatments",
                newName: "IX_patientTreatments_treatmentId");

            migrationBuilder.RenameColumn(
                name: "SchiduleId",
                table: "patientSchdules",
                newName: "schiduleId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "patientSchdules",
                newName: "patientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientSchdules_SchiduleId",
                table: "patientSchdules",
                newName: "IX_patientSchdules_schiduleId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "patients",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "NurseId",
                table: "patients",
                newName: "nursesId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_UserId",
                table: "patients",
                newName: "IX_patients_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_NurseId",
                table: "patients",
                newName: "IX_patients_nursesId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "nurses",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "nurses",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_UserId",
                table: "nurses",
                newName: "IX_nurses_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Nurses_DoctorId",
                table: "nurses",
                newName: "IX_nurses_doctorId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "doctors",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_UserId",
                table: "doctors",
                newName: "IX_doctors_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_treatments",
                table: "treatments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_schidules",
                table: "schidules",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patientTreatments",
                table: "patientTreatments",
                columns: new[] { "patientId", "treatmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_patientSchdules",
                table: "patientSchdules",
                columns: new[] { "patientId", "schiduleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_patients",
                table: "patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nurses",
                table: "nurses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_doctors",
                table: "doctors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "doctorSchidules",
                columns: table => new
                {
                    schiduleId = table.Column<int>(type: "int", nullable: false),
                    doctortId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorSchidules", x => new { x.schiduleId, x.doctortId });
                    table.ForeignKey(
                        name: "FK_doctorSchidules_doctors_doctortId",
                        column: x => x.doctortId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctorSchidules_schidules_schiduleId",
                        column: x => x.schiduleId,
                        principalTable: "schidules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nurseSchidules",
                columns: table => new
                {
                    schiduleId = table.Column<int>(type: "int", nullable: false),
                    nurseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nurseSchidules", x => new { x.schiduleId, x.nurseId });
                    table.ForeignKey(
                        name: "FK_nurseSchidules_nurses_nurseId",
                        column: x => x.nurseId,
                        principalTable: "nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nurseSchidules_schidules_schiduleId",
                        column: x => x.schiduleId,
                        principalTable: "schidules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctorSchidules_doctortId",
                table: "doctorSchidules",
                column: "doctortId");

            migrationBuilder.CreateIndex(
                name: "IX_nurseSchidules_nurseId",
                table: "nurseSchidules",
                column: "nurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_AspNetUsers_userId",
                table: "doctors",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nurses_AspNetUsers_userId",
                table: "nurses",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nurses_doctors_doctorId",
                table: "nurses",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_AspNetUsers_userId",
                table: "patients",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_nurses_nursesId",
                table: "patients",
                column: "nursesId",
                principalTable: "nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientSchdules_patients_patientId",
                table: "patientSchdules",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientSchdules_schidules_schiduleId",
                table: "patientSchdules",
                column: "schiduleId",
                principalTable: "schidules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientTreatments_patients_patientId",
                table: "patientTreatments",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientTreatments_treatments_treatmentId",
                table: "patientTreatments",
                column: "treatmentId",
                principalTable: "treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
