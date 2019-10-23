using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Entity.Enums;
using GE.Infraestructura.Context;
using GE.Infraestructura.Repositorio.Cuota;
using GE.Infraestructura.Repositorio.Factura;
using GE.IServicio.Cuota;
using GE.IServicio.Cuota.DTO;
using GE.IServicio.Factura;
using GE.IServicio.Factura.DTO;
using GE.IServicio.Movimiento;
using GE.IServicio.Movimiento.DTO;
using GE.IServicio.Pago_Factura;
using GE.IServicio.Pago_Factura.DTO;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class PagoCuotaController : Controller
    {
        private readonly IFacturaServicio _facturaServicio = new FacturaServicio();

        private readonly ICuotaServicio _cuotaServicio = new CuotaServicio();

        private readonly IMovimientoServicio _movimientoServicio = new MovimientoServicio();
        //private readonly IPago_FacturaServicio _pagoFacturaServicio = new Pago_FacturaServicio();

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

            using (var context = new Context())
            {
                context.Pago_Factura.Add(new Pago_Factura()
                {
                    FacturaId = facturaId.Id,
                    CuotaId = cuotaId.Id,
                    ClienteId = SessionActiva.ClienteId,
                    EmpleadoId = SessionActiva.EmpleadoId
                });
                context.SaveChanges();
            }

            var movimiento = new MovimientoDto()
            {
                Descripcion = "Pago Cuota",
                EmpleadoId = SessionActiva.EmpleadoId,
                FechaActualizacion = DateTime.Now,
                TipoMovimiento = TipoMovimiento.Ingreso,
                Monto = factura.SubTotal
            };

            _movimientoServicio.NuevoMovimiento(movimiento);

            return RedirectToAction("Index" , "Cliente");
            //_pagoFacturaServicio.PagoFactura(PagoFactura);
        }
    }
}