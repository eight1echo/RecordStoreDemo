﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStoreDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerRewardsCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProfiles_RewardsCards_RewardsCardId",
                table: "CustomerProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "RewardsCardId",
                table: "CustomerProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProfiles_RewardsCards_RewardsCardId",
                table: "CustomerProfiles",
                column: "RewardsCardId",
                principalTable: "RewardsCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProfiles_RewardsCards_RewardsCardId",
                table: "CustomerProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "RewardsCardId",
                table: "CustomerProfiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProfiles_RewardsCards_RewardsCardId",
                table: "CustomerProfiles",
                column: "RewardsCardId",
                principalTable: "RewardsCards",
                principalColumn: "Id");
        }
    }
}
