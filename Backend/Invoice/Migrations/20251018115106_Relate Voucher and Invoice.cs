using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class RelateVoucherandInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_company_CompanyId",
                table: "Banks");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Banks",
            //    table: "Banks");

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

            migrationBuilder.AddColumn<int>(
                name: "invoice_id",
                table: "voucher_master",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bank_name",
                table: "bank",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_bank",
            //    table: "bank",
            //    column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_master_invoice_id",
                table: "voucher_master",
                column: "invoice_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BANK_COMPANY",
                table: "bank",
                column: "company_id",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VOUCHER_INVOICE",
                table: "voucher_master",
                column: "invoice_id",
                principalTable: "invoice",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BANK_COMPANY",
                table: "bank");

            migrationBuilder.DropForeignKey(
                name: "FK_VOUCHER_INVOICE",
                table: "voucher_master");

            migrationBuilder.DropIndex(
                name: "IX_voucher_master_invoice_id",
                table: "voucher_master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bank",
                table: "bank");

            migrationBuilder.DropColumn(
                name: "invoice_id",
                table: "voucher_master");

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

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_company_CompanyId",
                table: "Banks",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
