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
                    var cliente = _clienteRepositorio.ObtenerPorDni(cadena);
                    var clienteResultado = cliente.FirstOrDefault(x => x.Dni == cadena);

                    if (clienteResultado == null)
                    {
                        ViewBag.sms = "NoseEncuentraCliente";

                        return View(clienteResultado);
                    }

                    if (_cuotaRepositorio.PuedePasar(cadena))
                    {
                        ViewBag.sms = "Puede Pasar";

                        return View(clienteResultado);
                    }

                    ViewBag.sms = "error";

                    return View(clienteResultado);
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