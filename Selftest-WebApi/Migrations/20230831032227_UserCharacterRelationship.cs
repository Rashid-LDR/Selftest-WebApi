using Microsoft.EntityFrameworkCore.Migrations;

namespace Selftest_WebApi.Migrations
{
    public partial class UserCharacterRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Userid",
                table: "Characters",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_User_Userid",
                table: "Characters",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_User_Userid",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Userid",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Characters");
        }
    }
}
