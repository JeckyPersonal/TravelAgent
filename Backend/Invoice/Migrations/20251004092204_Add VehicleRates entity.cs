using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleRatesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vahicle_rate_configuration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vahicle_rate_configuration", x => x.id);
                    table.ForeignKey(
                        name: "FK_VEHICLE_RATES_ITEM_DETAIL",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEHICLE_RATES_VEHICLE_DETAIL",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vahicle_rate_configuration_item_id",
                table: "vahicle_rate_configuration",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_vahicle_rate_configuration_vehicle_id",
                table: "vahicle_rate_configuration",
                column: "vehicle_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vahicle_rate_configuration");
        }
    }
}
