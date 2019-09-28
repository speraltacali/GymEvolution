﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Empleado;
using GE.IServicio.Empleado.DTO;
using GE.IServicio.Usuario;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio = new EmpleadoServicio();
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();
        // GET: Cliente
        public ActionResult Index()
        {
            var empleado = _empleadoServicio.ObtenerTodo();
            return View(empleado);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmpleadoDto empleado)
        {
            var Empleado = _empleadoServicio.Agregar(empleado);

            return RedirectToAction("Index");
        }


        public ActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateUser(long id)
        {
            var User = _usuarioServicio.Agregar(id);

            return View(User);
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