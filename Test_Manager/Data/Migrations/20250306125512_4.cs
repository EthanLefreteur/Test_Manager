using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultatCampagneId",
                table: "resultatTests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResultatCampagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    campagneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatCampagne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultatCampagne_BaseTest_campagneId",
                        column: x => x.campagneId,
                        principalTable: "BaseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_resultatTests_ResultatCampagneId",
                table: "resultatTests",
                column: "ResultatCampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatCampagne_campagneId",
                table: "ResultatCampagne",
                column: "campagneId");

            migrationBuilder.AddForeignKey(
                name: "FK_resultatTests_ResultatCampagne_ResultatCampagneId",
                table: "resultatTests",
                column: "ResultatCampagneId",
                principalTable: "ResultatCampagne",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resultatTests_ResultatCampagne_ResultatCampagneId",
                table: "resultatTests");

            migrationBuilder.DropTable(
                name: "ResultatCampagne");

            migrationBuilder.DropIndex(
                name: "IX_resultatTests_ResultatCampagneId",
                table: "resultatTests");

            migrationBuilder.DropColumn(
                name: "ResultatCampagneId",
                table: "resultatTests");
        }
    }
}
