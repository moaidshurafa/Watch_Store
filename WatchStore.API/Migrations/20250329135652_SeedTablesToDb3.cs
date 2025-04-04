using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedTablesToDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Country", "Description", "LogoUrl", "Name" },
                values: new object[] { new Guid("29837429-832f-43dd-b699-a05d45582b1f"), "Switzerland", "Rolex Watch", "https://via.placeholder.com/150", "Rolex" });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "BrandId", "Category", "Description", "ImageUrl", "Name", "Price", "ReleaseDate", "Stock" },
                values: new object[] { new Guid("fe39a8ab-6637-4f91-babb-eb7bdfd28d99"), new Guid("29837429-832f-43dd-b699-a05d45582b1f"), "Diving", "Rolex Watch", "https://via.placeholder.com/150", "Rolex Submariner", 1000m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10" });

            migrationBuilder.CreateIndex(
                name: "IX_Watches_BrandId",
                table: "Watches",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
