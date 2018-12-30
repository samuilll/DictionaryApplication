namespace EnglishDictApp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamStats");

            migrationBuilder.CreateTable(
                name: "Statistic",
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
                    table.PrimaryKey("PK_Statistic", x => new { x.UserId, x.WordId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_Statistic_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistic_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_ExamId",
                table: "Statistic",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_IsDeleted",
                table: "Statistic",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_WordId",
                table: "Statistic",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.CreateTable(
                name: "ExamStats",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    WordId = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
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
        }
    }
}
