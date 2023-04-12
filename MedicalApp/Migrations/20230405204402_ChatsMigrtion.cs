using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class ChatsMigrtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClinicMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClinicId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicMessages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicMessages_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMessages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientMessages_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

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
                name: "IX_Chats_ClinicId",
                table: "Chats",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_PatientId",
                table: "Chats",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicMessages_ChatId",
                table: "ClinicMessages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicMessages_ClinicId",
                table: "ClinicMessages",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMessages_ChatId",
                table: "PatientMessages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMessages_PatientId",
                table: "PatientMessages",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicMessages");

            migrationBuilder.DropTable(
                name: "PatientMessages");

            migrationBuilder.DropTable(
                name: "Chats");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20678ffd-1c5d-4eea-b15f-6437d71e0d0e", null, "Clinic", "CLINIC" },
                    { "aca88b90-c795-4874-b4aa-98be58afb3f6", null, "Pharmacy", "PHARMACY" },
                    { "cbaa9173-7bbc-4dc8-885e-dda2ea4dffd1", null, "Patient", "PATIENT" }
                });
        }
    }
}
