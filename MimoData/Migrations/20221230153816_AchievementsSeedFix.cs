using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MimoData.Migrations
{
    /// <inheritdoc />
    public partial class AchievementsSeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 3,
                column: "Units",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 4,
                column: "Units",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 3,
                column: "Units",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 4,
                column: "Units",
                value: 5);
        }
    }
}
