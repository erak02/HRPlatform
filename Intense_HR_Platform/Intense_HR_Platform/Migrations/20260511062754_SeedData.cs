using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Intense_HR_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobCandidates",
                columns: new[] { "Id", "ContactNo", "DateOfBirth", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "+381655525711", new DateTime(2002, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "eraknikola1@gmail.com", "Nikola Erak" },
                    { 2, "+381643828232", new DateTime(1997, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "markoerak97@gmail.com", "Marko Erak" },
                    { 3, "+381605827127", new DateTime(2002, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "mikipol14@gmail.com", "Milan Polić" },
                    { 4, "+381601593250", new DateTime(2001, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "markomarkovic@gmail.com", "Marko Marković" },
                    { 5, "381655525600", new DateTime(2004, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "petrovicpetar@gmail.com", "Petar Petrović" }
                });

            migrationBuilder.InsertData(
                table: "JobCandidatesSkills",
                columns: new[] { "JobCandidateId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 3 },
                    { 3, 5 },
                    { 4, 5 },
                    { 4, 6 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "c#" },
                    { 2, "java" },
                    { 3, "c++" },
                    { 4, "Database design" },
                    { 5, "English language" },
                    { 6, "Russian language" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobCandidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobCandidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobCandidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobCandidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobCandidates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "JobCandidatesSkills",
                keyColumns: new[] { "JobCandidateId", "SkillId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
