using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnwantedcolumnfrominvoiceMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_DRIVER",
                table: "invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_VEHICLE_DETAIL",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "sac_code",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "state_code",
                table: "invoice");

            migrationBuilder.RenameIndex(
                name: "IX_invoice_detail_InvoiceId",
                table: "invoice_detail",
                newName: "IX_invoice_detail_invoice_id");

            migrationBuilder.RenameColumn(
                name: "vehicle_detail_id",
                table: "invoice",
                newName: "VehicleDetailId");

            migrationBuilder.RenameColumn(
                name: "driver_id",
                table: "invoice",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_invoice_vehicle_detail_id",
                table: "invoice",
                newName: "IX_invoice_VehicleDetailId");

            migrationBuilder.AddColumn<decimal>(
                name: "cgst",
                table: "invoice_detail",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "igst",
                table: "invoice_detail",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "money",
                table: "invoice_detail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "sgst",
                table: "invoice_detail",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_customer_id",
                table: "invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_DriverId",
                table: "invoice",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_CUSTOMER_ID",
                table: "invoice",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_driver_DriverId",
                table: "invoice",
                column: "DriverId",
                principalTable: "driver",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_vehicle_detail_VehicleDetailId",
                table: "invoice",
                column: "VehicleDetailId",
                principalTable: "vehicle_detail",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICE_CUSTOMER_ID",
                table: "invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_invoice_driver_DriverId",
                table: "invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_invoice_vehicle_detail_VehicleDetailId",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_invoice_customer_id",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_invoice_DriverId",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "cgst",
                table: "invoice_detail");

            migrationBuilder.DropColumn(
                name: "igst",
                table: "invoice_detail");

            migrationBuilder.DropColumn(
                name: "money",
                table: "invoice_detail");

            migrationBuilder.DropColumn(
                name: "sgst",
                table: "invoice_detail");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "invoice");

            migrationBuilder.RenameColumn(
                name: "invoice_id",
                table: "invoice_detail",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_invoice_detail_invoice_id",
                table: "invoice_detail",
                newName: "IX_invoice_detail_InvoiceId");

            migrationBuilder.RenameColumn(
                name: "VehicleDetailId",
                table: "invoice",
                newName: "vehicle_detail_id");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "invoice",
                newName: "driver_id");

            migrationBuilder.RenameIndex(
                name: "IX_invoice_VehicleDetailId",
                table: "invoice",
                newName: "IX_invoice_vehicle_detail_id");

            migrationBuilder.AlterColumn<int>(
                name: "driver_id",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sac_code",
                table: "invoice",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "state_code",
                table: "invoice",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_DRIVER",
                table: "invoice",
                column: "vehicle_detail_id",
                principalTable: "driver",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICE_VEHICLE_DETAIL",
                table: "invoice",
                column: "vehicle_detail_id",
                principalTable: "vehicle_detail",
                principalColumn: "id");
        }
    }
}
