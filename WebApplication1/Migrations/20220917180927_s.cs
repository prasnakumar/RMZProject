using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1,
                column: "ZoneName",
                value: "#1");

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2,
                column: "ZoneName",
                value: "#2");

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "BuildingId", "FacilityId", "FloorId", "ZoneName", "cityId" },
                values: new object[] { 3, 1, 1, 1, "#3", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1,
                column: "ZoneName",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2,
                column: "ZoneName",
                value: "2");
        }
    }
}
