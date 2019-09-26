using System;
using System.Collections.Generic;
using System.Text;
using GE.Servicio.Base;

namespace GE.IServicio.Factura.DTO
{
    public class FacturaDto : BaseDto
    {
        public string NumeroFactura { get; set; }

        public DateTime FechaOperacion { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }
        
    }
}
