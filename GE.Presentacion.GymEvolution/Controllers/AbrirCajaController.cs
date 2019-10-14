using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Caja;
using GE.IServicio.Caja.DTO;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class AbrirCajaController : Controller
    {
        private ICajaServicio _cajaServicio = new CajaServicio();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Abrir(string cadena)
        {

            var caja = new CajaDto
            {
                MontoApertura = int.Parse(cadena),
                FechaApertura = DateTime.Now,
                MontoCierre = 0,
                UsuarioId = 1,
              
            };

             _cajaServicio.AbrirCaja(caja);

            return Index();
        }
    }
}