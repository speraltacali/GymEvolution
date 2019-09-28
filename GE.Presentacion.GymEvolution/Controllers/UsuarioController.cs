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


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UsuarioDto user)
        {
            if (_usuarioServicio.VerificarAcceso(user.UserName, user.Password))
            {

            }

            //var User = _usuarioServicio.Agregar(id);

            return RedirectToAction("Index");
        }
    }
}