using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("PagoFactura")]
    public class Pago_Factura : EntityBase
    {
        public long FacturaId { get; set; }

        public long CuotaId { get; set; }

        //********************************************//

        public virtual  Factura Facturas { get; set; }

        public virtual Cuota Cuotas { get; set; }

    }
}
