using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity.Entidades
{
    [Table("DetalleCaja")]
    public class DetalleCaja
    {
        public decimal Monto { get; set; }

        public TipoPago TipoPago { get; set; }

        public long CajaId { get; set; }

        //**************************************************//

        public Caja Caja { get; set; }

    }
}
