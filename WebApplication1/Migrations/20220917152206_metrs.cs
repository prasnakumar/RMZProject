using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class metrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_Building_BuildingMode",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_City_CityModel",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_Facility_FacilityMode",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_Floor_FacilityModel",
                table: "student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "Zone");

            migrationBuilder.RenameIndex(
                name: "IX_student_FacilityModel",
                table: "Zone",
                newName: "IX_Zone_FacilityModel");

            migrationBuilder.RenameIndex(
                name: "IX_student_FacilityMode",
                table: "Zone",
                newName: "IX_Zone_FacilityMode");

            migrationBuilder.RenameIndex(
                name: "IX_student_CityModel",
                table: "Zone",
                newName: "IX_Zone_CityModel");

            migrationBuilder.RenameIndex(
                name: "IX_student_BuildingMode",
                table: "Zone",
                newName: "IX_Zone_BuildingMode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zone",
                table: "Zone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Building_BuildingMode",
                table: "Zone",
                column: "BuildingMode",
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
                name: "FK_Zone_Facility_FacilityMode",
                table: "Zone",
                column: "FacilityMode",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Building_BuildingMode",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_City_CityModel",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Facility_FacilityMode",
                table: "Zone");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Floor_FacilityModel",
                table: "Zone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zone",
                table: "Zone");

            migrationBuilder.RenameTable(
                name: "Zone",
                newName: "student");

            migrationBuilder.RenameIndex(
                name: "IX_Zone_FacilityModel",
                table: "student",
                newName: "IX_student_FacilityModel");

            migrationBuilder.RenameIndex(
                name: "IX_Zone_FacilityMode",
                table: "student",
                newName: "IX_student_FacilityMode");

            migrationBuilder.RenameIndex(
                name: "IX_Zone_CityModel",
                table: "student",
                newName: "IX_student_CityModel");

            migrationBuilder.RenameIndex(
                name: "IX_Zone_BuildingMode",
                table: "student",
                newName: "IX_student_BuildingMode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_Building_BuildingMode",
                table: "student",
                column: "BuildingMode",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_City_CityModel",
                table: "student",
                column: "CityModel",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_Facility_FacilityMode",
                table: "student",
                column: "FacilityMode",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_Floor_FacilityModel",
                table: "student",
                column: "FacilityModel",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
