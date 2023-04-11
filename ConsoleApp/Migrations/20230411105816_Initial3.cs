using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_first_name_last_name",
                table: "tbl_customers",
                columns: new[] { "first_name", "last_name" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_books_title",
                table: "tbl_books",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_authors_first_name_last_name",
                table: "tbl_authors",
                columns: new[] { "first_name", "last_name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_customers_first_name_last_name",
                table: "tbl_customers");

            migrationBuilder.DropIndex(
                name: "IX_tbl_books_title",
                table: "tbl_books");

            migrationBuilder.DropIndex(
                name: "IX_tbl_authors_first_name_last_name",
                table: "tbl_authors");
        }
    }
}
