using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishDictApp.Data.Migrations
{
    public partial class FixWordTitleColumnProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Words_Title",
                table: "Words");

            migrationBuilder.CreateIndex(
                name: "IX_Words_Title",
                table: "Words",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_Title",
                table: "Words");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Words_Title",
                table: "Words",
                column: "Title");
        }
    }
}
