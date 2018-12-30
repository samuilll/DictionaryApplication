using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishDictApp.Data.Migrations
{
    public partial class toDeleteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToDelete",
                table: "Words",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToDelete",
                table: "Words");
        }
    }
}
