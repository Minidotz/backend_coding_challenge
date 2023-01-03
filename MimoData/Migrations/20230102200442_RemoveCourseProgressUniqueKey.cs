using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MimoData.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCourseProgressUniqueKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseProgress_CourseId_ChapterId_LessonId_UserId",
                table: "CourseProgress");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_CourseId",
                table: "CourseProgress",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseProgress_CourseId",
                table: "CourseProgress");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_CourseId_ChapterId_LessonId_UserId",
                table: "CourseProgress",
                columns: new[] { "CourseId", "ChapterId", "LessonId", "UserId" },
                unique: true);
        }
    }
}
