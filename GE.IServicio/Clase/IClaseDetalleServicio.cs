using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Clase.DTOs
{
    public interface IClaseDetalleServicio
    {
        ClaseDetalleDto Guardar(ClaseDetalleDto claseDetalle);

        ClaseDetalleDto Modificar(ClaseDetalleDto claseDetalle);

        void Eliminar(long Id);
    }
}
