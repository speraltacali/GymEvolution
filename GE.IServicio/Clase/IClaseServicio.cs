using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Clase.DTOs;

namespace GE.IServicio.Clase
{
    public interface IClaseServicio
    {
        ClaseDto Agregar(ClaseDto clase);

        ClaseDto Modificar(ClaseDto clase);

        void Eliminar(long Id);

        IEnumerable<ClaseDto> ObtenerTodo();

        IEnumerable<ClaseDto> ObtenerPorFiltro(string cadena);

        ClaseDto ObtenerPorId(long Id);
    }
}
