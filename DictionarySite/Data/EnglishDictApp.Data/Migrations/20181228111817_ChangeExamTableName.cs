namespace EnglishDictApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeExamTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_UserId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_Exam_ExamId",
                table: "Statistic");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exam_ExamId",
                table: "Words");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exam_ExamId1",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_UserId",
                table: "Exams",
                newName: "IX_Exams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_IsDeleted",
                table: "Exams",
                newName: "IX_Exams_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_UserId",
                table: "Exams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_Exams_ExamId",
                table: "Statistic",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_UserId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_Exams_ExamId",
                table: "Statistic");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exams_ExamId",
                table: "Words");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Exams_ExamId1",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_UserId",
                table: "Exam",
                newName: "IX_Exam_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_IsDeleted",
                table: "Exam",
                newName: "IX_Exam_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_UserId",
                table: "Exam",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_Exam_ExamId",
                table: "Statistic",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
