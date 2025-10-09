using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerinVehicleRateclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLE_RATES_ITEM_DETAIL",
                table: "vahicle_rate_configuration");

            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLE_RATES_VEHICLE_DETAIL",
                table: "vahicle_rate_configuration");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "vahicle_rate_configuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "vahicle_rate_configuration",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vahicle_rate_configuration_customer_id",
                table: "vahicle_rate_configuration",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_CUSTOER_RATE_DETAIL",
                table: "vahicle_rate_configuration",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_RATES_ITEM_DETAIL",
                table: "vahicle_rate_configuration",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_RATES_VEHICLE_DETAIL",
                table: "vahicle_rate_configuration",
                column: "vehicle_id",
                principalTable: "vehicle",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLE_CUSTOER_RATE_DETAIL",
                table: "vahicle_rate_configuration");

            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLE_RATES_ITEM_DETAIL",
                table: "vahicle_rate_configuration");

            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLE_RATES_VEHICLE_DETAIL",
                table: "vahicle_rate_configuration");

            migrationBuilder.DropIndex(
                name: "IX_vahicle_rate_configuration_customer_id",
                table: "vahicle_rate_configuration");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "vahicle_rate_configuration");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "vahicle_rate_configuration");

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_RATES_ITEM_DETAIL",
                table: "vahicle_rate_configuration",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_RATES_VEHICLE_DETAIL",
                table: "vahicle_rate_configuration",
                column: "vehicle_id",
                principalTable: "vehicle",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
