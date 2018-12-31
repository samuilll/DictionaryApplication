using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishDictApp.Data.Migrations
{
    public partial class RemoveMeaningColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meaning",
                table: "Words");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Meaning",
                table: "Words",
                nullable: false,
                defaultValue: "");
        }
    }
}
