using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Building_BuildingModel",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_City_CityModel",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Facility_FacilityModel",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Floor_FacilityModel",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_BuildingModel",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_CityModel",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_FacilityModel",
                table: "Zone");

            migrationBuilder.RenameColumn(
                name: "FacilityModel",
                table: "Zone",
                newName: "cityId");

            migrationBuilder.RenameColumn(
                name: "CityModel",
                table: "Zone",
                newName: "FloorId");

            migrationBuilder.RenameColumn(
                name: "BuildingModel",
                table: "Zone",
                newName: "FacilityId");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Zone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingModelId",
                table: "Zone",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorModelId",
                table: "Zone",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "BuildingId", "BuildingModelId", "FacilityId", "FloorId", "FloorModelId", "ZoneName", "cityId" },
                values: new object[] { 1, 1, null, 1, 1, null, "1", 1 });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "BuildingId", "BuildingModelId", "FacilityId", "FloorId", "FloorModelId", "ZoneName", "cityId" },
                values: new object[] { 2, 1, null, 1, 1, null, "2", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Zone_BuildingModelId",
                table: "Zone",
                column: "BuildingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_FloorModelId",
                table: "Zone",
                column: "FloorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Building_BuildingModelId",
                table: "Zone",
                column: "BuildingModelId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Floor_FloorModelId",
                table: "Zone",
                column: "FloorModelId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Building_BuildingModelId",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Floor_FloorModelId",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_BuildingModelId",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_FloorModelId",
                table: "Zone");

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "BuildingModelId",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "FloorModelId",
                table: "Zone");

            migrationBuilder.RenameColumn(
                name: "cityId",
                table: "Zone",
                newName: "FacilityModel");

            migrationBuilder.RenameColumn(
                name: "FloorId",
                table: "Zone",
                newName: "CityModel");

            migrationBuilder.RenameColumn(
                name: "FacilityId",
                table: "Zone",
                newName: "BuildingModel");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_BuildingModel",
                table: "Zone",
                column: "BuildingModel");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_CityModel",
                table: "Zone",
                column: "CityModel");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_FacilityModel",
                table: "Zone",
                column: "FacilityModel");

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Building_BuildingModel",
                table: "Zone",
                column: "BuildingModel",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_City_CityModel",
                table: "Zone",
                column: "CityModel",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Facility_FacilityModel",
                table: "Zone",
                column: "FacilityModel",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Floor_FacilityModel",
                table: "Zone",
                column: "FacilityModel",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
