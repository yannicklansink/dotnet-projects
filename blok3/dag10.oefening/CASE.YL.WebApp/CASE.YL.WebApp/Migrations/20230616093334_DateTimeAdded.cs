using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CASE.YL.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Staartdatum",
                table: "Cursusinstanties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Staartdatum",
                table: "Cursusinstanties");
        }
    }
}
