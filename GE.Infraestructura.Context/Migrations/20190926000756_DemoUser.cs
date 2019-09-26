using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class DemoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Persona");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeIngreso",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimineto",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrupoSanguineo",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persona",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Persona",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

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
                        name: "FK_ClienteControl_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
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
                    Descuento = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
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
                        name: "FK_Cliente_Factura_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "FechaDeIngreso",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "FechaVencimineto",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Persona");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");
        }
    }
}
