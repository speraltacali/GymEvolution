using GE.IServicio.Caja;
using GE.IServicio.Cliente.DTO;
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
        private IPago_FacturaServicio _facturaServicio = new Pago_FacturaServicio();

        private ICajaServicio _cajaServicio = new CajaServicio();


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult PagoFactura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PagoFactura(CuotaDto cuota , FacturaDto factura, ClienteDto cliente)
        {
            if(_cajaServicio.VerSiCajaEstaAbierta())
            {
                if (_facturaServicio.ValidarMesPago(cuota.CuotaVigente, SessionActiva.ClienteId) == false)
                {
                    _facturaServicio.PagoCuota(cuota, factura, cliente);
                    return RedirectToAction("CuotasCliente", "Cuota");
                }
                else
                {
                    TempData["Validacion"] = "Puede Pasar";
                    ModelState.AddModelError("Error", "El cliente ya posee la factura");
                    return RedirectToAction("CuotasCliente", "Cuota");
                }
            }
            else
            {
                TempData["error"] = "error";
                return RedirectToAction("Perfil", "Cliente");
            }
            //_pagoFacturaServicio.PagoFactura(PagoFactura);
        }
    }
}