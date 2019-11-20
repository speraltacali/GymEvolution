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

        bool VerSiCajaEstaAbierta();

        CajaDto TraerCajaAbierta();

        IEnumerable<CajaDto> ObtenerTodo();

        IEnumerable<CajaDto> ObtenerPorFiltro(DateTime fecha);

        CajaDto ObtenerPorId(long id);

    }
}
