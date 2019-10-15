using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class romper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Persona_ClienteId",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "Cliente_Factura");

            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Factura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Factura",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    CuotaVencimiento = table.Column<DateTime>(nullable: false),
                    CuotaVigente = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_Factura",
                columns: table => new
                {
                    ClienteId = table.Column<long>(nullable: false),
                    FacturaId = table.Column<long>(nullable: false),
                    CuotaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente_Factura", x => new { x.ClienteId, x.FacturaId });
                    table.ForeignKey(
                        name: "FK_Cliente_Factura_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Factura_Cuota_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Cuota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Factura_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Factura_CuotaId",
                table: "Cliente_Factura",
                column: "CuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Factura_FacturaId",
                table: "Cliente_Factura",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Persona_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
