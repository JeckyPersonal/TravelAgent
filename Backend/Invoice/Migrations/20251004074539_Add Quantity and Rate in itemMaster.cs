using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityandRateinitemMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "item_quantity",
                table: "item",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "item_unit",
                table: "item",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "item_quantity",
                table: "item");

            migrationBuilder.DropColumn(
                name: "item_unit",
                table: "item");
        }
    }
}
