using System;
using System.Collections.Generic;
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
                UsuarioId = dto.UsuarioId
            };

            _cajaRepositorio.Agregar(Caja);
            _cajaRepositorio.Guardar();
        }

        public void CerrarCaja(CajaDto dto)
        {
            var Caja = _cajaRepositorio.ObtenerPorId(dto.Id);

            Caja.FechaCierre = dto.FechaCierre;
            Caja.MontoCierre = dto.MontoCierre;

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
