using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeyahatProject.Migrations
{
    /// <inheritdoc />
    public partial class SeyahatProjectDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlars_Blogs_BlogID",
                table: "Yorumlars");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Yorumlars",
                newName: "Blogid");

            migrationBuilder.RenameIndex(
                name: "IX_Yorumlars_BlogID",
                table: "Yorumlars",
                newName: "IX_Yorumlars_Blogid");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlars_Blogs_Blogid",
                table: "Yorumlars",
                column: "Blogid",
                principalTable: "Blogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlars_Blogs_Blogid",
                table: "Yorumlars");

            migrationBuilder.RenameColumn(
                name: "Blogid",
                table: "Yorumlars",
                newName: "BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_Yorumlars_Blogid",
                table: "Yorumlars",
                newName: "IX_Yorumlars_BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlars_Blogs_BlogID",
                table: "Yorumlars",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
