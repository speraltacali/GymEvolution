using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace GE.IServicio.DTOEntidades
{
    public class CuotaEntidad
    {

        public string Cliente { get; set; }

        public string Numero { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaVigente { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        public int CantidadMeses { get; set; }

        public DateTime FechaOperacion { get; set; }

        public decimal MontoTotal { get; set; }
    }
}
