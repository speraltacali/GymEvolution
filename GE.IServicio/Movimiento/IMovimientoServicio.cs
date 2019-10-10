using GE.IServicio.Movimiento.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Movimiento
{
    public interface IMovimientoServicio
    {

        void NuevoMovimiento(MovimientoDto movimientoIngreso);

        IEnumerable<MovimientoDto> ListaTodosLosMovimientos();

        IEnumerable<MovimientoDto> ObtenerPorFecha(DateTime fecha);

        IEnumerable<MovimientoDto> ObtenerPorDescripcion(string cadena);

        IEnumerable<MovimientoDto> ObtenerFechaDesdeHasta(DateTime desde, DateTime hasta);

    }
}
