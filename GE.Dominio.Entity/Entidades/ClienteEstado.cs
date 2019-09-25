using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity.Entidades
{
    [Table("ClienteEstado")]
    public class ClienteEstado : EntityBase
    {
        public Estado Estado { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public long ClienteId { get; set; }

        public long FacturaId { get; set; }

        //*********************************************//

        public virtual Cliente Cliente { get; set; }

        public virtual Factura Factura { get; set; }
    }
}
