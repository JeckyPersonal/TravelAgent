using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    address_1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    address_2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    address_3 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    gst_no = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    varchar = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    phone_no = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    city = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    state = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    zip = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BANK_COMPANY",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    address_1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    address_2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    address_3 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    state = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    zip = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    trip_rate = table.Column<double>(type: "float", nullable: false),
                    gst_no = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    varchar = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    cess_no = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    phone_no = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_COMPANY",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driver_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    driver_mobile = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    license_no = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.id);
                    table.ForeignKey(
                        name: "FK_DRIVER_COMPANY",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "financial_year",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    to_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_year", x => x.id);
                    table.ForeignKey(
                        name: "FK_FINANCIAL_YEAR_COMPANY",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    item_rate = table.Column<decimal>(type: "money", nullable: true),
                    bit = table.Column<bool>(type: "bit", nullable: true),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_ITEM_COMPANY",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "FK_VEHICLE_COMPANY",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bank_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_number = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    isfc_code = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    bank_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BANK_DETAIL_BANK",
                        column: x => x.bank_id,
                        principalTable: "bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registration_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    vehicle_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_VEHICLE_DETAIL_VEHICLE",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_no = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    invoice_date = table.Column<DateTime>(type: "date", nullable: false),
                    starting_KM = table.Column<int>(type: "int", nullable: true),
                    starting_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    state_code = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    sac_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    total = table.Column<decimal>(type: "money", nullable: true),
                    c_gst = table.Column<decimal>(type: "money", nullable: true),
                    s_gst = table.Column<decimal>(type: "money", nullable: true),
                    i_gst = table.Column<decimal>(type: "money", nullable: true),
                    financial_year_id = table.Column<int>(type: "int", nullable: false),
                    driver_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_detail_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_INVOICE_DRIVER",
                        column: x => x.vehicle_detail_id,
                        principalTable: "driver",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_INVOICE_FINANCIAL_YEAR",
                        column: x => x.financial_year_id,
                        principalTable: "financial_year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVOICE_VEHICLE_DETAIL",
                        column: x => x.vehicle_detail_id,
                        principalTable: "vehicle_detail",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "invoice_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<decimal>(type: "money", nullable: true, name:"rate"),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "money", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INVOICE_DETAIL_ITEM",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_detail_invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoice",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bank_company_id",
                table: "bank",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_bank_detail_bank_id",
                table: "bank_detail",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_company_id",
                table: "customer",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_driver_company_id",
                table: "driver",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_financial_year_company_id",
                table: "financial_year",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_financial_year_id",
                table: "invoice",
                column: "financial_year_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_vehicle_detail_id",
                table: "invoice",
                column: "vehicle_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_detail_InvoiceId",
                table: "invoice_detail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_detail_item_id",
                table: "invoice_detail",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_company_id",
                table: "item",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_company_id",
                table: "vehicle",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_detail_vehicle_id",
                table: "vehicle_detail",
                column: "vehicle_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bank_detail");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "invoice_detail");

            migrationBuilder.DropTable(
                name: "bank");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "financial_year");

            migrationBuilder.DropTable(
                name: "vehicle_detail");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
