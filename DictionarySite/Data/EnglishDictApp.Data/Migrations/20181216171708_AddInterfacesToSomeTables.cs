namespace EnglishDictApp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddInterfacesToSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Words",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Words",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Words",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Words",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UsersWords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UsersWords",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersWords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UsersWords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_IsDeleted",
                table: "Words",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UsersWords_IsDeleted",
                table: "UsersWords",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_IsDeleted",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_UsersWords_IsDeleted",
                table: "UsersWords");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UsersWords");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UsersWords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersWords");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UsersWords");
        }
    }
}
