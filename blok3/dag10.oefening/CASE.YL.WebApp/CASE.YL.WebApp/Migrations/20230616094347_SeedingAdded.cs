using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Custisten",
                columns: new[] { "Id", "Achternaam", "Voornaam" },
                values: new object[,]
                {
                    { 1, "Jan", "Gert" },
                    { 2, "Bogard", "Pieter" },
                    { 3, "Zuid", "Kelly" }
                });

            migrationBuilder.InsertData(
                table: "Cursusinstanties",
                columns: new[] { "CursistId", "CususId", "Staartdatum" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cursusinstanties",
                keyColumns: new[] { "CursistId", "CususId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Cursusinstanties",
                keyColumns: new[] { "CursistId", "CususId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Cursusinstanties",
                keyColumns: new[] { "CursistId", "CususId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Custisten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Custisten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Custisten",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
