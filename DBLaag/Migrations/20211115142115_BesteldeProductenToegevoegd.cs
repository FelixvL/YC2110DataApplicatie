using Microsoft.EntityFrameworkCore.Migrations;

namespace DBLaag.Migrations
{
    public partial class BesteldeProductenToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "besteldeProducten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    aantalVanHetProduct = table.Column<int>(type: "int", nullable: false),
                    BestellingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_besteldeProducten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_besteldeProducten_bestellingen_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "bestellingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_besteldeProducten_producten_ProductId",
                        column: x => x.ProductId,
                        principalTable: "producten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_besteldeProducten_BestellingId",
                table: "besteldeProducten",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_besteldeProducten_ProductId",
                table: "besteldeProducten",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "besteldeProducten");
        }
    }
}
