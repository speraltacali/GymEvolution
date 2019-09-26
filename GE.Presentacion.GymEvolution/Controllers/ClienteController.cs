using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ClienteController : Controller
    {

        private IClienteServicio _clienteRepositorio = new ClienteServicio();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = _clienteRepositorio.ObtenerTodo();
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ClienteDto cliente)
        {
            var Cliente = _clienteRepositorio.Agregar(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var cliente = _clienteRepositorio.ObtenerPorId(id);

            return View(cliente);
        }


        [HttpPost]
        public ActionResult Update(ClienteDto clienteDto)
        {
            _clienteRepositorio.Modificar(clienteDto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var cliente = _clienteRepositorio.ObtenerPorId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(ClienteDto clienteDto)
        {
            _clienteRepositorio.Eliminar(clienteDto.Id);

            return RedirectToAction("Index");
        }
    }
}