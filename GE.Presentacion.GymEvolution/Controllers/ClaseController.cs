﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Clase;
using GE.IServicio.Clase.DTOs;
using GE.IServicio.Cliente;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ClaseController : Controller
    {
        private readonly IClaseServicio _claseServicio = new ClaseServicio();
        private readonly IClaseDetalleServicio _detalleServicio = new ClaseDetalleServicio();

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
                //ViewData["prueba"] =

                if (!String.IsNullOrEmpty(cadena))
                {
                    var FiltroClase = _claseServicio.ObtenerPorFiltro(cadena);
                    return View(FiltroClase);
                }
                else
                {
                    var TodoClase = _claseServicio.ObtenerTodo();
                    return View(TodoClase);
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
        public ActionResult Create(ClaseDto clase)
        {
            if (ModelState.IsValid)
            {
                if (clase.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{clase.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        clase.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    clase.FotoLink = $"/imgsistema/{clase.Foto.FileName}";
                }

                var Cliente = _claseServicio.Agregar(clase);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }

        public ActionResult Update(long id )
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var clase = _claseServicio.ObtenerPorId(id);

                return View(clase);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Update(ClaseDto dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{dto.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        dto.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    dto.FotoLink = $"/imgsistema/{dto.Foto.FileName}";
                }
                ///---///
                if (dto.Foto == null)
                {
                    dto.FotoLink = _claseServicio.ObtenerPorId(dto.Id).FotoLink;
                }

                _claseServicio.Modificar(dto);

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
                var clase = _claseServicio.ObtenerPorId(id);

                return View(clase);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        [HttpPost]
        public ActionResult Delete(ClaseDto dto)
        {
            _claseServicio.Eliminar(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var clase = _claseServicio.ObtenerPorId(id);

                return View(clase);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }



    }
}