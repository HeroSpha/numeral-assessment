using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Numeral.CoffeeShop.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class loyalty_programs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,0)",
                precision: 18,
                scale: 0,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "LoyaltyPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PointConversionRate = table.Column<int>(type: "int", nullable: false),
                    MinimumPointsToRedeem = table.Column<int>(type: "int", nullable: false),
                    PointRedemptionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyPrograms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoyaltyPrograms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");
        }
    }
}
