using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongestionHistory_Vehicle_VehicleId1",
                table: "CongestionHistory");

            migrationBuilder.DropIndex(
                name: "IX_CongestionHistory_VehicleId1",
                table: "CongestionHistory");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "CongestionHistory");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "CongestionHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_CongestionHistory_VehicleId",
                table: "CongestionHistory",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CongestionHistory_Vehicle_VehicleId",
                table: "CongestionHistory",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongestionHistory_Vehicle_VehicleId",
                table: "CongestionHistory");

            migrationBuilder.DropIndex(
                name: "IX_CongestionHistory_VehicleId",
                table: "CongestionHistory");

            migrationBuilder.AlterColumn<long>(
                name: "VehicleId",
                table: "CongestionHistory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId1",
                table: "CongestionHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CongestionHistory_VehicleId1",
                table: "CongestionHistory",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CongestionHistory_Vehicle_VehicleId1",
                table: "CongestionHistory",
                column: "VehicleId1",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
