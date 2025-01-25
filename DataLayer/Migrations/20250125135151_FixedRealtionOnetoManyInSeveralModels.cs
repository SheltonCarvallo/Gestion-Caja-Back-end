using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixedRealtionOnetoManyInSeveralModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turns_CashId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ClientId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionStatusId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionTypeId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_ClientId",
                table: "Attentions");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_CashId",
                table: "Turns",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId",
                table: "Payments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionStatusId",
                table: "Attentions",
                column: "AttentionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionTypeId",
                table: "Attentions",
                column: "AttentionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_ClientId",
                table: "Attentions",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turns_CashId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ClientId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionStatusId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionTypeId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_ClientId",
                table: "Attentions");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_CashId",
                table: "Turns",
                column: "CashId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId",
                table: "Payments",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionStatusId",
                table: "Attentions",
                column: "AttentionStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionTypeId",
                table: "Attentions",
                column: "AttentionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_ClientId",
                table: "Attentions",
                column: "ClientId",
                unique: true);
        }
    }
}
