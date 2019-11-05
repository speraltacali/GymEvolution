﻿using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Cuota.DTO;

namespace GE.IServicio.Cuota
{
    public interface ICuotaServicio
    {
        CuotaDto CuotaVigente(CuotaDto cuotaDto);

        DateTime CuotaUltimoVencimiento(IEnumerable<CuotaDto> cuotas);

        CuotaDto CuotaEspera(long id);

        CuotaDto ObtenerPorId(long id);

        IEnumerable<CuotaDto> ObtenerTodo();

        IEnumerable<CuotaDto> ObtenerPorFiltro(string cadena);

        IEnumerable<CuotaDto> ObtenerCuotasPorClienteId(long clienteId);

        bool PuedePasar(string dni);
    }
}
