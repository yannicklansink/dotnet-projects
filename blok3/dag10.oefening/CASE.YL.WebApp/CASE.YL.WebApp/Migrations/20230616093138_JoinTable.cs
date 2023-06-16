using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class JoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursusinstanties",
                columns: table => new
                {
                    CususId = table.Column<int>(type: "int", nullable: false),
                    CursistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursusinstanties", x => new { x.CususId, x.CursistId });
                    table.ForeignKey(
                        name: "FK_Cursusinstanties_Cursusen_CususId",
                        column: x => x.CususId,
                        principalTable: "Cursusen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursusinstanties_Custisten_CursistId",
                        column: x => x.CursistId,
                        principalTable: "Custisten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursusinstanties_CursistId",
                table: "Cursusinstanties",
                column: "CursistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursusinstanties");
        }
    }
}
