using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixedRealtionOnetoManyDeviceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_ServiceId",
                table: "Devices");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ServiceId",
                table: "Devices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_ServiceId",
                table: "Devices");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ServiceId",
                table: "Devices",
                column: "ServiceId",
                unique: true);
        }
    }
}
