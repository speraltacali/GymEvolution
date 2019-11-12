using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Pago_Factura;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class CuotaController : Controller
    {

        private IPago_FacturaServicio _facturaCuotaServicio = new Pago_FacturaServicio();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(string cadena)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");
                ViewData["Busqueda"] = cadena;

                if (!string.IsNullOrEmpty(cadena))
                {

                    return View();
                }
                else
                {

                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        public ActionResult CuotasCliente()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var Cuotas = _facturaCuotaServicio.MostrarDatosGenerales(SessionActiva.ClienteId);

                return View(Cuotas);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        //[HttpGet]
        //public ActionResult CuotasCliente(long ClienteId)
        //{
        //    return View();
        //}

    }
}