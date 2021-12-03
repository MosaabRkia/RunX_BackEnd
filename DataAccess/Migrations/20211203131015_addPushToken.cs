using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addPushToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Time_Medicine_MedicineId",
                table: "Time");

            migrationBuilder.AddColumn<int>(
                name: "notificationsId",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PushNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_notificationsId",
                table: "User",
                column: "notificationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Time_Medicine_MedicineId",
                table: "Time",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_PushNotifications_notificationsId",
                table: "User",
                column: "notificationsId",
                principalTable: "PushNotifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Time_Medicine_MedicineId",
                table: "Time");

            migrationBuilder.DropForeignKey(
                name: "FK_User_PushNotifications_notificationsId",
                table: "User");

            migrationBuilder.DropTable(
                name: "PushNotifications");

            migrationBuilder.DropIndex(
                name: "IX_User_notificationsId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "notificationsId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Time",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Time_Medicine_MedicineId",
                table: "Time",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
