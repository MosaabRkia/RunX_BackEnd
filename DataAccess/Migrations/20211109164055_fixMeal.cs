using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class fixMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_Meal_MealId",
                table: "FoodItem");

            migrationBuilder.DropIndex(
                name: "IX_FoodItem_MealId",
                table: "FoodItem");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "FoodItem");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "FoodChoosen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodChoosen_MealId",
                table: "FoodChoosen",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodChoosen_Meal_MealId",
                table: "FoodChoosen",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodChoosen_Meal_MealId",
                table: "FoodChoosen");

            migrationBuilder.DropIndex(
                name: "IX_FoodChoosen_MealId",
                table: "FoodChoosen");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "FoodChoosen");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "FoodItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_MealId",
                table: "FoodItem",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_Meal_MealId",
                table: "FoodItem",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
