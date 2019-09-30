using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ClienteController : Controller
    {

        private IClienteServicio _clienteRepositorio = new ClienteServicio();

        // GET: Cliente
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");
                var cliente = _clienteRepositorio.ObtenerTodo();
                return View(cliente);
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
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        [HttpPost]
        public ActionResult Create(ClienteDto cliente)
        {
            if (ModelState.IsValid)
            {
                var Cliente = _clienteRepositorio.Agregar(cliente);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Update(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var cliente = _clienteRepositorio.ObtenerPorId(id);

                return View(cliente);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        [HttpPost]
        public ActionResult Update(ClienteDto clienteDto)
        {
            if (ModelState.IsValid)
            {
                _clienteRepositorio.Modificar(clienteDto);

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
                var cliente = _clienteRepositorio.ObtenerPorId(id);

                return View(cliente);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        [HttpPost]
        public ActionResult Delete(ClienteDto clienteDto)
        {
            _clienteRepositorio.Eliminar(clienteDto.Id);

            return RedirectToAction("Index");
        }
    }
}