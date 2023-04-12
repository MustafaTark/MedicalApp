using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Category_CategoryId",
                table: "Clinics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ed2a65-e719-4524-9d76-aa97e507532c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a57dea48-c60b-4e85-8705-a2a07c53b537");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5b602ff-8c8e-41c0-96e0-e9280711067d");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "701d19d5-e2de-4071-9306-3fb3cf16b7d0", null, "Pharmacy", "PHARMACY" },
                    { "7605f4cd-9a10-4482-a4ff-46d153f2d34a", null, "Patient", "PATIENT" },
                    { "e9368186-d346-492d-9cbd-9eeae0f9071c", null, "Clinic", "CLINIC" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Categories_CategoryId",
                table: "Clinics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Categories_CategoryId",
                table: "Clinics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "701d19d5-e2de-4071-9306-3fb3cf16b7d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7605f4cd-9a10-4482-a4ff-46d153f2d34a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9368186-d346-492d-9cbd-9eeae0f9071c");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71ed2a65-e719-4524-9d76-aa97e507532c", null, "Pharmacy", "PHARMACY" },
                    { "a57dea48-c60b-4e85-8705-a2a07c53b537", null, "Patient", "PATIENT" },
                    { "d5b602ff-8c8e-41c0-96e0-e9280711067d", null, "Clinic", "CLINIC" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Category_CategoryId",
                table: "Clinics",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
