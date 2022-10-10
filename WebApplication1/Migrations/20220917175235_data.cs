using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Building_BuildingMode",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Facility_FacilityMode",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_BuildingMode",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "BuildingMode",
                table: "Zone");

            migrationBuilder.RenameColumn(
                name: "FacilityMode",
                table: "Zone",
                newName: "BuildingModel");

            migrationBuilder.RenameIndex(
                name: "IX_Zone_FacilityMode",
                table: "Zone",
                newName: "IX_Zone_BuildingModel");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "Rmz" },
                values: new object[] { 1, "bengaluru", "ABC" });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "Id", "BuildingId", "FloorName" },
                values: new object[] { 1, null, "First Floor" });

            migrationBuilder.InsertData(
                table: "Facility",
                columns: new[] { "Id", "CityIdId", "FacilityName", "LocationAddress" },
                values: new object[] { 1, 1, "RMZ", null });

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "BuildName", "FacilityIdId" },
                values: new object[] { 1, "RMZ Corp", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Building_BuildingModel",
                table: "Zone",
                column: "BuildingModel",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Facility_FacilityModel",
                table: "Zone",
                column: "FacilityModel",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Building_BuildingModel",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Facility_FacilityModel",
                table: "Zone");

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Floor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facility",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "BuildingModel",
                table: "Zone",
                newName: "FacilityMode");

            migrationBuilder.RenameIndex(
                name: "IX_Zone_BuildingModel",
                table: "Zone",
                newName: "IX_Zone_FacilityMode");

            migrationBuilder.AddColumn<int>(
                name: "BuildingMode",
                table: "Zone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_BuildingMode",
                table: "Zone",
                column: "BuildingMode");

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Building_BuildingMode",
                table: "Zone",
                column: "BuildingMode",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Facility_FacilityMode",
                table: "Zone",
                column: "FacilityMode",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
