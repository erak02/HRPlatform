using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intense_HR_Platform.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreatingChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "JobCandidates",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Name",
                table: "Skills",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidatesSkills_SkillId",
                table: "JobCandidatesSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidates_Email",
                table: "JobCandidates",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidatesSkills_JobCandidates_JobCandidateId",
                table: "JobCandidatesSkills",
                column: "JobCandidateId",
                principalTable: "JobCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidatesSkills_Skills_SkillId",
                table: "JobCandidatesSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidatesSkills_JobCandidates_JobCandidateId",
                table: "JobCandidatesSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidatesSkills_Skills_SkillId",
                table: "JobCandidatesSkills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_Name",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_JobCandidatesSkills_SkillId",
                table: "JobCandidatesSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobCandidates_Email",
                table: "JobCandidates");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "JobCandidates",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
