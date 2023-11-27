using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcoltovehicletbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Vehicle",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Vehicle_ParentVehicleId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ParentVehicleId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ParentVehicleId",
                table: "Vehicle");
        }
    }
}
