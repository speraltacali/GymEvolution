using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GE.Dominio.Entity.Enums;
using GE.Infraestructura.Repositorio.Cuota;
using GE.Infraestructura.Repositorio.Factura;
using GE.IServicio.Cuota;
using GE.IServicio.Cuota.DTO;
using GE.IServicio.Factura;
using GE.IServicio.Factura.DTO;
using GE.IServicio.Pago_Factura;
using GE.IServicio.Pago_Factura.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class PagoCuotaController : Controller
    {
        private readonly IFacturaServicio _facturaServicio = new FacturaServicio();

        private readonly ICuotaServicio _cuotaServicio = new CuotaServicio();

        private readonly IPago_FacturaServicio _pagoFacturaServicio = new Pago_FacturaServicio();

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult PagoFactura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PagoFactura(CuotaDto cuota , FacturaDto factura)
        {
            var Cuota = new CuotaDto()
            {
                CuotaVigente = cuota.CuotaVigente,
                CuotaVencimiento = cuota.CuotaVigente.AddMonths(cuota.Cantidad),
                Cantidad = cuota.Cantidad,
                Estado = Estado.Vigente
            };

            var Factura = new FacturaDto()
            {
                FechaOperacion = DateTime.Now,
                SubTotal = factura.SubTotal,
                Total = factura.SubTotal
            };

            var cuotaId = _cuotaServicio.CuotaVigente(Cuota);

            var facturaId = _facturaServicio.Agregar(Factura);

            var PagoFactura = new Pago_FacturaDto()
            {
                FacturaId = facturaId.Id,
                CuotaId = cuotaId.Id,
                ClienteId = 2,
                EmpleadoId = 1
            };

            _pagoFacturaServicio.PagoFactura(PagoFactura);

            return RedirectToAction("Perfil", "Cliente");
        }
    }
}