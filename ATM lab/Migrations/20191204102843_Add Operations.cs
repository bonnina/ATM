using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM_lab.Migrations
{
    public partial class AddOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Cards_CardId",
                table: "Operation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operation",
                table: "Operation");

            migrationBuilder.RenameTable(
                name: "Operation",
                newName: "Operations");

            migrationBuilder.RenameIndex(
                name: "IX_Operation_CardId",
                table: "Operations",
                newName: "IX_Operations_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Cards_CardId",
                table: "Operations",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Cards_CardId",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Operation");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_CardId",
                table: "Operation",
                newName: "IX_Operation_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operation",
                table: "Operation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Cards_CardId",
                table: "Operation",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
