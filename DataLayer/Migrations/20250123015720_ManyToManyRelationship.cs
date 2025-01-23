using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCashes",
                table: "UsersCashes",
                columns: new[] { "UserId", "CashId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCashes_CashId",
                table: "UsersCashes",
                column: "CashId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCashes_Cashs_CashId",
                table: "UsersCashes",
                column: "CashId",
                principalTable: "Cashs",
                principalColumn: "CashId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCashes_Users_UserId",
                table: "UsersCashes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCashes_Cashs_CashId",
                table: "UsersCashes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCashes_Users_UserId",
                table: "UsersCashes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCashes",
                table: "UsersCashes");

            migrationBuilder.DropIndex(
                name: "IX_UsersCashes_CashId",
                table: "UsersCashes");
        }
    }
}
