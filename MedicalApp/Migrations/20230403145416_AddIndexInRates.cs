using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexInRates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "823bd50c-3dde-4319-bca3-d60b356f0584");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96d095db-2c91-4d0e-a20c-332ef602d559");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f269232f-964e-4774-8f25-257d0a0cdb97");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicId",
                table: "Rates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20678ffd-1c5d-4eea-b15f-6437d71e0d0e", null, "Clinic", "CLINIC" },
                    { "aca88b90-c795-4874-b4aa-98be58afb3f6", null, "Pharmacy", "PHARMACY" },
                    { "cbaa9173-7bbc-4dc8-885e-dda2ea4dffd1", null, "Patient", "PATIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ClinicId",
                table: "Rates",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rates_ClinicId",
                table: "Rates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20678ffd-1c5d-4eea-b15f-6437d71e0d0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aca88b90-c795-4874-b4aa-98be58afb3f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbaa9173-7bbc-4dc8-885e-dda2ea4dffd1");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicId",
                table: "Rates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "823bd50c-3dde-4319-bca3-d60b356f0584", null, "Pharmacy", "PHARMACY" },
                    { "96d095db-2c91-4d0e-a20c-332ef602d559", null, "Clinic", "CLINIC" },
                    { "f269232f-964e-4774-8f25-257d0a0cdb97", null, "Patient", "PATIENT" }
                });
        }
    }
}
