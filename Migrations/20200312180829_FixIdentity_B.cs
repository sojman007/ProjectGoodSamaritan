using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectGoodSamaritan.Migrations
{
    public partial class FixIdentity_B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems");

            migrationBuilder.DropColumn(
                name: "newId",
                table: "FoundItems");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FoundItems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoundItems");

            migrationBuilder.AddColumn<string>(
                name: "newId",
                table: "FoundItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems",
                column: "newId");
        }
    }
}
