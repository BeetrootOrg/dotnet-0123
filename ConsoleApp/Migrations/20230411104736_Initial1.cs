using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    genre_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    isbn = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_books_tbl_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "tbl_authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_books_tbl_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "tbl_genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    direction = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_history", x => x.id);
                    table.CheckConstraint("direction", "direction IN ('IN', 'OUT')");
                    table.ForeignKey(
                        name: "FK_tbl_history_tbl_books_book_id",
                        column: x => x.book_id,
                        principalTable: "tbl_books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_history_tbl_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "tbl_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_books_author_id",
                table: "tbl_books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_books_genre_id",
                table: "tbl_books",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_history_book_id",
                table: "tbl_history",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_history_customer_id",
                table: "tbl_history",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_history");

            migrationBuilder.DropTable(
                name: "tbl_books");

            migrationBuilder.DropTable(
                name: "tbl_customers");

            migrationBuilder.DropTable(
                name: "tbl_authors");

            migrationBuilder.DropTable(
                name: "tbl_genres");
        }
    }
}
