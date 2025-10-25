using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddAmountbeforetaxfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "money",
                table: "invoice_detail",
                newName: "amount_before_tax");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_before_tax",
                table: "invoice_detail",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount_before_tax",
                table: "invoice_detail",
                newName: "money");

            migrationBuilder.AlterColumn<double>(
                name: "money",
                table: "invoice_detail",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
