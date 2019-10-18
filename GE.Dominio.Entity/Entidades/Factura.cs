using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Factura")]
    public class Factura : EntityBase
    {
        public string NumeroFactura { get; set; }

        public DateTime FechaOperacion { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        //*****************************************************//

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Pago_Factura> Pago_Facturas { get; set; }
    }
}
