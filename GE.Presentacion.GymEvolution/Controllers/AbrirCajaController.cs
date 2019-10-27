﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Caja;
using GE.IServicio.Caja.DTO;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class AbrirCajaController : Controller
    {
        private ICajaServicio _cajaServicio = new CajaServicio();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");

                if (_cajaServicio.VerSiCajaEstaAbierta())
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
        public IActionResult Abrir(CajaDto Caja)
        {

            if (_cajaServicio.VerSiCajaEstaAbierta())
            {
                return RedirectToAction("Index", "AbrirCaja");
            }

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