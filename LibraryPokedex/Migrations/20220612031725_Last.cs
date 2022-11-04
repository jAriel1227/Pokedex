using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryPokedex.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Pokemones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Pokemones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDRegions = table.Column<int>(type: "int", nullable: false),
                    IDType1Pokemon = table.Column<int>(type: "int", nullable: false),
                    IDType2Pokemon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemones_Regiones_IDRegions",
                        column: x => x.IDRegions,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_Pokemones_IDType1Pokemon",
                        column: x => x.IDType1Pokemon,
                        principalTable: "Tipos_Pokemones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_Pokemones_IDType2Pokemon",
                        column: x => x.IDType2Pokemon,
                        principalTable: "Tipos_Pokemones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IDRegions",
                table: "Pokemones",
                column: "IDRegions");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IDType1Pokemon",
                table: "Pokemones",
                column: "IDType1Pokemon");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IDType2Pokemon",
                table: "Pokemones",
                column: "IDType2Pokemon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemones");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Tipos_Pokemones");
        }
    }
}
