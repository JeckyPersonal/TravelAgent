using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class Addnewfieldworkdurationvisitorname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_INTERVAL",
                table: "item");

            migrationBuilder.AddColumn<string>(
                name: "billing_work_type",
                table: "voucher_master",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "end_from",
                table: "voucher_master",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "start_from",
                table: "voucher_master",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "visitor_name",
                table: "voucher_master",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "internal_id",
                table: "item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_INTERVAL",
                table: "item",
                column: "internal_id",
                principalTable: "item_interval",
                principalColumn: "id");

            migrationBuilder.Sql("UPDATE voucher_master SET billing_work_type = 'NONE' WHERE billing_work_type IS NULL");
            migrationBuilder.Sql("UPDATE voucher_master SET visitor_name = 'NONE' WHERE visitor_name IS NULL");
            migrationBuilder.Sql("UPDATE voucher_master SET end_from = '' WHERE end_from IS NULL");
            migrationBuilder.Sql("UPDATE voucher_master SET start_from = '' WHERE start_from IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_INTERVAL",
                table: "item");

            migrationBuilder.DropColumn(
                name: "billing_work_type",
                table: "voucher_master");

            migrationBuilder.DropColumn(
                name: "end_from",
                table: "voucher_master");

            migrationBuilder.DropColumn(
                name: "start_from",
                table: "voucher_master");

            migrationBuilder.DropColumn(
                name: "visitor_name",
                table: "voucher_master");

            migrationBuilder.AlterColumn<int>(
                name: "internal_id",
                table: "item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_INTERVAL",
                table: "item",
                column: "internal_id",
                principalTable: "item_interval",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
