using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment_received",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receive_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    payment_amount = table.Column<decimal>(type: "money", nullable: false),
                    tds = table.Column<decimal>(type: "money", nullable: false),
                    c_gst = table.Column<decimal>(type: "money", nullable: false),
                    s_gst = table.Column<decimal>(type: "money", nullable: false),
                    i_gst = table.Column<decimal>(type: "money", nullable: false),
                    receive_amount = table.Column<decimal>(type: "money", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_received", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INVOICE_PAYMENT",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_received_invoice_id",
                table: "payment_received",
                column: "invoice_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_received");
        }
    }
}
