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
        public IActionResult Abrir(CajaDto Caja)
        {

            var caja = new CajaDto
            {
                MontoApertura = Caja.MontoApertura,
                FechaApertura = DateTime.Now,
                MontoCierre = 0,
                UsuarioId = SessionActiva.UsuId,
              
            };

             _cajaServicio.AbrirCaja(caja);

            return RedirectToAction("Index" ,"Home");
        }
    }
}