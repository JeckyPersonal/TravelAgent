using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddTax_categoryinvoice_formatincustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "invoice_format",
                table: "customer",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tax_category",
                table: "customer",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invoice_format",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "tax_category",
                table: "customer");
        }
    }
}
