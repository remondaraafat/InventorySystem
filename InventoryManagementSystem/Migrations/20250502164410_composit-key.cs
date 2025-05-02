using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class compositkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductStocks_ProductId",
                table: "ProductStocks");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_ProductId_WarehouseId",
                table: "ProductStocks",
                columns: new[] { "ProductId", "WarehouseId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductStocks_ProductId_WarehouseId",
                table: "ProductStocks");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_ProductId",
                table: "ProductStocks",
                column: "ProductId");
        }
    }
}
