using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class delcolinvehicetbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Vehicle",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vehicle",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Vehicle",
                type: "int",
                nullable: true);
        }
    }
}
