using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Infrastructure.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 7, 20, 11, 3, 8, 328, DateTimeKind.Local).AddTicks(6330)),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 0),
                    VariantId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 7, 20, 11, 3, 8, 336, DateTimeKind.Local).AddTicks(217)),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[] { 1, "1010", new DateTime(2022, 7, 20, 11, 3, 8, 332, DateTimeKind.Local).AddTicks(2164), "Test test test", true, "Nike Ayakkabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "ProductId", "UpdatedDate" },
                values: new object[] { 1, "1000000851096", new DateTime(2022, 7, 20, 11, 3, 8, 338, DateTimeKind.Local).AddTicks(95), "Renk Mavi", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "ProductId", "UpdatedDate" },
                values: new object[] { 2, "1000000851097", new DateTime(2022, 7, 20, 11, 3, 8, 338, DateTimeKind.Local).AddTicks(555), "Renk Kirmizi", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Quantity", "VariantId" },
                values: new object[] { 1, new DateTime(2022, 7, 20, 11, 3, 8, 337, DateTimeKind.Local).AddTicks(294), 1, 10, 1 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Quantity", "VariantId" },
                values: new object[] { 2, new DateTime(2022, 7, 20, 11, 3, 8, 337, DateTimeKind.Local).AddTicks(1335), 1, 15, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_VariantId",
                table: "Stocks",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
