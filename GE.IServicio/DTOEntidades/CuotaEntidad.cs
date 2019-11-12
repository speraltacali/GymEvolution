using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GE.IServicio.DTOEntidades
{
    public class CuotaEntidad
    {
        public string Cliente { get; set; }

        public string Numero { get; set; }

        public DateTime FechaVigente { get; set; }
        
        public DateTime FechaVencimiento { get; set; }

        public int CantidadMeses { get; set; }

        public DateTime FechaOperacion { get; set; }

        public decimal MontoTotal { get; set; }
    }
}
