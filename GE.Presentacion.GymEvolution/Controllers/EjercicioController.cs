using System;
using System.IO;
using GE.IServicio.Ejercicio;
using GE.IServicio.Ejercicio.DTO;
using GE.IServicio.Usuario;
using GE.Servicio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class EjercicioController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEjercicioServicio _ejercicioServicio = new EjercicioServicio();
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        public EjercicioController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        //GET
        public IActionResult Index()
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
                    var FiltrarEjercicio = _ejercicioServicio.ObtenerPorFiltro(cadena);
                    return View(FiltrarEjercicio);
                }
                else
                {
                    var TodoEjercicio = _ejercicioServicio.ObtenerTodo();
                    return View(TodoEjercicio);
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Create()

        {
            if (!_usuarioServicio.VerificarExisteUsuario())
            {
                return View();
            }
            else
            {
                if (HttpContext.Session.GetString("Session") == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Create(EjercicioDto ejercicio)
        {

            if (ModelState.IsValid)

                if (ejercicio.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{ejercicio.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        ejercicio.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    ejercicio.FotoLink = $"/imgsistema/{ejercicio.Foto.FileName}";
                }

            var ejercicioAgregar = new EjercicioDto
            {
                Nombre = ejercicio.Nombre,
                Series = ejercicio.Series,
                Repeticiones = ejercicio.Repeticiones,
                FotoLink = ejercicio.FotoLink
            };

            var Ejercicio2 = _ejercicioServicio.Agregar(ejercicioAgregar);



            if (!_usuarioServicio.VerificarExisteUsuario())
            {

                _usuarioServicio.Agregar(Ejercicio2.Id);

                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }
        //GET
        public ActionResult Update(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {

                var Empleado = _ejercicioServicio.ObtenerPorId(id);

                return View(Empleado);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Update(EjercicioDto ejercicioDto)
        {

            if (ModelState.IsValid)
            {
                _ejercicioServicio.Modificar(ejercicioDto);

                if (ejercicioDto.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{ejercicioDto.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        ejercicioDto.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    ejercicioDto.FotoLink = $"/imgsistema/{ejercicioDto.Foto.FileName}";
                }

                _ejercicioServicio.Modificar(ejercicioDto);


                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //GET
        public ActionResult Delete(long id)
        {
            var Ejercicio = _ejercicioServicio.ObtenerPorId(id);

            return View(Ejercicio);
        }

        [HttpPost]
        public ActionResult Delete(EjercicioDto ejercicioDto)
        {
            _ejercicioServicio.Eliminar(ejercicioDto.Id);

            return RedirectToAction("Index");
        }
    }
}