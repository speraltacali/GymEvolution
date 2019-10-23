using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Infraestructura.Context.Migrations
{
    public partial class DbRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "Id", "FacturaId", "CuotaId", "ClienteId", "EmpleadoId" });

            migrationBuilder.CreateIndex(
                name: "IX_PagoFactura_FacturaId",
                table: "PagoFactura",
                column: "FacturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura");

            migrationBuilder.DropIndex(
                name: "IX_PagoFactura_FacturaId",
                table: "PagoFactura");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagoFactura",
                table: "PagoFactura",
                columns: new[] { "FacturaId", "CuotaId", "ClienteId", "EmpleadoId" });
        }
    }
}
