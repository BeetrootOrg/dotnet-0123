using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    money = table.Column<decimal>(type: "money", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_orders_tbl_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "tbl_customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_orders_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_orders_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_orders_products_tbl_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "tbl_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_orders_products_tbl_products_product_id",
                        column: x => x.product_id,
                        principalTable: "tbl_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_email",
                table: "tbl_customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_last_name_first_name",
                table: "tbl_customers",
                columns: new[] { "last_name", "first_name" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_orders_customer_id",
                table: "tbl_orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_orders_products_order_id",
                table: "tbl_orders_products",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_orders_products_product_id",
                table: "tbl_orders_products",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_orders_products");

            migrationBuilder.DropTable(
                name: "tbl_orders");

            migrationBuilder.DropTable(
                name: "tbl_products");

            migrationBuilder.DropTable(
                name: "tbl_customers");
        }
    }
}
