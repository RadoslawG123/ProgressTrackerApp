using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColorsToCategoryAndHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "textColor",
                table: "Habit",
                newName: "TextColor");

            migrationBuilder.RenameColumn(
                name: "backgroundColor",
                table: "Habit",
                newName: "BackgroundColor");

            migrationBuilder.RenameColumn(
                name: "textColor",
                table: "Category",
                newName: "TextColor");

            migrationBuilder.RenameColumn(
                name: "backgroundColor",
                table: "Category",
                newName: "BackgroundColor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextColor",
                table: "Habit",
                newName: "textColor");

            migrationBuilder.RenameColumn(
                name: "BackgroundColor",
                table: "Habit",
                newName: "backgroundColor");

            migrationBuilder.RenameColumn(
                name: "TextColor",
                table: "Category",
                newName: "textColor");

            migrationBuilder.RenameColumn(
                name: "BackgroundColor",
                table: "Category",
                newName: "backgroundColor");
        }
    }
}
