using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddPublication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    PublicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Publisher = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.PublicationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "PublicationId", "AvailableCopies", "PublishedDate", "Publisher", "Title", "TotalCopies", "Type" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Geographic", "National Geographic", 10, 2 },
                    { 2, 6, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forbes", "Forbes", 6, 2 },
                    { 3, 15, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hindu", "The Hindu", 15, 1 },
                    { 4, 12, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOI", "Times of India", 12, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");
        }
    }
}
