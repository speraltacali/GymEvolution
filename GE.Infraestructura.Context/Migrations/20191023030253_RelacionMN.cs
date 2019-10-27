using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class RelacionMN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PagoFactura_Id",
                table: "PagoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.DropIndex(
                name: "IX_PagoFactura_FacturaId",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PagoFactura");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PagoFactura");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "FacturaId", "CuotaId", "ClienteId", "EmpleadoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "Id", "FacturaId", "CuotaId", "ClienteId", "EmpleadoId" });

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_FacturaId",
                table: "PagoFactura",
                column: "FacturaId");
        }
    }
}
