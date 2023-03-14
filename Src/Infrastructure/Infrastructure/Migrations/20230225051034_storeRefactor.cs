using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class storeRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_ShopSellers_ShopSellerId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopSellerPictures_ShopSellers_ShopSellerId",
                table: "ShopSellerPictures");

            migrationBuilder.DropTable(
                name: "ShopSellers");

            migrationBuilder.RenameColumn(
                name: "ShopSellerId",
                table: "ShopSellerPictures",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopSellerPictures_ShopSellerId",
                table: "ShopSellerPictures",
                newName: "IX_ShopSellerPictures_StoreId");

            migrationBuilder.RenameColumn(
                name: "ShopSellerId",
                table: "Inventories",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_ShopSellerId",
                table: "Inventories",
                newName: "IX_Inventories_StoreId");

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Stores_StoreId",
                table: "Inventories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopSellerPictures_Stores_StoreId",
                table: "ShopSellerPictures",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Stores_StoreId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopSellerPictures_Stores_StoreId",
                table: "ShopSellerPictures");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "ShopSellerPictures",
                newName: "ShopSellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopSellerPictures_StoreId",
                table: "ShopSellerPictures",
                newName: "IX_ShopSellerPictures_ShopSellerId");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Inventories",
                newName: "ShopSellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories",
                newName: "IX_Inventories_ShopSellerId");

            migrationBuilder.CreateTable(
                name: "ShopSellers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopSellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSellers_UserId",
                table: "ShopSellers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_ShopSellers_ShopSellerId",
                table: "Inventories",
                column: "ShopSellerId",
                principalTable: "ShopSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopSellerPictures_ShopSellers_ShopSellerId",
                table: "ShopSellerPictures",
                column: "ShopSellerId",
                principalTable: "ShopSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
