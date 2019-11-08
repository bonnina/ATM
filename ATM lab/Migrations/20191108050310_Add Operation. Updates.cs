using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM_lab.Migrations
{
    public partial class AddOperationUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_CardId",
                table: "Operation",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");
        }
    }
}
