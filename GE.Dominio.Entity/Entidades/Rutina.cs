using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Rutina")]
    public class Rutina : EntityBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public byte[] Foto { get; set; }

        public long ClienteId { get; set; }

        //******************************************************//

        public virtual Cliente Cliente { get; set; }
    }
}
