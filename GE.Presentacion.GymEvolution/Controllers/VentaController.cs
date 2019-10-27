using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Factura;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class VentaController : Controller
    {
        private IFacturaServicio _facturaServicio = new FacturaServicio();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");

                var Facturas = _facturaServicio.ObtenerTodo();
                return View(Facturas);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        //[HttpGet]
        //public IActionResult Index(string cadena)
        //{
        //    if (HttpContext.Session.GetString("Session") != null)
        //    {
        //        ViewBag.Session = HttpContext.Session.GetString("Session");
        //        TempData["Session"] = HttpContext.Session.GetString("Session");

        //        var Facturas = _facturaServicio.ObtenerTodo();
        //        return View(Facturas);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }
        //}

        public IActionResult CuotaCalculo()
        {
            return View();
        }
    }
}