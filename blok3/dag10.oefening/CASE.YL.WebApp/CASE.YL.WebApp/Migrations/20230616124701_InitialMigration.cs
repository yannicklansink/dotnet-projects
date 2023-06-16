using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursussen",
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
                    table.PrimaryKey("PK_Cursussen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Custisten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straatnaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huisnummer = table.Column<int>(type: "int", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rekeningnummer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custisten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursusinstanties",
                columns: table => new
                {
                    CursusId = table.Column<int>(type: "int", nullable: false),
                    CursistId = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursusinstanties", x => new { x.CursusId, x.CursistId });
                    table.ForeignKey(
                        name: "FK_Cursusinstanties_Cursussen_CursusId",
                        column: x => x.CursusId,
                        principalTable: "Cursussen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursusinstanties_Custisten_CursistId",
                        column: x => x.CursistId,
                        principalTable: "Custisten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursussen",
                columns: new[] { "Id", "Code", "Duur", "Titel" },
                values: new object[,]
                {
                    { 1, "PROC#", 4, "Programming C#" },
                    { 2, "PROC++", 2, "Programming C++" },
                    { 3, "PROCPython", 5, "Programming Python" }
                });

            migrationBuilder.InsertData(
                table: "Custisten",
                columns: new[] { "Id", "Achternaam", "Discriminator", "Huisnummer", "Postcode", "Rekeningnummer", "Straatnaam", "Voornaam", "Woonplaats" },
                values: new object[,]
                {
                    { 1, "Jan", "Particulier", 10, "7573BZ", "NL04ABNA4938384777", "Spoorstraat", "Gert", "Bloemendaal" },
                    { 2, "Bogard", "Particulier", null, null, null, null, "Pieter", null },
                    { 3, "Zuid", "Particulier", null, null, null, null, "Kelly", null }
                });

            migrationBuilder.InsertData(
                table: "Cursusinstanties",
                columns: new[] { "CursistId", "CursusId", "Startdatum" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.DropTable(
                name: "Cursussen");

            migrationBuilder.DropTable(
                name: "Custisten");
        }
    }
}
