using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountnumberininvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bank_detail_id",
                table: "invoice",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_bank_detail_id",
                table: "invoice",
                column: "bank_detail_id");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_BANK_DETAIL_ID",
                table: "invoice",
                column: "bank_detail_id",
                principalTable: "bank_detail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_BANK_DETAIL_ID",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_invoice_bank_detail_id",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "bank_detail_id",
                table: "invoice");
        }
    }
}
