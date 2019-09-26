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
using GE.IServicio.Empleado;
using GE.IServicio.Empleado.DTO;
using GE.Repositorio;
using GE.Repositorio.Base;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GE.Presentacion.Gym.Controllers
{
    public class EmpleadoController : Controller
    {
        private IEmpleadoServicio _empleadoRepositorio = new EmpleadoServicio();

        // GET: Cliente
        public ActionResult Index()
        {
            var empleado = _empleadoRepositorio.ObtenerTodo();
            return View(empleado);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmpleadoDto cliente)
        {
            var Cliente = _empleadoRepositorio.Agregar(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var cliente = _empleadoRepositorio.ObtenerPorId(id);

            return View(cliente);
        }


        [HttpPost]
        public ActionResult Update(EmpleadoDto clienteDto)
        {
            _empleadoRepositorio.Modificar(clienteDto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var cliente = _empleadoRepositorio.ObtenerPorId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(EmpleadoDto clienteDto)
        {
            _empleadoRepositorio.Eliminar(clienteDto.Id);

            return RedirectToAction("Index");
        }
    }
}