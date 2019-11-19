using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Clase.DTOs;
using GE.Servicio;
using GE.Servicio.Helpers.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ClaseDetalleController : Controller
    {
        private readonly IClaseDetalleServicio _detalleServicio = new ClaseDetalleServicio();


        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");

                var detalle = _detalleServicio.ObtenerSegunClase(Parametros.Id);

                return View(detalle);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Create(ClaseDetalleDto dto)
        {
            if (ModelState.IsValid)
            {
                dto.ClaseId = Parametros.Id;
                var Detalle = _detalleServicio.Agregar(dto);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }


        public ActionResult Update(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var detalle = _detalleServicio.ObtenerPorId(id);

                return View(detalle);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Update(ClaseDetalleDto dto)
        {
            if (ModelState.IsValid)
            {
                _detalleServicio.Modificar(dto);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}