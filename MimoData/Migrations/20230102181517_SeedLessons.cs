using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MimoData.Migrations
{
    /// <inheritdoc />
    public partial class SeedLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "ChapterId", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, 1, "Lesson 1", 1 },
                    { 2, 1, "Lesson 2", 2 },
                    { 3, 1, "Lesson 3", 3 },
                    { 4, 1, "Lesson 4", 4 },
                    { 5, 1, "Lesson 5", 5 },
                    { 6, 1, "Lesson 6", 6 },
                    { 7, 1, "Lesson 7", 7 },
                    { 8, 1, "Lesson 8", 8 },
                    { 9, 1, "Lesson 9", 9 },
                    { 10, 1, "Lesson 10", 10 },
                    { 11, 2, "Lesson 1", 1 },
                    { 12, 2, "Lesson 2", 2 },
                    { 13, 2, "Lesson 3", 3 },
                    { 14, 2, "Lesson 4", 4 },
                    { 15, 2, "Lesson 5", 5 },
                    { 16, 2, "Lesson 6", 6 },
                    { 17, 2, "Lesson 7", 7 },
                    { 18, 2, "Lesson 8", 8 },
                    { 19, 2, "Lesson 9", 9 },
                    { 20, 2, "Lesson 10", 10 },
                    { 21, 3, "Lesson 1", 1 },
                    { 22, 3, "Lesson 2", 2 },
                    { 23, 3, "Lesson 3", 3 },
                    { 24, 3, "Lesson 4", 4 },
                    { 25, 3, "Lesson 5", 5 },
                    { 26, 3, "Lesson 6", 6 },
                    { 27, 3, "Lesson 7", 7 },
                    { 28, 3, "Lesson 8", 8 },
                    { 29, 3, "Lesson 9", 9 },
                    { 30, 3, "Lesson 10", 10 },
                    { 31, 4, "Lesson 1", 1 },
                    { 32, 4, "Lesson 2", 2 },
                    { 33, 4, "Lesson 3", 3 },
                    { 34, 4, "Lesson 4", 4 },
                    { 35, 4, "Lesson 5", 5 },
                    { 36, 4, "Lesson 6", 6 },
                    { 37, 4, "Lesson 7", 7 },
                    { 38, 4, "Lesson 8", 8 },
                    { 39, 4, "Lesson 9", 9 },
                    { 40, 4, "Lesson 10", 10 },
                    { 41, 5, "Lesson 1", 1 },
                    { 42, 5, "Lesson 2", 2 },
                    { 43, 5, "Lesson 3", 3 },
                    { 44, 5, "Lesson 4", 4 },
                    { 45, 5, "Lesson 5", 5 },
                    { 46, 5, "Lesson 6", 6 },
                    { 47, 5, "Lesson 7", 7 },
                    { 48, 5, "Lesson 8", 8 },
                    { 49, 5, "Lesson 9", 9 },
                    { 50, 5, "Lesson 10", 10 },
                    { 51, 6, "Lesson 1", 1 },
                    { 52, 6, "Lesson 2", 2 },
                    { 53, 6, "Lesson 3", 3 },
                    { 54, 6, "Lesson 4", 4 },
                    { 55, 6, "Lesson 5", 5 },
                    { 56, 6, "Lesson 6", 6 },
                    { 57, 6, "Lesson 7", 7 },
                    { 58, 6, "Lesson 8", 8 },
                    { 59, 6, "Lesson 9", 9 },
                    { 60, 6, "Lesson 10", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 55);

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
    }
}
