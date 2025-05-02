using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Warehouses__FromWarehouseID",
                table: "TransactionHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Warehouses__ToWarehouseID",
                table: "TransactionHistories");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistories__FromWarehouseID",
                table: "TransactionHistories");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistories__ToWarehouseID",
                table: "TransactionHistories");

            migrationBuilder.DropColumn(
                name: "_FromWarehouseID",
                table: "TransactionHistories");

            migrationBuilder.DropColumn(
                name: "_ToWarehouseID",
                table: "TransactionHistories");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistories_FromWarehouseId",
                table: "TransactionHistories",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistories_ToWarehouseId",
                table: "TransactionHistories",
                column: "ToWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Warehouses_FromWarehouseId",
                table: "TransactionHistories",
                column: "FromWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Warehouses_ToWarehouseId",
                table: "TransactionHistories",
                column: "ToWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Warehouses_FromWarehouseId",
                table: "TransactionHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Warehouses_ToWarehouseId",
                table: "TransactionHistories");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistories_FromWarehouseId",
                table: "TransactionHistories");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistories_ToWarehouseId",
                table: "TransactionHistories");

            migrationBuilder.AddColumn<int>(
                name: "_FromWarehouseID",
                table: "TransactionHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_ToWarehouseID",
                table: "TransactionHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistories__FromWarehouseID",
                table: "TransactionHistories",
                column: "_FromWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistories__ToWarehouseID",
                table: "TransactionHistories",
                column: "_ToWarehouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Warehouses__FromWarehouseID",
                table: "TransactionHistories",
                column: "_FromWarehouseID",
                principalTable: "Warehouses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Warehouses__ToWarehouseID",
                table: "TransactionHistories",
                column: "_ToWarehouseID",
                principalTable: "Warehouses",
                principalColumn: "ID");
        }
    }
}
