using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Custistentypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursusinstanties_Custisten_CursistId",
                table: "Cursusinstanties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Custisten",
                table: "Custisten");

            migrationBuilder.RenameTable(
                name: "Custisten",
                newName: "Cursisten");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursisten",
                table: "Cursisten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursusinstanties_Cursisten_CursistId",
                table: "Cursusinstanties",
                column: "CursistId",
                principalTable: "Cursisten",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursusinstanties_Cursisten_CursistId",
                table: "Cursusinstanties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursisten",
                table: "Cursisten");

            migrationBuilder.RenameTable(
                name: "Cursisten",
                newName: "Custisten");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Custisten",
                table: "Custisten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursusinstanties_Custisten_CursistId",
                table: "Cursusinstanties",
                column: "CursistId",
                principalTable: "Custisten",
                principalColumn: "Id");
        }
    }
}
