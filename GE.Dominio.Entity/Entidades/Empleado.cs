using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GE.Dominio.Entity.Entidades
{
    [Table("Persona_Empleado")]
    public class Empleado : Persona
    {
        public string Legajo { get; set; }

        public DateTime FechaIngreso { get; set; }

        public byte[] Foto { get; set; }

        //*********************************************************/

        public virtual ICollection<Movimiento> Movimientos { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Pago_Factura> Pago_Facturas { get; set; }
    }
}
