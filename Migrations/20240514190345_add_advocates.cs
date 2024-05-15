using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCorePlayground.Migrations
{
    /// <inheritdoc />
    public partial class add_advocates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advocates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Products = table.Column<string>(type: "TEXT", nullable: false),
                    Technologies = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advocates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Advocates",
                columns: new[] { "Id", "Name", "Products", "Technologies" },
                values: new object[,]
                {
                    { 1, "Maarten Balliauw", "[\"IntelliJ IDEA\",\"Rider\",\"ReSharper\"]", "[\".NET\",\"Java\"]" },
                    { 2, "Matthias Koch", "[\"ReSharper\",\"Rider\",\"Qodana\",\"Team City\"]", "[\".NET\",\"CI\"]" },
                    { 3, "Rachel Appel", "[\"ReSharper\",\"Rider\"]", "[\".NET\",\"JavaScript\"]" },
                    { 4, "Matt Ellis", "[\"Rider\",\"Gateway\"]", "[\".NET\",\"Unreal\",\"Unity\",\"Java\"]" },
                    { 5, "Khalid Abuhakmeh", "[\"Rider\",\"RustRover\"]", "[\".NET\",\"Rust\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advocates");
        }
    }
}
