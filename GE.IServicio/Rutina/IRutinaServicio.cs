using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Rutina.DTO;

namespace GE.IServicio.Rutina
{
    public interface IRutinaServicio
    {
        RutinaDto Agregar(RutinaDto dto);

        RutinaDto Modificar(RutinaDto dto);

        void Eliminar(long id);

        IEnumerable<RutinaDto> ObtenerTodo();

        RutinaDto ObtenerPorId(long id);

        IEnumerable<RutinaDto> ObtenerPorFiltro(string cadena);
    }
}
