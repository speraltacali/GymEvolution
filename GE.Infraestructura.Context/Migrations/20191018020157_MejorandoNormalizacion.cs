using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class MejorandoNormalizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Persona_EmpleadoId",
                table: "Factura");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Factura",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_EmpleadoId",
                table: "Factura",
                newName: "IX_Factura_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Usuario_UsuarioId",
                table: "Factura",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Usuario_UsuarioId",
                table: "Factura");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Factura",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_UsuarioId",
                table: "Factura",
                newName: "IX_Factura_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Persona_EmpleadoId",
                table: "Factura",
                column: "EmpleadoId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
