using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habit_Categroy_CategoryId",
                table: "Habit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categroy",
                table: "Categroy");

            migrationBuilder.RenameTable(
                name: "Categroy",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskG",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HabitCompletion",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Habit",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Goal",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskG_UserId",
                table: "TaskG",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitCompletion_UserId",
                table: "HabitCompletion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Habit_UserId",
                table: "Habit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_UserId",
                table: "Goal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_UserId",
                table: "Category",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_UserId",
                table: "Category",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_AspNetUsers_UserId",
                table: "Goal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_AspNetUsers_UserId",
                table: "Habit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_Category_CategoryId",
                table: "Habit",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitCompletion_AspNetUsers_UserId",
                table: "HabitCompletion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskG_AspNetUsers_UserId",
                table: "TaskG",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_UserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_AspNetUsers_UserId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Habit_AspNetUsers_UserId",
                table: "Habit");

            migrationBuilder.DropForeignKey(
                name: "FK_Habit_Category_CategoryId",
                table: "Habit");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitCompletion_AspNetUsers_UserId",
                table: "HabitCompletion");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskG_AspNetUsers_UserId",
                table: "TaskG");

            migrationBuilder.DropIndex(
                name: "IX_TaskG_UserId",
                table: "TaskG");

            migrationBuilder.DropIndex(
                name: "IX_HabitCompletion_UserId",
                table: "HabitCompletion");

            migrationBuilder.DropIndex(
                name: "IX_Habit_UserId",
                table: "Habit");

            migrationBuilder.DropIndex(
                name: "IX_Goal_UserId",
                table: "Goal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_UserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categroy");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskG",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HabitCompletion",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Habit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Goal",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Categroy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categroy",
                table: "Categroy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_Categroy_CategoryId",
                table: "Habit",
                column: "CategoryId",
                principalTable: "Categroy",
                principalColumn: "Id");
        }
    }
}
