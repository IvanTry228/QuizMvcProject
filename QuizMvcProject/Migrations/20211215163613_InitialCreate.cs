using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizMvcProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PddAllQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    questionText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PddAllQuestions", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PddAllAnswers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    answerText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    answerPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentQuestionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PddAllAnswers", x => x.id);
                    table.ForeignKey(
                        name: "FK_PddAllAnswers_PddAllQuestions_CurrentQuestionid",
                        column: x => x.CurrentQuestionid,
                        principalTable: "PddAllQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PddAllPictureables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    currentQuestionId = table.Column<int>(type: "int", nullable: false),
                    sourcePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PddAllPictureables", x => x.id);
                    table.ForeignKey(
                        name: "FK_PddAllPictureables_PddAllQuestions_currentQuestionId",
                        column: x => x.currentQuestionId,
                        principalTable: "PddAllQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PddAllAnswers_CurrentQuestionid",
                table: "PddAllAnswers",
                column: "CurrentQuestionid");

            migrationBuilder.CreateIndex(
                name: "IX_PddAllPictureables_currentQuestionId",
                table: "PddAllPictureables",
                column: "currentQuestionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PddAllAnswers");

            migrationBuilder.DropTable(
                name: "PddAllPictureables");

            migrationBuilder.DropTable(
                name: "PddAllQuestions");
        }
    }
}
