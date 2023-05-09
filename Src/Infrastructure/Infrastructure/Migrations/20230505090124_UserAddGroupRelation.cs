using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAddGroupRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AskerId",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponderId",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AskerId",
                table: "Groups",
                column: "AskerId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ResponderId",
                table: "Groups",
                column: "ResponderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_AskerId",
                table: "Groups",
                column: "AskerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_ResponderId",
                table: "Groups",
                column: "ResponderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_AskerId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_ResponderId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_AskerId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ResponderId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AskerId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ResponderId",
                table: "Groups");
        }
    }
}
