using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Clase.DTOs
{
    public interface IClaseDetalleServicio
    {
        ClaseDetalleDto Guardar(ClaseDetalleDto claseDetalle);

        ClaseDetalleDto Modificar(long Id);

        void Eliminar(long Id);
    }
}
