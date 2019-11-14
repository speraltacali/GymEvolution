using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Empleado;
using GE.Infraestructura.Context;
using GE.Infraestructura.Repositorio.Empleado;
using GE.IServicio.Empleado;
using GE.Repositorio;
using GE.Repositorio.Base;
using GE.Servicio;

namespace GE.Presentacion.GymEvolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosApiController : ControllerBase
    {
        private readonly IEmpleadoRepositorio _repositorio = new EmpleadoRepositorio();

        // GET: api/EmpleadosApi
        [HttpGet]
        public IEnumerable<Empleado> GetEmpleado()
        {
            return _repositorio.ObtenerTodo();
        }

    }
}
