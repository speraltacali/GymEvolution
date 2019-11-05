using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Base;

namespace GE.Dominio.Entity.Entidades
{
    public class Clase : EntityBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public byte Foto { get; set; }

        //****************************************************//

        public virtual ICollection<ClaseDetalle> ClaseDetalles { get; set; }

    }
}
