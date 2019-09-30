using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Persona.DTO;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Empleado.DTO
{
    public class EmpleadoDto : PersonaDto
    {
        public string Legajo { get; set; }

        public DateTime FechaIngreso { get; set; }

        public IFormFile Foto { get; set; }
    }
}
