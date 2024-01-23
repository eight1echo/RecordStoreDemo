using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStoreDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RewardsCardTransactionsContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RewardsTransaction_RewardsCards_RewardsCardId",
                table: "RewardsTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RewardsTransaction",
                table: "RewardsTransaction");

            migrationBuilder.RenameTable(
                name: "RewardsTransaction",
                newName: "RewardsTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_RewardsTransaction_RewardsCardId",
                table: "RewardsTransactions",
                newName: "IX_RewardsTransactions_RewardsCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RewardsTransactions",
                table: "RewardsTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardsTransactions_RewardsCards_RewardsCardId",
                table: "RewardsTransactions",
                column: "RewardsCardId",
                principalTable: "RewardsCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RewardsTransactions_RewardsCards_RewardsCardId",
                table: "RewardsTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RewardsTransactions",
                table: "RewardsTransactions");

            migrationBuilder.RenameTable(
                name: "RewardsTransactions",
                newName: "RewardsTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_RewardsTransactions_RewardsCardId",
                table: "RewardsTransaction",
                newName: "IX_RewardsTransaction_RewardsCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RewardsTransaction",
                table: "RewardsTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardsTransaction_RewardsCards_RewardsCardId",
                table: "RewardsTransaction",
                column: "RewardsCardId",
                principalTable: "RewardsCards",
                principalColumn: "Id");
        }
    }
}
