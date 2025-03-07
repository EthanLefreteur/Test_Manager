using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampagneId",
                table: "BaseTest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseTest",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BaseQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    reponse_possibles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reponse_correctes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reponse_correcte = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseQuestion_BaseTest_testId",
                        column: x => x.testId,
                        principalTable: "BaseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resultatTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testId = table.Column<int>(type: "int", nullable: false),
                    candidatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultatTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resultatTests_BaseTest_testId",
                        column: x => x.testId,
                        principalTable: "BaseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resultatTests_candidats_candidatId",
                        column: x => x.candidatId,
                        principalTable: "candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseReponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    ResultatTestId = table.Column<int>(type: "int", nullable: true),
                    reponse_candidat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReponseQCM_reponse_candidat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReponseRedaction_reponse_candidat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseReponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseReponse_BaseQuestion_questionId",
                        column: x => x.questionId,
                        principalTable: "BaseQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseReponse_resultatTests_ResultatTestId",
                        column: x => x.ResultatTestId,
                        principalTable: "resultatTests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseTest_CampagneId",
                table: "BaseTest",
                column: "CampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseQuestion_testId",
                table: "BaseQuestion",
                column: "testId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseReponse_questionId",
                table: "BaseReponse",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseReponse_ResultatTestId",
                table: "BaseReponse",
                column: "ResultatTestId");

            migrationBuilder.CreateIndex(
                name: "IX_resultatTests_candidatId",
                table: "resultatTests",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_resultatTests_testId",
                table: "resultatTests",
                column: "testId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseTest_BaseTest_CampagneId",
                table: "BaseTest",
                column: "CampagneId",
                principalTable: "BaseTest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseTest_BaseTest_CampagneId",
                table: "BaseTest");

            migrationBuilder.DropTable(
                name: "BaseReponse");

            migrationBuilder.DropTable(
                name: "BaseQuestion");

            migrationBuilder.DropTable(
                name: "resultatTests");

            migrationBuilder.DropIndex(
                name: "IX_BaseTest_CampagneId",
                table: "BaseTest");

            migrationBuilder.DropColumn(
                name: "CampagneId",
                table: "BaseTest");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseTest");
        }
    }
}
