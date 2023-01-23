using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1922c5cc-62af-420d-a09b-1739e19f6716", null, "Clinic", "CLINIC" },
                    { "3abe9574-2aef-44fd-b299-d702a6f2cab0", null, "Patient", "PATIENT" },
                    { "6bfd66a4-ace1-42d5-9a3f-c7ae1304245d", null, "Pharmacy", "PHARMACY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1922c5cc-62af-420d-a09b-1739e19f6716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abe9574-2aef-44fd-b299-d702a6f2cab0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bfd66a4-ace1-42d5-9a3f-c7ae1304245d");
        }
    }
}
