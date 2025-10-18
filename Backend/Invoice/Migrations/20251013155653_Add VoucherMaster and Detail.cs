using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddVoucherMasterandDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BANK_COMPANY",
                table: "bank");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_bank",
            //    table: "bank");

            migrationBuilder.RenameTable(
                name: "bank",
                newName: "Banks");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "Banks",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "bank_name",
                table: "Banks",
                newName: "BankName");

            migrationBuilder.RenameIndex(
                name: "IX_bank_company_id",
                table: "Banks",
                newName: "IX_Banks_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "vahicle_rate_configuration",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Banks",
            //    table: "Banks",
            //    column: "Id");

            migrationBuilder.CreateTable(
                name: "voucher_master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucher_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    from_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pickup_location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drop_location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    registration_id = table.Column<int>(type: "int", nullable: true),
                    financial_year_id = table.Column<int>(type: "int", nullable: false),
                    driver_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher_master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VOUCHER_CUSTOMER",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VOUCHER_DRIVER",
                        column: x => x.driver_id,
                        principalTable: "driver",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VOUCHER_FINANCIAL_YEAR_ID",
                        column: x => x.financial_year_id,
                        principalTable: "financial_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VOUCHER_REGISTRATION",
                        column: x => x.registration_id,
                        principalTable: "vehicle_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VOUCHER_VEHICLE",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "voucher_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    voucher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VOUCHER_DETAIL_ITEM",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VOUCHER_DETAIL_VOUCHER_MASTER",
                        column: x => x.voucher_id,
                        principalTable: "voucher_master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_voucher_detail_item_id",
                table: "voucher_detail",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_detail_voucher_id",
                table: "voucher_detail",
                column: "voucher_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_master_customer_id",
                table: "voucher_master",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_master_driver_id",
                table: "voucher_master",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_master_financial_year_id",
                table: "voucher_master",
                column: "financial_year_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_master_registration_id",
                table: "voucher_master",
                column: "registration_id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_master_vehicle_id",
                table: "voucher_master",
                column: "vehicle_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_company_CompanyId",
                table: "Banks",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_company_CompanyId",
                table: "Banks");

            migrationBuilder.DropTable(
                name: "voucher_detail");

            migrationBuilder.DropTable(
                name: "voucher_master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "bank");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "bank",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "bank",
                newName: "bank_name");

            migrationBuilder.RenameIndex(
                name: "IX_Banks_CompanyId",
                table: "bank",
                newName: "IX_bank_company_id");

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "vahicle_rate_configuration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bank_name",
                table: "bank",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bank",
                table: "bank",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BANK_COMPANY",
                table: "bank",
                column: "company_id",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
