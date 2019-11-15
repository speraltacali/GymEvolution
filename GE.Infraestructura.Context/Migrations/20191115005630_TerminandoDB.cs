using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class TerminandoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Repeticiones = table.Column<int>(nullable: false),
                    Series = table.Column<int>(nullable: false),
                    Musculo = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    RutinaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejercicio_Rutina_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_RutinaId",
                table: "Ejercicio",
                column: "RutinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Rutina");
        }
    }
}
