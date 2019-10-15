using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Pago_Factura.DTO;

namespace GE.IServicio.Pago_Factura
{
    public interface IPago_FacturaServicio
    {
        void PagoFactura(Pago_FacturaDto dto);
    }
}
