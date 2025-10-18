using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class RelatetheInvoiceandInvoiceDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ////migrationBuilder.DropForeignKey(
            ////    name: "FK_invoice_detail_invoice_InvoiceId",
            ////    table: "invoice_detail");

            //migrationBuilder.AddColumn<int>(
            //    name: "invoice_id",
            //    table: "invoice_detail",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_INVOICE_INVOICE_DETAIL",
            //    table: "invoice_detail",
            //    column: "invoice_id",
            //    principalTable: "invoice",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_INVOICE_INVOICE_DETAIL",
            //    table: "invoice_detail");

            //migrationBuilder.DropColumn(
            //    name: "invoice_id",
            //    table: "invoice_detail");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoice_detail_invoice_InvoiceId",
            //    table: "invoice_detail",
            //    column: "invoice_id",
            //    principalTable: "invoice",
            //    principalColumn: "id");
        }
    }
}
