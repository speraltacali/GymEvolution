using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Caja;
using GE.IServicio.Caja.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class CerrarCajaController : Controller
    {
        private ICajaServicio _cajaServicio = new CajaServicio();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");

                if (!_cajaServicio.VerSiCajaEstaAbierta())
                {
                    ViewBag.sms = "error";
                }

                return View(ViewBag);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public IActionResult Cerrar(CajaDto caja)
        {
            if (!_cajaServicio.VerSiCajaEstaAbierta())
            {
                return RedirectToAction("Index", "CerrarCaja");
            }

            var cajaacerrar = _cajaServicio.TraerCajaAbierta();

            cajaacerrar.FechaCierre = DateTime.Now;
            cajaacerrar.MontoCierre = caja.MontoCierre;

            _cajaServicio.CerrarCaja(cajaacerrar);

            return RedirectToAction("ConsultaCaja", "AbrirCaja");

        }
    }
}