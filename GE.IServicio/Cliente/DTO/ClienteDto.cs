using GE.Dominio.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Persona.DTO;

namespace GE.IServicio.Cliente.DTO
{
    public  class ClienteDto : PersonaDto
    {
        public GrupoSanguineo GrupoSanguineo { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public DateTime FechaVencimineto { get; set; }
    }
}
