using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Movimiento;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class MovimientoController : Controller
    {
        private IMovimientoServicio movimientoServicio = new MovimientoServicio();

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
                    var movimientobusqueda = movimientoServicio.ObtenerPorDescripcion(cadena);

                    return View(movimientobusqueda);
                }
                else
                {
                    var movimiento = movimientoServicio.ListaTodosLosMovimientos();

                    return View(movimiento);
                }

            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }



    }
}