using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GE.IServicio.Empleado;
using GE.IServicio.Empleado.DTO;
using GE.IServicio.Foto;
using GE.IServicio.Usuario;
using GE.Servicio;
using System.Drawing;
using System.Web;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;


namespace GE.Presentacion.GymEvolution.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio = new EmpleadoServicio();
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly IHostingEnvironment hostingEnvironment;
        public EmpleadoController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        // GET: Cliente
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
                    var FiltrarEmpleado = _empleadoServicio.ObtenerPorFiltro(cadena);
                    return View(FiltrarEmpleado);
                }
                else
                {
                    var TodoEmpleado = _empleadoServicio.ObtenerTodo();
                    return View(TodoEmpleado);
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
        public ActionResult Create(EmpleadoDto empleado)
        {

            if (ModelState.IsValid)

                if (empleado.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{empleado.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        empleado.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    empleado.FotoLink = $"/imgsistema/{empleado.Foto.FileName}";
                }

            var empleadoAgregar = new EmpleadoDto
            {
                Apellido = empleado.Apellido,
                Nombre = empleado.Nombre,
                Dni = empleado.Dni,
                Domicilio = empleado.Domicilio,
                FechaIngreso = empleado.FechaIngreso,
                FechaNacimiento = empleado.FechaNacimiento,
                Legajo = empleado.Legajo,
                Sexo = empleado.Sexo,
                Telefono = empleado.Telefono,
                FotoLink = empleado.FotoLink
            };

            var Empleado2= _empleadoServicio.Agregar(empleadoAgregar);

            

                if (!_usuarioServicio.VerificarExisteUsuario())
                {

                    _usuarioServicio.Agregar(Empleado2.Id);

                    return RedirectToAction("Login", "Usuario");
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
 
        }

        public ActionResult CreateUsuario(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                if (_usuarioServicio.VerificarEmpleadoUsuario(id))
                {
                    TempData["Advertencia"] = "El Usuario ya existe en el sistema";
                    return RedirectToAction("Index", "Empleado");
                }
                else
                {
                    var empleado = _empleadoServicio.ObtenerPorId(id);
                    return View(empleado);
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult CreateUsuario(EmpleadoDto dto)
        {
            var User = _usuarioServicio.Agregar(dto.Id);

            return RedirectToAction("Index");
        }


        public ActionResult Update(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {

                var Empleado = _empleadoServicio.ObtenerPorId(id);

                return View(Empleado);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        [HttpPost]
        public ActionResult Update(EmpleadoDto empleadoDto)
        {

            if (ModelState.IsValid)
            {
                _empleadoServicio.Modificar(empleadoDto);

                if (empleadoDto.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{empleadoDto.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        empleadoDto.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    empleadoDto.FotoLink = $"/imgsistema/{empleadoDto.Foto.FileName}";
                }

                _empleadoServicio.Modificar(empleadoDto);


                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //public ActionResult Delete(long id)
        //{
        //    var Empleado = _empleadoServicio.ObtenerPorId(id);

        //    return View(Empleado);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmpleadoDto empleadoDto)
        //{
        //    _empleadoServicio.Eliminar(empleadoDto.Id);

        //    return RedirectToAction("Index");
        //}

    }
}