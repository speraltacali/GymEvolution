using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IFacturaRepositorio _facturaRepositorio = new FacturaRepositorio();

        public FacturaDto Agregar(FacturaDto facturaDto)
        {
            var Factura = new Factura()
            {
                Numero = NumeroFactura(),
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
            return _facturaRepositorio.ObtenerTodo()
                .Select(x => new FacturaDto()
                {
                    Numero = x.Numero,
                    FechaOperacion = x.FechaOperacion,
                    SubTotal = x.SubTotal,
                    Total = x.Total,
                    Descuento = x.Descuento
                }).ToList();
        }

        public FacturaDto ObtenerTodoPorId(long id)
        {
            throw new NotImplementedException();
        }

        public string NumeroFactura()
        {
            var valor = _facturaRepositorio.ObtenerTodo().Count() + 1;
            return valor.ToString();
        }
    }
}
