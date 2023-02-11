using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("0a2ff2c1-fe38-41fa-8e6f-ee8670ed9e93"), 88000m, "Тут будет описание", "/images/laptop2.jpg", "Ноутбук 2" },
                    { new Guid("1154b150-02e8-4b0e-bae9-4c87a6eb9f06"), 40000m, "Тут будет описание", "/images/phone2.jpg", "Телефон 2" },
                    { new Guid("252f4820-f2b1-4f6a-8a30-59b8dfd61dda"), 95000m, "Тут будет описание", "/images/laptop3.jpg", "Ноутбук 3" },
                    { new Guid("4878a10c-c2e1-4e65-a9e2-6664ce39dac0"), 58000m, "Тут будет описание", "/images/tablet1.jpg", "Планшет 1" },
                    { new Guid("710588a8-5a47-4b1c-8e2b-99de8ae039e3"), 87000m, "Тут будет описание", "/images/tablet3.jpg", "Планшет 3" },
                    { new Guid("d184ce6e-4fba-424e-bbed-a6fa8cb1c5c0"), 50000m, "Тут будет описание", "/images/laptop1.jpg", "Ноутбук 1" },
                    { new Guid("dbcba1c5-5ce1-470b-b4e1-c71072998c55"), 57000m, "Тут будет описание", "/images/phone3.jpg", "Телефон 3" },
                    { new Guid("e550fdac-75ea-4322-8439-3d14e564ee08"), 87000m, "Тут будет описание", "/images/tablet2.jpg", "Планшет 2" },
                    { new Guid("f68ae5d3-000b-491f-8089-bd5c8b271bbc"), 76000m, "Тут будет описание", "/images/phone1.jpg", "Телефон 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a2ff2c1-fe38-41fa-8e6f-ee8670ed9e93"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1154b150-02e8-4b0e-bae9-4c87a6eb9f06"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("252f4820-f2b1-4f6a-8a30-59b8dfd61dda"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4878a10c-c2e1-4e65-a9e2-6664ce39dac0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("710588a8-5a47-4b1c-8e2b-99de8ae039e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d184ce6e-4fba-424e-bbed-a6fa8cb1c5c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dbcba1c5-5ce1-470b-b4e1-c71072998c55"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e550fdac-75ea-4322-8439-3d14e564ee08"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f68ae5d3-000b-491f-8089-bd5c8b271bbc"));
        }
    }
}
