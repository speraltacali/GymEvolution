using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cliente;
using GE.IServicio.Cuota;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ControlAccesoController : Controller
    {
        private ICuotaServicio _cuotaRepositorio = new CuotaServicio();
        private IClienteServicio _clienteRepositorio = new ClienteServicio();

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

                if (cadena != null)
                {
                    if (_cuotaRepositorio.PuedePasar(cadena))
                    {
                        ViewBag.sms = "Puede Pasar";

                        return View(ViewBag);
                    }

                    ViewBag.sms = "error";

                    return View(ViewBag);
                }
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
           
        }

    }
}