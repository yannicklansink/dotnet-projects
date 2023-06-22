using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CascadeOnDeleteWithCursus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursusinstanties_Custisten_CursistId",
                table: "Cursusinstanties");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursusinstanties_Custisten_CursistId",
                table: "Cursusinstanties",
                column: "CursistId",
                principalTable: "Custisten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursusinstanties_Custisten_CursistId",
                table: "Cursusinstanties");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursusinstanties_Custisten_CursistId",
                table: "Cursusinstanties",
                column: "CursistId",
                principalTable: "Custisten",
                principalColumn: "Id");
        }
    }
}
