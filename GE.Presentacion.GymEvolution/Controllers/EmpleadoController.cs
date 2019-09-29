using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Empleado;
using GE.IServicio.Empleado.DTO;
using GE.IServicio.Usuario;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio = new EmpleadoServicio();
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();
        // GET: Cliente
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var empleado = _empleadoServicio.ObtenerTodo();
                return View(empleado);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Create(long id)
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
            var Empleado = _empleadoServicio.Agregar(empleado);

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

            if (_usuarioServicio.VerificarEmpleadoUsuario(id))
            {
                TempData["Advertencia"] = "El Usuario ya existe en el sistema";
                return RedirectToAction("Index", "Empleado");
            }
            else
            {
                var empleado = _empleadoServicio.ObtenerPorId(id);
                return View();
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