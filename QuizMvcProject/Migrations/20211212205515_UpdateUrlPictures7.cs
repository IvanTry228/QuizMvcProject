using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizTemplateMvcDotnet6.Migrations
{
    public partial class UpdateUrlPictures7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PddAllPictureables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    currentQuestionId = table.Column<int>(type: "int", nullable: false),
                    sourcePath = table.Column<string>(type: "longtext", nullable: false)
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
                name: "IX_PddAllPictureables_currentQuestionId",
                table: "PddAllPictureables",
                column: "currentQuestionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PddAllPictureables");
        }
    }
}
