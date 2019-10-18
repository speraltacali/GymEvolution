using System;
using System.Collections.Generic;
using System.Text;

namespace GE.IServicio.Pago_Factura.DTO
{
    public class Pago_FacturaDto
    {
        public long FacturaId { get; set; }

        public long CuotaId { get; set; }

        public long ClienteId { get; set; }

        public long UsuarioId { get; set; }
    }
}
