using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("PagoFactura")]
    public class Pago_Factura
    {
        public long FacturaId { get; set; }

        public long CuotaId { get; set; }

        public long ClienteId { get; set; }

        public long EmpleadoId { get; set; }

        //********************************************//

        public virtual  Factura Factura { get; set; }

        public virtual Cuota Cuota { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
