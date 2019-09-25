using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Factura.DTO
{
    public class FacturaDto
    {
        public string NumeroFactura { get; set; }

        public DateTime FechaOperacion { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }
        
    }
}
