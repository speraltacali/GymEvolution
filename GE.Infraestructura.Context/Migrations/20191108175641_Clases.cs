using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class Clases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PagoFactura_Id",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PagoFactura");

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "Movimiento",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Cuota",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Movimiento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cuota");

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
        }
    }
}
