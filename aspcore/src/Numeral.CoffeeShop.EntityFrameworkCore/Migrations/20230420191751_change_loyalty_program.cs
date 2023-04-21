using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Numeral.CoffeeShop.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class change_loyalty_program : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoyaltyProgramId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "MinimumPointsToRedeem",
                table: "LoyaltyPrograms");

            migrationBuilder.AddColumn<string>(
                name: "ProgramName",
                table: "Rewards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramName",
                table: "Rewards");

            migrationBuilder.AddColumn<Guid>(
                name: "LoyaltyProgramId",
                table: "Rewards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MinimumPointsToRedeem",
                table: "LoyaltyPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
