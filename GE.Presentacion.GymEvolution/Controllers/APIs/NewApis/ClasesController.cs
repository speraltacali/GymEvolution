using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;
using GE.Dominio.Repositorio.Clase;
using GE.Infraestructura.Repositorio.Clase;

namespace GE.Presentacion.GymEvolution.Controllers.APIs.NewApis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly IClaseRepositorio claseRepositorio = new ClaseRepositorio();

        // GET: api/Clases
        [HttpGet]
        public IEnumerable<Clase> GetClase()
        {
            return claseRepositorio.ObtenerTodo();
        }

    }
}
