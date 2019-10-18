using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity.Entidades
{
    [Table("DetalleCaja")]
    public class DetalleCaja : EntityBase
    {

        public decimal Monto { get; set; }

        public TipoPago TipoPago { get; set; }

        public long CajaId { get; set; }

        //**************************************************//

        public virtual Caja Caja { get; set; }

    }
}
