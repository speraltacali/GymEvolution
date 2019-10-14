using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Cliente_Factura")]
    public class Cliente_Factura
    {
        public long ClienteId { get; set; }

        public long FacturaId { get; set; }

        public long CuotaId { get; set; }

        //*********************************************//

        public virtual Cuota Cuota { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Factura Factura { get; set; }
    }
}
