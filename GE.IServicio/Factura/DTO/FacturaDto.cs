using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Servicio.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GE.IServicio.Factura.DTO
{
    public class FacturaDto : BaseDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string Numero { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaOperacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, Double.MaxValue,
            ErrorMessage = "El {0} Debe ser mayor a 0")]
        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }
        
    }
}
