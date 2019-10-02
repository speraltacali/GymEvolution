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

            foreach (var item in empleado)
            {
                byte[] fotonew = new byte[item.Fotobyte.Length];
                MemoryStream ms = new MemoryStream(item.Fotobyte);
                Bitmap bm = null;
                /*
                Image image = Image.FromFile(item.DescripcionFoto);
                Image newImage = image.GetThumbnailImage(32, 32, null, new IntPtr());     */

                bm = new Bitmap(ms);

                var bx = bm.GetThumbnailImage(32, 32, null, new IntPtr());

                string finfoto = "data:image/jpg;base64," + Convert.ToBase64String(fotonew);

                item.BitmapString = $"{finfoto}";
                
            }

            return View(empleado);
        }

   

        public ActionResult Create()
        {
            return View();
        }

        private byte[] GetByteArrayFromImage(IFormFile file, byte[] byt, IFormFile filetamano)
        {
            using (var target = new MemoryStream())
            {
                var intes = Convert.ToInt32(filetamano.Length);
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        [HttpPost]
        public ActionResult Create(EmpleadoDto empleado)
        {
            //int tamanio = empleado.Foto.PostedFile.ContentLength;
            var tamano = empleado.Foto.Length;//
            IFormFile filetamano = empleado.Foto;
            byte[] tamana2 = new byte[tamano];//
            var img = GetByteArrayFromImage(empleado.Foto,tamana2,filetamano);//
            var imgCaption = empleado.ImageCaption;//

            var fileName = Path.GetFileName(empleado.Foto.FileName);
            var contentType = empleado.Foto.ContentType;
            string finfoto = "data:image/jpg;base64," + Convert.ToBase64String(img);//

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