using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchStore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Brands_BrandId",
                table: "Watches");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Watches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Brands_BrandId",
                table: "Watches",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Brands_BrandId",
                table: "Watches");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Watches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Brands_BrandId",
                table: "Watches",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
