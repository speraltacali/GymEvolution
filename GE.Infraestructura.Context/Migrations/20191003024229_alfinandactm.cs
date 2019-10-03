using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class alfinandactm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionFoto",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ImageCaption",
                table: "Persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescripcionFoto",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageCaption",
                table: "Persona",
                nullable: true);
        }
    }
}
