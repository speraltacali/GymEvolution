using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cuota;
using GE.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ControlAccesoController : Controller
    {
        private readonly ICuotaServicio _cuotaRepositorio = new CuotaServicio();

        public IActionResult Acceso()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Acceso(string dni)
        {



            return View();
        }

    }
}