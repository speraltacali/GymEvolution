using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Rutina_Cliente")]
    public class RutinaCliente
    {
        public long RutinaId { get; set; }

        public long EjercicioId { get; set; }

        //*****************************************************//

        public virtual Ejercicio Ejercicio { get; set; }

        public virtual Rutina Rutina { get; set; }
    }
} 
