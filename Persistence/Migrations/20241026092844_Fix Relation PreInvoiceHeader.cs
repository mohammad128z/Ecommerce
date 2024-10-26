using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationPreInvoiceHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreInvoiceHeader_SalesLine_SalesLineId",
                table: "PreInvoiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PreInvoiceHeader_Seller_SellerId",
                table: "PreInvoiceHeader");

            migrationBuilder.DropIndex(
                name: "IX_PreInvoiceHeader_SalesLineId",
                table: "PreInvoiceHeader");

            migrationBuilder.DropIndex(
                name: "IX_PreInvoiceHeader_SellerId",
                table: "PreInvoiceHeader");

            migrationBuilder.DropColumn(
                name: "SalesLineId",
                table: "PreInvoiceHeader");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "PreInvoiceHeader");

            migrationBuilder.AddColumn<int>(
                name: "PreInvoiceHeaderId",
                table: "SalesLineInSeller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesLineInSeller_PreInvoiceHeaderId",
                table: "SalesLineInSeller",
                column: "PreInvoiceHeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesLineInSeller_PreInvoiceHeader_PreInvoiceHeaderId",
                table: "SalesLineInSeller",
                column: "PreInvoiceHeaderId",
                principalTable: "PreInvoiceHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesLineInSeller_PreInvoiceHeader_PreInvoiceHeaderId",
                table: "SalesLineInSeller");

            migrationBuilder.DropIndex(
                name: "IX_SalesLineInSeller_PreInvoiceHeaderId",
                table: "SalesLineInSeller");

            migrationBuilder.DropColumn(
                name: "PreInvoiceHeaderId",
                table: "SalesLineInSeller");

            migrationBuilder.AddColumn<int>(
                name: "SalesLineId",
                table: "PreInvoiceHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "PreInvoiceHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PreInvoiceHeader_SalesLineId",
                table: "PreInvoiceHeader",
                column: "SalesLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PreInvoiceHeader_SellerId",
                table: "PreInvoiceHeader",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreInvoiceHeader_SalesLine_SalesLineId",
                table: "PreInvoiceHeader",
                column: "SalesLineId",
                principalTable: "SalesLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreInvoiceHeader_Seller_SellerId",
                table: "PreInvoiceHeader",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
