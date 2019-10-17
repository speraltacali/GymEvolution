using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class pruebaUnion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Persona_ClienteId",
                table: "PagoFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.DropIndex(
                name: "IX_PagoFactura_UsuarioId",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "PagoFactura");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "PagoFactura",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Caja",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "UsuarioId", "FacturaId", "CuotaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Caja");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "PagoFactura",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "PagoFactura",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "ClienteId", "FacturaId", "CuotaId" });

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_UsuarioId",
                table: "PagoFactura",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagoFactura_Persona_ClienteId",
                table: "PagoFactura",
                column: "ClienteId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
