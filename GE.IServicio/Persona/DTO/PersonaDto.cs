using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.Dominio.Entity.Enums;
using GE.Servicio.Base;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Persona.DTO
{
    public class PersonaDto :BaseDto
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {1} es obligatorio")]
        public string Apellido { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "El campo {1} es obligatorio")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(15, ErrorMessage = "El campo {1} es obligatorio")]
        public string Dni { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(300, ErrorMessage = "El campo {1} es obligatorio.")]
        public string Domicilio { get; set; }

        //Pasar los datos de DateTime a Date

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        public string Telefono { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Dominio.Entity.Enums.Sexo))]
        public Sexo Sexo { get; set; }

        public string ImageCaption { get; set; }
        public string DescripcionFoto { get; set; }
        public IFormFile Foto { get; set; }

    }
}
