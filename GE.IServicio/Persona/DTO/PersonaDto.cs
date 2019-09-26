using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Enums;
using GE.Servicio.Base;

namespace GE.IServicio.Persona.DTO
{
    public class PersonaDto :BaseDto
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Domicilio { get; set; }

        public string Mail { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] Foto { get; set; }

        public Sexo Sexo { get; set; }
    }
}
