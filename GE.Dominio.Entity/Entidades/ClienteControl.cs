using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("ClienteControl")]
    public class ClienteControl : EntityBase
    {
        public DateTime FechaAcceso { get; set; }

        public long ClienteId { get; set; }

        //*********************************//

        public Cliente Cliente { get; set; }
    }
}
