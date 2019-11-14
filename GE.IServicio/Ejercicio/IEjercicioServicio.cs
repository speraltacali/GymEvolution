using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Ejercicio.DTO;

namespace GE.IServicio.Ejercicio
{
    public interface IEjercicioServicio
    {
        EjercicioDto Agregar(EjercicioDto dto);

        EjercicioDto Modificar(EjercicioDto dto);

        void Eliminar(long id);

        IEnumerable<EjercicioDto> ObtenerTodo();

        EjercicioDto ObtenerPorId(long id);

        IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena);
    }
}
