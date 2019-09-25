using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Factura.DTO;

namespace GE.IServicio.Factura
{
    public interface IFacturaServicio
    {
        FacturaDto Agregar(FacturaDto facturaDto);

        //FacturaDto Modificar(FacturaDto facturaDto);

        //void Eliminar(long id);

        IEnumerable<FacturaDto> ObtenerTodo();

        FacturaDto ObtenerTodoPorId(long id);
    }
}
