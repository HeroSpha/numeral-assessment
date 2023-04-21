using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Numeral.CoffeeShop.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class updated_rewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Rewards");

            migrationBuilder.AddColumn<decimal>(
                name: "CashValue",
                table: "Rewards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "Rewards",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "PointConversionRate",
                table: "LoyaltyPrograms",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashValue",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Rewards");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PointConversionRate",
                table: "LoyaltyPrograms",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
