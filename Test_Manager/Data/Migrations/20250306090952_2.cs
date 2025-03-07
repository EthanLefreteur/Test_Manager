using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "entrepriseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GestionnaireId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseTest_AspNetUsers_GestionnaireId",
                        column: x => x.GestionnaireId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "entreprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entreprises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "candidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseTestId = table.Column<int>(type: "int", nullable: true),
                    GestionnaireId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_candidats_AspNetUsers_GestionnaireId",
                        column: x => x.GestionnaireId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidats_BaseTest_BaseTestId",
                        column: x => x.BaseTestId,
                        principalTable: "BaseTest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_entrepriseId",
                table: "AspNetUsers",
                column: "entrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseTest_GestionnaireId",
                table: "BaseTest",
                column: "GestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_candidats_BaseTestId",
                table: "candidats",
                column: "BaseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_candidats_GestionnaireId",
                table: "candidats",
                column: "GestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_entreprises_entrepriseId",
                table: "AspNetUsers",
                column: "entrepriseId",
                principalTable: "entreprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_entreprises_entrepriseId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "candidats");

            migrationBuilder.DropTable(
                name: "entreprises");

            migrationBuilder.DropTable(
                name: "BaseTest");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_entrepriseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "entrepriseId",
                table: "AspNetUsers");
        }
    }
}
