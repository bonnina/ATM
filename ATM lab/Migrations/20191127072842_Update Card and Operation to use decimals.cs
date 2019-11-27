using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM_lab.Migrations
{
    public partial class UpdateCardandOperationtousedecimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Operation",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Cards",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Operation",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
