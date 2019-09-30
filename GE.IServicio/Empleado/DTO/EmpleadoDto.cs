using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GE.IServicio.Persona.DTO;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Empleado.DTO
{
    public class EmpleadoDto : PersonaDto
    {
        public string Legajo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
    }
}
