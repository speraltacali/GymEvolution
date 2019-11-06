using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Enums;
using GE.Servicio.Base;

namespace GE.IServicio.Clase.DTOs
{
    public class ClaseDetalleDto : BaseDto
    {
        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public Dias Dia { get; set; }

        public long ClaseId { get; set; }

    }
}
