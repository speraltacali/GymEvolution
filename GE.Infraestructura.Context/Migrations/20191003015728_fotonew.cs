using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class fotonew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoLink",
                table: "Persona",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoLink",
                table: "Persona");
        }
    }
}
