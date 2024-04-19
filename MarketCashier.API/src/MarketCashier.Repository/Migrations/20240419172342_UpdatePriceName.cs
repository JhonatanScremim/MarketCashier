using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketCashier.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Product",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "Value");
        }
    }
}
