using GE.Dominio.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Movimiento.DTO
{
    public class MovimientoDto
    {
        public TipoMovimiento TipoMovimiento { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public string Descripcion { get; set; }

        public long EmpleadoId { get; set; }
    }
}
