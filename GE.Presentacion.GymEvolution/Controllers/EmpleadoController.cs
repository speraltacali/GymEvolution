using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Headers;

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
            

            foreach (var item in empleado)
            {
                var filename = ContentDispositionHeaderValue.Parse(item.Foto.ContentDisposition).FileName.Trim('"');

               // item.Foto = filename.b;

            }

            return View(empleado);
        }

   

    public ActionResult Create()
        {
            return View();
        }

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        [HttpPost]
        public ActionResult Create(EmpleadoDto empleado)
        {
            var img = GetByteArrayFromImage(empleado.Foto);
            var imgCaption = empleado.ImageCaption;

            var fileName = Path.GetFileName(empleado.Foto.FileName);
            var contentType = empleado.Foto.ContentType;

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
                ImageCaption = imgCaption,
                DescripcionFoto = fileName,
                Foto = empleado.Foto
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