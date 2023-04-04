using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorInventoryOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOperations_Inventories_InventoryId",
                table: "InventoryOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOperations_Users_UserId",
                table: "InventoryOperations");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOperations_UserId",
                table: "InventoryOperations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InventoryOperations");

            migrationBuilder.RenameColumn(
                name: "PriceOperation",
                table: "InventoryOperations",
                newName: "Price");

            migrationBuilder.AlterColumn<long>(
                name: "InventoryId",
                table: "InventoryOperations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOperations_Inventories_InventoryId",
                table: "InventoryOperations",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOperations_Inventories_InventoryId",
                table: "InventoryOperations");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "InventoryOperations",
                newName: "PriceOperation");

            migrationBuilder.AlterColumn<long>(
                name: "InventoryId",
                table: "InventoryOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "InventoryOperations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_UserId",
                table: "InventoryOperations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOperations_Inventories_InventoryId",
                table: "InventoryOperations",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOperations_Users_UserId",
                table: "InventoryOperations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
