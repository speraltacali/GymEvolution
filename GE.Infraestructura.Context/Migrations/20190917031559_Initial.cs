using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeIngreso",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimineto",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrupoSanguineo",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClienteControl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaAcceso = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteControl_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NumeroFactura = table.Column<string>(nullable: true),
                    FechaOperacion = table.Column<DateTime>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_Factura",
                columns: table => new
                {
                    ClienteId = table.Column<long>(nullable: false),
                    FacturaId = table.Column<long>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente_Factura", x => new { x.ClienteId, x.FacturaId });
                    table.ForeignKey(
                        name: "FK_Cliente_Factura_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
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
                name: "IX_Cliente_Factura_FacturaId",
                table: "Cliente_Factura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteControl_ClienteId",
                table: "ClienteControl",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente_Factura");

            migrationBuilder.DropTable(
                name: "ClienteControl");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropColumn(
                name: "FechaDeIngreso",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "FechaVencimineto",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Cliente");
        }
    }
}
