using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Ejercicio")]
    public class Ejercicio : EntityBase
    {
        public string Nombre { get; set; }

        public int Repeticiones { get; set; }

        public int Series { get; set; }

        public Musculo Musculo { get; set; }

        public string Foto { get; set; }

        public long RutinaId { get; set; }

        //**************************************************************//

        public virtual Rutina Rutina { get; set; }
    }
}
