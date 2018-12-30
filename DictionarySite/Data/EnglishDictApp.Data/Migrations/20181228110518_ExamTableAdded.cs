namespace EnglishDictApp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ExamTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Words",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamId1",
                table: "Words",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordDifficulty",
                table: "Words",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    NumberOfQuestions = table.Column<int>(nullable: false),
                    RightAnswers = table.Column<int>(nullable: false),
                    Grade = table.Column<double>(nullable: false),
                    ExamDifficulty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamStats",
                columns: table => new
                {
                    WordId = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStats", x => new { x.UserId, x.WordId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamStats_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamStats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamStats_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_ExamId",
                table: "Words",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ExamId1",
                table: "Words",
                column: "ExamId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_IsDeleted",
                table: "Exam",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_UserId",
                table: "Exam",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStats_ExamId",
                table: "ExamStats",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStats_IsDeleted",
                table: "ExamStats",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStats_WordId",
                table: "ExamStats",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Exam_ExamId",
                table: "Words",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Exam_ExamId1",
                table: "Words",
                column: "ExamId1",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exam_ExamId",
                table: "Words");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exam_ExamId1",
                table: "Words");

            migrationBuilder.DropTable(
                name: "ExamStats");

            migrationBuilder.DropTable(
                name: "Exam");

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

            migrationBuilder.DropColumn(
                name: "WordDifficulty",
                table: "Words");
        }
    }
}
