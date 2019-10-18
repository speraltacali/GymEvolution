using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class Normalizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura");

            migrationBuilder.DropIndex(
                name: "IX_PagoFactura_UsuarioId",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "PagoFactura");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmpleadoId",
                table: "Factura",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Cuota",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_EmpleadoId",
                table: "Factura",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_ClienteId",
                table: "Cuota",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuota_Persona_ClienteId",
                table: "Cuota",
                column: "ClienteId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Persona_EmpleadoId",
                table: "Factura",
                column: "EmpleadoId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuota_Persona_ClienteId",
                table: "Cuota");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Persona_EmpleadoId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_EmpleadoId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Cuota_ClienteId",
                table: "Cuota");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cuota");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "PagoFactura",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_UsuarioId",
                table: "PagoFactura",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
