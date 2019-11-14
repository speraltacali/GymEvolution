using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Ejercicio.DTO;

namespace GE.IServicio.Ejercicio
{
    public interface IEjercicioServicio
    {
        EjercicioDto Guardar(EjercicioDto dto);

        EjercicioDto Modificar(EjercicioDto dto);

        EjercicioDto Eliminar(long id);

        IEnumerable<EjercicioDto> ObtenerTodo();

        IEnumerable<EjercicioDto> ObtenerPorId(long id);

        IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena);
    }
}
