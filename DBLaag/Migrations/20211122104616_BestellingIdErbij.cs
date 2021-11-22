using Microsoft.EntityFrameworkCore.Migrations;

namespace DBLaag.Migrations
{
    public partial class BestellingIdErbij : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_besteldeProducten_bestellingen_BestellingId",
                table: "besteldeProducten");

            migrationBuilder.DropForeignKey(
                name: "FK_besteldeProducten_producten_ProductId",
                table: "besteldeProducten");

            migrationBuilder.DropIndex(
                name: "IX_besteldeProducten_ProductId",
                table: "besteldeProducten");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "besteldeProducten",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BestellingId",
                table: "besteldeProducten",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_besteldeProducten_ProductId",
                table: "besteldeProducten",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_besteldeProducten_bestellingen_BestellingId",
                table: "besteldeProducten",
                column: "BestellingId",
                principalTable: "bestellingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_besteldeProducten_producten_ProductId",
                table: "besteldeProducten",
                column: "ProductId",
                principalTable: "producten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_besteldeProducten_bestellingen_BestellingId",
                table: "besteldeProducten");

            migrationBuilder.DropForeignKey(
                name: "FK_besteldeProducten_producten_ProductId",
                table: "besteldeProducten");

            migrationBuilder.DropIndex(
                name: "IX_besteldeProducten_ProductId",
                table: "besteldeProducten");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "besteldeProducten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BestellingId",
                table: "besteldeProducten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_besteldeProducten_ProductId",
                table: "besteldeProducten",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_besteldeProducten_bestellingen_BestellingId",
                table: "besteldeProducten",
                column: "BestellingId",
                principalTable: "bestellingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_besteldeProducten_producten_ProductId",
                table: "besteldeProducten",
                column: "ProductId",
                principalTable: "producten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
