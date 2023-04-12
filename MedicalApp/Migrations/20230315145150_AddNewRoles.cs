using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e41052d-69f6-45b6-9729-c3f1d5e25630", null, "Clinic", "CLINIC" },
                    { "25a29e0c-9a4e-4c1c-9860-ccee87efbebd", null, "Pharmacy", "PHARMACY" },
                    { "ff3255c5-229c-4d10-bbc9-2ea4c0f78aae", null, "Patient", "PATIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e41052d-69f6-45b6-9729-c3f1d5e25630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25a29e0c-9a4e-4c1c-9860-ccee87efbebd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3255c5-229c-4d10-bbc9-2ea4c0f78aae");
        }
    }
}
