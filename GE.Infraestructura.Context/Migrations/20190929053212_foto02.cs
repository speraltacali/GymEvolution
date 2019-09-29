using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class foto02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreFoto",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TamañoFoto",
                table: "Persona",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreFoto",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "TamañoFoto",
                table: "Persona");
        }
    }
}
