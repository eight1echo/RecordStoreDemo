using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStoreDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RewardsCardTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RewardsTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsChange = table.Column<int>(type: "int", nullable: false),
                    RewardsCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardsTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardsTransaction_RewardsCards_RewardsCardId",
                        column: x => x.RewardsCardId,
                        principalTable: "RewardsCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RewardsTransaction_RewardsCardId",
                table: "RewardsTransaction",
                column: "RewardsCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RewardsTransaction");
        }
    }
}
