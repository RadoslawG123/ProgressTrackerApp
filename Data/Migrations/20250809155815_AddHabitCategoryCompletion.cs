using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitCategoryCompletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskG",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Goal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categroy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categroy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habit_Categroy_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categroy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HabitCompletion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitCompletion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitCompletion_Habit_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habit_CategoryId",
                table: "Habit",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitCompletion_HabitId",
                table: "HabitCompletion",
                column: "HabitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitCompletion");

            migrationBuilder.DropTable(
                name: "Habit");

            migrationBuilder.DropTable(
                name: "Categroy");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskG");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Goal");
        }
    }
}
