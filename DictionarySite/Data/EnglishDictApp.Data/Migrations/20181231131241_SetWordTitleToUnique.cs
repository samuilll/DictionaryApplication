using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishDictApp.Data.Migrations
{
    public partial class SetWordTitleToUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Words_Title",
                table: "Words",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Words_Title",
                table: "Words");
        }
    }
}
