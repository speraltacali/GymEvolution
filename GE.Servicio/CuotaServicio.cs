using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Cuota;
using GE.Infraestructura.Repositorio.Cuota;
using GE.IServicio.Cliente;
using GE.IServicio.Cuota;
using GE.IServicio.Cuota.DTO;

namespace GE.Servicio
{
    public class CuotaServicio : ICuotaServicio
    {
        private readonly ICuotaRepositorio _cuotaRepositorio = new CuotaRepositorio();
        private IClienteServicio _clienteRepositorio = new ClienteServicio();

        public CuotaDto CuotaVigente(CuotaDto cuotaDto)
        {
            var Cuota = new Cuota()
            {
                Numero = cuotaDto.Numero,
                CuotaVigente = cuotaDto.CuotaVigente,
                CuotaVencimiento = cuotaDto.CuotaVencimiento,
                Cantidad = cuotaDto.Cantidad,
                Estado = cuotaDto.Estado,
                ClienteId = cuotaDto.ClienteId
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
            var Cuota = _cuotaRepositorio.ObtenerPorId(id);

            return new CuotaDto()
            {
                Numero = Cuota.Numero,
                CuotaVigente = Cuota.CuotaVigente,
                CuotaVencimiento = Cuota.CuotaVencimiento,
                Cantidad = Cuota.Cantidad,
                Estado = Cuota.Estado,
                ClienteId = Cuota.ClienteId
            };
        }

        public IEnumerable<CuotaDto> ObtenerTodo()
        {
            return _cuotaRepositorio.ObtenerTodo()
                .Select(x => new CuotaDto()
                {
                    Numero = x.Numero,
                    CuotaVencimiento = x.CuotaVencimiento,
                    Cantidad = x.Cantidad,
                    ClienteId = x.ClienteId,
                    CuotaVigente = x.CuotaVigente,
                    Estado = x.Estado,
                    Id = x.Id
                }).ToList();
        }

        public IEnumerable<CuotaDto> ObtenerPorFiltro(DateTime fecha)
        {
            return _cuotaRepositorio.ObtenerPorFiltro(x => x.CuotaVigente >= fecha
                                                           && x.CuotaVencimiento <= fecha)
                .Select(x => new CuotaDto()
                {
                    Numero = x.Numero,
                    CuotaVencimiento = x.CuotaVencimiento,
                    Cantidad = x.Cantidad,
                    ClienteId = x.ClienteId,
                    CuotaVigente = x.CuotaVigente,
                    Estado = x.Estado,
                    Id = x.Id
                }).ToList();
        }

        public IEnumerable<CuotaDto> ObtenerCuotasPorClienteId(long clienteId)
        {
            return _cuotaRepositorio.ObtenerPorFiltro(x => x.ClienteId == clienteId).Select(x => new CuotaDto
            {
                Numero = x.Numero,
                CuotaVencimiento = x.CuotaVencimiento,
                Cantidad = x.Cantidad,
                ClienteId = x.ClienteId,
                CuotaVigente = x.CuotaVigente,
                Estado = x.Estado,
                Id = x.Id

            }).ToList();
        }

        public bool PuedePasar(string dni)
        {
            var cliente = _clienteRepositorio.ObtenerPorDni(dni);

            var cliente2 = cliente.FirstOrDefault(x => x.Dni == dni);

            if (cliente2 == null)
            {
                return false;
            }

            var cuotasDelCliente = ObtenerCuotasPorClienteId(cliente2.Id);

            if (cuotasDelCliente == null)
            {
                return false;
            }

            var fechavencimiento = CuotaUltimoVencimiento(cuotasDelCliente);

            if (fechavencimiento >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime CuotaUltimoVencimiento(IEnumerable<CuotaDto> cuotas)
        {
            DateTime comodin = new DateTime();
            DateTime bandera = new DateTime();

            foreach (var item in cuotas)
            {
                comodin = item.CuotaVencimiento;

                if (bandera == null)
                {
                    bandera = item.CuotaVencimiento;
                }

                if (comodin >= bandera)
                {

                    bandera = comodin;

                }
            }

            return bandera;
        }
    }
}
