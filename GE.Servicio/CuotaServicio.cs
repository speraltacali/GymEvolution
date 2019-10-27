using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Cuota;
using GE.Infraestructura.Repositorio.Cuota;
using GE.IServicio.Cuota;
using GE.IServicio.Cuota.DTO;

namespace GE.Servicio
{
    public class CuotaServicio : ICuotaServicio
    {
        private readonly ICuotaRepositorio _cuotaRepositorio = new CuotaRepositorio();

        public CuotaDto CuotaVigente(CuotaDto cuotaDto)
        {
            var Cuota = new Cuota()
            {
                Numero = cuotaDto.Numero,
                CuotaVigente = cuotaDto.CuotaVigente,
                CuotaVencimiento = cuotaDto.CuotaVencimiento,
                Cantidad = cuotaDto.Cantidad,
                Estado = cuotaDto.Estado
            };

            _cuotaRepositorio.Agregar(Cuota);
            _cuotaRepositorio.Guardar();

            cuotaDto.Id = Cuota.Id;
            return cuotaDto;
        }

        public CuotaDto CuotaVencimiento(long id)
        {
            throw new NotImplementedException();
        }

        public CuotaDto CuotaEspera(long id)
        {
            throw new NotImplementedException();
        }

        public CuotaDto ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CuotaDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CuotaDto> ObtenerPorFiltro(string cadena)
        {
            throw new NotImplementedException();
        }
    }
}
