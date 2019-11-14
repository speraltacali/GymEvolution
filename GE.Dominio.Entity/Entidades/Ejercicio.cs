using GE.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Ejercicio")]
    public class Ejercicio : EntityBase
    {
        public string Descripcion { get; set; }
        public int Repeticiones { get; set; }
        public int Serie { get; set; }
        public byte[] Foto { get; set; }
        public string FotoLink { get; set; }
    }
}
