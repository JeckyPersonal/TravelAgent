using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddFinancialyearreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "financial_year_id",
                table: "payment_received",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_payment_received_financial_year_id",
                table: "payment_received",
                column: "financial_year_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FINANCIAL_YEAR_PAYMENT",
                table: "payment_received",
                column: "financial_year_id",
                principalTable: "financial_year",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FINANCIAL_YEAR_PAYMENT",
                table: "payment_received");

            migrationBuilder.DropIndex(
                name: "IX_payment_received_financial_year_id",
                table: "payment_received");

            migrationBuilder.DropColumn(
                name: "financial_year_id",
                table: "payment_received");
        }
    }
}
