using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class tenderfulechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "item_desc",
                table: "voucher_detail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tender",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fix_rate = table.Column<double>(type: "float", nullable: false),
                    contract_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    diff_per = table.Column<double>(type: "float", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FinancialYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tender", x => x.id);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_TENDER",
                        column: x => x.CustomerID,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TENDER_FYEAR",
                        column: x => x.FinancialYearId,
                        principalTable: "financial_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fuel_rate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_Date = table.Column<DateTime>(type: "date", nullable: false),
                    to_Date = table.Column<DateTime>(type: "date", nullable: false),
                    prise = table.Column<double>(type: "float", nullable: false),
                    TenderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_rate", x => x.id);
                    table.ForeignKey(
                        name: "FK_TENDER_FUEL",
                        column: x => x.TenderID,
                        principalTable: "tender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fuel_rate_TenderID",
                table: "fuel_rate",
                column: "TenderID");

            migrationBuilder.CreateIndex(
                name: "IX_tender_CustomerID",
                table: "tender",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tender_FinancialYearId",
                table: "tender",
                column: "FinancialYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fuel_rate");

            migrationBuilder.DropTable(
                name: "tender");

            migrationBuilder.DropColumn(
                name: "item_desc",
                table: "voucher_detail");
        }
    }
}
