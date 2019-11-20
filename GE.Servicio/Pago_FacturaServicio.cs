using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Entity.Enums;
using GE.Dominio.Repositorio.Pago_Factura;
using GE.Infraestructura.Context;
using GE.Infraestructura.Repositorio.Pago_Factura;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.IServicio.Cuota;
using GE.IServicio.Cuota.DTO;
using GE.IServicio.DTOEntidades;
using GE.IServicio.Factura;
using GE.IServicio.Factura.DTO;
using GE.IServicio.Movimiento;
using GE.IServicio.Movimiento.DTO;
using GE.IServicio.Pago_Factura;
using GE.IServicio.Pago_Factura.DTO;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace GE.Servicio
{
    public class Pago_FacturaServicio : IPago_FacturaServicio
    {
        private readonly IFacturaServicio _facturaServicio = new FacturaServicio();

        private readonly ICuotaServicio _cuotaServicio = new CuotaServicio();

        private readonly IMovimientoServicio _movimientoServicio = new MovimientoServicio();

        private readonly  IClienteServicio _clienteServicio = new ClienteServicio();

        public void PagoCuota(CuotaDto cuota, FacturaDto factura, ClienteDto cliente)
        {
            var Cuota = new CuotaDto()
            {
                CuotaVigente = cuota.CuotaVigente,
                CuotaVencimiento = cuota.CuotaVigente.AddMonths(cuota.Cantidad),
                Cantidad = cuota.Cantidad,
                Estado = Estado.Vigente,
                ClienteId = cliente.Id
            };

            var Factura = new FacturaDto()
            {
                FechaOperacion = DateTime.Now,
                SubTotal = factura.SubTotal,
                Total = factura.SubTotal
            };

            var cuotaId = _cuotaServicio.CuotaVigente(Cuota);

            var facturaId = _facturaServicio.Agregar(Factura);

            using (var context = new Context())
            {
                context.Pago_Factura.Add(new Pago_Factura()
                {
                    FacturaId = facturaId.Id,
                    CuotaId = cuotaId.Id,
                    ClienteId = SessionActiva.ClienteId,
                    EmpleadoId = SessionActiva.EmpleadoId
                });
                context.SaveChanges();
            }

            var movimiento = new MovimientoDto()
            {
                Descripcion = "Pago Cuota",
                EmpleadoId = SessionActiva.EmpleadoId,
                FechaActualizacion = DateTime.Now,
                TipoMovimiento = TipoMovimiento.Ingreso,
                Monto = factura.SubTotal
            };

            _movimientoServicio.NuevoMovimiento(movimiento);
        }

        public bool ValidarMesPago(DateTime fecha , long ClienteId)
        {
            var Cliente = _clienteServicio.ObtenerPorId(ClienteId);
            bool aux = false;

            if (Cliente != null)
            {
                using (var Context = new Context())
                {
                    foreach (var factura in Context.Pago_Factura.ToList())
                    {
                        if (factura.ClienteId == Cliente.Id)
                        {
                            var Cuota = _cuotaServicio.ObtenerPorId(factura.CuotaId);

                            if (Cuota.CuotaVigente <= fecha && Cuota.CuotaVencimiento >= fecha)
                            {
                                aux = true;
                            }
                        }
                    }
                }
            }

            return aux;
        }


        public IEnumerable<CuotaEntidad> MostrarDatosGenerales(long clienteId)
        {
            var Cliente = _clienteServicio.ObtenerPorId(clienteId);

            List<CuotaEntidad> CuotasCliente = new List<CuotaEntidad>();

            using (var Context = new Context())
            {
                foreach (var factura in Context.Pago_Factura.ToList())
                {
                    if (factura.ClienteId == Cliente.Id)
                    {
                        var Cuota = _cuotaServicio.ObtenerPorId(factura.CuotaId);

                        var Factura = _facturaServicio.ObtenerTodoPorId(factura.FacturaId);

                        var Mostrar = new CuotaEntidad()
                        {
                            Numero = Factura.Numero,
                            CantidadMeses = Cuota.Cantidad,
                            FechaVigente = Cuota.CuotaVigente,
                            FechaVencimiento = Cuota.CuotaVencimiento,
                            MontoTotal = Factura.Total,
                            FechaOperacion = Factura.FechaOperacion
                        };

                        CuotasCliente.Add(Mostrar);
                    }
                }
            }

            return CuotasCliente.ToList();
        }

    }
}
