using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Ejercicio.DTO
{
    public class EjercicioDto : EntityBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {1} es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Repeticiones { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Series { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Dominio.Entity.Enums.Musculo))]
        public Musculo Musculo { get; set; }

        public IFormFile Foto { get; set; } 
        public string FotoLink { get; set; }

    }
}
