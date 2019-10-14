using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Base;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity.Entidades
{
    public class Cuota : EntityBase
    {
        public string Numero { get; set; }

        public DateTime CuotaVigente { get; set; }

        public DateTime CuotaVencimiento { get; set; }

        public int Cantidad { get; set; }
         
        public Estado Estado { get; set; }

        //*****************************************************//

        public virtual ICollection<Cliente_Factura> ClienteFactura { get; set; }
    }
}
