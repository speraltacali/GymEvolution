using GE.Dominio.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Cliente.DTO
{
    public  class ClienteDto
    {
        public long Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Domicilio { get; set; }

        public string Mail { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Sexo Sexo { get; set; }

        public GrupoSanguineo GrupoSanguineo { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public DateTime FechaVencimineto { get; set; }
    }
}
