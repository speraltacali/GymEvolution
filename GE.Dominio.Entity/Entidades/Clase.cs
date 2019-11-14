using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Clase")]
    public class Clase : EntityBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Foto { get; set; }

        //****************************************************//

        public virtual ICollection<ClaseDetalle> ClaseDetalles { get; set; }

    }
}
