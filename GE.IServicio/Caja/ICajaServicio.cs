using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Caja.DTO;

namespace GE.IServicio.Caja
{
    public interface ICajaServicio
    {
        void AbrirCaja(CajaDto dto);

        void CerrarCaja(CajaDto dto);
    }
}
