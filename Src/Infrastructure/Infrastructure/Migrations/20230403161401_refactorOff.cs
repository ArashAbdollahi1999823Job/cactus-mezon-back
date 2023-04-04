using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorOff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Offs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Offs_StoreId",
                table: "Offs",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offs_Stores_StoreId",
                table: "Offs",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offs_Stores_StoreId",
                table: "Offs");

            migrationBuilder.DropIndex(
                name: "IX_Offs_StoreId",
                table: "Offs");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Offs");
        }
    }
}
