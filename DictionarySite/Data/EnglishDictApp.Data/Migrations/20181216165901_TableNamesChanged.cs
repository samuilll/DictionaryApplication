using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishDictApp.Data.Migrations
{
    public partial class TableNamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWord_AspNetUsers_UserId",
                table: "UserWord");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWord_Word_WordId",
                table: "UserWord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Word",
                table: "Word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWord",
                table: "UserWord");

            migrationBuilder.RenameTable(
                name: "Word",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "UserWord",
                newName: "UsersWords");

            migrationBuilder.RenameIndex(
                name: "IX_UserWord_WordId",
                table: "UsersWords",
                newName: "IX_UsersWords_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersWords",
                table: "UsersWords",
                columns: new[] { "UserId", "WordId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersWords_AspNetUsers_UserId",
                table: "UsersWords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersWords_Words_WordId",
                table: "UsersWords",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersWords_AspNetUsers_UserId",
                table: "UsersWords");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersWords_Words_WordId",
                table: "UsersWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersWords",
                table: "UsersWords");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "Word");

            migrationBuilder.RenameTable(
                name: "UsersWords",
                newName: "UserWord");

            migrationBuilder.RenameIndex(
                name: "IX_UsersWords_WordId",
                table: "UserWord",
                newName: "IX_UserWord_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Word",
                table: "Word",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWord",
                table: "UserWord",
                columns: new[] { "UserId", "WordId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserWord_AspNetUsers_UserId",
                table: "UserWord",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWord_Word_WordId",
                table: "UserWord",
                column: "WordId",
                principalTable: "Word",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
