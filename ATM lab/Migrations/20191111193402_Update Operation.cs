using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM_lab.Migrations
{
    public partial class UpdateOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Operation",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Operation");
        }
    }
}
