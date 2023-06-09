using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dag8.oefening1.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "IsDone", "Title", "UitersteDatum" },
                values: new object[,]
                {
                    { 1, "Doe de afwas", false, "afwas", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 2, "Doe de afwas2", false, "afwas", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { 3, "Doe de afwas3", false, "afwas", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
