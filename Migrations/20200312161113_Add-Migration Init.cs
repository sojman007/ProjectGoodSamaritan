using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectGoodSamaritan.Migrations
{
    public partial class AddMigrationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoundItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    FoundDateTime = table.Column<DateTime>(nullable: false),
                    ItemRecoveryInstructions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LostItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ItemName = table.Column<string>(maxLength: 20, nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    LostDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LostItems_Index",
                table: "LostItems",
                column: "Index");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoundItems");

            migrationBuilder.DropTable(
                name: "LostItems");
        }
    }
}
