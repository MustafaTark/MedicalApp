using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Migrations
{
    /// <inheritdoc />
    public partial class mesaMigfff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Patients_PatientId",
                table: "Chats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a89c1ac-a2c8-4960-b422-3301201a526e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6049e780-3dfa-4181-95d6-ee6e0f1a731b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9012d07-b0aa-456e-8abd-c83450a0879a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19b9f103-aa14-4587-a050-a47bd4ec438e", null, "Clinic", "CLINIC" },
                    { "3b66706f-e393-4057-b290-516448d5d6cf", null, "Patient", "PATIENT" },
                    { "fbefaf8b-de9c-4f18-a48f-d3ee8fbb965d", null, "Pharmacy", "PHARMACY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Patients_PatientId",
                table: "Chats",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Patients_PatientId",
                table: "Chats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b9f103-aa14-4587-a050-a47bd4ec438e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b66706f-e393-4057-b290-516448d5d6cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbefaf8b-de9c-4f18-a48f-d3ee8fbb965d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a89c1ac-a2c8-4960-b422-3301201a526e", null, "Clinic", "CLINIC" },
                    { "6049e780-3dfa-4181-95d6-ee6e0f1a731b", null, "Pharmacy", "PHARMACY" },
                    { "a9012d07-b0aa-456e-8abd-c83450a0879a", null, "Patient", "PATIENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Patients_PatientId",
                table: "Chats",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
