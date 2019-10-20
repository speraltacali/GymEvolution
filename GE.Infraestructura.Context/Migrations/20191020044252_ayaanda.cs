using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class ayaanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Descuento = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Domicilio = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FotoLink = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    GrupoSanguineo = table.Column<int>(nullable: true),
                    FechaDeIngreso = table.Column<DateTime>(nullable: true),
                    Legajo = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteControl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaAcceso = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
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
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TipoMovimiento = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Persona_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EstaBloqueado = table.Column<bool>(nullable: false),
                    EmpleadoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Caja_UsuarioId",
                table: "Caja",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteControl_ClienteId",
                table: "ClienteControl",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCaja_CajaId",
                table: "DetalleCaja",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_EmpleadoId",
                table: "Movimiento",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpleadoId",
                table: "Usuario",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteControl");

            migrationBuilder.DropTable(
                name: "DetalleCaja");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
