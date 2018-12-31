namespace EnglishDictApp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SentencesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exams_ExamId",
                table: "Words");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exams_ExamId1",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_ExamId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_ExamId1",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ExamId1",
                table: "Words");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnswerRight",
                table: "Statistic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SentencesWords",
                columns: table => new
                {
                    WordId = table.Column<int>(nullable: false),
                    SentenceId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentencesWords", x => new { x.SentenceId, x.WordId });
                    table.ForeignKey(
                        name: "FK_SentencesWords_Sentences_SentenceId",
                        column: x => x.SentenceId,
                        principalTable: "Sentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SentencesWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sentences_IsDeleted",
                table: "Sentences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SentencesWords_IsDeleted",
                table: "SentencesWords",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SentencesWords_WordId",
                table: "SentencesWords",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentencesWords");

            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropColumn(
                name: "IsAnswerRight",
                table: "Statistic");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Words",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamId1",
                table: "Words",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_ExamId",
                table: "Words",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ExamId1",
                table: "Words",
                column: "ExamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Exams_ExamId",
                table: "Words",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Exams_ExamId1",
                table: "Words",
                column: "ExamId1",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
