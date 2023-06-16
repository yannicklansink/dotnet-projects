using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class NameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursusinstanties_Cursusen_CususId",
                table: "Cursusinstanties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursusen",
                table: "Cursusen");

            migrationBuilder.RenameTable(
                name: "Cursusen",
                newName: "Cursussen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursussen",
                table: "Cursussen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursusinstanties_Cursussen_CususId",
                table: "Cursusinstanties",
                column: "CususId",
                principalTable: "Cursussen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursusinstanties_Cursussen_CususId",
                table: "Cursusinstanties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursussen",
                table: "Cursussen");

            migrationBuilder.RenameTable(
                name: "Cursussen",
                newName: "Cursusen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursusen",
                table: "Cursusen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursusinstanties_Cursusen_CususId",
                table: "Cursusinstanties",
                column: "CususId",
                principalTable: "Cursusen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
