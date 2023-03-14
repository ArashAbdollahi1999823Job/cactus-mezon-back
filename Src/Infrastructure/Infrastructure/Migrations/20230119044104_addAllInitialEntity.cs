using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAllInitialEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShopSellers_ShopSellerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ShopSellerId",
                table: "Products",
                newName: "OffId");

            migrationBuilder.RenameColumn(
                name: "OffPercent",
                table: "Products",
                newName: "Count");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopSellerId",
                table: "Products",
                newName: "IX_Products_OffId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ShopSellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShopSellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "ShopSellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ShopSellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShopSellers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentProductTypeId",
                table: "ProductTypes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventoryId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UserAnswerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserAnswerId",
                        column: x => x.UserAnswerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopSellerId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_ShopSellers_ShopSellerId",
                        column: x => x.ShopSellerId,
                        principalTable: "ShopSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffPercent = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypePictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ProductTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypePictures_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopSellerPictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ShopSellerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSellerPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopSellerPictures_ShopSellers_ShopSellerId",
                        column: x => x.ShopSellerId,
                        principalTable: "ShopSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceOperation = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    InventoryOperationType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOperations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOperations_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOperations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSellers_UserId",
                table: "ShopSellers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ParentProductTypeId",
                table: "ProductTypes",
                column: "ParentProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryId",
                table: "Products",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserAnswerId",
                table: "Comment",
                column: "UserAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ShopSellerId",
                table: "Inventories",
                column: "ShopSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_InventoryId",
                table: "InventoryOperations",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_ProductId",
                table: "InventoryOperations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_UserId",
                table: "InventoryOperations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypePictures_ProductTypeId",
                table: "ProductTypePictures",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopSellerPictures_ShopSellerId",
                table: "ShopSellerPictures",
                column: "ShopSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventories_InventoryId",
                table: "Products",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Offs_OffId",
                table: "Products",
                column: "OffId",
                principalTable: "Offs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_ProductTypes_ParentProductTypeId",
                table: "ProductTypes",
                column: "ParentProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopSellers_AspNetUsers_UserId",
                table: "ShopSellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventories_InventoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Offs_OffId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_ProductTypes_ParentProductTypeId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopSellers_AspNetUsers_UserId",
                table: "ShopSellers");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "InventoryOperations");

            migrationBuilder.DropTable(
                name: "Offs");

            migrationBuilder.DropTable(
                name: "ProductTypePictures");

            migrationBuilder.DropTable(
                name: "ShopSellerPictures");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_ShopSellers_UserId",
                table: "ShopSellers");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_ParentProductTypeId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "ShopSellers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShopSellers");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "ShopSellers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ShopSellers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShopSellers");

            migrationBuilder.DropColumn(
                name: "ParentProductTypeId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OffId",
                table: "Products",
                newName: "ShopSellerId");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Products",
                newName: "OffPercent");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OffId",
                table: "Products",
                newName: "IX_Products_ShopSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShopSellers_ShopSellerId",
                table: "Products",
                column: "ShopSellerId",
                principalTable: "ShopSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
