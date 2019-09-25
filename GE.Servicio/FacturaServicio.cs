using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
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
