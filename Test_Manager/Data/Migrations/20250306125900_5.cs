using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultatCampagne_BaseTest_campagneId",
                table: "ResultatCampagne");

            migrationBuilder.DropForeignKey(
                name: "FK_resultatTests_ResultatCampagne_ResultatCampagneId",
                table: "resultatTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultatCampagne",
                table: "ResultatCampagne");

            migrationBuilder.RenameTable(
                name: "ResultatCampagne",
                newName: "resultatCampagnes");

            migrationBuilder.RenameIndex(
                name: "IX_ResultatCampagne_campagneId",
                table: "resultatCampagnes",
                newName: "IX_resultatCampagnes_campagneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_resultatCampagnes",
                table: "resultatCampagnes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_resultatCampagnes_BaseTest_campagneId",
                table: "resultatCampagnes",
                column: "campagneId",
                principalTable: "BaseTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_resultatTests_resultatCampagnes_ResultatCampagneId",
                table: "resultatTests",
                column: "ResultatCampagneId",
                principalTable: "resultatCampagnes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resultatCampagnes_BaseTest_campagneId",
                table: "resultatCampagnes");

            migrationBuilder.DropForeignKey(
                name: "FK_resultatTests_resultatCampagnes_ResultatCampagneId",
                table: "resultatTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_resultatCampagnes",
                table: "resultatCampagnes");

            migrationBuilder.RenameTable(
                name: "resultatCampagnes",
                newName: "ResultatCampagne");

            migrationBuilder.RenameIndex(
                name: "IX_resultatCampagnes_campagneId",
                table: "ResultatCampagne",
                newName: "IX_ResultatCampagne_campagneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultatCampagne",
                table: "ResultatCampagne",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultatCampagne_BaseTest_campagneId",
                table: "ResultatCampagne",
                column: "campagneId",
                principalTable: "BaseTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_resultatTests_ResultatCampagne_ResultatCampagneId",
                table: "resultatTests",
                column: "ResultatCampagneId",
                principalTable: "ResultatCampagne",
                principalColumn: "Id");
        }
    }
}
