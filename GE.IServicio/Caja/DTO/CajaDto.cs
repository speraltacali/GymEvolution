using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Base;

namespace GE.IServicio.Caja.DTO
{
    public class CajaDto : EntityBase
    {
        public DateTime FechaApertura { get; set; }

        public DateTime FechaCierre { get; set; }

        public decimal MontoApertura { get; set; }

        public decimal MontoCierre { get; set; }

        public long UsuarioId { get; set; }
    }
}
