using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailPreInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPreInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailPreInvoice_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesLineInProduct",
                columns: table => new
                {
                    SalesLineId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLineInProduct", x => new { x.SalesLineId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SalesLineInProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesLineInProduct_SalesLine_SalesLineId",
                        column: x => x.SalesLineId,
                        principalTable: "SalesLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreInvoiceHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    SalesLineId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreInvoiceHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreInvoiceHeader_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreInvoiceHeader_SalesLine_SalesLineId",
                        column: x => x.SalesLineId,
                        principalTable: "SalesLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreInvoiceHeader_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesLineInSeller",
                columns: table => new
                {
                    SalesLineId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLineInSeller", x => new { x.SalesLineId, x.SellerId });
                    table.ForeignKey(
                        name: "FK_SalesLineInSeller_SalesLine_SalesLineId",
                        column: x => x.SalesLineId,
                        principalTable: "SalesLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesLineInSeller_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailPreInvoiceId = table.Column<int>(type: "int", nullable: true),
                    PreInvoiceHeaderId = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_DetailPreInvoice_DetailPreInvoiceId",
                        column: x => x.DetailPreInvoiceId,
                        principalTable: "DetailPreInvoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discount_PreInvoiceHeader_PreInvoiceHeaderId",
                        column: x => x.PreInvoiceHeaderId,
                        principalTable: "PreInvoiceHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailPreInvoice_ProductId",
                table: "DetailPreInvoice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_DetailPreInvoiceId",
                table: "Discount",
                column: "DetailPreInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_PreInvoiceHeaderId",
                table: "Discount",
                column: "PreInvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PreInvoiceHeader_CustomerId",
                table: "PreInvoiceHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PreInvoiceHeader_SalesLineId",
                table: "PreInvoiceHeader",
                column: "SalesLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PreInvoiceHeader_SellerId",
                table: "PreInvoiceHeader",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLineInProduct_ProductId",
                table: "SalesLineInProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLineInSeller_SellerId",
                table: "SalesLineInSeller",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "SalesLineInProduct");

            migrationBuilder.DropTable(
                name: "SalesLineInSeller");

            migrationBuilder.DropTable(
                name: "DetailPreInvoice");

            migrationBuilder.DropTable(
                name: "PreInvoiceHeader");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SalesLine");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
