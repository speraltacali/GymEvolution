using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class CuotaController : Controller
    {
        [HttpGet]
        public IActionResult Index(string cadena)
        {
            return View();
        }



    }
}