using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DropFKinAttentionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttentionsStatuses_Attentions_StatusId",
                table: "AttentionsStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "AttentionStatus_PK",
                table: "AttentionsStatuses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Attentions_AttentionStatusId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "AttentionsStatuses");

            migrationBuilder.DropColumn(
                name: "AttentionStatusId",
                table: "Attentions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "AttentionsStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttentionStatusId",
                table: "Attentions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "AttentionStatus_PK",
                table: "AttentionsStatuses",
                column: "StatusId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Attentions_AttentionStatusId",
                table: "Attentions",
                column: "AttentionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionsStatuses_Attentions_StatusId",
                table: "AttentionsStatuses",
                column: "StatusId",
                principalTable: "Attentions",
                principalColumn: "AttentionStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
