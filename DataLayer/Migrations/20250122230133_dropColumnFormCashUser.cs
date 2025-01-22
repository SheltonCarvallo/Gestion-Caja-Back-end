using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class dropColumnFormCashUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Relation_cash_PK",
                table: "UsersCashes");

            migrationBuilder.DropPrimaryKey(
                name: "Contract_FK",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CashId",
                table: "UsersCashes");

            migrationBuilder.AddPrimaryKey(
                name: "Contract_PK",
                table: "Contracts",
                column: "ContractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Contract_PK",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "CashId",
                table: "UsersCashes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "Relation_cash_PK",
                table: "UsersCashes",
                column: "CashId");

            migrationBuilder.AddPrimaryKey(
                name: "Contract_FK",
                table: "Contracts",
                column: "ContractId");
        }
    }
}
