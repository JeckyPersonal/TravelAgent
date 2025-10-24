using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class RelationbetweenVoucherDetailandinvoicedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invoice_detail_id",
                table: "voucher_detail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherDetailId",
                table: "invoice_detail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_voucher_detail_invoice_detail_id",
                table: "voucher_detail",
                column: "invoice_detail_id",
                unique: true,
                filter: "[invoice_detail_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_VOUCHER_DETAIL_INVOICE_DETAIL",
                table: "voucher_detail",
                column: "invoice_detail_id",
                principalTable: "invoice_detail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VOUCHER_DETAIL_INVOICE_DETAIL",
                table: "voucher_detail");

            migrationBuilder.DropIndex(
                name: "IX_voucher_detail_invoice_detail_id",
                table: "voucher_detail");

            migrationBuilder.DropColumn(
                name: "invoice_detail_id",
                table: "voucher_detail");

            migrationBuilder.DropColumn(
                name: "VoucherDetailId",
                table: "invoice_detail");
        }
    }
}
