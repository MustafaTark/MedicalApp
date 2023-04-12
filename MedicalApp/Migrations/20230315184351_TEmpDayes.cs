using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class TEmpDayes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Day",
                table: "ClinicDayes");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "ClinicDayes",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
