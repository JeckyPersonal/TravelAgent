using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class CreatetheItemIntervaltablewithdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "internal_id",
                table: "item",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "item_interval",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interval = table.Column<int>(type: "int", nullable: false),
                    interval_name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_interval", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_internal_id",
                table: "item",
                column: "internal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_INTERVAL",
                table: "item",
                column: "internal_id",
                principalTable: "item_interval",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            string[] columnNames = new string[] {"interval", "interval_name" };

            migrationBuilder.InsertData(table: "item_interval", columnNames, values: new object[] { 1, "Daily" }, null);
            migrationBuilder.InsertData(table: "item_interval", columnNames, values: new object[] { 30, "Monthly" }, null);
            migrationBuilder.InsertData(table: "item_interval", columnNames, values: new object[] { 7, "Weekly" }, null);
            migrationBuilder.InsertData(table: "item_interval", columnNames, values: new object[] { 365, "Yearly" }, null);
            migrationBuilder.InsertData(table: "item_interval", columnNames, values: new object[] { 0, "Extra" }, null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_INTERVAL",
                table: "item");

            migrationBuilder.DropTable(
                name: "item_interval");

            migrationBuilder.DropIndex(
                name: "IX_item_internal_id",
                table: "item");

            migrationBuilder.DropColumn(
                name: "internal_id",
                table: "item");

            migrationBuilder.Sql("DELETE FROM item_interval");
        }
    }
}
