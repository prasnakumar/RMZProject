using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class dataaddcheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilityIdId",
                table: "Floor",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "BuildName", "FacilityIdId" },
                values: new object[] { 3, "RMZ Corp 2", 1 });

            migrationBuilder.UpdateData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 8,
                column: "ZoneId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 9,
                column: "ZoneId",
                value: 11);

            migrationBuilder.InsertData(
                table: "Facility",
                columns: new[] { "Id", "CityIdId", "FacilityName", "LocationAddress" },
                values: new object[] { 2, 1, "RMZMG", null });

            migrationBuilder.UpdateData(
                table: "Floor",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacilityIdId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "Id", "BuildingId", "FacilityIdId", "FloorName" },
                values: new object[] { 6, null, 1, "First Floor" });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "BuildingId", "FacilityId", "FloorId", "ZoneName", "cityId" },
                values: new object[,]
                {
                    { 10, 3, 1, 1, "#11", 1 },
                    { 11, 3, 1, 1, "#12", 1 },
                    { 13, 3, 1, 1, "#13", 1 }
                });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "BuildName", "FacilityIdId" },
                values: new object[] { 2, "RMZNext", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Floor_FacilityIdId",
                table: "Floor",
                column: "FacilityIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Facility_FacilityIdId",
                table: "Floor",
                column: "FacilityIdId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Facility_FacilityIdId",
                table: "Floor");

            migrationBuilder.DropIndex(
                name: "IX_Floor_FacilityIdId",
                table: "Floor");

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Floor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Facility",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FacilityIdId",
                table: "Floor");

            migrationBuilder.UpdateData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 8,
                column: "ZoneId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ElectricMeter",
                keyColumn: "Id",
                keyValue: 9,
                column: "ZoneId",
                value: 2);
        }
    }
}
