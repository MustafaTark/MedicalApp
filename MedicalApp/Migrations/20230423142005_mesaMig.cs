using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class mesaMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicMessages_Clinics_ClinicId",
                table: "ClinicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMessages_Patients_PatientId",
                table: "PatientMessages");

            migrationBuilder.DropIndex(
                name: "IX_PatientMessages_PatientId",
                table: "PatientMessages");

            migrationBuilder.DropIndex(
                name: "IX_ClinicMessages_ClinicId",
                table: "ClinicMessages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ba210ef-7dee-48f3-8795-4b927be97ea4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21f30164-be58-4d45-8622-d20f2fbaa1f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b28b092a-b233-4a84-9b24-ec873976af9d");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientMessages");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "ClinicMessages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a89c1ac-a2c8-4960-b422-3301201a526e", null, "Clinic", "CLINIC" },
                    { "6049e780-3dfa-4181-95d6-ee6e0f1a731b", null, "Pharmacy", "PHARMACY" },
                    { "a9012d07-b0aa-456e-8abd-c83450a0879a", null, "Patient", "PATIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a89c1ac-a2c8-4960-b422-3301201a526e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6049e780-3dfa-4181-95d6-ee6e0f1a731b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9012d07-b0aa-456e-8abd-c83450a0879a");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "PatientMessages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicId",
                table: "ClinicMessages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ba210ef-7dee-48f3-8795-4b927be97ea4", null, "Patient", "PATIENT" },
                    { "21f30164-be58-4d45-8622-d20f2fbaa1f9", null, "Clinic", "CLINIC" },
                    { "b28b092a-b233-4a84-9b24-ec873976af9d", null, "Pharmacy", "PHARMACY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMessages_PatientId",
                table: "PatientMessages",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicMessages_ClinicId",
                table: "ClinicMessages",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicMessages_Clinics_ClinicId",
                table: "ClinicMessages",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMessages_Patients_PatientId",
                table: "PatientMessages",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
