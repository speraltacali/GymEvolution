using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Caja")]
    public class Caja : EntityBase
    {

        public DateTime FechaApertura { get; set; }

        public DateTime FechaCierre { get; set; }

        public decimal MontoApertura { get; set; }

        public decimal MontoCierre { get; set; }

        public long UsuarioId { get; set; }

        public bool Estado { get; set; }

        //*****************************************************//

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<DetalleCaja> DetalleCajas { get; set; }

    }
}
