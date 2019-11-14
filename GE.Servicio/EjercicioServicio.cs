using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Repositorio.Ejercicio;
using GE.Infraestructura.Repositorio.Ejercicio;
using GE.IServicio.Ejercicio;
using GE.IServicio.Ejercicio.DTO;

namespace GE.Servicio
{
    public class EjercicioServicio : IEjercicioServicio
    {
        private readonly  IEjercicioRepositorio _ejercicioRepositorio = new EjercicioRepositorio();
        public EjercicioDto Guardar(EjercicioDto dto)
        {
            
        }

        public EjercicioDto Modificar(EjercicioDto dto)
        {
            
        }

        public EjercicioDto Eliminar(long id)
        {
            
        }

        public IEnumerable<EjercicioDto> ObtenerTodo()
        {
            
        }

        public IEnumerable<EjercicioDto> ObtenerPorId(long id)
        {
            
        }

        public IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena)
        {
            
        }
    }
}
