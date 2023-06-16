using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CursistenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursusen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duur = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursusen", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cursusen",
                columns: new[] { "Id", "Code", "Duur", "Titel" },
                values: new object[,]
                {
                    { 1, "PROC#", 4, "Programming C#" },
                    { 2, "PROC++", 2, "Programming C++" },
                    { 3, "PROCPython", 5, "Programming Python" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursusen");
        }
    }
}
