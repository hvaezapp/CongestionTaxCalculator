using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcoltovehicletbl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Vehicle_ParentVehicleId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ParentVehicleId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ParentVehicleId",
                table: "Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParentId",
                table: "Vehicle",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Vehicle_ParentId",
                table: "Vehicle",
                column: "ParentId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Vehicle_ParentId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ParentId",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "ParentVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParentVehicleId",
                table: "Vehicle",
                column: "ParentVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Vehicle_ParentVehicleId",
                table: "Vehicle",
                column: "ParentVehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
