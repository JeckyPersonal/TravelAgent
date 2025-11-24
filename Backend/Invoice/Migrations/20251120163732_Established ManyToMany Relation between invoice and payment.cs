using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class EstablishedManyToManyRelationbetweeninvoiceandpayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_PAYMENT",
                table: "payment_received");

            migrationBuilder.DropIndex(
                name: "IX_payment_received_invoice_id",
                table: "payment_received");

            migrationBuilder.DropColumn(
                name: "invoice_id",
                table: "payment_received");

            migrationBuilder.CreateTable(
                name: "invoice_payment",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_payment", x => new { x.InvoiceId, x.PaymentId });
                    table.ForeignKey(
                        name: "FK_INVOICE_INVOICE_PAYMENT",
                        column: x => x.InvoiceId,
                        principalTable: "invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAYMENT_INVOICE_PAYMENT",
                        column: x => x.PaymentId,
                        principalTable: "payment_received",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_payment_PaymentId",
                table: "invoice_payment",
                column: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_payment");

            migrationBuilder.AddColumn<int>(
                name: "invoice_id",
                table: "payment_received",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_payment_received_invoice_id",
                table: "payment_received",
                column: "invoice_id");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_PAYMENT",
                table: "payment_received",
                column: "invoice_id",
                principalTable: "invoice",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
