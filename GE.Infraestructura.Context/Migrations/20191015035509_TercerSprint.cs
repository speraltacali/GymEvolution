using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class TercerSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaVencimineto",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Cliente_Factura");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ClienteControl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CuotaId",
                table: "Cliente_Factura",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaApertura = table.Column<DateTime>(nullable: false),
                    FechaCierre = table.Column<DateTime>(nullable: false),
                    MontoApertura = table.Column<decimal>(nullable: false),
                    MontoCierre = table.Column<decimal>(nullable: false),
                    UsuarioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caja_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "DetalleCaja",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    TipoPago = table.Column<int>(nullable: false),
                    CajaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCaja_Caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "Caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Factura_CuotaId",
                table: "Cliente_Factura",
                column: "CuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Caja_UsuarioId",
                table: "Caja",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCaja_CajaId",
                table: "DetalleCaja",
                column: "CajaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Factura_Cuota_CuotaId",
                table: "Cliente_Factura",
                column: "CuotaId",
                principalTable: "Cuota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Factura_Cuota_CuotaId",
                table: "Cliente_Factura");

            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "DetalleCaja");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Factura_CuotaId",
                table: "Cliente_Factura");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ClienteControl");

            migrationBuilder.DropColumn(
                name: "CuotaId",
                table: "Cliente_Factura");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimineto",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Cliente_Factura",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
