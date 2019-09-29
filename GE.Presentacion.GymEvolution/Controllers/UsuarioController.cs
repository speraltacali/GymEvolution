using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Usuario;
using GE.IServicio.Usuario.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        public IActionResult Index()
        {
            var cliente = _usuarioServicio.ObtenerTodo();
            return View(cliente);
        }

        public ActionResult Login()
        {
            if (_usuarioServicio.VerificarExisteUsuario())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Empleado");
            }
        }

        [HttpPost]
        public ActionResult Login(UsuarioDto user)
        {
            if (_usuarioServicio.VerificarAcceso(user.UserName, user.Password))
            {
                return RedirectToAction("Index", "Cliente");
            }
            else
            {

                ViewBag.Messege = "Usuario o contraseña incorrectos , reintentar";
                return View();
            }
        }
    }
}