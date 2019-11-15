using GE.IServicio.Ejercicio.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Ejercicio
{
    public interface IEjercicioServicio
    {
        EjercicioDto Agregar(EjercicioDto ejercicioDto);

        EjercicioDto Modificar(EjercicioDto ejercicioDto);

        void Eliminar(long id);

        IEnumerable<EjercicioDto> ObtenerTodo();

        IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena);

        EjercicioDto ObtenerPorId(long id);
    }
}
