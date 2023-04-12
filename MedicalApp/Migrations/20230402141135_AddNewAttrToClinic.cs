using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAttrToClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d2d5e19-54f4-4997-bfb2-3566840fe17e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "befd067d-f07d-4e70-8f01-25bfacd719be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2740340-5960-441f-ae72-1d1cd03c9dd5");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Clinics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Clinics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d2d5e19-54f4-4997-bfb2-3566840fe17e", null, "Clinic", "CLINIC" },
                    { "befd067d-f07d-4e70-8f01-25bfacd719be", null, "Pharmacy", "PHARMACY" },
                    { "c2740340-5960-441f-ae72-1d1cd03c9dd5", null, "Patient", "PATIENT" }
                });
        }
    }
}
