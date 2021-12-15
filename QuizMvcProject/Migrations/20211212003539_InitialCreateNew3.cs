using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizTemplateMvcDotnet6.Migrations
{
    public partial class InitialCreateNew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizPdd_Answer_QuizPdd_Question_CurrentQuestionid",
                table: "QuizPdd_Answer");

            migrationBuilder.DropTable(
                name: "TestUserEntitySet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizPdd_Question",
                table: "QuizPdd_Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizPdd_Answer",
                table: "QuizPdd_Answer");

            migrationBuilder.RenameTable(
                name: "QuizPdd_Question",
                newName: "PddAllQuestions");

            migrationBuilder.RenameTable(
                name: "QuizPdd_Answer",
                newName: "PddAllAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_QuizPdd_Answer_CurrentQuestionid",
                table: "PddAllAnswers",
                newName: "IX_PddAllAnswers_CurrentQuestionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PddAllQuestions",
                table: "PddAllQuestions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PddAllAnswers",
                table: "PddAllAnswers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                table: "PddAllAnswers",
                column: "CurrentQuestionid",
                principalTable: "PddAllQuestions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                table: "PddAllAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PddAllQuestions",
                table: "PddAllQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PddAllAnswers",
                table: "PddAllAnswers");

            migrationBuilder.RenameTable(
                name: "PddAllQuestions",
                newName: "QuizPdd_Question");

            migrationBuilder.RenameTable(
                name: "PddAllAnswers",
                newName: "QuizPdd_Answer");

            migrationBuilder.RenameIndex(
                name: "IX_PddAllAnswers_CurrentQuestionid",
                table: "QuizPdd_Answer",
                newName: "IX_QuizPdd_Answer_CurrentQuestionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizPdd_Question",
                table: "QuizPdd_Question",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizPdd_Answer",
                table: "QuizPdd_Answer",
                column: "id");

            migrationBuilder.CreateTable(
                name: "TestUserEntitySet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUserEntitySet", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizPdd_Answer_QuizPdd_Question_CurrentQuestionid",
                table: "QuizPdd_Answer",
                column: "CurrentQuestionid",
                principalTable: "QuizPdd_Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
