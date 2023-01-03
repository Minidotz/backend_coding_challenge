using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MimoData.Migrations
{
    /// <inheritdoc />
    public partial class AchievementCourseFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Achievements_CourseId",
                table: "Achievements",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Courses_CourseId",
                table: "Achievements",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Courses_CourseId",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_CourseId",
                table: "Achievements");
        }
    }
}
