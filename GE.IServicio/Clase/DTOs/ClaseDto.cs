using System;
using System.Collections.Generic;
using System.Text;
using GE.Servicio.Base;

namespace GE.IServicio.Clase.DTOs
{
    public class ClaseDto : BaseDto
    {
        public string Nombre { get; set; }

        public string  Descrpcion { get; set; }

        public string Foto { get; set; }
    }
}
