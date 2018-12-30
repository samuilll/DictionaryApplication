namespace EnglishDictApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Meaning",
                table: "Words",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Meaning",
                table: "Words",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
