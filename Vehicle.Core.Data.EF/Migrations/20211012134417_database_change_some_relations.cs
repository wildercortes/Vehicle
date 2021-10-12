using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.Core.Data.EF.Migrations
{
    public partial class database_change_some_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Histories_HistoryId1",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Histories_HistoryId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Histories_HistoryId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_HistoryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_HistoryId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Details_HistoryId1",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "HistoryId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "HistoryId1",
                table: "Details");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Histories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_VehicleId",
                table: "Histories",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Vehicles_VehicleId",
                table: "Histories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Vehicles_VehicleId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_VehicleId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Histories");

            migrationBuilder.AddColumn<int>(
                name: "HistoryId1",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId1",
                table: "Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_HistoryId",
                table: "Vehicles",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_HistoryId1",
                table: "Vehicles",
                column: "HistoryId1",
                unique: true,
                filter: "[HistoryId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Details_HistoryId1",
                table: "Details",
                column: "HistoryId1",
                unique: true,
                filter: "[HistoryId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Histories_HistoryId1",
                table: "Details",
                column: "HistoryId1",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Histories_HistoryId",
                table: "Vehicles",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Histories_HistoryId1",
                table: "Vehicles",
                column: "HistoryId1",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
