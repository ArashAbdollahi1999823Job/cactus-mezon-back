using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteDoubleKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId1",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "ShopSellerId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ShopSellers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSellers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopSellerId",
                table: "Products",
                column: "ShopSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShopSellers_ShopSellerId",
                table: "Products",
                column: "ShopSellerId",
                principalTable: "ShopSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShopSellers_ShopSellerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ShopSellers");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopSellerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopSellerId",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "ProductTypeId1",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId1",
                table: "Products",
                column: "ProductTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId1",
                table: "Products",
                column: "ProductTypeId1",
                principalTable: "ProductTypes",
                principalColumn: "Id");
        }
    }
}
