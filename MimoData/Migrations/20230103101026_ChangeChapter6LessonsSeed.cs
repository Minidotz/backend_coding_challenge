using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MimoData.Migrations
{
    /// <inheritdoc />
    public partial class ChangeChapter6LessonsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 60);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "ChapterId", "Name", "Sort" },
                values: new object[,]
                {
                    { 56, 6, "Lesson 6", 6 },
                    { 57, 6, "Lesson 7", 7 },
                    { 58, 6, "Lesson 8", 8 },
                    { 59, 6, "Lesson 9", 9 },
                    { 60, 6, "Lesson 10", 10 }
                });
        }
    }
}
