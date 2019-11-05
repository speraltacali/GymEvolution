using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cliente;
using GE.IServicio.Cuota;
using GE.Servicio;
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
        public IActionResult Index(string dni)
        {

            if (_cuotaRepositorio.PuedePasar(dni))
            {
                ViewBag.sms = "Puede Pasar";

                return View(ViewBag);
            }

            ViewBag.sms = "error";

            return View(ViewBag);
        }

    }
}