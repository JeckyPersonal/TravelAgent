using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Migrations
{
    /// <inheritdoc />
    public partial class AddcolumntypeifEntityConfigurationTypeforRateSettingclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "vahicle_rate_configuration",
                newName: "configuration_type");

            migrationBuilder.AlterColumn<string>(
                name: "configuration_type",
                table: "vahicle_rate_configuration",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "configuration_type",
                table: "vahicle_rate_configuration",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "vahicle_rate_configuration",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)");
        }
    }
}
