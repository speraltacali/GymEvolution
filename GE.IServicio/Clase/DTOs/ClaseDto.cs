using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Servicio.Base;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Clase.DTOs
{
    public class ClaseDto : BaseDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {1} es obligatorio")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(500, ErrorMessage = "El campo {1} es obligatorio")]
        public string  Descripcion { get; set; }

        public IFormFile Foto { get; set; }

        public string FotoLink { get; set; }

        public List<ClaseDetalleDto> ClaseDetalle { get; set; }
    }
}
