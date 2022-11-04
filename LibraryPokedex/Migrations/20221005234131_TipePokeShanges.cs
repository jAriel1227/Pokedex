using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryPokedex.Migrations
{
    public partial class TipePokeShanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_Tipos_Pokemones_IDType1Pokemon",
                table: "Pokemones");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_Tipos_Pokemones_IDType1Pokemon",
                table: "Pokemones",
                column: "IDType1Pokemon",
                principalTable: "Tipos_Pokemones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_Tipos_Pokemones_IDType1Pokemon",
                table: "Pokemones");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_Tipos_Pokemones_IDType1Pokemon",
                table: "Pokemones",
                column: "IDType1Pokemon",
                principalTable: "Tipos_Pokemones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
