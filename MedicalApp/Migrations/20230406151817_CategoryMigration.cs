using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class CategoryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clinics_Category",
                table: "Clinics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03559373-ea92-4643-9551-63405423fae4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82e578db-81ec-4508-a64b-eb06ca33fa3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4474954-234a-497f-880c-203b13563ebc");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71ed2a65-e719-4524-9d76-aa97e507532c", null, "Pharmacy", "PHARMACY" },
                    { "a57dea48-c60b-4e85-8705-a2a07c53b537", null, "Patient", "PATIENT" },
                    { "d5b602ff-8c8e-41c0-96e0-e9280711067d", null, "Clinic", "CLINIC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_CategoryId",
                table: "Clinics",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Category_CategoryId",
                table: "Clinics",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Category_CategoryId",
                table: "Clinics");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_CategoryId",
                table: "Clinics");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Clinics");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Clinics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03559373-ea92-4643-9551-63405423fae4", null, "Pharmacy", "PHARMACY" },
                    { "82e578db-81ec-4508-a64b-eb06ca33fa3e", null, "Clinic", "CLINIC" },
                    { "c4474954-234a-497f-880c-203b13563ebc", null, "Patient", "PATIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Category",
                table: "Clinics",
                column: "Category");
        }
    }
}
