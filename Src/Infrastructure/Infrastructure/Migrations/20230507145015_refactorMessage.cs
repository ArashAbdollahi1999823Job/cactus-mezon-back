using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderPhoneNumber",
                table: "Messages",
                newName: "ResponderPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "ResponderId");

            migrationBuilder.RenameColumn(
                name: "ReceiverPhoneNumber",
                table: "Messages",
                newName: "AskerPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Messages",
                newName: "AskerId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                newName: "IX_Messages_ResponderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                newName: "IX_Messages_AskerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_AskerId",
                table: "Messages",
                column: "AskerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ResponderId",
                table: "Messages",
                column: "ResponderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_AskerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ResponderId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ResponderPhoneNumber",
                table: "Messages",
                newName: "SenderPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ResponderId",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "AskerPhoneNumber",
                table: "Messages",
                newName: "ReceiverPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AskerId",
                table: "Messages",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ResponderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_AskerId",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
