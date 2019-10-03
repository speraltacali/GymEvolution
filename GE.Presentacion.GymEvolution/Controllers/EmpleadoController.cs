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
            var empleado = _empleadoServicio.ObtenerTodo();
            //List<Bitmap> lista = new List<Bitmap>();            

            return View(empleado);
        }

   

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmpleadoDto empleado)
        {
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

            var Empleado = _empleadoServicio.Agregar(empleadoAgregar);
            
            if (!_usuarioServicio.VerificarExisteUsuario())
            {
                _usuarioServicio.Agregar(Empleado.Id);

                return RedirectToAction("Login","Usuario");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult CreateUsuario(long id )
        {
            var empleado = _empleadoServicio.ObtenerPorId(id);

            return View(empleado);
        }

        [HttpPost]
        public ActionResult CreateUsuario(EmpleadoDto dto)
        {
            var User = _usuarioServicio.Agregar(dto.Id);

            return RedirectToAction("Index");
        }


        public ActionResult Update(long id)
        {
            var Empleado = _empleadoServicio.ObtenerPorId(id);

            return View(Empleado);
        }


        [HttpPost]
        public ActionResult Update(EmpleadoDto empleadoDto)
        {
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

        public ActionResult Delete(long id)
        {
            var Empleado = _empleadoServicio.ObtenerPorId(id);

            return View(Empleado);
        }

        [HttpPost]
        public ActionResult Delete(EmpleadoDto empleadoDto)
        {
            _empleadoServicio.Eliminar(empleadoDto.Id);

            return RedirectToAction("Index");
        }
    }
}