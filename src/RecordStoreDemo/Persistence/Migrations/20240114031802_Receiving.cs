using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStoreDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Receiving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiveItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiveItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiveItem_CatalogProducts_CatalogProductId",
                        column: x => x.CatalogProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceiveItem_InventoryProducts_InventoryProductId",
                        column: x => x.InventoryProductId,
                        principalTable: "InventoryProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceiveItem_Receives_ReceiveId",
                        column: x => x.ReceiveId,
                        principalTable: "Receives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveItem_CatalogProductId",
                table: "ReceiveItem",
                column: "CatalogProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveItem_InventoryProductId",
                table: "ReceiveItem",
                column: "InventoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveItem_ReceiveId",
                table: "ReceiveItem",
                column: "ReceiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiveItem");

            migrationBuilder.DropTable(
                name: "Receives");
        }
    }
}
