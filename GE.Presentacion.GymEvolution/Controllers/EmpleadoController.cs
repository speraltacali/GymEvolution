using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Empleado;
using GE.IServicio.Empleado.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class EmpleadoController : Controller
    {
        private IEmpleadoServicio _empleadoServicio = new EmpleadoServicio();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = _empleadoServicio.ObtenerTodo();
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmpleadoDto empleado)
        {
            var Cliente = _empleadoServicio.Agregar(empleado);

            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var empleado = _empleadoServicio.ObtenerPorId(id);

            return View(empleado);
        }


        [HttpPost]
        public ActionResult Update(EmpleadoDto empleadoDto)
        {
            _empleadoServicio.Modificar(empleadoDto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var empleado = _empleadoServicio.ObtenerPorId(id);

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Delete(EmpleadoDto empleadoDto)
        {
            _empleadoServicio.Eliminar(empleadoDto.Id);

            return RedirectToAction("Index");
        }
    }
}