using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatetransactionhistoryrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionType_TransactionType_TransactionTypeID",
                table: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_TransactionType_TransactionTypeID",
                table: "TransactionType");

            migrationBuilder.DropColumn(
                name: "TransactionTypeID",
                table: "TransactionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeID",
                table: "TransactionType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionType_TransactionTypeID",
                table: "TransactionType",
                column: "TransactionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionType_TransactionType_TransactionTypeID",
                table: "TransactionType",
                column: "TransactionTypeID",
                principalTable: "TransactionType",
                principalColumn: "ID");
        }
    }
}
