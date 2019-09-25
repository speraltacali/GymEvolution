using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.Dominio.Entity;
using GE.Dominio.Repositorio.Cliente;
using GE.Infraestructura.Context;
using GE.Infraestructura.Repositorio.Cliente;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.Repositorio;
using GE.Repositorio.Base;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GE.Presentacion.Gym.Controllers
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
            var cliente = _clienteRepositorio.ObtenerTodoPorId(id);

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
            var cliente = _clienteRepositorio.ObtenerTodoPorId(id);

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