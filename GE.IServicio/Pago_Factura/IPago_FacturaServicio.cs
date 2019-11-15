using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Cliente.DTO;
using GE.IServicio.Cuota.DTO;
using GE.IServicio.DTOEntidades;
using GE.IServicio.Factura.DTO;
using GE.IServicio.Pago_Factura.DTO;

namespace GE.IServicio.Pago_Factura
{
    public interface IPago_FacturaServicio
    {
        void PagoCuota(CuotaDto cuota, FacturaDto factura, ClienteDto cliente);

        bool ValidarMesPago(DateTime fecha , long ClienteId);

        IEnumerable<CuotaEntidad> MostrarDatosGenerales(long clienteId);
    }
}
