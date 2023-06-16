using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cursusinstanties",
                columns: new[] { "CursistId", "CursusId", "Startdatum" },
                values: new object[,]
                {
                    { 4, 2, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cursusinstanties",
                keyColumns: new[] { "CursistId", "CursusId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Cursusinstanties",
                keyColumns: new[] { "CursistId", "CursusId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Cursusinstanties",
                keyColumns: new[] { "CursistId", "CursusId" },
                keyValues: new object[] { 6, 2 });
        }
    }
}
