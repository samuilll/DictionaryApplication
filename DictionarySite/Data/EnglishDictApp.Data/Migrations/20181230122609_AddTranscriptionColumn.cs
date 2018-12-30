using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishDictApp.Data.Migrations
{
    public partial class AddTranscriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToDelete",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "WordTitleToDelete",
                table: "Sentences");

            migrationBuilder.AddColumn<string>(
                name: "Transcription",
                table: "Words",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transcription",
                table: "Words");

            migrationBuilder.AddColumn<string>(
                name: "ToDelete",
                table: "Words",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WordTitleToDelete",
                table: "Sentences",
                nullable: true);
        }
    }
}
