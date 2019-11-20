using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;

namespace GE.IServicio.Cuota.DTO
{
    public class CuotaDto : EntityBase
    {
        public string Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime CuotaVigente { get; set; }

        [DataType(DataType.Date)]
        public DateTime CuotaVencimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, Int32.MaxValue,
            ErrorMessage = "La {0} Debe ser mayor a 0")]
        public int Cantidad { get; set; }

        public Estado Estado { get; set; }

        public long ClienteId { get; set; }
    }
}
