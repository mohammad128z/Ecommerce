using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationPreInvoiceHeaderAndDetailPreInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesLineInSeller",
                table: "SalesLineInSeller");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SalesLineInSeller",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PreInvoiceHeaderId",
                table: "DetailPreInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesLineInSeller",
                table: "SalesLineInSeller",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLineInSeller_SalesLineId",
                table: "SalesLineInSeller",
                column: "SalesLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPreInvoice_PreInvoiceHeaderId",
                table: "DetailPreInvoice",
                column: "PreInvoiceHeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailPreInvoice_PreInvoiceHeader_PreInvoiceHeaderId",
                table: "DetailPreInvoice",
                column: "PreInvoiceHeaderId",
                principalTable: "PreInvoiceHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailPreInvoice_PreInvoiceHeader_PreInvoiceHeaderId",
                table: "DetailPreInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesLineInSeller",
                table: "SalesLineInSeller");

            migrationBuilder.DropIndex(
                name: "IX_SalesLineInSeller_SalesLineId",
                table: "SalesLineInSeller");

            migrationBuilder.DropIndex(
                name: "IX_DetailPreInvoice_PreInvoiceHeaderId",
                table: "DetailPreInvoice");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SalesLineInSeller");

            migrationBuilder.DropColumn(
                name: "PreInvoiceHeaderId",
                table: "DetailPreInvoice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesLineInSeller",
                table: "SalesLineInSeller",
                columns: new[] { "SalesLineId", "SellerId" });
        }
    }
}
