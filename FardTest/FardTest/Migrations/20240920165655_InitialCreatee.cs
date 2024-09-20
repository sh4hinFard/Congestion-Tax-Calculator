using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FardTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxRules",
                columns: new[] { "Id", "Amount", "City", "EndTime", "StartTime", "Year" },
                values: new object[,]
                {
                    { 1, 8, "Gothenburg", new TimeSpan(0, 6, 29, 59, 0), new TimeSpan(0, 6, 0, 0, 0), 2013 },
                    { 2, 13, "Gothenburg", new TimeSpan(0, 6, 59, 59, 0), new TimeSpan(0, 6, 30, 0, 0), 2013 },
                    { 3, 18, "Gothenburg", new TimeSpan(0, 7, 59, 59, 0), new TimeSpan(0, 7, 0, 0, 0), 2013 },
                    { 4, 13, "Gothenburg", new TimeSpan(0, 8, 29, 59, 0), new TimeSpan(0, 8, 0, 0, 0), 2013 },
                    { 5, 8, "Gothenburg", new TimeSpan(0, 14, 59, 59, 0), new TimeSpan(0, 8, 30, 0, 0), 2013 },
                    { 6, 13, "Gothenburg", new TimeSpan(0, 15, 29, 59, 0), new TimeSpan(0, 15, 0, 0, 0), 2013 },
                    { 7, 18, "Gothenburg", new TimeSpan(0, 16, 59, 59, 0), new TimeSpan(0, 15, 30, 0, 0), 2013 },
                    { 8, 13, "Gothenburg", new TimeSpan(0, 17, 59, 59, 0), new TimeSpan(0, 17, 0, 0, 0), 2013 },
                    { 9, 8, "Gothenburg", new TimeSpan(0, 18, 29, 59, 0), new TimeSpan(0, 18, 0, 0, 0), 2013 },
                    { 10, 0, "Gothenburg", new TimeSpan(0, 5, 59, 59, 0), new TimeSpan(0, 18, 30, 0, 0), 2013 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRules");
        }
    }
}
