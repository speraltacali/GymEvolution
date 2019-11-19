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


        [HttpGet]
        public ActionResult Index(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");

                var valor = id;

                var detalle = _detalleServicio.ObtenerSegunClase(id);

                return View(detalle);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
        

        [HttpPost]
        public ActionResult Create(ClaseDetalleDto dto)
        {
            //if (ModelState.IsValid)
            //{
            //    dto.ClaseId = Parametros.Id;
            //    _detalleServicio.Agregar(dto);

            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View();
            //}

            dto.ClaseId = Parametros.Id;
            _detalleServicio.Agregar(dto);

            return RedirectToAction("Detalle","Clase");
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
                dto.ClaseId = Parametros.Id;
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