using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Persona.DTO;

namespace GE.IServicio.Usuario.DTO
{
    public class UsuarioDto : PersonaDto
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public long EmpleadoId { get; set; }
    }
}
