using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryPokedex.Migrations
{
    public partial class AutitableBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tipos_Pokemones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Tipos_Pokemones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LasModified",
                table: "Tipos_Pokemones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Tipos_Pokemones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Regiones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Regiones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LasModified",
                table: "Regiones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Regiones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Pokemones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Pokemones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LasModified",
                table: "Pokemones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Pokemones",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tipos_Pokemones");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Tipos_Pokemones");

            migrationBuilder.DropColumn(
                name: "LasModified",
                table: "Tipos_Pokemones");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Tipos_Pokemones");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Regiones");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Regiones");

            migrationBuilder.DropColumn(
                name: "LasModified",
                table: "Regiones");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Regiones");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "LasModified",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Pokemones");
        }
    }
}
