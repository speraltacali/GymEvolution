using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;
using GE.Dominio.Repositorio.Rutina;
using GE.Infraestructura.Repositorio.Rutina;

namespace GE.Presentacion.GymEvolution.Controllers.APIs.NewApis
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinasController : ControllerBase
    {
        private readonly IRutinaRepositorio rutinaRepositorio = new RutinaRepositorio();

        // GET: api/Rutinas
        [HttpGet]
        public IEnumerable<Rutina> GetRutina()
        {
            return rutinaRepositorio.ObtenerTodo();
        }
    }
}
