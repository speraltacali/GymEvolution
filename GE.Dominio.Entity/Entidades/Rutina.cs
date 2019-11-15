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
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        //******************************************************//

        public virtual ICollection<Ejercicio> Ejercicios { get; set; }

    }
}
