
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Ejercicio;
using GE.Infraestructura.Repositorio.Ejercicio;
using GE.IServicio.Ejercicio;
using GE.IServicio.Ejercicio.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GE.Servicio
{
    public class EjercicioServicio : IEjercicioServicio
    {
        private readonly IEjercicioRepositorio _ejercicioServicio = new EjercicioRepositorio();
        public EjercicioDto Agregar(EjercicioDto ejercicioDto)
        {
            var Ejercicio = new Ejercicio()
            {

            };
        }

        public EjercicioDto Modificar(EjercicioDto ejercicioDto)
        {
            return _ejercicioServicioImplementation.Modificar(ejercicioDto);
        }

        public void Eliminar(long id)
        {
            _ejercicioServicioImplementation.Eliminar(id);
        }

        public IEnumerable<EjercicioDto> ObtenerTodo()
        {
            return _ejercicioServicioImplementation.ObtenerTodo();
        }

        public IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena)
        {
            return _ejercicioServicioImplementation.ObtenerPorFiltro(cadena);
        }

        public EjercicioDto ObtenerPorId(long id)
        {
            return _ejercicioServicioImplementation.ObtenerPorId(id);
        }
    }
}
