using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class dataadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ElectricMeter",
                columns: new[] { "Id", "Cost", "Date", "ZoneId" },
                values: new object[,]
                {
                    { 7, 100, new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 800, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 900, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "WaterMeter",
                columns: new[] { "Id", "Cost", "Date", "ZoneId" },
                values: new object[,]
                {
                    { 4, 100, new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 200, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 300, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WaterMeter",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WaterMeter",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WaterMeter",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
