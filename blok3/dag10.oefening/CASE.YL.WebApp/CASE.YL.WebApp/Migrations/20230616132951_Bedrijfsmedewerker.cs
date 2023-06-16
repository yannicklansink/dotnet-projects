using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Bedrijfsmedewerker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Afdeling",
                table: "Custisten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bedrijfsnaam",
                table: "Custisten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Offertenummer",
                table: "Custisten",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Custisten",
                columns: new[] { "Id", "Achternaam", "Afdeling", "Bedrijfsnaam", "Discriminator", "Offertenummer", "Voornaam" },
                values: new object[,]
                {
                    { 4, "Stevens", "Inkoop", "Amazon", "Bedrijfsmedewerker", 12345678, "Gerard" },
                    { 5, "Kentelier", "Goudsmith", "Juwelier Vreriks", "Bedrijfsmedewerker", 48375198, "Josoef" },
                    { 6, "Truida", "Inkoop", "Apple", "Bedrijfsmedewerker", 47293343, "Samuel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Custisten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Custisten",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Custisten",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Afdeling",
                table: "Custisten");

            migrationBuilder.DropColumn(
                name: "Bedrijfsnaam",
                table: "Custisten");

            migrationBuilder.DropColumn(
                name: "Offertenummer",
                table: "Custisten");
        }
    }
}
