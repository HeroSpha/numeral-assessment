using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Numeral.CoffeeShop.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class cash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cash",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Customers");
        }
    }
}
