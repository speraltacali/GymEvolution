using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Usuario;
using GE.IServicio.Usuario.DTO;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

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
                HttpContext.Session.SetString("Session", SessionActiva.ApyNom);
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