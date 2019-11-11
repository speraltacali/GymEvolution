using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class sprint04 : Migration
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

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaseDetalle",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFin = table.Column<TimeSpan>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    ClaseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaseDetalle_Clase_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaseDetalle_ClaseId",
                table: "ClaseDetalle",
                column: "ClaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaseDetalle");

            migrationBuilder.DropTable(
                name: "Clase");

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
