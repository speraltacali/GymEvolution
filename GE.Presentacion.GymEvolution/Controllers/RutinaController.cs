using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Rutina;
using GE.IServicio.Rutina.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class RutinaController : Controller
    {
        private readonly IRutinaServicio _rutinaServicio = new RutinaServicio();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Index(string cadena)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");
                ViewData["Busqueda"] = cadena;

                if (!String.IsNullOrEmpty(cadena))
                {
                    var FiltroRutina = _rutinaServicio.ObtenerPorFiltro(cadena);
                    return View(FiltroRutina);  
                }
                else
                {
                    var TodoRutina = _rutinaServicio.ObtenerTodo();
                    return View(TodoRutina);
                }
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
                //return View();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Create(RutinaDto rutina)
        {
            if (ModelState.IsValid)
            {
                var Cliente = _rutinaServicio.Agregar(rutina);

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
                var rutina = _rutinaServicio.ObtenerPorId(id);

                return View(rutina);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Update(RutinaDto dto)
        {
            if (ModelState.IsValid)
            {

                _rutinaServicio.Modificar(dto);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }


        public ActionResult Delete(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var rutina = _rutinaServicio.ObtenerPorId(id);

                return View(rutina);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        [HttpPost]
        public ActionResult Delete(RutinaDto dto)
        {
            _rutinaServicio.Eliminar(dto.Id);

            return RedirectToAction("Index");
        }

    }
}