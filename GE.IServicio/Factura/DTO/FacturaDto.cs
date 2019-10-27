using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Servicio.Base;

namespace GE.IServicio.Factura.DTO
{
    public class FacturaDto : BaseDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string Numero { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaOperacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }
        
    }
}
