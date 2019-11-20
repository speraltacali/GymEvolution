using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Dominio.Base;

namespace GE.IServicio.Caja.DTO
{
    public class CajaDto : EntityBase
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaApertura { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaCierre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal MontoApertura { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal MontoCierre { get; set; }

        public long UsuarioId { get; set; }

        public bool Estado { get; set; }
    }
}
