using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity.Entidades
{
    public class ClaseDetalle : EntityBase
    {
        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public Dias Dia { get; set; }

        public long ClaseId { get; set; }

        //****************************************************//

        public virtual Clase Clase { get; set; }
    }
}
