using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorUserPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPicture_Users_UserId",
                table: "UserPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPicture",
                table: "UserPicture");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserPicture");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserPicture");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UserPicture");

            migrationBuilder.DropColumn(
                name: "PictureAlt",
                table: "UserPicture");

            migrationBuilder.DropColumn(
                name: "PictureTitle",
                table: "UserPicture");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "UserPicture");

            migrationBuilder.RenameTable(
                name: "UserPicture",
                newName: "UserPictures");

            migrationBuilder.RenameIndex(
                name: "IX_UserPicture_UserId",
                table: "UserPictures",
                newName: "IX_UserPictures_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPictures",
                table: "UserPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPictures_Users_UserId",
                table: "UserPictures",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPictures_Users_UserId",
                table: "UserPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPictures",
                table: "UserPictures");

            migrationBuilder.RenameTable(
                name: "UserPictures",
                newName: "UserPicture");

            migrationBuilder.RenameIndex(
                name: "IX_UserPictures_UserId",
                table: "UserPicture",
                newName: "IX_UserPicture_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserPicture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserPicture",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UserPicture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureAlt",
                table: "UserPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureTitle",
                table: "UserPicture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "UserPicture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPicture",
                table: "UserPicture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPicture_Users_UserId",
                table: "UserPicture",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
