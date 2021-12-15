using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizTemplateMvcDotnet6.Migrations
{
    public partial class DowngradeMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                table: "PddAllAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "questionText",
                table: "PddAllQuestions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "sourcePath",
                table: "PddAllPictureables",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentQuestionid",
                table: "PddAllAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                table: "PddAllAnswers",
                column: "CurrentQuestionid",
                principalTable: "PddAllQuestions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                table: "PddAllAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "questionText",
                table: "PddAllQuestions",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "sourcePath",
                table: "PddAllPictureables",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentQuestionid",
                table: "PddAllAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                table: "PddAllAnswers",
                column: "CurrentQuestionid",
                principalTable: "PddAllQuestions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
