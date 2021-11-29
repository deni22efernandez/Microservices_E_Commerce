using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Product 1 description...", "Product 1", 538.0, 93 },
                    { 2, "Product 2 description...", "Product 2", 871.0, 2 },
                    { 3, "Product 3 description...", "Product 3", 834.0, 39 },
                    { 4, "Product 4 description...", "Product 4", 869.0, 30 },
                    { 5, "Product 5 description...", "Product 5", 290.0, 14 },
                    { 6, "Product 6 description...", "Product 6", 957.0, 12 },
                    { 7, "Product 7 description...", "Product 7", 470.0, 39 },
                    { 8, "Product 8 description...", "Product 8", 262.0, 99 },
                    { 9, "Product 9 description...", "Product 9", 740.0, 84 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                schema: "Catalog",
                table: "Products",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
