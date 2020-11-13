using Microsoft.EntityFrameworkCore.Migrations;

namespace QlySach.Migrations
{
    public partial class Sach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicYear = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "Kinh tế" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "Văn Học" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 3, "Chính trị" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Amount", "Author", "CategoryId", "Name", "PublicYear", "ShortContent" },
                values: new object[] { 2, 30, "Thomas Friedman", 1, "Thế Giới Phẳng", 2006, "Longtime no see" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Amount", "Author", "CategoryId", "Name", "PublicYear", "ShortContent" },
                values: new object[] { 1, 20, "Nguyễn Du", 2, "Truyện Kiều", 1696, "Longtime no see" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Amount", "Author", "CategoryId", "Name", "PublicYear", "ShortContent" },
                values: new object[] { 3, 10, "Aristotle", 3, "Chính trị Luận", 1995, "Longtime no see" });

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoryId",
                table: "books",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
