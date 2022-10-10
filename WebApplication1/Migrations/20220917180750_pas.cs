using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class pas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BuildingModelId",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "FloorModelId",
                table: "Zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
