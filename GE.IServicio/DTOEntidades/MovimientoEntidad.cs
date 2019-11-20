using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Enums;

namespace GE.IServicio.DTOEntidades
{
    public class MovimientoEntidad
    {
        public string Empleado { get; set; }

        public string Descripcion { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        public string Cliente { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public decimal Monto { get; set; }
    }
}
