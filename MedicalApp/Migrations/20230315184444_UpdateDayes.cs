using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDayes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ff686f2-286a-4766-98fa-3810ccb06599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bd15de1-32ba-42db-a47d-c65dddd045dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b75ece68-802c-4c84-9730-25e204fb1b76");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "ClinicDayes",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28e4da60-6839-49bd-9ee3-2ee410e02261", null, "Patient", "PATIENT" },
                    { "73db4f14-68d3-49fd-bde0-b50f82962643", null, "Clinic", "CLINIC" },
                    { "98f1ba08-3219-4f0a-85d0-c857c1b0fb39", null, "Pharmacy", "PHARMACY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e4da60-6839-49bd-9ee3-2ee410e02261");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73db4f14-68d3-49fd-bde0-b50f82962643");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f1ba08-3219-4f0a-85d0-c857c1b0fb39");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "ClinicDayes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ff686f2-286a-4766-98fa-3810ccb06599", null, "Clinic", "CLINIC" },
                    { "9bd15de1-32ba-42db-a47d-c65dddd045dd", null, "Pharmacy", "PHARMACY" },
                    { "b75ece68-802c-4c84-9730-25e204fb1b76", null, "Patient", "PATIENT" }
                });
        }
    }
}
