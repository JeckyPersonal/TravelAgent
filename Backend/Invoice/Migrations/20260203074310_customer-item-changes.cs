using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class customeritemchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "po_no",
                table: "customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "quantity",
                table: "voucher_detail",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "po_no",
                table: "customer",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            string[] columnNames = new string[] { "interval", "interval_name" };

            migrationBuilder.DeleteData(table: "item_interval", columnNames, keyValues: new object[] { 7, "Weekly" }, null);
            migrationBuilder.DeleteData(table: "item_interval", columnNames, keyValues: new object[] { 365, "Yearly" }, null);
            migrationBuilder.InsertData(table: "item_interval", columnNames, values: new object[] { 0, "Fixed" }, null);
            migrationBuilder.UpdateData(table: "item_interval", keyColumn: "id", keyValue: "2", columnNames, values: new object[] { 31, "Monthly" }, null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "po_no",
                table: "customer");

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "voucher_detail",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "po_no",
                table: "customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
