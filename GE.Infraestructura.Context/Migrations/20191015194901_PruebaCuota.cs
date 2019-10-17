using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class PruebaCuota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    CuotaVigente = table.Column<DateTime>(nullable: false),
                    CuotaVencimiento = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PagoFactura",
                columns: table => new
                {
                    FacturaId = table.Column<long>(nullable: false),
                    ClienteId = table.Column<long>(nullable: false),
                    CuotaId = table.Column<long>(nullable: false),
                    EmpleadoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoFactura", x => new { x.ClienteId, x.FacturaId, x.CuotaId });
                    table.ForeignKey(
                        name: "FK_PagoFactura_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoFactura_Cuota_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Cuota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoFactura_Persona_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagoFactura_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_CuotaId",
                table: "PagoFactura",
                column: "CuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_EmpleadoId",
                table: "PagoFactura",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_FacturaId",
                table: "PagoFactura",
                column: "FacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagoFactura");

            migrationBuilder.DropTable(
                name: "Cuota");
        }
    }
}
