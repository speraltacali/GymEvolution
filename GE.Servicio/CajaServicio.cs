using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Caja;
using GE.Infraestructura.Repositorio.Caja;
using GE.IServicio.Caja;
using GE.IServicio.Caja.DTO;

namespace GE.Servicio
{
    public class CajaServicio : ICajaServicio
    {
        private readonly ICajaRepositorio _cajaRepositorio = new CajaRepositorio();

        public void AbrirCaja(CajaDto dto)
        {
            var Caja = new Caja()
            {
                FechaApertura = dto.FechaApertura,
                MontoApertura = dto.MontoApertura,
                UsuarioId = dto.UsuarioId,
                Estado = true
            };

            _cajaRepositorio.Agregar(Caja);
            _cajaRepositorio.Guardar();
        }

        public void CerrarCaja(CajaDto dto)
        {
            var Caja = _cajaRepositorio.ObtenerPorId(dto.Id);

            Caja.FechaCierre = dto.FechaCierre;
            Caja.MontoCierre = dto.MontoCierre;
            Caja.Estado = false;

            _cajaRepositorio.Modificar(Caja);
            _cajaRepositorio.Guardar();
        }

        public CajaDto TraerCajaAbierta()
        {
            var cajas = _cajaRepositorio.ObtenerTodo();

            DateTime fechadefecto = new DateTime();

            var abierta = cajas.FirstOrDefault(x => x.FechaCierre == fechadefecto);

            var devolver = new CajaDto
            {
                Id = abierta.Id,
                FechaApertura = abierta.FechaApertura,
                MontoApertura = abierta.MontoApertura,
                FechaCierre = abierta.FechaCierre,
                MontoCierre = abierta.MontoCierre,
                UsuarioId = abierta.UsuarioId
            };

            return devolver;

        }

        public IEnumerable<CajaDto> ObtenerTodo()
        {
            return _cajaRepositorio.ObtenerPorFiltro(x=>!x.Estado)
                .Select(x => new CajaDto()
                {
                    Id = x.Id,
                    FechaApertura = x.FechaApertura,
                    MontoApertura = x.MontoApertura,
                    FechaCierre = x.FechaCierre,
                    MontoCierre = x.MontoCierre,
                    UsuarioId = x.UsuarioId,
                    Estado = x.Estado
                });
        }

        public IEnumerable<CajaDto> ObtenerPorFiltro(DateTime Desde , DateTime Hasta)
        {
            return _cajaRepositorio.ObtenerPorFiltro(x=>x.FechaApertura.Date >= Desde.Date
                                                                       && x.FechaCierre.Date <= Hasta.Date)
                .Select(x => new CajaDto()
                {
                    Id = x.Id,
                    FechaApertura = x.FechaApertura,
                    MontoApertura = x.MontoApertura,
                    FechaCierre = x.FechaCierre,
                    MontoCierre = x.MontoCierre,
                    UsuarioId = x.UsuarioId,
                    Estado = x.Estado
                });
        }

        public CajaDto ObtenerPorId(long id)
        {
            var Caja = _cajaRepositorio.ObtenerPorId(id);

            return new CajaDto()
                {
                    Id = Caja.Id,
                    FechaApertura = Caja.FechaApertura,
                    MontoApertura = Caja.MontoApertura,
                    FechaCierre = Caja.FechaCierre,
                    MontoCierre = Caja.MontoCierre,
                    UsuarioId = Caja.UsuarioId,
                    Estado = Caja.Estado
            };
        }

        public bool VerSiCajaEstaAbierta()
        {

            var cajas = _cajaRepositorio.ObtenerTodo();

            DateTime fechadefecto = new DateTime();

            var abierta = cajas.FirstOrDefault(x => x.FechaCierre == fechadefecto);

            if (abierta != null)
            {
                return true;
            }
            return false;
        }
    }
}
