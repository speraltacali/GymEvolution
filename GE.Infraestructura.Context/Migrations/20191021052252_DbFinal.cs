using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class DbFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Usuario_UsuarioId",
                table: "Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_UsuarioId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Factura");

            migrationBuilder.AddColumn<long>(
                name: "EmpleadoId",
                table: "PagoFactura",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "FacturaId", "CuotaId", "ClienteId", "EmpleadoId" });

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_EmpleadoId",
                table: "PagoFactura",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagoFactura_Persona_EmpleadoId",
                table: "PagoFactura",
                column: "EmpleadoId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Persona_EmpleadoId",
                table: "PagoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.DropIndex(
                name: "IX_PagoFactura_EmpleadoId",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "PagoFactura");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "Factura",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "FacturaId", "CuotaId", "ClienteId" });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_UsuarioId",
                table: "Factura",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Usuario_UsuarioId",
                table: "Factura",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
