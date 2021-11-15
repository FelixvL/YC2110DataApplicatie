using Microsoft.EntityFrameworkCore.Migrations;

namespace DBLaag.Migrations
{
    public partial class Nieuw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "producten",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fotonaam",
                table: "producten",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "producten");

            migrationBuilder.DropColumn(
                name: "Fotonaam",
                table: "producten");
        }
    }
}
