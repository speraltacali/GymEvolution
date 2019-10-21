using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Factura;
using GE.Infraestructura.Repositorio.Factura;
using GE.IServicio.Factura;
using GE.IServicio.Factura.DTO;

namespace GE.Servicio
{
    public class FacturaServicio : IFacturaServicio
    {
        private readonly IFacturaRepositorio _facturaRepositorio;

        public FacturaServicio(FacturaRepositorio facturaRepositorio)
        {
            _facturaRepositorio = facturaRepositorio;
        }

        public FacturaDto Agregar(FacturaDto facturaDto)
        {
            var Factura = new Factura()
            {
                Numero = facturaDto.Numero,
                FechaOperacion = facturaDto.FechaOperacion,
                SubTotal = facturaDto.SubTotal,
                Total = facturaDto.Total,
                Descuento = facturaDto.Descuento
            };

            _facturaRepositorio.Agregar(Factura);
            _facturaRepositorio.Guardar();

            facturaDto.Id = Factura.Id;
            return facturaDto;
        }

        public IEnumerable<FacturaDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public FacturaDto ObtenerTodoPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
