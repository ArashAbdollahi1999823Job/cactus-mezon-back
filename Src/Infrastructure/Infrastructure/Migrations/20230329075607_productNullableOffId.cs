using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productNullableOffId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Offs_OffId",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "OffId",
                table: "Products",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Offs_OffId",
                table: "Products",
                column: "OffId",
                principalTable: "Offs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Offs_OffId",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "OffId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Offs_OffId",
                table: "Products",
                column: "OffId",
                principalTable: "Offs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
