using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Servicio.Base;

namespace GE.IServicio.Rutina.DTO
{
    public class RutinaDto : BaseDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {1} es obligatorio")]
        public string Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(500, ErrorMessage = "El campo {1} es obligatorio")]
        public  string Descripcion { get; set; }
    }
}
