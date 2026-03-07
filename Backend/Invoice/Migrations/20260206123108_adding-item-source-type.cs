using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class addingitemsourcetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "item_category",
                table: "item",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "item_des",
                table: "item",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "item_source",
                table: "item",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "item_category",
                table: "item");

            migrationBuilder.DropColumn(
                name: "item_des",
                table: "item");

            migrationBuilder.DropColumn(
                name: "item_source",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "po_no",
                table: "customer",
                newName: "PONumber");
        }
    }
}
