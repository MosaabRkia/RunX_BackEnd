using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class choosenFoodToListInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_User_UserId",
                table: "FoodItem");

            migrationBuilder.DropIndex(
                name: "IX_FoodItem_UserId",
                table: "FoodItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodItem");

            migrationBuilder.CreateTable(
                name: "FoodChoosen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodChoosen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodChoosen_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodChoosen_UserId",
                table: "FoodChoosen",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodChoosen");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FoodItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_UserId",
                table: "FoodItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_User_UserId",
                table: "FoodItem",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
