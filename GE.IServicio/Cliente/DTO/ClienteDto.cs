using GE.Dominio.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.IServicio.Persona.DTO;

namespace GE.IServicio.Cliente.DTO
{
    public  class ClienteDto : PersonaDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Dominio.Entity.Enums.GrupoSanguineo))]
        public GrupoSanguineo GrupoSanguineo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaDeIngreso { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaVencimineto { get; set; }

        public  Estado Estado { get; set; }
    }
}
