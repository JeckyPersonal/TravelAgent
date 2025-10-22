using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddtheAmountinInvoiceMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_CUSTOMER_ID",
                table: "invoice");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "invoice",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_CUSTOMER_ID",
                table: "invoice",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_CUSTOMER_ID",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "invoice");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_CUSTOMER_ID",
                table: "invoice",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
