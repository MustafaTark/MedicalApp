using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd1a725-a8fd-4379-ac6a-636a35473e65", null, "Patient", "PATIENT" },
                    { "8c0e771c-fa0c-4fef-a491-0c2b42d2f2ed", null, "Pharmacy", "PHARMACY" },
                    { "e19b1ba8-b1f5-41c1-be8b-70d557ac52c4", null, "Clinic", "CLINIC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd1a725-a8fd-4379-ac6a-636a35473e65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c0e771c-fa0c-4fef-a491-0c2b42d2f2ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19b1ba8-b1f5-41c1-be8b-70d557ac52c4");
        }
    }
}
