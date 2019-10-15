using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Pago_Factura")]
    public class Pago_Factura : EntityBase
    {

        public long ClienteId { get; set; }

        public long FacturaId { get; set; }

        public long CuotaId { get; set; }

        public long UsuarioId { get; set; }

        //*********************************************//

        public virtual Cuota Cuota { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
