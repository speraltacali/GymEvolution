using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class CajaController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //hola fer
        }
    }
}