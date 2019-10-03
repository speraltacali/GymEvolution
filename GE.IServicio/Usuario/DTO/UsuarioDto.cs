using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.IServicio.Persona.DTO;

namespace GE.IServicio.Usuario.DTO
{
    public class UsuarioDto : PersonaDto
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public long EmpleadoId { get; set; }
    }
}
