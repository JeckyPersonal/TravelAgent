using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class itemsourcechagnes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "item_source",
                table: "item");

            migrationBuilder.AddColumn<bool>(
                name: "src_invoice",
                table: "item",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "src_system",
                table: "item",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "src_voucher",
                table: "item",
                type: "bit",
                nullable: true);

            migrationBuilder.Sql(@"
                    BEGIN TRANSACTION;

                    UPDATE item SET src_voucher=1,src_invoice=0,src_system=0;

                    COMMIT TRANSACTION;
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "src_invoice",
                table: "item");

            migrationBuilder.DropColumn(
                name: "src_system",
                table: "item");

            migrationBuilder.DropColumn(
                name: "src_voucher",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "item_category",
                table: "item",
                newName: "item_catogery");

            migrationBuilder.AddColumn<string>(
                name: "item_source",
                table: "item",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
