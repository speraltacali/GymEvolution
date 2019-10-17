using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class UsuarioFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Persona_EmpleadoId",
                table: "PagoFactura");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "PagoFactura",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_PagoFactura_EmpleadoId",
                table: "PagoFactura",
                newName: "IX_PagoFactura_UsuarioId");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PagoFactura",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PagoFactura",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PagoFactura_Id",
                table: "PagoFactura",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagoFactura_Usuario_UsuarioId",
                table: "PagoFactura");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PagoFactura_Id",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PagoFactura");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "PagoFactura",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_PagoFactura_UsuarioId",
                table: "PagoFactura",
                newName: "IX_PagoFactura_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagoFactura_Persona_EmpleadoId",
                table: "PagoFactura",
                column: "EmpleadoId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
