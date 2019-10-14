using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Cuota.DTO;

namespace GE.IServicio.Cuota
{
    public interface ICuotaServicio
    {
        void CuotaVigente(CuotaDto cuotaDto);

        CuotaDto CuotaVencimiento(long id);

        CuotaDto CuotaEspera(long id);

        CuotaDto ObtenerPorId(long id);

        IEnumerable<CuotaDto> ObtenerTodo();

        IEnumerable<CuotaDto> ObtenerPorFiltro(string cadena);

    }
}
