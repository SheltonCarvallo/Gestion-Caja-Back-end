using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixFKinAttention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "AttentionsStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionStatusId",
                table: "Attentions",
                column: "AttentionStatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attentions_AttentionsStatuses_AttentionStatusId",
                table: "Attentions",
                column: "AttentionStatusId",
                principalTable: "AttentionsStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attentions_AttentionsStatuses_AttentionStatusId",
                table: "Attentions");

            migrationBuilder.DropPrimaryKey(
                name: "AttentionStatus_PK",
                table: "AttentionsStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionStatusId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "AttentionsStatuses");

            migrationBuilder.DropColumn(
                name: "AttentionStatusId",
                table: "Attentions");
        }
    }
}
