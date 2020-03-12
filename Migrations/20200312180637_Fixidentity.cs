using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectGoodSamaritan.Migrations
{
    public partial class Fixidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LostItems_Index",
                table: "LostItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "LostItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoundItems");

            migrationBuilder.AddColumn<string>(
                name: "newId",
                table: "FoundItems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems",
                column: "newId");

            migrationBuilder.CreateIndex(
                name: "IX_LostItems_ItemName",
                table: "LostItems",
                column: "ItemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoundItems_ItemName",
                table: "FoundItems",
                column: "ItemName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LostItems_ItemName",
                table: "LostItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems");

            migrationBuilder.DropIndex(
                name: "IX_FoundItems_ItemName",
                table: "FoundItems");

            migrationBuilder.DropColumn(
                name: "newId",
                table: "FoundItems");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "LostItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FoundItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoundItems",
                table: "FoundItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LostItems_Index",
                table: "LostItems",
                column: "Index");
        }
    }
}
